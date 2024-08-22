using AuctionApp.Pages.LoginPage;
using AuctionApp.Services.NavigationService;

namespace AuctionApp
{
    public partial class AppShell : Shell
    {
        private readonly INavigationService _navigationService;
        public AppShell(AppShellViewModel appShellViewModel, INavigationService navigationService)
        {
            _navigationService = navigationService;

            InitializeComponent();

            BindingContext = appShellViewModel;
        }

        protected override bool OnBackButtonPressed()
        {
            Application.Current?.Quit();
            return true;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await _navigationService.InitializeAsync();
        }
    }
}
