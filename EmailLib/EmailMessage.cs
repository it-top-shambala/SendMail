using System.Net.Mail;

namespace EmailLib
{
    public class EmailMessage
    {
        private readonly MailMessage _email;

        public EmailMessage(string to, string @from, string subject, string message, string path="")
        {
            _email = new MailMessage(new MailAddress(@from), new MailAddress(to));
            _email.Subject = subject;
            _email.Body = message;
            _email.Attachments.Add(new Attachment(path));
            _email.IsBodyHtml = false;
        }

        public MailMessage GetMailMessage() => _email;
    }
}