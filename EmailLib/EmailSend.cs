using System.Net.Mail;

namespace EmailLib
{
    public static class EmailSend
    {
        public static void Send(EmailMessage email)
        {
            var smtp = SmtpConfig.InitFromJson();
            smtp.Send(email.GetMailMessage());
        }
    }
}