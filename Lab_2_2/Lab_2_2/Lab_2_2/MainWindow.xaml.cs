using System;
using System.Text;
using System.Windows;
using System.Net;
using System.IO;
using System.Web;

namespace Lab_2_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PostButton_Click(object sender, RoutedEventArgs e)
        {
            HttpWebRequest rq = (HttpWebRequest)HttpWebRequest.Create("http://localhost:8088/post.KYA");
            rq.Method = "POST";
            ASCIIEncoding encoding = new ASCIIEncoding();
            String[] name = myText.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            byte[] byte1 = encoding.GetBytes("ParamA=" + name[0] + "&ParamB=" + name[1]);
            rq.ContentType = "application/x-www-form-urlencoded";
            rq.ContentLength = byte1.Length;
            using (var stream = rq.GetRequestStream())
            {
                stream.Write(byte1, 0, byte1.Length);
            }
            HttpWebResponse rs = (HttpWebResponse)rq.GetResponse();
            String responseString;
            using (Stream stream = rs.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                responseString = reader.ReadToEnd();
            }
            myText.Text = responseString;
        }
    }
}
