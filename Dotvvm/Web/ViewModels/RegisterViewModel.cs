using DotVVM.Framework.ViewModel.Validation;
using Service;
using Service.Values;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Web.Attributes;

namespace Web.ViewModels
{
    public class RegisterViewModel : MasterPageViewModel
    {
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

        private readonly IUserService _userService;

        public RegisterViewModel(IUserService userService)
        {
            Title = "Create an account";
            _userService = userService;
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

            var result = await _userService.Register(accountRegister);

            if (!result.Succeeded)
            {
                MapErrorsToViewModel(result.Errors);
                Context.FailOnInvalidModelState();
            }
        }

        private void MapErrorsToViewModel(IdentityError[] errors)
        {
            foreach (var error in errors)
            {
                switch (error.Error)
                {
                    case Common.Enums.IdentityErrorEnum.PasswordRequiresDigit:
                    case Common.Enums.IdentityErrorEnum.PasswordRequiresLower:
                    case Common.Enums.IdentityErrorEnum.PasswordRequiresNonAlphanumeric:
                    case Common.Enums.IdentityErrorEnum.PasswordRequiresUpper:
                        this.AddModelError(v => v.Password, error.Description);
                        break;
                }
            }
        }
    }
}

