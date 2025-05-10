using BankaSpotNew.App_Code;
using Dapper;
using System;

namespace BankaSpotNew.Employee
{
    public partial class EditCase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["emp"] == null)
            {
                Response.Redirect("../EmployeeLogin.aspx");
            }
            if (!IsPostBack)
            {
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
        }
        private void GetDetails(string Id)
        {
            Employee_Add oEmployee_Add = Session["emp"] as Employee_Add;

            //if (Request.QueryString["typ"] == null)
            //{
            var parameters = new DynamicParameters();
            parameters.Add("Id", Id);
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySingleOrDefaultSPDynamic<Case_Add>("sp_getcaseby_id", parameters);
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
                //txtRemarks.Text = result.ext1;

                txtBankName.Text = result.BankName;
                txtBankEmpName.Text = result.BankEmpName;
                txtBankEmpContact.Text = result.BankEmpContactNo;
                // txtLeadHandling.Text = result.LeadHandling;
                txtLeadHandling.Text = oEmployee_Add.Name;

                //txtLeadGenerated.Text = result.LeadGenerated;
                //txtLeadGeneratedContactNo.Text = result.LeadGenContactNo;

                if (result.ConnectorId != 0)
                {
                    parameters = new DynamicParameters();
                    parameters.Add("Id", result.ConnectorId);
                    var connector = oDataAccess.QuerySingleOrDefaultSPDynamic<Connector_Add>("sp_getconnectorby_id", parameters);

                    txtLeadGenerated.Text = connector.Name;
                    txtLeadGeneratedContactNo.Text = connector.MobileNo;
                }
                if (result.ext3 != null || !result.ext3.ToString().Equals("0"))
                {
                    parameters = new DynamicParameters();
                    parameters.Add("p_Id", result.ext3);
                    var freelancer = oDataAccess.QuerySingleOrDefaultSPDynamic<Freelancer_Add>("sp_getfreelancerby_id", parameters);

                    if (freelancer != null)
                    {
                        txtLeadGenerated.Text = freelancer.Name;
                        txtLeadGeneratedContactNo.Text = freelancer.MobileNo;
                    }
                }
                if (result.ext4 != null && !result.ext4.ToString().Equals("") && !result.ext4.ToString().Equals("0"))
                {
                    parameters = new DynamicParameters();
                    parameters.Add("p_Id", result.ext4);
                    var markEmployee = oDataAccess.QuerySingleOrDefaultSPDynamic<Marketing_Employee_Add>("sp_getmarketingempby_id", parameters);
                    if (markEmployee != null)
                    {
                        txtMarketingEmployee.Text = markEmployee.Name;
                    }
                }
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
            //}
            //else
            //{
            //    var parameters = new DynamicParameters();
            //    parameters.Add("Id", Id);
            //    DataAccess oDataAccess = new DataAccess();
            //    var result = oDataAccess.QuerySingleOrDefaultSPDynamic<Case_Add>("sp_getcase_byidfor_freelancer", parameters);
            //    if (result != null)
            //    {
            //        txtName.Text = result.Name;
            //        txtMobileNo.Text = result.MobileNo;
            //        txtCity.Text = result.City;
            //        txtAddress.Text = result.Address;
            //        ddlProduct.SelectedValue = "" + result.ProductReq;
            //        txtAmount.Text = "" + result.AmountReq;
            //        txtProfile.Text = result.CustomerProfile;
            //        txtMonthlyIncome.Text = result.MonthlyIncome;
            //        //txtRemarks.Text = result.ext1;

            //        txtBankName.Text = result.BankName;
            //        txtBankEmpName.Text = result.BankEmpName;
            //        txtBankEmpContact.Text = result.BankEmpContactNo;
            //        txtLeadHandling.Text = result.LeadHandling;
            //        //txtLeadHandling.Text = oEmployee_Add.Name;

            //        //txtLeadGenerated.Text = result.LeadGenerated;
            //        //txtLeadGeneratedContactNo.Text = result.LeadGenContactNo;
            //        txtLeadGenerated.Text = result.ConnectorName;
            //        txtLeadGeneratedContactNo.Text = result.ConnectorMobileNo;
            //        try
            //        {
            //            txtFileLoginDate.Text = Convert.ToDateTime(result.FileLogInDate).ToString("yyyy-MM-dd");
            //            txtExpectedDisbursedDate.Text = Convert.ToDateTime(result.ExpectedDisbursedDate).ToString("yyyy-MM-dd");
            //        }
            //        catch (Exception ex)
            //        {
            //            var errorLogger = new Log("ErrorLog.txt");
            //            errorLogger.LogError(ex);
            //        }
            //    }
            //}


        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (txtMobileNo.Text.Length < 10)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Valid Mobile No.!!');", true);
                        return;
                    }
                    if (txtBankEmpContact.Text.Length < 10)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Valid Mobile No.!!');", true);
                        return;
                    }
                    if (txtLeadGeneratedContactNo.Text.Length < 10)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Valid Mobile No.!!');", true);
                        return;
                    }

                    if (Request.QueryString["id"] != null)
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
                        //parameters.Add("ext1", txtRemarks.Text);

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

                        if (Request.QueryString["pgtyp"] != null)
                        {
                            if (Request.QueryString["pgtyp"].ToString().Equals("1"))
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added');window.location.href='ShowCasesFromConnectors.aspx';", true);
                            }
                            else if (Request.QueryString["pgtyp"].ToString().Equals("2"))
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added');window.location.href='CasesFromFreelancer.aspx';", true);
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added');window.location.href='ShowCases.aspx';", true);
                            }
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated');window.location.href='ShowCasesFromConnectors.aspx';", true);
                        }
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