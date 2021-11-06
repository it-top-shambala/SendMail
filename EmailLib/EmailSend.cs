using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text.Json;

namespace EmailLib
{
    public static class EmailSend
    {
        private static SmtpClient InitFromJson()
        {
            using var file = new FileStream("smtp.json", FileMode.Open);
            var smtp = JsonSerializer.DeserializeAsync<Smtp>(file).Result;
            var client = new SmtpClient(smtp.Server, smtp.Port);
            client.Credentials = new NetworkCredential(smtp.Login, smtp.Password);
            client.EnableSsl = true;

            return client;
        }
        
        private static MailMessage CreateMessage(string to, string @from, string subject, string message, string path="")
        {
            var email = new MailMessage(new MailAddress(@from), new MailAddress(to));
            email.Subject = subject;
            email.Body = message;
            email.Attachments.Add(new Attachment(path));
            email.IsBodyHtml = false;
            return email;
        }
        
        public static void Send(string to, string @from, string subject, string message, string path)
        {
            var smtp = InitFromJson();
            var mail = CreateMessage(to, @from, subject, message, path);
            smtp.Send(mail);
        }
    }
}