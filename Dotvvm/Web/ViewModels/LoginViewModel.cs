using DotVVM.Framework.ViewModel;
using Service;
using Service.Models;
using System.Threading.Tasks;
using Web.Attributes;

namespace Web.ViewModels
{
    public class LoginViewModel : MasterPageViewModel
    {
        [CustomRequired]
        public string UserNameOrEmail { get; set; }

        [CustomRequired]
        public string Password { get; set; }

        [Bind(Direction.ServerToClient)]
        public string ErrorMessage { get; set; }

        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public LoginViewModel(IUserService userService, IAuthService authService)
        {
            Title = "Login";
            _userService = userService;
            _authService = authService;
        }

        public async Task Login()
        {
            var user = UserNameOrEmail.Contains("@") ?
                await _userService.GetByEmail(UserNameOrEmail) :
                await _userService.GetByUserName(UserNameOrEmail);

            if (user == default(User))
            {
                ErrorMessage = "Invalid login information, please try again.";
                return;
            }

            var result = await _authService.Login(user.UserName, Password);

            if (!result.Succeeded)
                ErrorMessage = "Invalid login information, please try again.";
        }
    }
}

