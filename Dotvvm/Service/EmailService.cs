using Mailer;
using Mailer.Models;
using Service.Interfaces;
using Service.Models;
using System;
using System.Threading.Tasks;

namespace Service
{
    public class EmailService : IEmailService
    {
        private readonly IUnitOfWork _uow;

        public EmailService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task SendEmail(Email email)
        {
            var message = new EmailMessage
            {
                From = email.From,
                To = email.To,
                Subject = email.Subject,
                Body = email.Body
            };

            EmailSender.SendEmail(message, "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");
            email.Sent = DateTime.Now;
            await _uow.EmailRepository.Insert(email);
            await _uow.Commit();
        }
    }
}
