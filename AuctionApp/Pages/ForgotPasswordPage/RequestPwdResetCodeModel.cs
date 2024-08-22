namespace AuctionApp.Pages.ForgotPasswordPage
{
    public class RequestPwdResetCodeModel
    {
        public string Email { get; set; }

        public RequestPwdResetCodeModel(string email)
        {
            Email = email;
        }
    }
}
