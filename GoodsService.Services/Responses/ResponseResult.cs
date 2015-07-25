namespace GoodsService.Services.Responses
{
    public class RequestResult
    {
        /// <summary>
        ///     The success resource
        /// </summary>
        public static RequestResult SuccessResult(object data=null,string msg=null)
        {
            return new RequestResult { Success = true, Data =data, Msg = msg };
        }

        public bool Success { get; set; }

        public string Msg { get; set; }

        public object Data { get; set; }

        public static RequestResult FailureResult(string msg)
        {
            return new RequestResult {Success = false, Msg = msg};
        }
    }
}