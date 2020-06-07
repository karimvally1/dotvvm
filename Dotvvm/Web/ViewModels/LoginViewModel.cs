using DotVVM.Framework.ViewModel;
using Service.Interfaces;
using Service.Models;
using System.Threading.Tasks;
using Web.Attributes;

namespace Web.ViewModels
{
    public class LoginViewModel : MasterPageViewModel
    {
        public override string Title => "Login";

        [CustomRequired]
        public string UserNameOrEmail { get; set; }

        [CustomRequired]
        public string Password { get; set; }

        [Bind(Direction.ServerToClient)]
        public string ErrorMessage { get; set; }

        private readonly IAuthService _authService;

        public LoginViewModel(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task Login()
        {
            var result = await _authService.SignIn(UserNameOrEmail, Password);

            if (!result.Succeeded)
            {
                ErrorMessage = "Invalid login information, please try again.";
                return;
            }
        }
    }
}

