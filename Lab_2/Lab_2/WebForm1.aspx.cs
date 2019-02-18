using System;
using System.Net;
using System.IO;
using System.Text;

namespace Lab_2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String[] name = myText.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            HttpWebRequest rq = (HttpWebRequest)HttpWebRequest.Create("http://localhost:8088/get.KYA?" + "ParamA=" + name[0] + "&ParamB=" + name[1]);
            rq.Method = "GET";
            HttpWebResponse rs = (HttpWebResponse)rq.GetResponse();
            StreamReader rdr = new StreamReader(rs.GetResponseStream());
            Response.Write(rdr.ReadToEnd());
            Response.Write("");
        }

        protected void postButton_Click(object sender, EventArgs e)
        {
            HttpWebRequest rq = (HttpWebRequest)HttpWebRequest.Create("http://localhost:8088/post.KYA");
            rq.Method = "POST";
            sendRequest(rq);
        }

        protected void putButton_Click(object sender, EventArgs e)
        {
            HttpWebRequest rq = (HttpWebRequest)HttpWebRequest.Create("http://localhost:8088/put.KYA");
            rq.Method = "PUT";
            sendRequest(rq);
        }

        protected void errorHandler_Click(object sender, EventArgs e)
        {
            try
            {
                HttpWebRequest rq = (HttpWebRequest)HttpWebRequest.Create("http://localchost:8088/vv.ndy");
                rq.Method = "GET";
                HttpWebResponse rs = (HttpWebResponse)rq.GetResponse();
                StreamReader rdr = new StreamReader(rs.GetResponseStream());
                Response.Write(rdr.ReadToEnd());
            }
            catch (WebException we)
            {
                Response.Write("");
                Response.Write(we.Status);
                Response.Write("<br />" + we.Message);
                Response.Write("<br />" + we.TargetSite);
                Response.Write("<br />" + we.Source);
                Response.Write("");
            }
        }

        private void sendRequest(HttpWebRequest rq)
        {
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
            StreamReader rdr = new StreamReader(rs.GetResponseStream());
            Response.Write(rdr.ReadToEnd());
            Response.Write("");
        }
    }
}