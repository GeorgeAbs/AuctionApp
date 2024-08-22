using AuctionApp.Services.UserService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AuctionApp.Pages.ForgotPasswordPage
{
    public partial class ForgotPasswordViewModel : ObservableObject
    {
        private readonly IUserService _userService;

        [ObservableProperty]
        private bool _isCodeSuccessfullySended = false;
        [ObservableProperty]
        private string _email;
        [ObservableProperty]
        private string _code;
        [ObservableProperty]
        private string _password1;
        [ObservableProperty]
        private string _password2;

        public delegate void MessagesHandler(List<string> messages);
        public event MessagesHandler? MessagesAccured;

        public delegate void RequestHandler();
        public event RequestHandler? RequestRequested;

        public event RequestHandler? CodeRequestSuccesfullyRequested;

        public ForgotPasswordViewModel(IUserService userService)
        {
            _userService = userService;
        }

        [RelayCommand]
        private async Task RequestCodeAsync()
        {
            RequestRequested?.Invoke();

            var res = await _userService.RequestPwdResetCodeAsync(new(Email));

            MessagesAccured?.Invoke(res.Messages);

            if (!res.IsSucceeded)
            {
                return;
            }

            IsCodeSuccessfullySended = true;

            
        }

        [RelayCommand]
        private async Task ResetPasswordAsync()
        {
            RequestRequested?.Invoke();

            var res = await _userService.ResetPwdAsync(new (Email, Code, Password1, Password2));

            MessagesAccured?.Invoke(res.Messages);

            if (!res.IsSucceeded)
            {
                return;
            }
        }
    }
}
