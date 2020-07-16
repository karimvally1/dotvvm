using Service.Interfaces;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IIdentityProvider _identityProvider;

        public UserService(IIdentityProvider identityProvider)
        {
            _identityProvider = identityProvider;
        }

        public void GetNonAdminUsers()
        {
            throw new System.NotImplementedException();
        }
    }
}
