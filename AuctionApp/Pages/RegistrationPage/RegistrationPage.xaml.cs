namespace AuctionApp.Pages.RegistrationPage;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage()
	{
		InitializeComponent();

		var registrationViewModel = ServiceHelper.GetService<RegistrationViewModel>();

		BindingContext = registrationViewModel;

        registrationViewModel.MessagesAccured += DisplayMessages;
        registrationViewModel.RegistrationRequested += ClearMessages;
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