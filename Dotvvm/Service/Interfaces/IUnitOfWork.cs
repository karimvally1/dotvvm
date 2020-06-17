using Service.Models;
using System;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IUnitOfWork
    {
        IReadWriteRepository<Email> EmailRepository { get; }
        Task Commit();
    }
}
