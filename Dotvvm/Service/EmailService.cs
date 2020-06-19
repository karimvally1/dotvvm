using System;
using System.Threading.Tasks;
using Service.Interfaces;
using Service.Models;
using Mailer.Models;
using Mailer.Interfaces;

namespace Service
{
    public class EmailService : IEmailService
    {
        private readonly IUnitOfWork _uow;
        private readonly IEmailSender _emailSender;

        public EmailService(IUnitOfWork uow, IEmailSender emailSender)
        {
            _uow = uow;
            _emailSender = emailSender;
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

            _emailSender.SendEmail(message);
            email.Sent = DateTime.Now;
            await _uow.EmailRepository.Insert(email);
            await _uow.Commit();
        }
    }
}
