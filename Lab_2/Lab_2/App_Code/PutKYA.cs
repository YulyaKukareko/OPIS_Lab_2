using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_2.App_Code
{
    public class PutKYA : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            HttpResponse response = context.Response;

            response.Write("GET-Http-XYZ:ParmA = " + context.Request.Form["ParamA"] + " ParmB = " + context.Request.Form["ParamB"]);
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}