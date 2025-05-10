using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Employee
{
    public partial class AddCase : System.Web.UI.Page
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["emp"] == null)
            {
                Response.Redirect("../EmployeeLogin.aspx");
            }
            if (!IsPostBack)
            {
                Employee_Add oEmployee_Add = Session["emp"] as Employee_Add;
                txtLeadHandling.Text = oEmployee_Add.Name;

                txtFileLoginDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtExpectedDisbursedDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                GetData();
                if (Request.QueryString["id"] != null)
                {
                    GetDetails(Request.QueryString["id"]);
                }
            }
        }
        private void GetData()
        {
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPDynamic<Product_Add>("sp_getallproducts");
            ddlProduct.DataSource = result;
            ddlProduct.DataTextField = "ProductName";
            ddlProduct.DataValueField = "Id";
            ddlProduct.DataBind();

            ddlProfile.Items.Clear();
            ddlProfile.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlProfile.Items.Insert(1, new ListItem("Salaried", "1"));
            ddlProfile.Items.Insert(2, new ListItem("Self Employed", "2"));
            ddlProfile.Items.Insert(3, new ListItem("Business Man", "3"));
            ddlProfile.Items.Insert(4, new ListItem("Pensioner", "4"));
            ddlProfile.Items.Insert(5, new ListItem("Agriculturist", "5"));
        }
        private void GetDetails(string Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", Id);
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySingleOrDefaultSPDynamic<Case_Add>("sp_getcasesforemp_bycaseid", parameters);
            if (result != null)
            {
                txtName.Text = result.Name;
                txtMobileNo.Text = result.MobileNo;
                txtCity.Text = result.City;
                txtAddress.Text = result.Address;
                ddlProduct.SelectedValue = "" + result.ProductReq;
                txtAmount.Text = "" + result.AmountReq;
                //txtProfile.Text = result.CustomerProfile;
                try
                {
                    ddlProfile.Items.FindByText(result.CustomerProfile).Selected = true;
                }
                catch (Exception ex)
                {
                    ddlProfile.Items.Insert(6, new ListItem(result.CustomerProfile, "6"));

                    ddlProfile.Items.FindByText(result.CustomerProfile).Selected = true;

                    //var errorLogger = new Log("ErrorLog.txt");
                    //errorLogger.LogError(ex);
                }
                txtMonthlyIncome.Text = result.MonthlyIncome;
                txtRemarks.Text = result.ext1;

                txtBankName.Text = result.BankName;
                txtBankEmpName.Text = result.BankEmpName;
                txtBankEmpContact.Text = result.BankEmpContactNo;
                txtLeadHandling.Text = result.LeadHandling;
                txtLeadGenerated.Text = result.LeadGenerated;
                txtLeadGeneratedContactNo.Text = result.LeadGenContactNo;
                try
                {
                    txtFileLoginDate.Text = Convert.ToDateTime(result.FileLogInDate).ToString("yyyy-MM-dd");
                    txtExpectedDisbursedDate.Text = Convert.ToDateTime(result.ExpectedDisbursedDate).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {
                    var errorLogger = new Log("ErrorLog.txt");
                    errorLogger.LogError(ex);
                }
            }
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

                    if (txtMobileNo.Text.Length < 10)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Valid Mobile No.');", true);
                        return;
                    }

                    Employee_Add oEmployee_Add = Session["emp"] as Employee_Add;
                    if (Request.QueryString["id"] == null)
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("Name", txtName.Text);
                        parameters.Add("MobileNo", txtMobileNo.Text);
                        parameters.Add("City", txtCity.Text);
                        parameters.Add("Address", txtAddress.Text);
                        parameters.Add("ProductReq", ddlProduct.SelectedValue);
                        parameters.Add("AmountReq", txtAmount.Text);
                        parameters.Add("CustomerProfile", ddlProfile.SelectedItem.Text);
                        parameters.Add("MonthlyIncome", txtMonthlyIncome.Text);
                        parameters.Add("ConnectorId", 0);
                        parameters.Add("EmpId", oEmployee_Add.Id);
                        parameters.Add("BranchId", oEmployee_Add.BranchId);
                        parameters.Add("ext1", txtRemarks.Text);

                        parameters.Add("BankName", txtBankName.Text);
                        parameters.Add("BankEmpName", txtBankEmpName.Text);
                        parameters.Add("BankEmpContactNo", txtBankEmpContact.Text);
                        parameters.Add("LeadHandling", txtLeadHandling.Text);
                        parameters.Add("LeadGenerated", txtLeadGenerated.Text);
                        parameters.Add("LeadGenContactNo", txtLeadGeneratedContactNo.Text);
                        parameters.Add("FileLogInDate", txtFileLoginDate.Text);
                        parameters.Add("ExpectedDisbursedDate", txtExpectedDisbursedDate.Text);

                        DataAccess oDataAccess = new DataAccess();
                        var res = oDataAccess.QuerySingleOrDefaultSPDynamic<int>("sp_insert_case_byemployee", parameters);

                        if (res != 0)
                        {
                            parameters = new DynamicParameters();
                            parameters.Add("p_CaseId", res);
                            parameters.Add("p_EmployeeId", oEmployee_Add.Id);
                            parameters.Add("p_CreatedOn", indianTime);

                            oDataAccess.ExecuteSPDynamic("sp_insert_empcasehistory", parameters);
                        }

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added');window.location.href='AddCase.aspx';", true);
                    }
                    else
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("Name", txtName.Text);
                        parameters.Add("MobileNo", txtMobileNo.Text);
                        parameters.Add("City", txtCity.Text);
                        parameters.Add("Address", txtAddress.Text);
                        parameters.Add("ProductReq", ddlProduct.SelectedValue);
                        parameters.Add("AmountReq", txtAmount.Text);
                        parameters.Add("CustomerProfile", ddlProfile.SelectedItem.Text);
                        parameters.Add("MonthlyIncome", txtMonthlyIncome.Text);
                        parameters.Add("Id", Request.QueryString["id"]);
                        parameters.Add("ext1", txtRemarks.Text);

                        parameters.Add("BankName", txtBankName.Text);
                        parameters.Add("BankEmpName", txtBankEmpName.Text);
                        parameters.Add("BankEmpContactNo", txtBankEmpContact.Text);
                        parameters.Add("LeadHandling", txtLeadHandling.Text);
                        parameters.Add("LeadGenerated", txtLeadGenerated.Text);
                        parameters.Add("LeadGenContactNo", txtLeadGeneratedContactNo.Text);
                        parameters.Add("FileLogInDate", txtFileLoginDate.Text);
                        parameters.Add("ExpectedDisbursedDate", txtExpectedDisbursedDate.Text);

                        DataAccess oDataAccess = new DataAccess();
                        oDataAccess.ExecuteSPDynamic("sp_update_case_byemployee", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated');window.location.href='ShowCases.aspx';", true);
                    }
                }
                catch (Exception ex)
                {
                    var errorLogger = new Log("ErrorLog.txt");
                    errorLogger.LogError(ex);
                    if (ex.Message.Contains("Duplicate"))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Mobile No. Already Exists');", true);
                    }
                }
            }
        }
    }
}