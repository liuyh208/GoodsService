using System.Linq;
using GoodsService.Core;
using GoodsService.Services.Base;
using GoodsService.Services.Dtos;
using GoodsService.Services.Request;
using GoodsService.Services.Responses;
using ServiceStack.ServiceInterface;

namespace GoodsService.Services
{
 
    public class AccountService : ServiceBase
    {
        public RequestResult Post(UserLogin user)
        {
            var sqlTemp =
                "select users.UserName,users.UserID,users.StationID, station.StationName from SYS_User users WITH(NOLOCK)  left join BAS_StationInformation station WITH(NOLOCK)  on users.StationID = station.StationID  where users.loginName='{0}' and users.Password='{1}' and users.ifdel <>1 and ifsysuser=1";

            var pwd = OESoftware.Security.CryptoString.Encrypt(user.Pwd);
            var lst = SqlHelper.ExecuteSql<LoginResultDto>(string.Format(sqlTemp, user.Name, pwd));
            if (lst.Count()==0)
            {
                return RequestResult.FailureResult("用户名或密码错误!");
            }
       
            var ss=  SessionFactory.GetOrCreateSession();
            ss.Set<LoginResultDto>("login",lst.FirstOrDefault());
           
            return  RequestResult.SuccessResult(lst.FirstOrDefault());
        }



        public RequestResult Get(CustomRequest request)
        {
            string sql =
                @"SELECT ConsignerID AS ID ,ConsignerName AS Name  FROM dbo.Bas_Consigner WHERE CusType=0 order by name";

            var lst = SqlHelper.ExecuteSql<CustomerDto>(sql);
            return RequestResult.SuccessResult(lst);

        }

        public RequestResult Get(StartStationRequest request)
        {
            string sql =
                @"select StationID,StationName from Bas_StationInformation where IfDel=0 and StationType in (2,3) order by StationName ";

            var lst = SqlHelper.ExecuteSql<StationDto>(sql);
            return RequestResult.SuccessResult(lst);

        }

        public RequestResult Get(EndStationRequest request)
        {
            string sql =
                @"SELECT FinalStationId as StationID ,FinalStationName as StationName  FROM Bas_FinalPlace WHERE ifdelID=0  order by FinalStationName";

            var lst = SqlHelper.ExecuteSql<StationDto>(sql);
            return RequestResult.SuccessResult(lst);

        }
    }
}