using AuctionApp.Controls;

namespace AuctionApp.Pages.MyProfilePage.Views;

public partial class MenuView : ContentView
{
	public delegate void MenuItemClickHandler(string viewRoute);

	public event MenuItemClickHandler? MenuItemClicked;

	public MenuView(MyProfileViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}

    private void MenuItem_Clicked(object sender, EventArgs e)
    {
		var viewRoute = (sender as CustomButton)!.Tag;

        MenuItemClicked?.Invoke(viewRoute);
    }
}