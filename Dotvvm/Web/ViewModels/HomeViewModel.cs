using Microsoft.AspNetCore.Authorization;

namespace Web.ViewModels
{
    [Authorize]
    public class HomeViewModel : MasterPageViewModel
    {
        public HomeViewModel()
        {
            Title = "Home";
        }
    }
}
