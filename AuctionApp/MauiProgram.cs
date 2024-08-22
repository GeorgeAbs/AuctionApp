using AuctionApp.Pages.ActivationPage;
using AuctionApp.Pages.ForgotPasswordPage;
using AuctionApp.Pages.LoginPage;
using AuctionApp.Pages.MainPage;
using AuctionApp.Pages.MyProfilePage;
using AuctionApp.Pages.MyProfilePage.Views.AdressesView;
using AuctionApp.Pages.MyProfilePage.Views.ProfileViews;
using AuctionApp.Pages.RegistrationPage;
using AuctionApp.Services.AuthService;
using AuctionApp.Services.MyProfileServices.AdressesService;
using AuctionApp.Services.MyProfileServices.ProfileService;
using AuctionApp.Services.NavigationService;
using AuctionApp.Services.RequestProvider;
using AuctionApp.Services.UserCredentialsService;
using AuctionApp.Services.UserService;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;

namespace AuctionApp
{
    public static class MauiProgram
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddHttpClient<IRequestProvider,RequestProvider>(client =>
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });
            
            builder.Services.AddSingleton<AppShellViewModel>();
            builder.Services.AddSingleton<AppShell>();
            builder.Services.AddSingleton(FileSystem.Current);
            builder.Services.AddSingleton(Preferences.Default);
            builder.Services.AddSingleton(SecureStorage.Default);

            builder.Services.AddTransient(typeof(IUserCredentialsService), typeof(UserCredentialsService));
            builder.Services.AddTransient(typeof(INavigationService), typeof(NavigationService));
            builder.Services.AddTransient(typeof(IAuthService), typeof(AuthService));
            builder.Services.AddTransient(typeof(IUserService), typeof(UserService));
            builder.Services.AddTransient(typeof(IProfileService), typeof(ProfileService));
            builder.Services.AddTransient(typeof(IAdressesService), typeof(AdressService));

            AddPage<MainPage, MainPageViewModel>(builder.Services, RoutesConstants.MAIN_PAGE_ROUTE);
            AddPage<LoginPage, LoginPageViewModel>(builder.Services, RoutesConstants.LOGIN_PAGE_ROUTE);
            AddPage<RegistrationPage, RegistrationViewModel > (builder.Services, RoutesConstants.REGISTRATION_PAGE_ROUTE);
            AddPage<ForgotPasswordPage, ForgotPasswordViewModel>(builder.Services, RoutesConstants.FORGOT_PWD_PAGE_ROUTE);
            AddPage<ActivationPage, ActivationPageViewModel>(builder.Services, RoutesConstants.ACTIVATION_PAGE_ROUTE);
            AddPage<MyProfilePage, MyProfileViewModel>(builder.Services, RoutesConstants.MY_PROFILE_PAGE_ROUTE);

            AddView<ProfileView, ProfileVM>(builder.Services);
            AddView<AdressesView, AdressesVM>(builder.Services);

            ServiceProvider = builder.Services.BuildServiceProvider();


#if DEBUG
            builder.Logging.AddDebug();
#endif


            return builder.Build();
        }

        private static IServiceCollection AddPage<TPage,TViewModel>(IServiceCollection services, string route) where TPage : Page where TViewModel : ObservableObject
        {
            services
                .AddTransient(typeof(TPage))
                .AddTransient(typeof(TViewModel));

            Routing.RegisterRoute(route, typeof(TPage));

            return services;
        }

        private static IServiceCollection AddView<TView, TViewModel>(IServiceCollection services) where TView : ContentView where TViewModel : ObservableObject
        {
            services
                .AddTransient(typeof(TView))
                .AddTransient(typeof(TViewModel));

            return services;
        }
    }
}
