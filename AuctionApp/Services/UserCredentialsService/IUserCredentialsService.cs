using AuctionApp.Services.UserCredentialsService.Dto;

namespace AuctionApp.Services.UserCredentialsService
{
    public interface IUserCredentialsService
    {
        public Task<UserCredentials?> GetUserCredentialsAsync();

        public Task WriteNewUserCredentialsAsync(string email, string password);
    }
}
