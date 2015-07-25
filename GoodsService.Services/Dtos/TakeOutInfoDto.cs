using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using GoodsService.Services;
using ServiceStack.ServiceHost;

namespace GoodsService.Domain
{
  
    /// <summary>
    /// 提货单信息
    /// </summary>
    [Table("OP_TakeOutGoods")]
    
   
    public class TakeOutGoodsDto
    {
        public  TakeOutGoodsDto()
        {
            
        }


        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public Guid ID
        {
            get;
            set;
        }
        /// <summary>
        /// 提货单号
        /// </summary>
        public int Code
        {
            get;
            set;
        }
        /// <summary>
        /// 提货日期
        /// </summary>
        public string Date
        {
            get;
            set;
        }
        /// <summary>
        /// 收货人
        /// </summary>
        public string Person
        {
            get;
            set;
        }
        /// <summary>
        /// 始发站
        /// </summary>
        public string StartStation
        {
            get;
            set;
        }
        /// <summary>
        /// 目的地
        /// </summary>
        public string EndStation
        {
            get;
            set;
        }
        /// <summary>
        /// 件数
        /// </summary>
        public int Num
        {
            get;
            set;
        }
        /// <summary>
        /// 服务方式
        /// </summary>
        public string ServiceType
        {
            get;
            set;
        }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address
        {
            get;
            set;
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserID
        {
            get;
            set;
        }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName
        {
            get;
            set;
        }

        /// <summary>
        /// 状态
        /// </summary>
        public EnumTakeOutStatus Status
        {
            get;
            set;
        }
        /// <summary>
        /// 派单日期
        /// </summary>
        public string SendDate
        {
            get;
            set;
        }
        /// <summary>
        /// 客户ID
        /// </summary>
        public string CustomerID
        {
            get;
            set;
        }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomName
        {
            get;
            set;
        }
        /// <summary>
        /// 来源
        /// </summary>
        public string Source
        {
            get;
            set;
        }

    }

    [Route("/TakeOutGoods/Add", "POST")]
    public class TakeOutGoodsRequest : TakeOutGoodsDto
    {
        public string StartStationID { get; set; }
        public string EndStationID { get; set; }

        public string ToInsertSql()
        {
            string temp = @"INSERT INTO [dbo].[OP_TakeOutGoods]	([ID],[Date],[Person],[StartStation]
		,[EndStation],[Num],[ServiceType],[Address],[UserID],[UserName],[IsDelete],[Status],[SendDate],[CustomerID]
		,[CustomName],[Source],[IsPrint],StartStationID,EndStationID)
	VALUES
		('{0}','{1}','{2}','{3}'
        ,'{4}',{5},'{6}','{7}','{8}','{9}',0,{16},'{10}','{11}'
        ,'{12}','{13}',0,'{14}','{15}')";
            return string.Format(temp, ID, Date, Person, StartStation,
                EndStation, Num, ServiceType, Address, UserID, UserName, SendDate, CustomerID,
                CustomName, Source,StartStationID,EndStationID,(int)Status);
        }
    }

     [Route("/TakeOutGoods/Edit", "POST")]
    public class TakeOutGoodsEditRequest : TakeOutGoodsDto
    {
        public string StartStationID { get; set; }
        public string EndStationID { get; set; }
         public string ToUpdateSql()
         {
             string temp = @"UPDATE [OP_TakeOutGoods]
	SET  [Date] = '{1}'	,[Person] ='{2}',[StartStation] = '{3}'
		,[EndStation] = '{4}',[Num] = {5},[ServiceType] = '{6}'
		,[Address] = '{7}',[StartStationID]='{8}',[EndStationID]='{9}'
        ,[CustomerID]='{10}',[CustomName]='{11}'
	WHERE code={0}";
             return string.Format(temp, Code, Date, Person, StartStation,
                 EndStation, Num, ServiceType, Address,StartStationID,EndStationID,CustomerID,CustomName);
         }
    }
}