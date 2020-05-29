using Microsoft.AspNetCore.Identity;
using Identity.Models;
using Service.Interfaces;
using Service.Models;

namespace Identity
{
    public class UserManager : IUserManager<Service.Models.User>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserManager(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async void Create(Service.Models.User user, string password)
        {
            var applicationUser = new ApplicationUser
            {
                Email = user.Email,
                UserName = user.UserName
            };

            var result = await _userManager.CreateAsync(applicationUser, password);
        }
    }
}
