using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using GoodsService.Domain;
using GoodsService.Services.Base;
using GoodsService.Services.Dtos;
using GoodsService.Services.Request;
using GoodsService.Services.Responses;
using ServiceStack.Common.Utils;
using ServiceStack.ServiceInterface;

namespace GoodsService.Services
{

    public class TakeOutGoodsService : ServiceBase
    {
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="pageIndex">页码(0开始)</param>
        /// <param name="pageSize">页大小 默认10</param>
        /// <returns>IList{TakeOutGoodsDto}.</returns>
        public RequestResult Get(GetTakeOutGoodsRequest request)
        {
            var ss = Session.Get<LoginResultDto>("login");
            if (ss == null)
            {
                return RequestResult.FailureResult("用户未登录");
            }
            string strw = string.Format(" isDelete=0 and userid='{0}'", ss.UserID);
            if (!string.IsNullOrWhiteSpace(request.StartStationID))
            {
                strw = strw + string.Format(" and startstarionID='{0}'", request.StartStationID);
            }
            if (!string.IsNullOrWhiteSpace(request.EndStationID))
            {
                strw = strw + string.Format(" and EndStationID='{0}'", request.EndStationID);
            }
            if (request.Status > 0)
            {
                strw = strw + string.Format(" and Status={0}", request.Status);
            }
            else
            {
                strw = strw + string.Format(" and Status>={0}", (int)EnumTakeOutStatus.Send);
            }
            if (request.StartDate.HasValue)
            {
                strw = strw + string.Format(" and date>='{0}'", request.StartDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            }

            if (request.EndDate.HasValue)
            {
                strw = strw + string.Format(" and date<'{0}'", request.EndDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            }

            string temp =
                "select top {0} * from ( select row_number() over(order by date desc) as rownumber,* from OP_TakeOutGoods where {2}) A where rownumber > {1}";

            var sql = string.Format(temp, request.PageSize, request.StartRow(),strw);
            
            var dt=  SqlHelper.ExecuteSql<TakeOutGoodsDto>(sql);
           return RequestResult.SuccessResult(dt);

        }

        /// <summary>
        /// 打印完成
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>RequestResult.</returns>
        public RequestResult Post(PrintRequest request)
        {
            var ss = Session.Get<LoginResultDto>("login");
            if (ss == null)
            {
                return RequestResult.FailureResult("用户未登录");
            }
            string temp = "UPDATE [dbo].[OP_TakeOutGoods]	SET  [IsPrint] = {1} WHERE code='{0}'";
            var sql = string.Format(temp, request.Code, 1);
            var i = SqlHelper.Execute(sql);
            if (i > 0)
            {
                return RequestResult.SuccessResult();
            }
            else
            {
                return RequestResult.FailureResult("设置打印状态失败");
            }
            
        }

        /// <summary>
        /// 提货完成
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>RequestResult.</returns>
        public RequestResult Post(OverRequest request)
        {
            var ss = Session.Get<LoginResultDto>("login");
            if (ss == null)
            {
                return RequestResult.FailureResult("用户未登录");
            }
            var codes = request.Code.Split(',');
            if (codes.Length == 0)
            {
                return RequestResult.FailureResult("请输入提货单号");
            }
            string strw = string.Format(" isDelete=0 and userid='{0}'", ss.UserID);
            string cc = "1";
            foreach (var code in codes)
            {
                cc = cc + "," + code;
            }
            strw =strw+  string.Format(" and code in ({0})", cc);
            string temp = "UPDATE [dbo].[OP_TakeOutGoods]	SET  [Status] = {1} WHERE {0}";
            var sql = string.Format(temp, strw, (int)EnumTakeOutStatus.Over);
            var i = SqlHelper.Execute(sql);
            if (i > 0)
            {
                return RequestResult.SuccessResult();
            }
            else
            {
                return RequestResult.FailureResult("设置提货单状态失败");
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>RequestResult.</returns>
        public RequestResult Post(TakeOutGoodsRequest request)
        {
            var ss = Session.Get<LoginResultDto>("login");
            if (ss==null)
            {
                return RequestResult.FailureResult("用户未登录");
            }
           
         
            request.ID=Guid.NewGuid();
            request.Date=DateTime.Now.ToString2();
            request.SendDate=DateTime.Now.ToString2();
            request.Status = EnumTakeOutStatus.Send;
            //request.Code = CodeCreator.CreateCode();
            //request.ServiceType = "站点送货";
            request.Source = "手机下单";
            request.UserID = ss.UserID;
            request.UserName = ss.UserName;

            var sql = request.ToInsertSql();
            var i = SqlHelper.Execute(sql);

            //sql =string.Format( "select code from OP_TakeOutGoods  where id='{0}'",request.ID);
            // SqlHelper.ExecuteSql<int>(sql);
            if (i>0)
            {
                return RequestResult.SuccessResult(null, "添加成功");
            }
            else
            {
                return RequestResult.FailureResult("提交失败");
            }
            
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>RequestResult.</returns>
        public RequestResult Post(TakeOutGoodsEditRequest request)
        {
            var ss = Session.Get<LoginResultDto>("login");
            if (ss == null)
            {
                return RequestResult.FailureResult("用户未登录");
            }

            request.Date=DateTime.Now.ToString2();
            var sql = request.ToUpdateSql();
            var i = SqlHelper.Execute(sql);

            if (i > 0)
            {
                return RequestResult.SuccessResult(null,"修改成功");
            }
            else
            {
                return RequestResult.FailureResult("修改失败");
            }
        }


        public RequestResult Post(DeleteRequest request)
        {
            var ss = Session.Get<LoginResultDto>("login");
            if (ss == null)
            {
                return RequestResult.FailureResult("用户未登录");
            }
            string strw = string.Format(" userid='{0}'", ss.UserID);

            var codes = request.Codes.Split(',');
            if (codes.Length == 0)
            {
                return RequestResult.FailureResult("请输入提货单号");
            }
            string cc = "1";
            foreach (var code in codes)
            {
                cc = cc + "," + code;
            }
            strw = strw + string.Format(" and code in ({0})", cc);

            var sql = string.Format("update OP_TakeOutGoods set isDelete=1 where {0}", strw);
            var i = SqlHelper.Execute(sql);

            if (i > 0)
            {
                return RequestResult.SuccessResult(null, "删除成功");
            }
            else
            {
                return RequestResult.FailureResult("删除失败");
            }
        }
        
        public RequestResult Get(GetByCodeRequest request)
        {
            var ss = Session.Get<LoginResultDto>("login");
            if (ss == null)
            {
                return RequestResult.FailureResult("用户未登录");
            }
            string strw = string.Format(" isDelete=0 and userid='{0}'", ss.UserID);

            var codes = request.Codes.Split(',');
            if (codes.Length == 0)
            {
                return RequestResult.FailureResult("请输入提货单号");
            }
            string cc = "1";
            foreach (var code in codes)
            {
                cc = cc + "," + code;
            }
            strw = strw + string.Format(" and code in ({0})", cc);

            string temp =
                "select * from OP_TakeOutGoods where {0}";

            var sql = string.Format(temp, strw);

            var dt = SqlHelper.ExecuteSql<TakeOutGoodsDto>(sql);
            return RequestResult.SuccessResult(dt);
        }
    }
}