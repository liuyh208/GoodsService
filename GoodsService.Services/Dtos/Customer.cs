using System;
using GoodsService.Services.Responses;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface.ServiceModel;

namespace GoodsService.Services.Dtos
{


    public class CustomerDto
    {
        public string ID { get; set; }

        public string Name { get; set; }

    }

    public class StationDto
    {
        public string StationID { get; set; }

        public string StationName { get; set; }

    }
}