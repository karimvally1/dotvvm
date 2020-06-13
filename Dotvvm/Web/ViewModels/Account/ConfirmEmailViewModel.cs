using DotVVM.Framework.ViewModel;
using Service.Interfaces;
using Service.Models;
using System.Threading.Tasks;
using Web.Constants;

namespace Web.ViewModels.Account
{
    public class ConfirmEmailViewModel : MasterPageViewModel
    {
        public override string Title => "Confirm Email";

        [FromQuery("userId")]
        public string UserId { get; set; }

        private readonly IIdentityProvider _identityProvier;
        private readonly IAccountService _accountService;

        public ConfirmEmailViewModel(IIdentityProvider identityProvider, IAccountService accountService)
        {
            _identityProvier = identityProvider;
            _accountService = accountService;
        }

        public async Task Resend()
        {
            var user = await _identityProvier.GetById(UserId);
            
            if (user == default(User))
                Context.RedirectToRoute(Routes.NotFound);

            _accountService.SendEmailConfirmation(user.UserName);
        }
    }
}

