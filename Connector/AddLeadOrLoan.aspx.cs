using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Connector
{
    public partial class AddLeadOrLoan1 : System.Web.UI.Page
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cnt"] == null)
            {
                Response.Redirect("../ConnectorLogin.aspx");
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
        private void GetCustomerData()
        {
            ddlType.Items.Clear();
            ddlType.Items.Insert(0, new ListItem("Lead", "lead"));
            ddlType.Items.Insert(1, new ListItem("Loan", "loan"));


            var result = oDataAccess.QuerySPDynamic<Product_Add>("sp_getallproducts");
            ddlProduct.DataSource = result;
            ddlProduct.DataTextField = "ProductName";
            ddlProduct.DataValueField = "Id";
            ddlProduct.DataBind();

            Connector_Add oConnector_Add = Session["cnt"] as Connector_Add;

            var parameters = new DynamicParameters();
            parameters.Add("p_CustomerId", oConnector_Add.Id);
            parameters.Add("p_CustomerType", "Connector");

            var leads = oDataAccess.QuerySPListDynamic<LoanModel>("sp_getconnector_leads", parameters);

            GridAllCases.DataSource = leads;
            GridAllCases.DataBind();

            if (GridAllCases.Rows.Count > 0)
            {
                GridAllCases.UseAccessibleHeader = true;
                GridAllCases.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridAllCases.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void GetLoanData()
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_Id", Request.QueryString["id"]);
            parameters.Add("p_Type", Request.QueryString["type"]);

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
                ddlType.Items.FindByValue(res.Type).Selected = true;
            }
        }
        protected void ShowSweetAlert()
        {
            // Execute JavaScript code to show the SweetAlert and redirect after it is dismissed
            string script = @"
        Swal.fire({
            title: 'Success!',
            text: 'Saved',
            icon: 'success',
        }).then((result) => {
            if (result.isConfirmed || result.isDismissed) {
                window.location.href = 'AddLeadOrLoan.aspx';
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
                window.location.href = 'AddLeadOrLoan.aspx';
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
                    Connector_Add oConnector_Add = Session["cnt"] as Connector_Add;

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
                        parameters.Add("p_CustomerId", oConnector_Add.Id);
                        parameters.Add("p_CreatedOn", indianTime);
                        parameters.Add("p_ProductId", ddlProduct.SelectedValue);
                        parameters.Add("p_BranchId", oConnector_Add.BranchId);
                        parameters.Add("p_Type", ddlType.SelectedValue);
                        parameters.Add("p_CustomerType", "Connector");

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

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            string[] commandArgs = button.CommandArgument.ToString().Split(',');

            Response.Redirect($"AddLeadOrLoan.aspx?id={commandArgs[0]}&type={commandArgs[1]}");
        }
    }
}