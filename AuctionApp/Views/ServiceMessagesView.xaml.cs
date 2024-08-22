using System.Collections.ObjectModel;

namespace AuctionApp.Views;

public partial class ServiceMessagesView : ContentView
{
	public ObservableCollection<string> Messages { get; set; } = [];

	public ServiceMessagesView()
	{
		InitializeComponent();

        BindingContext = this;

    }
}