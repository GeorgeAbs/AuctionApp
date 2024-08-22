namespace AuctionApp.Services.RequestProvider
{
    public interface IRequestProvider
    {
        public Task<RequestResult<TResult?>> GetAsync<TResult>(string uri, string? token = null);

        public Task<RequestResult<TResult?>> PostAsync<TSend, TResult>(string uri, TSend sendedObj, string? token = null);

        public Task<RequestResult<TResult?>> PutAsync<TSend, TResult>(string uri, TSend sendedObj, string? token = null);

        public Task<RequestResult<TResult?>> DeleteAsync<TResult>(string uri, string? token = null);
    }
}
