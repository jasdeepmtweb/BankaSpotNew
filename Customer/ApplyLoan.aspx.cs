using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI;

namespace BankaSpotNew.Customer
{
    public partial class ApplyLoan : System.Web.UI.Page
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
                if (Request.QueryString["id"] != null)
                {
                    GetLoanData();
                }
            }
        }

        private void GetLoanData()
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_Id", Request.QueryString["id"]);
            parameters.Add("p_Type", "loan");

            var res = oDataAccess.QuerySingleOrDefaultSPDynamic<LoanModel>("sp_getsingleloan", parameters);

            if (res != null)
            {
                txtAmountRequired.Text = res.AmountReq.ToString();
                txtCity.Text = res.City;
                txtMobileNo.Text = res.MobileNo;
                txtMonthlyIncome.Text = res.MonthlyIncome;
                txtName.Text = res.Name;
                txtProfile.Text = res.Profile;
                ddlProduct.SelectedValue = res.ProductId.ToString();
            }
        }

        private void GetCustomerData()
        {
            //CustomerModel oCustomerModel = Session["cust"] as CustomerModel;

            //var parameters = new DynamicParameters();
            //parameters.Add("p_Id", oCustomerModel.Id);
            //parameters.Add("p_Status", 1);

            //var res = oDataAccess.QuerySingleOrDefaultSPDynamic<CustomerModel>("sp_getsingle_customerbyid", parameters);

            //if (res != null)
            //{
            //    txtCity.Text = res.City;
            //    txtMobileNo.Text = res.CustomerMobileNo;
            //    txtName.Text = res.CustomerName;
            //}

            var result = oDataAccess.QuerySPDynamic<Product_Add>("sp_getallproducts");
            ddlProduct.DataSource = result;
            ddlProduct.DataTextField = "ProductName";
            ddlProduct.DataValueField = "Id";
            ddlProduct.DataBind();
        }
        protected void ShowSweetAlert()
        {
            // Execute JavaScript code to show the SweetAlert and redirect after it is dismissed
            string script = @"
        Swal.fire({
            title: 'Success!',
            text: 'Loan Applied',
            icon: 'success',
        }).then((result) => {
            if (result.isConfirmed || result.isDismissed) {
                window.location.href = 'ApplyLoan.aspx';
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
            text: 'Updated',
            icon: 'success',
        }).then((result) => {
            if (result.isConfirmed || result.isDismissed) {
                window.location.href = 'ShowAppliedLoans.aspx';
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

                    if (Request.QueryString["id"] == null)
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("p_Name", txtName.Text);
                        parameters.Add("p_MobileNo", txtMobileNo.Text);
                        parameters.Add("p_LoanReq", ddlProduct.SelectedItem.Text);
                        parameters.Add("p_AmountReq", txtAmountRequired.Text);
                        parameters.Add("p_Profile", txtProfile.Text);
                        parameters.Add("p_MonthlyIncome", txtMonthlyIncome.Text);
                        parameters.Add("p_City", txtCity.Text);
                        parameters.Add("p_CustomerId", oCustomerModel.Id);
                        parameters.Add("p_CreatedOn", indianTime);
                        parameters.Add("p_ProductId", ddlProduct.SelectedValue);
                        parameters.Add("p_BranchId", oCustomerModel.BranchId);
                        parameters.Add("p_Type", "loan");
                        parameters.Add("p_CustomerType", "Customer");

                        oDataAccess.ExecuteSPDynamic("sp_insert_loan", parameters);

                        ShowSweetAlert();
                    }
                    else
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("p_Name", txtName.Text);
                        parameters.Add("p_MobileNo", txtMobileNo.Text);
                        parameters.Add("p_LoanReq", ddlProduct.SelectedItem.Text);
                        parameters.Add("p_AmountReq", txtAmountRequired.Text);
                        parameters.Add("p_Profile", txtProfile.Text);
                        parameters.Add("p_MonthlyIncome", txtMonthlyIncome.Text);
                        parameters.Add("p_City", txtCity.Text);
                        parameters.Add("p_ProductId", ddlProduct.SelectedValue);
                        parameters.Add("p_Id", Request.QueryString["id"]);

                        oDataAccess.ExecuteSPDynamic("sp_update_loan", parameters);

                        ShowUpdateSweetAlert();
                    }
                        
                }
                catch (Exception ex)
                {
                    var errorLogger = new Log("ErrorLog.txt");
                    errorLogger.LogError(ex);
                }
            }
        }
    }
}