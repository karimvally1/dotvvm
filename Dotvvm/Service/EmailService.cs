using Mailer;
using Mailer.Models;
using Service.Interfaces;

namespace Service
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string from, string[] to, string subject, string body)
        {
            var email = new Email  
            {
                From = from,
                To = to,
                Subject = subject,
                Body = body
            };

            EmailSender.SendEmail(email, "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");
        }
    }
}
