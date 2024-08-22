using AuctionApp.Services.UserService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AuctionApp.Pages.ActivationPage
{
    public partial class ActivationPageViewModel : ObservableObject
    {
        private readonly IUserService _userService;
        [ObservableProperty]
        private string _email = string.Empty;
        [ObservableProperty]
        private string _code = string.Empty;

        public delegate void MessagesHandler(List<string> messages);
        public event MessagesHandler? MessagesAccured;

        public delegate void RequestHandler();
        public event RequestHandler? RequestRequested;

        public ActivationPageViewModel(IUserService userService)
        {
            _userService = userService;
        }

        [RelayCommand]
        private async Task RequestNewCodeAsync()
        {
            RequestRequested?.Invoke();

            var res = await _userService.ResentActivationEmailCodeAsync(Email);

            MessagesAccured?.Invoke(res.Messages);
        }

        [RelayCommand]
        private async Task ActivateAsync()
        {
            RequestRequested?.Invoke();

            var res = await _userService.ActivateEmailAsync(new(Email, Code));

            MessagesAccured?.Invoke(res.Messages);
        }
    }
}
