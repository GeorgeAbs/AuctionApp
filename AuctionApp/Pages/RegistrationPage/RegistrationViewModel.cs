using AuctionApp.Services.NavigationService;
using AuctionApp.Services.UserService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AuctionApp.Pages.RegistrationPage
{
    public partial class RegistrationViewModel : ObservableObject
    {
        private readonly IUserService _userService;
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private string _password = "!Ab1234";
        [ObservableProperty]
        private string _email = @"g.k.yudin@gmail.com";
        [ObservableProperty]
        private string _userName = $"User{Random.Shared.Next(100000)}";

        public delegate void MessagesHandler(List<string> messages);
        public event MessagesHandler? MessagesAccured;

        public delegate void RequestHandler();
        public event RequestHandler? RegistrationRequested;

        public RegistrationViewModel(IUserService userService, INavigationService navigationService)
        {
            _userService = userService;
            _navigationService = navigationService;
        }

        [RelayCommand]
        private async Task RegistrateAsync()
        {
            RegistrationRequested?.Invoke();

            var model = new RegistrationModel(password: Password,
                email: Email,
                userName: UserName);

            var res = await _userService.RegistrateAsync(model);

            if (!res.IsSucceeded)
            {
                MessagesAccured?.Invoke(res.Messages);
                return;
            }

            await _navigationService.NavigateToAsync(RoutesConstants.ACTIVATION_PAGE_ROUTE);
        }
    }
}
