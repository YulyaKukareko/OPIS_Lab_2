using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json.Linq;


namespace Lab_2.App_Code
{
    public class SumKYA : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            HttpResponse response = context.Response;
            StreamReader streamReader = new StreamReader(HttpContext.Current.Request.InputStream);
            string param = streamReader.ReadToEnd();
            dynamic data = JObject.Parse(param);
            int sum = Convert.ToInt32(data.field1) + Convert.ToInt32(data.field2);

            response.Write(sum);
        }


        public bool IsReusable
        {
            get { return false; }
        }


    }
}