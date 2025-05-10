using BankaSpotNew.App_Code;
using Dapper;
using System;

namespace BankaSpotNew
{
    public partial class FreeLancerLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            if (!CheckAgree.Checked)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Tick Checkbox');", true);
                return;
            }
            string sql = "SELECT * FROM tbfreelancer WHERE MobileNo = @MobileNo AND Password = @Password AND ext4=1";
            var parameters = new DynamicParameters();
            parameters.Add("Password", txtPassword.Text);
            parameters.Add("MobileNo", txtMobileNo.Text.Trim());

            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySingleOrDefaultDynamic<Freelancer_Add>(sql, parameters);
            if (result != null)
            {
                Session["frl"] = result;
                Response.Redirect("FreeLancer/Dashboard.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid Mobile No. Or Password');", true);
            }
        }
    }
}