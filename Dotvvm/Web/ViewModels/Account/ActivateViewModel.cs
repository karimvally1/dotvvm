using DotVVM.Framework.ViewModel;
using Service.Interfaces;
using System.Threading.Tasks;
using Web.Constants;

namespace Web.ViewModels.Account
{
    public class ActivateViewModel : MasterPageViewModel
    {
        public override string Title => "Activate";

        [FromQuery("userId")]
        public string UserId { get; set; }

        [FromQuery("token")]
        public string Token { get; set; }

        private readonly IAccountService _accountService;

        public ActivateViewModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public override async Task Init()
        {
            if (string.IsNullOrEmpty(UserId) || string.IsNullOrEmpty(Token))
                Context.RedirectToRoute(Routes.NotFound);

            var result = await _accountService.ConfirmEmail(UserId, Token);

            if (!result.Succeeded)
                Context.RedirectToRoute(Routes.NotFound);

            Context.RedirectToRoute(Routes.NotFound);
        }
    }
}

