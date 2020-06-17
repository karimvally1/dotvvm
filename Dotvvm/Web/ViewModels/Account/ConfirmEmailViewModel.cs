using DotVVM.Framework.Runtime.Filters;
using Service.Interfaces;
using Service.Models;
using System.Threading.Tasks;
using Web.Constants;
using Web.Extensions;

namespace Web.ViewModels.Account
{
    [Authorize]
    public class ConfirmEmailViewModel : MasterPageViewModel
    {
        public override string Title => "Confirm Email";

        private readonly IIdentityProvider _identityProvier;
        private readonly IAccountService _accountService;

        public ConfirmEmailViewModel(IIdentityProvider identityProvider, IAccountService accountService)
        {
            _identityProvier = identityProvider;
            _accountService = accountService;
        }

        public async Task Resend()
        {
            await _accountService.SendEmailConfirmation(Context.HttpContext.User.GetUserId());
        }
    }
}

