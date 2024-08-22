namespace AuctionApp.Services.UserCredentialsService.Dto
{
    public class UserCredentials
    {
        public string Email { get; private set; }

        public string Password { get; private set; }

        public UserCredentials(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
