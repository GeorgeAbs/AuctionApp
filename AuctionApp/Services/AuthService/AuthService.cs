using AuctionApp.Data;
using AuctionApp.Services.RequestProvider;
using AuctionApp.Services.UserCredentialsService;

namespace AuctionApp.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IRequestProvider _requestProvider; 
        private readonly IUserCredentialsService _userCredentialsService;
        public AuthService(IRequestProvider requestProvider, IUserCredentialsService userCredentialsService) 
        {
            _requestProvider = requestProvider;
            _userCredentialsService = userCredentialsService;
        }

        public async Task<MethodResult> AuthenticateAsync(string email, string pwd)
        {
            var res = await _requestProvider.PostAsync<UserAuthModel, UserAuthModelResponse>("Authentication/Login", new UserAuthModel { Email = email, Password = pwd });

            if (res.ResultEntity is not null && res.ResultEntity.AccessToken is not null)
            {
                await _userCredentialsService.WriteNewUserCredentialsAsync(email, pwd);

                AccessTokenProvider.AccessToken = res.ResultEntity.AccessToken;

                return new(true, []);
            }

            else
            {
                return new(false, res.Messages);
            }
        }

        public async Task<bool> IsAuthenticatedFromServiceAsync()
        {
            var credentials = await _userCredentialsService.GetUserCredentialsAsync();

            if (credentials is null) return false;

            var res = await _requestProvider.PostAsync<UserAuthModel, UserAuthModelResponse>("Authentication/Login", new UserAuthModel { Email = credentials.Email, Password = credentials.Password });

            if (res.ResultEntity is not null && res.ResultEntity.AccessToken is not null)
            {
                AccessTokenProvider.AccessToken = res.ResultEntity.AccessToken;

                return true;
            }

            else
            {
                return false;
            }
        }

        class UserAuthModel
        {
            public string Email { get; set; }
            public string Password { get; set; }

            public UserAuthModel() { }
        }

        class UserAuthModelResponse
        {
            public string AccessToken { get; set; }
            public string RefreshToken { get; set; }

            public UserAuthModelResponse() { }
        }
    }
}
