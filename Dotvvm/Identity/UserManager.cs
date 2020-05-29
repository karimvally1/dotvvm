using Microsoft.AspNetCore.Identity;
using Identity.Models;
using Service.Interfaces;
using Service.Models;

namespace Identity
{
    public class UserManager : IUserManager<User>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserManager(UserManager<ApplicationUser> userManager)
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
