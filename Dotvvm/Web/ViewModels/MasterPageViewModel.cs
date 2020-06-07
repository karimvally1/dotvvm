using DotVVM.Framework.ViewModel;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public abstract class MasterPageViewModel : DotvvmViewModelBase
    {
        public abstract string Title { get; }

        public async Task LogOut()
        {
            Context.RedirectToRoute("Logout");
        }
    }
}
