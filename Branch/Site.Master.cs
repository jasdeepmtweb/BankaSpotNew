using BankaSpotNew.App_Code;
using System;

namespace BankaSpotNew.Branch
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["branch"] == null)
            {
                Response.Redirect("../BranchLogin.aspx");
            }
            Branch_Add oBranch_Add = Session["branch"] as Branch_Add;
            lblName.Text = oBranch_Add.BranchName;
        }
    }
}