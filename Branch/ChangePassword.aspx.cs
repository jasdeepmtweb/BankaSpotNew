using BankaSpotNew.App_Code;
using System;

namespace BankaSpotNew.Branch
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["branch"] == null)
            {
                Response.Redirect("../BranchLogin.aspx");
            }
            if (!IsPostBack)
            {
                Branch_Add oBranch_Add = Session["branch"] as Branch_Add;
                cmpOldPassword.ValueToCompare = oBranch_Add.BranchPassword;
            }
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Branch_Add oBranch_Add = Session["branch"] as Branch_Add;
                var parameters = new { BranchPassword = txtConfirmNewPassword.Text.Trim(), Id = oBranch_Add.Id };
                DataAccess oDataAccess = new DataAccess();
                oDataAccess.ExecuteSP("sp_changebranch_password", parameters);

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Password Changed');window.location.href='../BranchLogin.aspx';", true);
            }
        }
    }
}