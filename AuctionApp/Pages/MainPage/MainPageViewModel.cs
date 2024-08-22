using AuctionApp.Services.AuthService;
using AuctionApp.Services.NavigationService;
using AuctionApp.Services.UserCredentialsService;
using CommunityToolkit.Mvvm.ComponentModel;
namespace AuctionApp.Pages.MainPage
{
    public class MainPageViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IAuthService _authService;
        private readonly IUserCredentialsService _userCredentialsService;

        private string _text = "123";
        public string Text
        {
            get { return _text; } 
            set
            {
                SetProperty(ref _text, value);
            }
        }
        public MainPageViewModel(INavigationService navigationService, IAuthService authService, IUserCredentialsService userCredentialsService) 
        {
            _navigationService = navigationService;
            _authService = authService;
            _userCredentialsService = userCredentialsService;

            _text = "qwqqwqq";
        }
    }
}
