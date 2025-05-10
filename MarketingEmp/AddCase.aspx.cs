using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.MarketingEmp
{
    public partial class AddCase : System.Web.UI.Page
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["memp"] == null)
            {
                Response.Redirect("../MarketingEmpLogin.aspx");
            }
            if (!IsPostBack)
            {
                DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

                Marketing_Employee_Add oMarketing_Employee_Add = Session["memp"] as Marketing_Employee_Add;
                txtLeadGenerated.Text = oMarketing_Employee_Add.Name;

                txtFileLoginDate.Text = indianTime.ToString("yyyy-MM-dd");
                txtExpectedDisbursedDate.Text = indianTime.ToString("yyyy-MM-dd");

                GetData();
                if (Request.QueryString["id"] != null)
                {
                    GetDetails(Request.QueryString["id"]);
                }
            }
        }
        private void GetData()
        {
            Marketing_Employee_Add oMarketing_Employee_Add = Session["memp"] as Marketing_Employee_Add;

            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPListDynamic<Product_Add>("sp_getallproducts");
            ddlProduct.DataSource = result;
            ddlProduct.DataTextField = "ProductName";
            ddlProduct.DataValueField = "Id";
            ddlProduct.DataBind();

            var parameters = new DynamicParameters();
            parameters.Add("BranchId", oMarketing_Employee_Add.BranchId);
            var employees = oDataAccess.QuerySPDynamic<Employee_Add>("sp_getallemployee", parameters);
            employees = employees.Where(x => x.EmployeeStatus.Equals("1"));
            ddlEmployee.DataSource = employees;
            ddlEmployee.DataTextField = "Name";
            ddlEmployee.DataValueField = "Id";
            ddlEmployee.DataBind();
            ddlEmployee.Items.Insert(0, new ListItem("---Select---", "0"));
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
                txtProfile.Text = result.CustomerProfile;
                txtMonthlyIncome.Text = result.MonthlyIncome;
                txtRemarks.Text = result.Remarks;

                txtBankName.Text = result.BankName;
                txtBankEmpName.Text = result.BankEmpName;
                txtBankEmpContact.Text = result.BankEmpContactNo;
                txtLeadHandling.Text = result.LeadHandling;
                txtLeadGenerated.Text = result.LeadGenerated;
                txtLeadGeneratedContactNo.Text = result.LeadGenContactNo;
                ddlEmployee.SelectedValue = result.EmpId.ToString();
                try
                {
                    txtFileLoginDate.Text = result.FileLogInDate.ToString("yyyy-MM-dd");
                    txtExpectedDisbursedDate.Text = result.ExpectedDisbursedDate.ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {
                    var errorLogger = new Log("ErrorLog.txt");
                    errorLogger.LogError(ex);
                }
                ddlEmployee.Enabled = false;
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

                    Marketing_Employee_Add oMarketing_Employee_Add = Session["memp"] as Marketing_Employee_Add;
                    if (Request.QueryString["id"] == null)
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("p_Name", txtName.Text);
                        parameters.Add("p_MobileNo", txtMobileNo.Text);
                        parameters.Add("p_City", txtCity.Text);
                        parameters.Add("p_Address", txtAddress.Text);
                        parameters.Add("p_ProductReq", Convert.ToInt32(ddlProduct.SelectedValue));
                        parameters.Add("p_AmountReq", Convert.ToDouble(txtAmount.Text));
                        parameters.Add("p_CustomerProfile", txtProfile.Text);
                        parameters.Add("p_MonthlyIncome", txtMonthlyIncome.Text);
                        parameters.Add("p_ConnectorId", 0);
                        parameters.Add("p_EmpId", ddlEmployee.SelectedValue);
                        parameters.Add("p_BranchId", oMarketing_Employee_Add.BranchId);
                        parameters.Add("p_CreatedOn", indianTime);
                        parameters.Add("p_Status", "-");
                        parameters.Add("p_Remarks", txtRemarks.Text);
                        parameters.Add("p_ext1", "-");
                        parameters.Add("p_BankName", txtBankName.Text);
                        parameters.Add("p_BankEmpName", txtBankEmpName.Text);
                        parameters.Add("p_BankEmpContactNo", txtBankEmpContact.Text);
                        parameters.Add("p_LeadHandling", txtLeadHandling.Text);
                        parameters.Add("p_LeadGenerated", txtLeadGenerated.Text);
                        parameters.Add("p_LeadGenContactNo", txtLeadGeneratedContactNo.Text);
                        parameters.Add("p_FileLogInDate", txtFileLoginDate.Text);
                        parameters.Add("p_ExpectedDisbursedDate", txtExpectedDisbursedDate.Text); // Assuming today's date as default
                        parameters.Add("p_ext5", 0);
                        parameters.Add("p_ext6", 0);
                        parameters.Add("p_ext2", 0);
                        parameters.Add("p_ext3", 0);
                        parameters.Add("p_ext4", oMarketing_Employee_Add.Id);


                        DataAccess oDataAccess = new DataAccess();
                        var res = oDataAccess.QuerySingleOrDefaultSPDynamic<int>("sp_insertcase_marketingemp", parameters);

                        if (res != 0)
                        {
                            parameters = new DynamicParameters();
                            parameters.Add("p_CaseId", res);
                            parameters.Add("p_EmployeeId", ddlEmployee.SelectedValue);
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
                        parameters.Add("CustomerProfile", txtProfile.Text);
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

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated');window.location.href='ShowAllCases.aspx';", true);
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

        protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLeadHandling.Text = ddlEmployee.SelectedItem.Text;
        }
    }
}