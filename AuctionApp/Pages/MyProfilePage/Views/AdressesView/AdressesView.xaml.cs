
namespace AuctionApp.Pages.MyProfilePage.Views.AdressesView;

public partial class AdressesView : ContentView
{
    private readonly AdressesVM vm;
    public AdressesView()
	{
		InitializeComponent();

        vm = ServiceHelper.GetService<AdressesVM>();

        BindingContext = vm;
        Loaded += Initialize;
    }

    private void Initialize(object? sender, EventArgs e)
    {
        vm.GetAdressesAsync();
    }
}