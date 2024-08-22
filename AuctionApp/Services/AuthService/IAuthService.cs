namespace AuctionApp.Services.AuthService
{
    public interface IAuthService
    {
        public Task<MethodResult> AuthenticateAsync(string email, string password);

        public Task<bool> IsAuthenticatedFromServiceAsync();
    }
}
