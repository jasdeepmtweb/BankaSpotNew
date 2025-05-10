using System;

namespace BankaSpotNew
{
    public partial class AppIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnConnectorLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConnectorLogin.aspx");
        }

        protected void BtnFreeLancerLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("FreeLancerLogin.aspx");
        }
    }
}