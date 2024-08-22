using AuctionApp.Services.AuthService;
using AuctionApp.Services.NavigationService;
using AuctionApp.Services.UserCredentialsService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AuctionApp.Pages.LoginPage
{
    public partial class LoginPageViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IAuthService _authService;
        private readonly IUserCredentialsService _userCredentialsService;

        [ObservableProperty]
        private string _email;
        [ObservableProperty]
        private string _password;
        [ObservableProperty]
        private List<string> _errorsMessages;

        private bool _isErrors = false;

        public delegate void ErrorsHandler(List<string> errors);
        public event ErrorsHandler? ErrorsAccured;

        public delegate void AuthHandler();
        public event AuthHandler? AuthRequested;

        public bool IsErrors
        {
            get => _isErrors;
            set => SetProperty(ref _isErrors, value);
        }

        public LoginPageViewModel(INavigationService navigationService, IAuthService authService, IUserCredentialsService userCredentialsService)
        {
            _navigationService = navigationService;
            _authService = authService;
            _userCredentialsService = userCredentialsService;
            IsErrors = false;
        }

        public async Task AuthWhileInitializeAsync()
        {
            var credentials = await _userCredentialsService.GetUserCredentialsAsync();

            //File.WriteAllText("C:\\Users\\Asus\\Desktop\\mauiLog.txt", credentials.Email + " " + credentials.Password);

            if (credentials is null) return;

            var res = await _authService.AuthenticateAsync(credentials.Email, credentials.Password);
            if (!res.IsSucceeded)
            {
                return;
            }

            await _navigationService.NavigateToAsync("/" + RoutesConstants.MAIN_PAGE_ROUTE);
        }

        [RelayCommand]
        private async Task AuthenticateAsync()
        {
            AuthRequested?.Invoke();

            var res = await _authService.AuthenticateAsync(_email, _password);
            if (!res.IsSucceeded)
            {
                IsErrors = true;
                if(res.Messages is not null && res.Messages.Count > 0)
                    ErrorsAccured?.Invoke(res.Messages);

                return;
            }

            await _navigationService.NavigateToAsync("/" + RoutesConstants.MAIN_PAGE_ROUTE);
        }

        [RelayCommand]
        private async Task RegistrateAsync()
        {
            await _navigationService.NavigateToAsync(RoutesConstants.REGISTRATION_PAGE_ROUTE);
        }

        [RelayCommand]
        private async Task ForgotPasswordAsync()
        {
            await _navigationService.NavigateToAsync(RoutesConstants.FORGOT_PWD_PAGE_ROUTE);
        }

        [RelayCommand]
        private async Task GoToActivationPageAsync()
        {
            await _navigationService.NavigateToAsync(RoutesConstants.ACTIVATION_PAGE_ROUTE);
        }
    }
}
