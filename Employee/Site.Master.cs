using BankaSpotNew.App_Code;
using System;

namespace BankaSpotNew.Employee
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["emp"] == null)
            {
                Response.Redirect("../EmployeeLogin.aspx");
            }
            if (!IsPostBack)
            {
                Employee_Add oEmployee_Add = Session["emp"] as Employee_Add;
                lblName.Text = oEmployee_Add.Name;
            }
        }
    }
}