using AuctionApp.Data;
using AuctionApp.Services.MyProfileServices.ProfileService.Models;
using AuctionApp.Services.RequestProvider;

namespace AuctionApp.Services.MyProfileServices.ProfileService
{
    public class ProfileService : IProfileService
    {
        private readonly IRequestProvider _requestProvider;
        public ProfileService(IRequestProvider requestProvider) 
        { 
            _requestProvider = requestProvider;
        }
        public async Task<MethodResult> ChangeUserNameAsync(string userName)
        {
            var res = await _requestProvider.PutAsync<string,List<string>>("MyProfile/ChangeUserName", userName, AccessTokenProvider.AccessToken);

            if (res.StatusCode == 401)
            {

            }

            return new MethodResult(res.IsSucceeded, res.Messages, res.StatusCode);
        }

        public async Task<MethodResult> ChangeUserLogoAsync(Stream imageStream)
        {
            var res = await _requestProvider.PutAsync<Stream, string>("MyProfile/ChangeUserLogo", imageStream, AccessTokenProvider.AccessToken);

            await Console.Out.WriteLineAsync(res.IsSucceeded.ToString());
            await Console.Out.WriteLineAsync(res.Messages is not null? res.Messages.First() : "");
            if (res.StatusCode == 401)
            {

            }

            return new MethodResult(res.IsSucceeded, res.Messages, res.StatusCode);
        }

        public async Task<MethodResult> ChangeShopLogoAsync(Stream imageStream)
        {
            var res = await _requestProvider.PutAsync<Stream, string>("MyProfile/ChangeShopLogo", imageStream, AccessTokenProvider.AccessToken);

            if (res.StatusCode == 401)
            {

            }

            return new MethodResult(res.IsSucceeded, res.Messages, res.StatusCode);
        }

        public async Task<MethodResult> ChangeUserInfoAsync(UserProfileRequest dto)
        {
            var res = await _requestProvider.PutAsync<UserProfileRequest, List<string>>("MyProfile/ChangeUserInfo", dto, AccessTokenProvider.AccessToken);

            if (res.StatusCode == 401)
            {

            }

            return new MethodResult(res.IsSucceeded, res.Messages, res.StatusCode);
        }
    }
}
