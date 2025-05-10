using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI;

namespace BankaSpotNew.Connector
{
    public partial class AddSubconnector : System.Web.UI.Page
    {
        DataAccess oDataAccess = new DataAccess();
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cnt"] == null)
            {
                Response.Redirect("../ConnectorLogin.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    GetCustomerData();
                }
            }
        }
        private void GetCustomerData()
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_Id", Request.QueryString["id"]);
            parameters.Add("p_Status", 1);

            var res = oDataAccess.QuerySingleOrDefaultSPDynamic<CustomerModel>("sp_getsingle_customerbyid", parameters);

            if (res != null)
            {
                txtAddress.Text = res.Address;
                txtCity.Text = res.City;
                txtEmailId.Text = res.EmailId;
                txtMobileNo.Text = res.CustomerMobileNo;
                txtName.Text = res.CustomerName;
                txtPassword.Text = res.Password;

                txtPassword.Enabled = false;
            }
        }
        protected void ShowSweetAlert()
        {
            // Execute JavaScript code to show the SweetAlert and redirect after it is dismissed
            string script = @"
        Swal.fire({
            title: 'Success!',
            text: 'Successfully Registered',
            icon: 'success',
        }).then((result) => {
            if (result.isConfirmed || result.isDismissed) {
                window.location.href = 'AddSubconnector.aspx';
            }
        });
    ";

            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "showSweetAlert", script, true);
        }
        protected void ShowUpdateSweetAlert()
        {
            // Execute JavaScript code to show the SweetAlert and redirect after it is dismissed
            string script = @"
        Swal.fire({
            title: 'Success!',
            text: 'Successfully Updated',
            icon: 'success',
        }).then((result) => {
            if (result.isConfirmed || result.isDismissed) {
                window.location.href = 'ShowSubconnectors.aspx';
            }
        });
    ";

            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "showSweetAlert", script, true);
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            Connector_Add oConnector_Add = Session["cnt"] as Connector_Add;
            try
            {
                if (Request.QueryString["id"] == null)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("p_CustomerName", txtName.Text);
                    parameters.Add("p_CustomerMobileNo", txtMobileNo.Text);
                    parameters.Add("p_City", txtCity.Text);
                    parameters.Add("p_Address", txtAddress.Text);
                    parameters.Add("p_BranchId", oConnector_Add.BranchId);
                    parameters.Add("p_CreatedOn", indianTime);
                    parameters.Add("p_EmailId", txtEmailId.Text);
                    parameters.Add("p_IsLoanAgent", 0);
                    parameters.Add("p_Status", 1);
                    parameters.Add("p_Password", txtPassword.Text);
                    parameters.Add("p_ReferId", oConnector_Add.Id);
                    parameters.Add("p_ReferIdType", "Connector");
                    parameters.Add("p_Type", "SC");

                    oDataAccess.ExecuteSPDynamic("sp_insert_customer", parameters);

                    ShowSweetAlert();
                }
                else
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("p_CustomerName", txtName.Text);
                    parameters.Add("p_CustomerMobileNo", txtMobileNo.Text);
                    parameters.Add("p_City", txtCity.Text);
                    parameters.Add("p_Address", txtAddress.Text);
                    parameters.Add("p_BranchId", oConnector_Add.BranchId);
                    parameters.Add("p_EmailId", txtEmailId.Text);
                    parameters.Add("p_Id", Request.QueryString["id"]);

                    oDataAccess.ExecuteSPDynamic("sp_update_customer", parameters);

                    ShowUpdateSweetAlert();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "showSweetAlert", "Swal.fire('Error!', 'Mobile No. Already Exists!', 'warning');", true);
                }
                var errorLogger = new Log("ErrorLog.txt");
                errorLogger.LogError(ex);
            }
        }
    }
}