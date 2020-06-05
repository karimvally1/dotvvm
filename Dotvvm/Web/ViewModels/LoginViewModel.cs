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

        private readonly IIdentityManager _identityManager;
        private readonly IIdentityProvider _identityProvider;

        public LoginViewModel(IIdentityManager identityManager, IIdentityProvider identityProvider)
        {
            _identityManager = identityManager;
            _identityProvider = identityProvider;
        }

        public async Task Login()
        {
            var user = UserNameOrEmail.Contains("@") ?
                await _identityProvider.GetByEmail(UserNameOrEmail) :
                await _identityProvider.GetByUserName(UserNameOrEmail);

            if (user == default(User))
            {
                ErrorMessage = "Invalid login information, please try again.";
                return;
            }

            var result = await _identityManager.PasswordSignIn(user.UserName, Password, true, true);

            if (!result.Succeeded)
            {
                ErrorMessage = "Invalid login information, please try again.";
                return;
            }
        }
    }
}

