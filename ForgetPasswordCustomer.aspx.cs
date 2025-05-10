using System;
using System.Web.UI;
using BankaSpotNew.App_Code;
using Dapper;

namespace BankaSpotNew
{
    public partial class ForgetPasswordCustomer : System.Web.UI.Page
    {
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnForgetPassword_Click(object sender, EventArgs e)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_CustomerMobileNo", txtMobileNo.Text.Trim());
            parameters.Add("p_Type", "Customer");
            parameters.Add("p_Status", 1);

            var res = oDataAccess.QuerySingleOrDefaultSPDynamic<CustomerModel>("sp_getcustomerby_mobileno", parameters);

            if (res != null)
            {
                String msg = $"Dear User, Your Login Id- {res.CustomerMobileNo} and Password: {res.Password}-VOWEL";

                SendMessage.Send_Msg(txtMobileNo.Text.Trim(), msg);

                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "showSweetAlert", "Swal.fire('Success!', 'Password Sent to your Mobile No.', 'success');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "showSweetAlert", "Swal.fire('Error!', 'Invalid Mobile No.', 'warning');", true);
            }
        }
    }
}