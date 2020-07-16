using DotVVM.Framework.Controls;
using DotVVM.Framework.Runtime.Filters;
using Service.Interfaces;
using Service.Models;
using System.Threading.Tasks;

namespace Web.ViewModels.Admin
{
    [Authorize(Roles = "Administrator")]
    public class UsersViewModel : MasterPageViewModel
    {
        public override string Title => "Users";

        private readonly IIdentityProvider _identityProvider;

        public GridViewDataSet<User> Data { get; set; } = new GridViewDataSet<User>() { PagingOptions = { PageSize = 5 } };

        public UsersViewModel(IIdentityProvider identityProvider)
        {
            _identityProvider = identityProvider;
        }

        public override Task Init()
        {
            var users = _identityProvider.GetAll();
            var identity = Context.HttpContext;
            Data.LoadFromQueryable(users);
            return base.Init();
        }
    }
}

