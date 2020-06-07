using DotVVM.Framework.Runtime.Filters;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    [Authorize]
    public class HomeViewModel : MasterPageViewModel
    {
        public override string Title => "Home";

        public HomeViewModel()
        {
            
        }

        public override Task Init()
        {
            var identity = Context.HttpContext;
            return base.Init();
        }
    }
}
