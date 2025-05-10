using System;

namespace BankaSpotNew.Branch
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../BranchLogin.aspx");
        }
    }
}