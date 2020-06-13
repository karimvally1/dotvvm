using Service.Interfaces;
using System.Threading.Tasks;
using Web.Constants;

namespace Web.ViewModels
{
    public class LogoutViewModel : MasterPageViewModel
    {
        public override string Title => "Logout";

        private readonly IIdentityManager _identityManager;

        public LogoutViewModel(IIdentityManager identityManager)
        {
            _identityManager = identityManager;
        }

        public override async Task Init()
        {
            await _identityManager.SignOut();
            Context.RedirectToRoute(Routes.Login);
        }
    }
}

