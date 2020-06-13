using Service.Interfaces;
using Service.Models;
using Service.Values;
using System.Threading.Tasks;

namespace Service
{
    public class AccountService : IAccountService
    {
        private readonly IIdentityManager _identityManager;
        private readonly IIdentityProvider _identityProvider;
        private readonly IEmailService _emailService;

        public AccountService(IIdentityManager identityManager, IIdentityProvider identityProvider, IEmailService emailService)
        {
            _identityManager = identityManager;
            _identityProvider = identityProvider;
            _emailService = emailService;
        }

        public async Task<IdentityResult> Register(AccountRegister accountRegister)
        {
            var user = new User
            {
                FirstName = accountRegister.FirstName,
                LastName = accountRegister.LastName,
                Email = accountRegister.Email,
                UserName = accountRegister.UserName
            };

            var result = await _identityManager.Create(user, accountRegister.Password);

            if (!result.Succeeded)
                return result;

            SendEmailConfirmation(user.UserName);
            return result;
        }

        public async Task<IdentityResult> ConfirmEmail(string userId, string token)
        {
            var user = await _identityProvider.GetById(userId);

            if (user == default(User))
            {
                return new IdentityResult
                {
                    Succeeded = false
                };
            }

            if (await _identityManager.IsEmailConfirmed(user.UserName))
            {
                return new IdentityResult
                {
                    Succeeded = false
                };
            }

            return await _identityManager.ConfirmEmailToken(user.UserName, token);
        }

        public async void SendEmailConfirmation(string userName)
        {
            var token = await _identityManager.CreateEmailConfirmationToken(userName);
            _emailService.SendEmail("karimvally@hotmail.co.uk", new string[]{ "creamvally@gmail.com" }, "Confirm email", token);
        }
    }
}
