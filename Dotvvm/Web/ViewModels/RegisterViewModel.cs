using Common.Enums;
using DotVVM.Framework.ViewModel.Validation;
using Service.Interfaces;
using Service.Values;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Web.Attributes;
using Web.Constants;

namespace Web.ViewModels
{
    public class RegisterViewModel : MasterPageViewModel
    {
        public override string Title => "Register";

        [CustomRequired]
        public string FirstName { get; set; }

        [CustomRequired]
        public string LastName { get; set; }

        [CustomRequired]
        [EmailAddress]
        public string Email { get; set; }

        [CustomRequired]
        public string UserName { get; set; }

        [CustomRequired]  
        public string Password { get; set; }

        private readonly IAccountService _accountService;
        private readonly IIdentityProvider _identityProvider;

        public RegisterViewModel(IAccountService accountService, IIdentityProvider identityProvider)
        {
            _accountService = accountService;
            _identityProvider = identityProvider;
        }

        public async Task Create()
        {
            var accountRegister = new AccountRegister
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                UserName = UserName,
                Password = Password
            };

            var result = await _accountService.Register(accountRegister);

            if (!result.Succeeded)
            {
                MapErrorsToViewModel(result.Errors);
                Context.FailOnInvalidModelState();
            }

            var user = await _identityProvider.GetByUserName(accountRegister.UserName);
            Context.RedirectToRoute(Routes.ConfirmEmail, query: new { userId = user.AspNetUserId });
        }

        private void MapErrorsToViewModel(IdentityError[] errors)
        {
            foreach (var error in errors)
            {
                switch (error.Error)
                {
                    case IdentityErrorEnum.PasswordRequiresDigit:
                    case IdentityErrorEnum.PasswordRequiresLower:
                    case IdentityErrorEnum.PasswordRequiresNonAlphanumeric:
                    case IdentityErrorEnum.PasswordRequiresUpper:
                    case IdentityErrorEnum.PasswordTooShort:
                        this.AddModelError(v => v.Password, error.Description);
                        break;
                    case IdentityErrorEnum.InvalidUserName:
                    case IdentityErrorEnum.DuplicateUserName:
                        this.AddModelError(v => v.UserName, error.Description);
                        break;
                    case IdentityErrorEnum.InvalidEmail:
                    case IdentityErrorEnum.DuplicateEmail:
                        this.AddModelError(v => v.Email, error.Description);
                        break;
                }
            }
        }
    }
}

