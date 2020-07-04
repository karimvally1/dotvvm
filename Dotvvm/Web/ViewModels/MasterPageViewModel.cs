using DotVVM.Framework.ViewModel;
using System.Threading.Tasks;
using Web.Constants;

namespace Web.ViewModels
{
    public abstract class MasterPageViewModel : DotvvmViewModelBase
    {
        public abstract string Title { get; }

        public async Task LogOut()
        {
            Context.RedirectToRoute(Routes.Logout);
        }

        public async Task Users()
        {
            Context.RedirectToRoute(Routes.Users);
        }
    }
}
