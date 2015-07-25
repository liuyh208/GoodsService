using System;
using GoodsService.Services.Responses;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface.ServiceModel;

namespace GoodsService.Services.Dtos
{
    [Route("/login", "POST")]
    public class UserLogin
    {
        public string Name { get; set; }
        public string Pwd { get; set; }
    }


    public class LoginResultDto
    {
        public Guid UserID { get; set; }

        public string UserName { get; set; }

        public string StationID { get; set; }
        public string StationName { get; set; }
    }
}