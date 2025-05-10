using BankaSpotNew.App_Code;
using Dapper;
using System;

namespace BankaSpotNew.FreeLancer
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["frl"] == null)
            {
                Response.Redirect("../FreeLancerLogin.aspx");
            }
            if (!IsPostBack)
            {
                Freelancer_Add oFreelancer_Add = Session["frl"] as Freelancer_Add;
                cmpOldPassword.ValueToCompare = oFreelancer_Add.Password;
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Freelancer_Add oFreelancer_Add = Session["frl"] as Freelancer_Add;
                var parameters = new DynamicParameters();
                parameters.Add("p_Id", oFreelancer_Add.Id);
                parameters.Add("p_Password", txtConfirmNewPassword.Text.Trim());
                DataAccess oDataAccess = new DataAccess();
                oDataAccess.ExecuteSPDynamic("sp_changefreelancer_password", parameters);

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Password Changed');window.location.href='../FreeLancerLogin.aspx';", true);
            }
        }
    }
}