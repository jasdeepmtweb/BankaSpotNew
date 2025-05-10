using BankaSpotNew.App_Code;
using Dapper;
using System;

namespace BankaSpotNew
{
    public partial class AccountantLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string sql = "SELECT `Id`, `Name`, `MobileNo`, `EmailId`, `Password`, `CreatedOn` FROM `tbaccountant` WHERE MobileNo=@p_MobileNo AND Password=@p_Password";
            var parameters = new DynamicParameters();
            parameters.Add("p_MobileNo", txtMobileNo.Text);
            parameters.Add("p_Password", txtPassword.Text);
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySingleOrDefaultDynamic<AccountantModel>(sql, parameters);
            if (result != null)
            {
                Session["acc"] = result;
                Response.Redirect("Accountant/ShowAllCases.aspx", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid Mobile No. Or Password');", true);
            }
        }
    }
}