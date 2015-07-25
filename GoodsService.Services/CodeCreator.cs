using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;

namespace GoodsService.Services
{
    public class CodeCreator
    {

        public static  string CreateCode()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssffff");
        }
    }
}
