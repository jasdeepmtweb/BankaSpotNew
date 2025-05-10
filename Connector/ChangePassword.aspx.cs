using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI;

namespace BankaSpotNew.Connector
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cnt"] == null)
            {
                Response.Redirect("../ConnectorLogin.aspx");
            }
            if (!IsPostBack)
            {
                Connector_Add oConnector_Add = Session["cnt"] as Connector_Add;
                cmpOldPassword.ValueToCompare = oConnector_Add.Password;
            }
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Connector_Add oConnector_Add = Session["cnt"] as Connector_Add;
                var parameters = new DynamicParameters();
                parameters.Add("Id", oConnector_Add.Id);
                parameters.Add("Password", txtConfirmNewPassword.Text.Trim());
                DataAccess oDataAccess = new DataAccess();
                oDataAccess.ExecuteSPDynamic("sp_changecon_password", parameters);

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Password Changed');window.location.href='../ConnectorLogin.aspx';", true);
            }
        }
    }
}