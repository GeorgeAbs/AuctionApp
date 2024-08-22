using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AuctionApp.Pages.MyProfilePage
{
    public partial class MyProfileViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isMainViewVisible = true;

        public bool IsMenuVisible { get; set; } = false;

        public MyProfileViewModel()
        {

        }
    }
}
