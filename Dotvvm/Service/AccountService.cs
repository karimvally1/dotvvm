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

            await _identityManager.SignIn(user.UserName);

            user = await _identityProvider.GetByUserName(user.UserName);

            await SendEmailConfirmation(user.AspNetUserId);

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

        public async Task SendEmailConfirmation(string aspnetUserId)
        {
            var user = await _identityProvider.GetById(aspnetUserId);
            var token = await _identityManager.CreateEmailConfirmationToken(user.UserName);
            var email = new Email
            {
                From = "karimvally@hotmail.co.uk",
                To = new string[] { user.Email },
                Subject = "Confirm Email",
                Body = token,
                User = user
            };

            await _emailService.SendEmail(email);
        }
    }
}
