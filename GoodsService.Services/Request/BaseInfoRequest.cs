using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceHost;

namespace GoodsService.Services.Request
{
    [Route("/Customer", "GET")]
    public class CustomRequest
    {
    }


    [Route("/endstation", "GET")]
    public class EndStationRequest
    {
    }

    [Route("/StartStation", "GET")]
    public class StartStationRequest
    {
    }
}
