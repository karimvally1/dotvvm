using Microsoft.AspNetCore.Identity;
using Identity.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;
using System.Linq;

namespace Identity
{
    public class IdentityProvider : IIdentityProvider
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityProvider(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IQueryable<Service.Models.User> GetAll()
        {
            return _userManager.Users
                .Include(a => a.User)
                .Select(a => new Service.Models.User
                {
                    AspNetUserId = a.Id,
                    Id = a.User.Id,
                    Email = a.Email,
                    UserName = a.UserName,
                    FirstName = a.User.FirstName,
                    LastName = a.User.LastName
                });
        }

        public IQueryable<Service.Models.User> GetAllNotInRole(string role)
        {
            return GetAll();
        }

        public async Task<Service.Models.User> GetById(string userId)
        {
            return await GetAll()
                .SingleOrDefaultAsync(u => u.AspNetUserId == userId);
        }

        public async Task<Service.Models.User> GetByUserName(string userName)
        {
            return await GetAll()
                .SingleOrDefaultAsync(a => a.UserName == userName);
        }

        public async Task<Service.Models.User> GetByEmail(string email)
        {
            return await GetAll()
                .SingleOrDefaultAsync(a => a.Email == email);
        }
    }
}
