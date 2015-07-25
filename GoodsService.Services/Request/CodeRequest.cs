using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceHost;

namespace GoodsService.Services.Request
{
    [Route("/TakeOutGoods/Over", "POST")]
    public class OverRequest
    {
        public string Code { get; set; }
    }

    [Route("/TakeOutGoods/print", "POST")]
    public class PrintRequest
    {
        public string Code { get; set; }
    }

    [Route("/TakeOutGoods/GetByCode", "GET")]
    public class GetByCodeRequest
    {
        public string Codes { get; set; }
    }

    [Route("/TakeOutGoods/Delete", "POST")]
    public class DeleteRequest
    {
        public string Codes { get; set; }
    }
}
