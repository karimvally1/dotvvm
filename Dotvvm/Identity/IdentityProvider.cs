using Microsoft.AspNetCore.Identity;
using Identity.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;

namespace Identity
{
    public class IdentityProvider : IIdentityProvider
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityProvider(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Service.Models.User> GetByUserName(string userName)
        {
            var applicationUser = await _userManager.Users
                .Include(a => a.User)
                .SingleOrDefaultAsync(a => a.UserName == userName);

            if (applicationUser == default(ApplicationUser))
                return null;

            return MapApplicationUserToUser(applicationUser);
        }

        public async Task<Service.Models.User> GetByEmail(string email)
        {
            var applicationUser = await _userManager.Users
                .Include(a => a.User)
                .SingleOrDefaultAsync(a => a.Email == email);

            if (applicationUser == default(ApplicationUser))
                return null;

            return MapApplicationUserToUser(applicationUser);
        }


        private Service.Models.User MapApplicationUserToUser(ApplicationUser applicationUser)
        {
            return new Service.Models.User
            {
                AspNetUserId = applicationUser.Id,
                Id = applicationUser.User.Id,
                Email = applicationUser.Email,
                UserName = applicationUser.UserName,
                FirstName = applicationUser.User.FirstName,
                LastName = applicationUser.User.LastName
            };
        }
    }
}
