namespace AuctionApp
{
    public class MethodResult
    {
        public bool IsSucceeded { get; private set; }

        public List<string>? Messages { get; private set; } = new List<string>();

        public int RequestStatusCode { get; private set; }

        public MethodResult(bool isSucceded, List<string>? messages, int requestStatusCode = 200)
        {
            IsSucceeded = isSucceded;
            Messages = messages;
            RequestStatusCode = requestStatusCode;
        }
    }

    public class MethodResult<TResultEntity>
    {
        public TResultEntity? ResultEntity { get; set; }

        public bool IsSucceeded { get; private set; }

        public List<string>? Messages { get; private set; } = new List<string>();

        public int RequestStatusCode { get; private set; }

        public MethodResult(TResultEntity? resultEntity, bool isSucceded, List<string>? messages, int requestStatusCode = 200)
        {
            ResultEntity = resultEntity;
            IsSucceeded = isSucceded;
            Messages = messages;
            RequestStatusCode = requestStatusCode;
        }
    }
}
