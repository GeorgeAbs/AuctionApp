using AuctionApp.Data;

namespace AuctionApp.Services.NavigationService
{
    public class NavigationService : INavigationService
    {
        public async Task InitializeAsync()
        {
            await NavigateToAsync(string.IsNullOrEmpty(AccessTokenProvider.AccessToken) ? RoutesConstants.LOGIN_PAGE_ROUTE : RoutesConstants.MAIN_PAGE_ROUTE);
        }

        public Task NavigateToAsync(string route, IDictionary<string, object>? routeParameters = null)
        {
            return routeParameters is not null
            ? Shell.Current.GoToAsync(new(route), routeParameters)
            : Shell.Current.GoToAsync(new(route));
        }

        public Task GoBackAsync()
        {
            return Shell.Current.GoToAsync("..");
        }

        public async Task PopAsync()
        {

        }
    }
}
