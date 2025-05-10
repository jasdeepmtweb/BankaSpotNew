using BankaSpotNew.App_Code;
using System;

namespace BankaSpotNew
{
    public partial class EmployeeLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM tbemployee WHERE MobileNo = @MobileNo AND EmpPassword = @EmpPassword AND ext1=1";
            var parameters = new { MobileNo = txtMobileNo.Text.Trim(), EmpPassword = txtPassword.Text };
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySingleOrDefault<Employee_Add>(sql, parameters);
            if (result != null)
            {
                Session["emp"] = result;
                Response.Redirect("Employee/Dashboard.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid Mobile No. Or Password');", true);
            }
        }
    }
}