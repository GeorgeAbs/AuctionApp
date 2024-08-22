namespace AuctionApp.Pages.RegistrationPage
{
    public class RegistrationModel
    {
        public string Password { get; private set; } = string.Empty;

        public string Email { get; private set; } = string.Empty;

        public string UserName { get; private set; } = string.Empty;

        public RegistrationModel(string password, string email, string userName)
        {
            Password = password;
            Email = email;
            UserName = userName;
        }
    }
}
