using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI;

namespace BankaSpotNew.Branch
{
    public partial class AddMarketingEmp : System.Web.UI.Page
    {
        DataAccess oDataAccess = new DataAccess();
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["branch"] == null)
            {
                Response.Redirect("../BranchLogin.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    GetDetails(Request.QueryString["id"]);
                }
            }
        }
        private void GetDetails(string Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_Id", Id);
            
            var result = oDataAccess.QuerySingleOrDefaultSPDynamic<Marketing_Employee_Add>("sp_getmarketingempby_id", parameters);
            if (result != null)
            {
                txtAccountNo.Text = result.AccountNo;
                txtAddress.Text = result.Address;
                txtBankBranchAddress.Text = result.BankBranchAddress;
                txtBankName.Text = result.BankName;
                txtDateOfJoining.Text = result.DateOfJoining.ToString("yyyy-MM-dd");
                txtEmailId.Text = result.EmailId;
                txtEmpIdNo.Text = result.EmpId;
                txtIFSCCode.Text = result.IFSCCode;
                txtLocation.Text = result.EmpLocation;
                txtMonthTarget.Text = result.MonthTarget;
                txtName.Text = result.Name;
                txtMobileNo.Text = result.MobileNo;
                txtPassword.Text = result.EmpPassword;
                txtProIncentivePercentage.Text = "" + result.ProIncentivePercentage;
                txtDateOfAnniversary.Text = result.ext3;
                txtDateOfBirth.Text = result.ext4;

                txtMobileNo.Enabled = false;
                txtPassword.Enabled = false;

                divMob.Visible = true;
                divPassword.Visible = true;
            }
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            if (Page.IsValid)
            {
                try
                {
                    if (txtMobileNo.Text.Length < 10)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Valid Mobile No.!!');", true);
                        return;
                    }

                    Branch_Add oBranch_Add = Session["branch"] as Branch_Add;
                    if (Request.QueryString["id"] == null)
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("p_EmpId", txtEmpIdNo.Text);
                        parameters.Add("p_Name", txtName.Text);
                        parameters.Add("p_MobileNo", txtMobileNo.Text);
                        parameters.Add("p_EmailId", txtEmailId.Text);
                        parameters.Add("p_EmpLocation", txtLocation.Text);
                        parameters.Add("p_Address", txtAddress.Text);
                        parameters.Add("p_BankName", txtBankName.Text);
                        parameters.Add("p_AccountNo", txtAccountNo.Text);
                        parameters.Add("p_IFSCCode", txtIFSCCode.Text);
                        parameters.Add("p_BankBranchAddress", txtBankBranchAddress.Text);
                        parameters.Add("p_BranchId", oBranch_Add.Id);
                        parameters.Add("p_DateOfJoining", txtDateOfJoining.Text);
                        parameters.Add("p_ProIncentivePercentage", txtProIncentivePercentage.Text);
                        parameters.Add("p_MonthTarget", txtMonthTarget.Text);
                        parameters.Add("p_EmpPassword", txtPassword.Text);
                        parameters.Add("p_CreatedOn", indianTime);
                        parameters.Add("p_ext1", "1");
                        parameters.Add("p_ext2", "-");
                        parameters.Add("p_ext3", txtDateOfAnniversary.Text);
                        parameters.Add("p_ext4", txtDateOfBirth.Text);

                        
                        oDataAccess.ExecuteSPDynamic("sp_insert_marketingemp", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added');window.location.href='AddMarketingEmp.aspx';", true);
                    }
                    else
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("p_EmpId", txtEmpIdNo.Text);
                        parameters.Add("p_Name", txtName.Text);
                        parameters.Add("p_EmailId", txtEmailId.Text);
                        parameters.Add("p_EmpLocation", txtLocation.Text);
                        parameters.Add("p_Address", txtAddress.Text);
                        parameters.Add("p_BankName", txtBankName.Text);
                        parameters.Add("p_AccountNo", txtAccountNo.Text);
                        parameters.Add("p_IFSCCode", txtIFSCCode.Text);
                        parameters.Add("p_BankBranchAddress", txtBankBranchAddress.Text);
                        parameters.Add("p_DateOfJoining", txtDateOfJoining.Text);
                        parameters.Add("p_ProIncentivePercentage", txtProIncentivePercentage.Text);
                        parameters.Add("p_MonthTarget", txtMonthTarget.Text);
                        //parameters.Add("p_ext1", "-");
                        parameters.Add("p_ext2", "-");
                        parameters.Add("p_ext3", txtDateOfAnniversary.Text);
                        parameters.Add("p_ext4", txtDateOfBirth.Text);
                        parameters.Add("p_Id", Request.QueryString["id"]);

                        
                        oDataAccess.ExecuteSPDynamic("sp_updatemarketingemp", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated');window.location.href='ShowMarketingEmp.aspx';", true);
                    }
                }
                catch (Exception ex)
                {
                    var errorLogger = new Log("ErrorLog.txt");
                    errorLogger.LogError(ex);

                    if (ex.Message.Contains("Duplicate"))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Valid Mobile No.!!');", true);
                    }
                }
            }
        }
    }
}