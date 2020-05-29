using Service.Models;

namespace Service.Interfaces
{
    public interface IUserManager<T> where T : User
    {
        void Create(T user, string password);
    }
}
