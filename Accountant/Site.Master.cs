using BankaSpotNew.App_Code;
using System;

namespace BankaSpotNew.Accountant
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["acc"] == null)
            {
                Response.Redirect("../AccountantLogin.aspx");
            }
            AccountantModel oAccountantModel = Session["acc"] as AccountantModel;
            lblName.Text = oAccountantModel.Name;
        }
    }
}