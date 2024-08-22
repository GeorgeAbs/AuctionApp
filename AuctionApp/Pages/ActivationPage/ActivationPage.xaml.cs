namespace AuctionApp.Pages.ActivationPage;

public partial class ActivationPage : ContentPage
{
	public ActivationPage()
	{
		InitializeComponent();

		var vm = ServiceHelper.GetService<ActivationPageViewModel>();
        BindingContext = vm;
        vm.MessagesAccured += DisplayMessages;
        vm.RequestRequested += ClearMessages;
    }

    private void DisplayMessages(List<string> messages)
    {
        messagesView.IsVisible = true;
        foreach (var message in messages)
        {
            messagesView.Messages.Add(message);
        }
    }

    private void ClearMessages()
    {
        messagesView.IsVisible = false;
        messagesView.Messages.Clear();
    }
}