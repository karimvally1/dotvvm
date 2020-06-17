using DotVVM.Framework.Runtime.Filters;
using DotVVM.Framework.ViewModel;
using Service.Interfaces;
using System.Threading.Tasks;
using Web.Constants;
using Web.Extensions;

namespace Web.ViewModels.Account
{
    [Authorize]
    public class ActivateViewModel : MasterPageViewModel
    {
        public override string Title => "Activate";

        [FromQuery("token")]
        public string Token { get; set; }

        private readonly IAccountService _accountService;

        public ActivateViewModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public override async Task Init()
        {
            if (string.IsNullOrEmpty(Token))
                Context.RedirectToRoute(Routes.NotFound);

            var result = await _accountService.ConfirmEmail(Context.HttpContext.User.GetUserId(), Token);

            if (!result.Succeeded)
                Context.RedirectToRoute(Routes.NotFound);

            Context.RedirectToRoute(Routes.NotFound);
        }
    }
}

