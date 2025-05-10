using BankaSpotNew.App_Code;
using System;

namespace BankaSpotNew
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();

            var errorLogger = new Log("ErrorLog.txt");
            errorLogger.LogError(exception);

            Server.ClearError();

            string previousPageUrl = Request.UrlReferrer != null ? Request.UrlReferrer.ToString() : string.Empty;
            Session["PreviousPageUrl"] = previousPageUrl;

            Response.Redirect("~/Error.aspx?prevPage=" + Server.UrlEncode(previousPageUrl));
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}