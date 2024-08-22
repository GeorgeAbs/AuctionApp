using AuctionApp.Services.MyProfileServices.AdressesService;
using AuctionApp.Services.MyProfileServices.AdressesService.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AuctionApp.Pages.MyProfilePage.Views.AdressesView
{
    public partial class AdressesVM : ObservableObject
    {
        [ObservableProperty]
        private Guid adressId = Guid.Empty;
        [ObservableProperty]
        private string adressTitle  = string.Empty;
        [ObservableProperty]
        private string country = string.Empty;
        [ObservableProperty]
        private string city = string.Empty;
        [ObservableProperty]
        private string region = string.Empty;
        [ObservableProperty]
        private string district  = string.Empty;
        [ObservableProperty]
        private string street  = string.Empty;
        [ObservableProperty]
        private string building = string.Empty;
        [ObservableProperty]
        private string floor = string.Empty;
        [ObservableProperty]
        private string flat = string.Empty;
        [ObservableProperty]
        private string postIndex = string.Empty;
        [ObservableProperty]
        private bool isForShipment = false;
        [ObservableProperty]
        private bool isDefaultForShipment = false;
        [ObservableProperty]
        private bool isForReceiving = false;
        [ObservableProperty]
        private bool isDefaultForReceiving = false;

        public ObservableCollection<Adress> Adresses { get; set; } = [];

        private readonly IAdressesService _adressesService;


        public delegate void MessagesHandler(List<string> messages);
        public event MessagesHandler? MessagesAccured;

        public AdressesVM(IAdressesService adressesService) 
        {
            _adressesService = adressesService;
        }

        public async Task GetAdressesAsync()
        {
            var res = await _adressesService.GetAddressesAsync().ConfigureAwait(false);

            if (res.IsSucceeded && res.ResultEntity is not null)
            {
                Adresses.Clear();

                res.ResultEntity.Sort((a, b) => a.AdressTitle.CompareTo(b.AdressTitle));

                foreach (var adress in res.ResultEntity)
                {
                    Adresses.Add(adress);
                }
            }
        }

        [RelayCommand]
        public async Task CreateAdressAsync()
        {
            var res = await _adressesService.SaveAddressAsync(new Adress(AdressId,
                AdressTitle, 
                Country,
                City, 
                Region,
                District,
                Street, 
                Building, 
                Floor, 
                Flat, 
                PostIndex,
                IsForShipment, 
                IsDefaultForShipment,
                IsForReceiving, 
                IsDefaultForReceiving));

            if (res.IsSucceeded)
            {
                await GetAdressesAsync();
            }
        }

        [RelayCommand]
        public async Task DeleteAdressAsync(Guid adressId)
        {
            var res = await _adressesService.DeleteAddressAsync(adressId);

            if (res.IsSucceeded)
            {
                await GetAdressesAsync();
            }
        }

    }
}
