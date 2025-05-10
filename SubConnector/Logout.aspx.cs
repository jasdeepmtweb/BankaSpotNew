using System;

namespace BankaSpotNew.SubConnector
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../SubconnectorLogin.aspx");
        }
    }
}