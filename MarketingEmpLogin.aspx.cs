using BankaSpotNew.App_Code;
using System;

namespace BankaSpotNew
{
    public partial class MarketingEmpLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM tbmarketingemp WHERE MobileNo = @MobileNo AND EmpPassword = @EmpPassword";
            var parameters = new { MobileNo = txtMobileNo.Text.Trim(), EmpPassword = txtPassword.Text };
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySingleOrDefault<Marketing_Employee_Add>(sql, parameters);
            if (result != null)
            {
                Session["memp"] = result;
                Response.Redirect("MarketingEmp/Dashboard.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid Mobile No. Or Password');", true);
            }
        }
    }
}