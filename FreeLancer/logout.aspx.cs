using System;

namespace BankaSpotNew.FreeLancer
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../FreeLancerLogin.aspx");
        }
    }
}