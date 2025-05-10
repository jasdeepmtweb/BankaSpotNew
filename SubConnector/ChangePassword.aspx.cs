using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI;

namespace BankaSpotNew.SubConnector
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["scon"] == null)
            {
                Response.Redirect("../SubconnectorLogin.aspx");
            }
            if (!IsPostBack)
            {
                CustomerModel oCustomerModel = Session["scon"] as CustomerModel;
                cmpOldPassword.ValueToCompare = oCustomerModel.Password;
            }
        }
        protected void ShowSweetAlert()
        {
            // Execute JavaScript code to show the SweetAlert and redirect after it is dismissed
            string script = @"
        Swal.fire({
            title: 'Success!',
            text: 'Password Changed.Please Login Again',
            icon: 'success',
        }).then((result) => {
            if (result.isConfirmed || result.isDismissed) {
                window.location.href = '../SubconnectorLogin.aspx';
            }
        });
    ";

            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "showSweetAlert", script, true);
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                CustomerModel oCustomerModel = Session["scon"] as CustomerModel;

                var parameters = new DynamicParameters();
                parameters.Add("p_Password", txtConfirmNewPassword.Text.Trim());
                parameters.Add("p_Id", oCustomerModel.Id);

                oDataAccess.ExecuteSPDynamic("sp_changecustomer_password", parameters);

                Session.Remove("scon");

                ShowSweetAlert();
            }
        }
    }
}