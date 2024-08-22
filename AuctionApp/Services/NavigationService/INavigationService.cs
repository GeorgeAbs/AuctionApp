namespace AuctionApp.Services.NavigationService
{
    public interface INavigationService
    {
        public Task InitializeAsync();

        public Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null);

        public Task GoBackAsync();

        public Task PopAsync();
    }
}
