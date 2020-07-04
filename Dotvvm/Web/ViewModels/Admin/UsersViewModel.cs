
using DotVVM.Framework.Runtime.Filters;

namespace Web.ViewModels.Admin
{
    [Authorize(Roles = "Administrator")]
    public class UsersViewModel : MasterPageViewModel
    {
        public override string Title => "Users";
    }
}

