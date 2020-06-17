using Data;
using Service.Interfaces;
using Service.Models;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IReadWriteRepository<Email> EmailRepository { get; }

        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext, IReadWriteRepository<Email> emailRepository)
        {
            _dbContext = dbContext;
            EmailRepository = emailRepository;
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
