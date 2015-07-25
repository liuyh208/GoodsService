using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceHost;

namespace GoodsService.Services.Request
{
    [Route("/TakeOutGoods", "GET")]
    public class GetTakeOutGoodsRequest
    {
        public GetTakeOutGoodsRequest()
        {
            this.PageIndex = 0;
            PageSize = 10;
            Status = -1;
        }
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int StartRow()
        {
            return PageIndex * PageSize;
        }

        /// <summary>
        /// 起始站ID
        /// </summary>
        /// <value>The start station identifier.</value>
        public string StartStationID { get; set; }

        /// <summary>
        /// 目的站ID
        /// </summary>
        /// <value>The end station identifier.</value>
        public string EndStationID { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        /// <value>The status.</value>
        public int Status { get; set; }


        /// <summary>
        /// 开始日期
        /// </summary>
        /// <value>The start date.</value>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        /// <value>The end date.</value>
        public DateTime? EndDate { get; set; }

    }

}
