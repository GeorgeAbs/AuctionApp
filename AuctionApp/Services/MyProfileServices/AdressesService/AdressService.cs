using AuctionApp.Data;
using AuctionApp.Services.MyProfileServices.AdressesService.Models;
using AuctionApp.Services.RequestProvider;

namespace AuctionApp.Services.MyProfileServices.AdressesService
{
    public class AdressService : IAdressesService
    {
        private readonly IRequestProvider _requestProvider;
        public AdressService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<MethodResult<List<Adress>>> GetAddressesAsync()
        {
            var res = await _requestProvider.GetAsync<List<Adress>>("MyProfile/GetAdresses", AccessTokenProvider.AccessToken);

            return new MethodResult<List<Adress>>(res.ResultEntity, res.IsSucceeded, res.Messages, res.StatusCode);
        }

        public async Task<MethodResult> SaveAddressAsync(Adress adressRequest)
        {
            var res = await _requestProvider.PostAsync<Adress, List<string>>("MyProfile/SaveAdress", adressRequest, AccessTokenProvider.AccessToken);

            return new MethodResult(res.IsSucceeded, res.Messages, res.StatusCode);
        }

        public async Task<MethodResult> DeleteAddressAsync(Guid adressId)
        {
            var res = await _requestProvider.PostAsync<Guid, List<string>>("MyProfile/DeleteAdress", adressId, AccessTokenProvider.AccessToken);


            return new MethodResult(res.IsSucceeded, res.Messages, res.StatusCode);
        }
    }
}
