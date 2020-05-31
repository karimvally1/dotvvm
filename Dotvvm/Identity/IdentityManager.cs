using Microsoft.AspNetCore.Identity;
using Identity.Models;
using Service.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Service.Values;
using Identity.Extensions;

namespace Identity
{
    public class IdentityManager : IIdentityManager<Service.Models.User>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityManager(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Service.Values.IdentityResult> Create(Service.Models.User user, string password)
        {
            var applicationUser = new ApplicationUser
            {
                Email = user.Email,
                UserName = user.UserName,
                User = new User
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName
                }
            };

            var result = await _userManager.CreateAsync(applicationUser, password);

            return new Service.Values.IdentityResult
            {
                Succeeded = result.Succeeded,
                Errors = result.Errors.Select(e => new Service.Values.IdentityError
                {
                    Error = e.GetEnum(),
                    Description = e.Description
                }).ToArray()
            };                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
        }
    }
}
