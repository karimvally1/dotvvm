using Mailer.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Linq;

namespace Mailer
{
    public static class EmailSender
    {
        public static async void SendEmail(EmailMessage email, string apiKey)
        {
            var message = new SendGridMessage()
            {
                From = new EmailAddress(email.From),
                Subject = email.Subject,
                PlainTextContent = email.Body,
                HtmlContent = email.Body
            };

            message.AddTos(email.To.Select(t => new EmailAddress(t)).ToList());

            var client = new SendGridClient(apiKey);
            var result = await client.SendEmailAsync(message);
        }
    }
}
