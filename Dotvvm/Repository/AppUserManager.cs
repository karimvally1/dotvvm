using Data.Models;
using Microsoft.AspNetCore.Identity;
using Service.Interfaces;
using Service.Models;

namespace Repository
{
    public class AppUserManager : IAppUserManager<User>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AppUserManager(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async void Create(User user, string password)
        {
            var applicationUser = new ApplicationUser
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName
            };

            var result = await _userManager.CreateAsync(applicationUser, password);
        }
    }
}
