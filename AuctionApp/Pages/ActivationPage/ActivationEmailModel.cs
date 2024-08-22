namespace AuctionApp.Pages.ActivationPage
{
    public class ActivationEmailModel
    {
        public string Email { get; }

        public string ActivationCode { get; }

        public ActivationEmailModel(string email, string code)
        {
            Email = email;
            ActivationCode = code;
        }
    }
}
