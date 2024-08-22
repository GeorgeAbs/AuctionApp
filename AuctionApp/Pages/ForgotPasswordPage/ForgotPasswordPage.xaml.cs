namespace AuctionApp.Pages.ForgotPasswordPage;

public partial class ForgotPasswordPage : ContentPage
{
	public ForgotPasswordPage()
	{
		InitializeComponent();

		var vm = ServiceHelper.GetService<ForgotPasswordViewModel>();

		BindingContext = vm;
        vm.MessagesAccured += DisplayMessages;
        vm.RequestRequested += ClearMessages;
        vm.CodeRequestSuccesfullyRequested += () => vm.IsCodeSuccessfullySended = true;

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