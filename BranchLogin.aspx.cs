using BankaSpotNew.App_Code;
using System;

namespace BankaSpotNew
{
    public partial class BranchLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM tbbranch WHERE BranchMobileNo = @BranchMobileNo AND BranchPassword = @BranchPassword";
            var parameters = new { BranchMobileNo = txtMobileNo.Text.Trim(), BranchPassword = txtPassword.Text };
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySingleOrDefault<Branch_Add>(sql, parameters);
            if (result != null)
            {
                if (result.Role == 1)
                {
                    Session["id"] = result.Id;
                    Response.Redirect("Admin/AddBranch.aspx", true);
                }
                else
                {
                    Session["branch"] = result;
                    Response.Redirect("Branch/Dashboard.aspx", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid Mobile No. Or Password');", true);
            }
        }
    }
}