namespace AuctionApp
{
    public class RequestResult<TResult>
    {
        /// <summary>
        /// if responce code is 200-299
        /// </summary>
        public bool IsSucceeded { get; private set; }

        /// <summary>
        /// errors messages if not succeded
        /// </summary>
        public List<string>? Messages { get; private set; }

        /// <summary>
        /// entity from request. Generally Not null if succeded
        /// </summary>
        public TResult? ResultEntity { get; private set; }

        public int StatusCode { get; private set; }

        public RequestResult(bool isSucceded, TResult? result, int statusCode, List<string>? messages = null) 
        {
            Messages = messages;
            IsSucceeded = isSucceded;
            ResultEntity = result;
            StatusCode = statusCode;
        }
    }
}
