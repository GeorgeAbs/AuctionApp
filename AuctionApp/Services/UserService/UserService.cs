using AuctionApp.Pages.ActivationPage;
using AuctionApp.Pages.ForgotPasswordPage;
using AuctionApp.Pages.RegistrationPage;
using AuctionApp.Services.RequestProvider;
using System.Net.Mail;

namespace AuctionApp.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IRequestProvider _requestProvider;
        public UserService(IRequestProvider requestProvider) 
        {
            _requestProvider = requestProvider;
        }

        public async Task<MethodResult> RegistrateAsync(RegistrationModel registrationModel)
        {
            if (registrationModel is null) return new MethodResult(false, ["Ошибка отправки"]);

            try
            {
                MailAddress m = new MailAddress(registrationModel.Email);
            }
            catch { return new MethodResult(false, ["Ошибка формата адреса почты"]); }

            var res = await _requestProvider.PostAsync<RegistrationModel, List<string>>("user/create", registrationModel);

            return new MethodResult(res.IsSucceeded, res.Messages);
        }

        public async Task<MethodResult> RequestPwdResetCodeAsync(RequestPwdResetCodeModel model)
        {
            if (model is null) return new MethodResult(false, ["Ошибка отправки"]);

            try
            {
                MailAddress m = new MailAddress(model.Email);
            } catch { return new MethodResult(false, ["Ошибка формата адреса почты"]); }

            var res = await _requestProvider.PostAsync<RequestPwdResetCodeModel, List<string>>("User/SendCodeForResetPassword", model);

            return new MethodResult(res.IsSucceeded, res.Messages);
        }

        public async Task<MethodResult> ResetPwdAsync(ResetPwdModel resetPwdModel)
        {
            if (resetPwdModel is null) return new MethodResult(false, ["Ошибка отправки"]);

            try
            {
                MailAddress m = new MailAddress(resetPwdModel.Email);
            }
            catch { return new MethodResult(false, ["Ошибка формата адреса почты"]); }

            var res = await _requestProvider.PostAsync<ResetPwdModel, List<string>>("User/ResetPassword", resetPwdModel);

            return new MethodResult(res.IsSucceeded, res.Messages);
        }

        public async Task<MethodResult> ActivateEmailAsync(ActivationEmailModel model)
        {
            if (model is null) return new MethodResult(false, ["Ошибка отправки"]);

            try
            {
                MailAddress m = new MailAddress(model.Email);
            }

            catch { return new MethodResult(false, ["Ошибка формата адреса почты"]); }

            var res = await _requestProvider.PostAsync<ActivationEmailModel, List<string>>("User/Activate", model);

            return new MethodResult(res.IsSucceeded, res.Messages);
        }

        public async Task<MethodResult> ResentActivationEmailCodeAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return new MethodResult(false, ["Ошибка отправки"]);

            try
            {
                MailAddress m = new MailAddress(email);
            }
            catch { return new MethodResult(false, ["Ошибка формата адреса почты"]); }

            var res = await _requestProvider.PostAsync<string, List<string>>("User/ResendEmailActivationCode", email);

            return new MethodResult(res.IsSucceeded, res.Messages);
        }
    }
}
