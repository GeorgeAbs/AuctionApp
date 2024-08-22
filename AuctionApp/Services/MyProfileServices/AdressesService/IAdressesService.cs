using AuctionApp.Services.MyProfileServices.AdressesService.Models;

namespace AuctionApp.Services.MyProfileServices.AdressesService
{
    public interface IAdressesService
    {
        public Task<MethodResult<List<Adress>>> GetAddressesAsync();

        public Task<MethodResult> SaveAddressAsync(Adress adressRequest);

        public Task<MethodResult> DeleteAddressAsync(Guid adressId);
    }
}
