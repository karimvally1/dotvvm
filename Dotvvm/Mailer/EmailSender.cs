using System.Linq;
using Mailer.Interfaces;
using Mailer.Models;
using Mailer.Settings;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Mailer
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;

        public EmailSender(EmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }

        public async void SendEmail(EmailMessage email)
        {
            var message = new SendGridMessage()
            {
                From = new EmailAddress(email.From),
                Subject = email.Subject,
                PlainTextContent = email.Body,
                HtmlContent = email.Body
            };

            message.AddTos(email.To.Select(t => new EmailAddress(t)).ToList());

            var client = new SendGridClient(_emailSettings.Key);
            var result = await client.SendEmailAsync(message);
        }
    }
}
