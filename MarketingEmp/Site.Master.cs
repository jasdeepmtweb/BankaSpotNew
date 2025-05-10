using BankaSpotNew.App_Code;
using System;

namespace BankaSpotNew.MarketingEmp
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["memp"] == null)
            {
                Response.Redirect("../MarketingEmpLogin.aspx");
            }
            if (!IsPostBack)
            {
                Marketing_Employee_Add oEmployee_Add = Session["memp"] as Marketing_Employee_Add;
                lblName.Text = oEmployee_Add.Name;
            }
        }
    }
}