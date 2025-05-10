using BankaSpotNew.App_Code;
using System;

namespace BankaSpotNew.Admin
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("../BranchLogin.aspx");
            }
            if (!IsPostBack)
            {
                cmpOldPassword.ValueToCompare = GetOldPassword(Session["id"].ToString());
            }
        }

        private string GetOldPassword(string v)
        {
            string sql = "SELECT BranchPassword FROM tbbranch WHERE Id = @Id";
            var parameters = new { Id = v };
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySingleOrDefault<Branch_Add>(sql, parameters);
            return result.BranchPassword;
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string sql = "UPDATE tbbranch SET BranchPassword=@BranchPassword WHERE Id=@Id";
                var parameters = new { BranchPassword = txtConfirmNewPassword.Text.Trim(), Id = Session["id"] };
                DataAccess oDataAccess = new DataAccess();
                oDataAccess.Execute(sql, parameters);

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Password Changed');window.location.href='../BranchLogin.aspx';", true);
            }
        }
    }
}