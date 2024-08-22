using AuctionApp.Services.UserCredentialsService.Dto;

namespace AuctionApp.Services.UserCredentialsService
{
    public class UserCredentialsService : IUserCredentialsService
    {
        private readonly ISecureStorage _storage;
        public UserCredentialsService(ISecureStorage storage)
        {
            _storage = storage;
        }

        public async Task<UserCredentials?> GetUserCredentialsAsync()
        {
            var pwd = await _storage.GetAsync(Constants.GeneralConstants.PWD_STORAGE_KEY);
            var email = await _storage.GetAsync(Constants.GeneralConstants.EMAIL_STORAGE_KEY);

            if (pwd is not null && email is not null)
                return new UserCredentials(email, pwd);

            return null;
        }

        public async Task WriteNewUserCredentialsAsync(string email, string password)
        {
            await _storage.SetAsync(Constants.GeneralConstants.PWD_STORAGE_KEY, password);
            await _storage.SetAsync(Constants.GeneralConstants.EMAIL_STORAGE_KEY, email);
        }
    }
}
