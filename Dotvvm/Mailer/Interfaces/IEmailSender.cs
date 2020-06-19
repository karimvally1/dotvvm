using Mailer.Models;

namespace Mailer.Interfaces
{
    public interface IEmailSender
    {
        void SendEmail(EmailMessage email);
    }
}
