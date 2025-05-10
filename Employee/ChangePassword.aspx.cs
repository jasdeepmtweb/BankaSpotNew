using BankaSpotNew.App_Code;
using System;

namespace BankaSpotNew.Employee
{
    public partial class ChangePassword : System.Web.UI.Page
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
                cmpOldPassword.ValueToCompare = oEmployee_Add.EmpPassword;
            }
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Employee_Add oEmployee_Add = Session["emp"] as Employee_Add;
                var parameters = new { EmpPassword = txtConfirmNewPassword.Text.Trim(), oEmployee_Add.Id };
                DataAccess oDataAccess = new DataAccess();
                oDataAccess.ExecuteSP("sp_changeemp_password", parameters);

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Password Changed');window.location.href='../EmployeeLogin.aspx';", true);
            }
        }
    }
}