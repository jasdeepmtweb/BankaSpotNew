using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI;

namespace BankaSpotNew.Accountant
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["acc"] == null)
            {
                Response.Redirect("../AccountantLogin.aspx");
            }
            if (!IsPostBack)
            {
                AccountantModel oAccountantModel = Session["acc"] as AccountantModel;
                cmpOldPassword.ValueToCompare = oAccountantModel.Password;
            }
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                AccountantModel oAccountantModel = Session["acc"] as AccountantModel;
                var parameters = new DynamicParameters();
                parameters.Add("p_Id", oAccountantModel.Id);
                parameters.Add("p_Password", txtConfirmNewPassword.Text.Trim());
                DataAccess oDataAccess = new DataAccess();
                oDataAccess.ExecuteSPDynamic("sp_changeacc_password", parameters);

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Password Changed');window.location.href='../AccountantLogin.aspx';", true);
            }
        }
    }
}