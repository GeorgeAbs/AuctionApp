using AuctionApp.Pages.MyProfilePage.Models;
using AuctionApp.Services.MyProfileServices.ProfileService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AuctionApp.Pages.MyProfilePage.Views.ProfileViews
{
    public partial class ProfileVM : ObservableObject
    {
        [ObservableProperty]
        private string _userName = string.Empty;
        [ObservableProperty] 
        private string _firstName = "first";
        [ObservableProperty]
        private string _lastName = "last";
        [ObservableProperty]
        private DateTime _birthDate = DateTime.Now;
        [ObservableProperty]
        private string _email = string.Empty;
        [ObservableProperty]
        private string _phoneNumber = string.Empty;
        [ObservableProperty]
        private string _vkLink = "vk";
        [ObservableProperty]
        private string _facebookLink = string.Empty;
        [ObservableProperty]
        private string _telegramLink = string.Empty;
        [ObservableProperty]
        private string _whatsappLink = string.Empty;
        [ObservableProperty]
        private string _userLogo = string.Empty;
        [ObservableProperty]
        private bool _isUserAsShopOption = false;
        [ObservableProperty]
        private string _shopTitle = "shop title";
        [ObservableProperty]
        private string _shopDescription = "shop desc";
        [ObservableProperty]
        private string _shopLogo = string.Empty;
        [ObservableProperty]
        private int _defaultDaysForShipment = 1;

        public Stream UserLogoStream { get; private set; }
        public Stream ShopLogoStream { get; private set; }

        public ObservableCollection<AddressModel> Adresses { get; set; } = [];

        public List<int> PaymentMethods { get; set; } = [];

        public delegate void ImagePickHandler(Stream imageStream);
        public event ImagePickHandler? UserLogoPicked;
        public event ImagePickHandler? ShopLogoPicked;

        public delegate void MessagesHandler(List<string> messages);
        public event MessagesHandler? MessagesAccured;

        private readonly IProfileService _profileService;
        public ProfileVM(IProfileService profileService)
        {
            _profileService = profileService;
        }

        private async Task<FileResult?> PickAndShowAsync(PickOptions? options = null)
        {
            try
            {
                var result = await FilePicker.Default.PickAsync(options);
                if (result != null)
                {
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                    {
                        using var stream = await result.OpenReadAsync();
                        var image = ImageSource.FromStream(() => stream);

                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return null;
        }

        [RelayCommand]
        private async Task SelectUserLogoAsync()
        {
            var fileRes = await PickAndShowAsync();

            if (fileRes == null) return;

            UserLogoStream?.Dispose();

            UserLogoStream = await fileRes.OpenReadAsync();

            UserLogoPicked?.Invoke(UserLogoStream);
        }

        [RelayCommand]
        private async Task SelectShopLogoAsync()
        {
            var fileRes = await PickAndShowAsync();

            if (fileRes == null) return;

            ShopLogoStream?.Dispose();

            ShopLogoStream = await fileRes.OpenReadAsync();

            ShopLogoPicked?.Invoke(ShopLogoStream);
        }

        [RelayCommand]
        private async Task ChangeUserNameAsync()
        {
            var res = await _profileService.ChangeUserNameAsync(UserName);

            if (res.Messages is not null && res.Messages.Count > 0) MessagesAccured?.Invoke(res.Messages);
        }

        [RelayCommand]
        private async Task ChangeUserLogoAsync()
        {
            var res = await _profileService.ChangeUserLogoAsync(UserLogoStream);

            await UserLogoStream.DisposeAsync();

            if (res.Messages is not null && res.Messages.Count > 0) MessagesAccured?.Invoke(res.Messages);
        }

        [RelayCommand]
        private async Task ChangeShopLogoAsync()
        {
            var res = await _profileService.ChangeShopLogoAsync(UserLogoStream);

            await ShopLogoStream.DisposeAsync();

            if (res.Messages is not null && res.Messages.Count > 0) MessagesAccured?.Invoke(res.Messages);
        }

        [RelayCommand]
        private async Task ChangeUserInfoAsync()
        {
            var res = await _profileService.ChangeUserInfoAsync(new(
                firstName: FirstName,
                secondName: LastName,
                birthDate: BirthDate,
                vkLink: VkLink,
                facebookLink: FacebookLink,
                telegramLink: TelegramLink,
                whatsappLink: WhatsappLink,
                isUserAsShopOption: IsUserAsShopOption,
                shopTitle: ShopTitle,
                shopDescription: ShopDescription,
                daysForShipment: DefaultDaysForShipment));

            if (res.Messages is not null && res.Messages.Count > 0) MessagesAccured?.Invoke(res.Messages);
        }
    }
}
