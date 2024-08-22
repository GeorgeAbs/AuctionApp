namespace AuctionApp.Pages.ForgotPasswordPage
{
    public class ResetPwdModel
    {
        public string Email { get; }

        public string ValidationResetPwdCode { get; }

        public string NewPwd1 { get; }

        public string NewPwd2 { get; }

        public ResetPwdModel(string email, string validationResetPwdCode, string newPwd1, string newPwd2)
        {
            Email = email;
            ValidationResetPwdCode = validationResetPwdCode;
            NewPwd1 = newPwd1;
            NewPwd2 = newPwd2;
        }
    }
}
