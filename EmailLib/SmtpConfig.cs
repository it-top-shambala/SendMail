using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text.Json;

namespace EmailLib
{
    public static class SmtpConfig
    {
        public static SmtpClient InitFromJson()
        {
            using var file = new FileStream("smtp.json", FileMode.Open);
            var smtp = JsonSerializer.DeserializeAsync<Smtp>(file).Result;
            var client = new SmtpClient(smtp.Server, smtp.Port);
            client.Credentials = new NetworkCredential(smtp.Login, smtp.Password);
            client.EnableSsl = true;

            return client;
        }
    }
}