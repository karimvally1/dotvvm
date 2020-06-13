using DotVVM.Framework.Runtime.Filters;

namespace Web.ViewModels
{
    [Authorize]
    public class HomeViewModel : MasterPageViewModel
    {
        public override string Title => "Home";

        public HomeViewModel()
        {
            
        }
    }
}
