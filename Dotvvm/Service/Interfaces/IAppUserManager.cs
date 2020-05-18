using Service.Models;

namespace Service.Interfaces
{
    public interface IAppUserManager<T> where T : User
    {
        void Create(T user, string password);
    }
}
