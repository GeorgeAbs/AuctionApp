using AuctionApp.Services.MyProfileServices.ProfileService.Models;

namespace AuctionApp.Services.MyProfileServices.ProfileService
{
    public interface IProfileService
    {
        public Task<MethodResult> ChangeUserNameAsync(string userName);

        public Task<MethodResult> ChangeUserLogoAsync(Stream imageStream);

        public Task<MethodResult> ChangeShopLogoAsync(Stream imageStream);

        public Task<MethodResult> ChangeUserInfoAsync(UserProfileRequest dto);
    }
}
