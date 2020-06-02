using DotVVM.Framework.ViewModel;
using Service;
using Service.Values;
using System.Threading.Tasks;
using Web.Attributes;

namespace Web.ViewModels
{
    public class LoginViewModel : MasterPageViewModel
    {
        [CustomRequired]
        public string UserName { get; set; }

        [CustomRequired]
        public string Password { get; set; }

        [Bind(Direction.ServerToClient)]
        public string ErrorMessage { get; set; }

        private readonly IAuthService _authService;

        public LoginViewModel(IAuthService authService)
        {
            Title = "Login";
            _authService = authService;
        }

        public async Task Login()
        {
            var result = await _authService.Login(UserName, Password);

            if (result == default(SignInResult))
            {
                ErrorMessage = "Invalid username or password";
                return;
            }

            if (!result.Succeeded)
            {
                switch (result.Error)
                {
                    case Common.Enums.SignInErrorEnum.IsLockedOut:
                        ErrorMessage = "This account is locked out, please contact an administrator.";
                        break;
                    default:
                        ErrorMessage = "Invalid username or password";
                        break;
                }
            }
        }
    }
}

