namespace AuctionApp.Pages.LoginPage;

public partial class LoginPage : ContentPage
{
	private readonly LoginPageViewModel _loginPageViewModel;
    public LoginPage()
	{
		InitializeComponent();

        _loginPageViewModel = ServiceHelper.GetService<LoginPageViewModel>();

        BindingContext = _loginPageViewModel;

        _loginPageViewModel.ErrorsAccured += DisplayErrors;
        _loginPageViewModel.AuthRequested += ClearErrors;
    }

    protected override async void OnAppearing()
    {

		await _loginPageViewModel.AuthWhileInitializeAsync();

        base.OnAppearing();
    }

    protected override bool OnBackButtonPressed()
    {
        Application.Current?.Quit();
        return true;
    }

    private void DisplayErrors(List<string> errors)
    {
        errorView.IsVisible = true;
        foreach (var error in errors)
        {
            errorView.Messages.Add(error);
        }
    }

    private void ClearErrors()
    {
        errorView.IsVisible = false;
        errorView.Messages.Clear();
    }
}