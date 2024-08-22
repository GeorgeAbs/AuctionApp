namespace AuctionApp.Pages.MyProfilePage.Views.ProfileViews;

public partial class ProfileView : ContentView
{
	public ProfileView()
	{
		InitializeComponent();

		var vm = ServiceHelper.GetService<ProfileVM>();

		BindingContext = vm;
		vm.UserLogoPicked += SetUserLogo;
		vm.ShopLogoPicked += SetShopLogo;
    }

	private void SetUserLogo(Stream stream)
	{
		//userLogo.Source = ImageSource.FromStream(() => stream);
    }

    private void SetShopLogo(Stream stream)
    {
        shopLogo.Source = ImageSource.FromStream(() => stream);

    }

}