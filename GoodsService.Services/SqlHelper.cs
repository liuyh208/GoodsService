using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using Microsoft.SqlServer.Server;

namespace GoodsService.Services
{
    public class SqlHelper
    {
        public  static IDbConnection OpenConnection()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GoodsService"].ToString());
            con.Open();
            return con;
        }
        public static IEnumerable<T> ExecuteSql<T>(string sql,object param=null)
        {
            // select users.UserName,users.UserID,users.StationID, station.StationName from SYS_User users WITH(NOLOCK)  left join BAS_StationInformation station WITH(NOLOCK)  on users.StationID = station.StationID  where users.loginName='431'  and users.ifdel <>1 and ifsysuser=1

            using (var cnn=OpenConnection())
            {
                return  cnn.Query<T>(sql,param );
            }
        }

        public static int Execute(string sql)
        {
            using (var cnn = OpenConnection())
            {
               
                return cnn.Execute(sql);
            }
        }

        public static T ExecuteScalar<T>(string sql)
        {
            using (var cnn = OpenConnection())
            {

                return cnn.ExecuteScalar<T>(sql);
            }
        }
       
    }
}
