using System.Net;
using System.Net.Mail;
using System.Windows;
using Microsoft.Win32;

namespace SendMail
{
    public partial class MainWindow : Window
    {
        private static string _path;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Attach_OnClick(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = "Any files (*.*)"
            }; 
            ofd.ShowDialog();
            _path = ofd.FileName;
        }
        private void Button_Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Input_To.Clear();
            Input_From.Clear();
            Input_Subject.Clear();
            Input_Message.Clear();
        }
        private void Button_Send_OnClick(object sender, RoutedEventArgs e)
        {
            var emailFrom = new MailAddress(Input_From.Text);
            var emailTo = new MailAddress(Input_To.Text);
            var email = new MailMessage(emailFrom, emailTo);
            email.Subject = Input_Subject.Text;
            email.Body = Input_Message.Text;
            email.IsBodyHtml = false;
            email.Attachments.Add(new Attachment(_path));
            
            var smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("somemail@gmail.com", "mypassword");
            smtp.EnableSsl = true;
            smtp.Send(email);
        }
    }
}