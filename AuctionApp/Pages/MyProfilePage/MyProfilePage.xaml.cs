using AuctionApp.Pages.MyProfilePage.Views;
using AuctionApp.Pages.MyProfilePage.Views.AdressesView;
using AuctionApp.Pages.MyProfilePage.Views.ProfileViews;
using AuctionApp.Pages.MyProfilePage.Views.PurchasingsView;
using AuctionApp.Pages.MyProfilePage.Views.SellingsView;

namespace AuctionApp.Pages.MyProfilePage;

public partial class MyProfilePage : ContentPage
{
	private MenuView menuView;
    private MainView mainView;
    private ProfileView profileView;
    private AdressesView adressesView;
    private SellingsView sellingsView;
    private PurchasingsView purchasingsView;

    private MyProfileViewModel Vm {  get;}

    private bool isFirstMenuClick = true;

    public MyProfilePage()
	{
		InitializeComponent();

		Vm = ServiceHelper.GetService<MyProfileViewModel>();

		BindingContext = Vm;

        mainView = new MainView();

        menuView = new MenuView(Vm);
		menuView.IsVisible = true;
        menuView.MenuItemClicked += ChangeView;

        borderForMenu.Content = menuView;
    }

    private void MenuButton_Clicked(object sender, EventArgs e)
    {
        if (isFirstMenuClick)
        {
            isFirstMenuClick = false;
            return;
        }

		menuView.IsVisible = !menuView.IsVisible;

        myProfileMainView.IsVisible = !menuView.IsVisible;
    }

	private void ChangeView(string viewRoute)
	{
        menuView.IsVisible = false;

        myProfileMainView.IsVisible = !menuView.IsVisible;

        switch (viewRoute)
		{
			case RoutesConstants.MY_PROFILE_VIEW:
                profileView ??= new ProfileView();
                myProfileMainView.Content = profileView ;
                break;

            case RoutesConstants.MY_ADRESSES_VIEW:
                adressesView ??= new AdressesView();
                myProfileMainView.Content = adressesView;
                break;

            case RoutesConstants.MY_SELLINGS_VIEW:
                sellingsView ??= new SellingsView();
                myProfileMainView.Content = sellingsView;
                break;

            case RoutesConstants.MY_PURCHASINGS_VIEW:
                purchasingsView ??= new PurchasingsView();
                myProfileMainView.Content = purchasingsView;
                break;
        }
	}
}