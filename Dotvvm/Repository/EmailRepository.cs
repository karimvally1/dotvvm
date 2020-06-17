using Data;
using Service.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class EmailRepository : IReadWriteRepository<Service.Models.Email>
    {
        private readonly ApplicationDbContext _dbContext;

        public EmailRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Service.Models.Email> GetAll()
        {
            //return _dbContext.Emails.Select(e => new Service.Models.Email
            //{
            //    Id = e.Id,
            //    From = e.From,
            //    Subject = e.Subject,
            //    Body = e.Body,
            //    Sent = e.Sent
            //});
            return null;
        }

        public Service.Models.Email GetById(int id)
        {
            return GetAll().Single(e => e.Id == id);
        }

        public async Task Insert(Service.Models.Email model)
        {
            var email = new Data.Models.Email
            {
                UserId = model.User.Id,
                From = model.From,
                To = string.Join(";", model.To),
                Subject = model.Subject,
                Body = model.Body,
                Sent = model.Sent,
            };

            await _dbContext.Emails.AddAsync(email);
            await _dbContext.SaveChangesAsync();
        }

        public void Update(Service.Models.Email model)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Service.Models.Email model)
        {
            throw new System.NotImplementedException();
        }

        public async void SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
