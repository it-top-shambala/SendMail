using System.Net;
using System.Net.Mail;
using System.Windows;
using EmailLib;
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
            EmailSend.Send(Input_To.Text, Input_From.Text, Input_Subject.Text, Input_Message.Text, _path);
        }
    }
}