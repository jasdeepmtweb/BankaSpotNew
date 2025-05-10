using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI;

namespace BankaSpotNew.Customer
{
    public partial class BecomeLoanAdvisor : System.Web.UI.Page
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cust"] == null)
            {
                Response.Redirect("../CustomerLogin.aspx");
            }
            if (!IsPostBack)
            {
                GetCustomerData();
            }
        }
        private void GetCustomerData()
        {
            CustomerModel oCustomerModel = Session["cust"] as CustomerModel;

            var parameters = new DynamicParameters();
            parameters.Add("p_Id", oCustomerModel.Id);
            parameters.Add("p_Status", 1);

            var res = oDataAccess.QuerySingleOrDefaultSPDynamic<CustomerModel>("sp_getsingle_customerbyid", parameters);

            if (res != null)
            {
                txtCity.Text = res.City;
                txtMobileNo.Text = res.CustomerMobileNo;
                txtName.Text = res.CustomerName;
            }
        }
        protected void ShowSweetAlert()
        {
            // Execute JavaScript code to show the SweetAlert and redirect after it is dismissed
            string script = @"
        Swal.fire({
            title: 'Success!',
            text: 'Added',
            icon: 'success',
        }).then((result) => {
            if (result.isConfirmed || result.isDismissed) {
                window.location.href = 'BecomeLoanAdvisor.aspx';
            }
        });
    ";

            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "showSweetAlert", script, true);
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            if (Page.IsValid)
            {
                try
                {
                    CustomerModel oCustomerModel = Session["cust"] as CustomerModel;

                    var parameters = new DynamicParameters();
                    parameters.Add("p_Name", txtName.Text);
                    parameters.Add("p_MobileNo", txtMobileNo.Text);
                    parameters.Add("p_Qualification", ddlQualification.SelectedValue);
                    parameters.Add("p_CurrentProfession", txtCurrentProfession.Text);
                    parameters.Add("p_City", txtCity.Text);
                    parameters.Add("p_CustomerId", oCustomerModel.Id);
                    parameters.Add("p_CreatedOn", indianTime);

                    oDataAccess.ExecuteSPDynamic("sp_insert_loanadvisor", parameters);

                    parameters = new DynamicParameters();
                    parameters.Add("p_IsLoanAgent", 1);
                    parameters.Add("p_Id", oCustomerModel.Id);

                    oDataAccess.ExecuteSPDynamic("sp_update_loanadv_status", parameters);

                    ShowSweetAlert();
                }
                catch (Exception ex)
                {
                    var errorLogger = new Log("ErrorLog.txt");
                    errorLogger.LogError(ex);

                    if (ex.Message.Contains("Duplicate"))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "showSweetAlert", "Swal.fire('Error!', 'Mobile No. Already Exists Or Already Loan Advisor!!', 'warning');", true);
                    }
                }
            }
        }
    }
}