using AuctionApp.Pages.ActivationPage;
using AuctionApp.Pages.ForgotPasswordPage;
using AuctionApp.Pages.RegistrationPage;

namespace AuctionApp.Services.UserService
{
    public interface IUserService
    {
        public Task<MethodResult> RegistrateAsync(RegistrationModel registrationModel);

        public Task<MethodResult> RequestPwdResetCodeAsync(RequestPwdResetCodeModel model);

        public Task<MethodResult> ResetPwdAsync(ResetPwdModel resetPwdModel);

        public Task<MethodResult> ActivateEmailAsync(ActivationEmailModel activationEmailModel);

        public Task<MethodResult> ResentActivationEmailCodeAsync(string email);
    }
}
