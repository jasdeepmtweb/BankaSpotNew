using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI;

namespace BankaSpotNew.Branch
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        DataAccess oDataAccess = new DataAccess();
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
            var parameters = new
            {
                Id
            };

            var result = oDataAccess.QuerySingleOrDefaultSP<Employee_Add>("sp_getemployeeby_id", parameters);
            if (result != null)
            {
                txtAccountNo.Text = result.AccountNo;
                txtAddress.Text = result.Address;
                txtBankBranchAddress.Text = result.BankBranchAddress;
                txtBankName.Text = result.BankName;
                txtDateOfJoining.Text = result.DateOfJoining.ToString("yyyy-MM-dd");
                txtEmailId.Text = result.EmailId;
                lblEmployeeId.Text = result.EmpId;
                txtIFSCCode.Text = result.IFSCCode;
                txtLocation.Text = result.EmpLocation;
                txtMonthTarget.Text = result.MonthTarget;
                txtName.Text = result.Name;
                txtMobileNo.Text = result.MobileNo;
                txtPassword.Text = result.EmpPassword;
                txtProIncentivePercentage.Text = "" + result.ProIncentivePercentage;
                txtDesignation.Text = result.ext2;
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
                        var parameters = new
                        {
                            EmpId = "-",
                            Name = txtName.Text,
                            MobileNo = txtMobileNo.Text,
                            EmailId = txtEmailId.Text,
                            EmpLocation = txtLocation.Text,
                            Address = txtAddress.Text,
                            BankName = txtBankName.Text,
                            AccountNo = txtAccountNo.Text,
                            IFSCCode = txtIFSCCode.Text,
                            BankBranchAddress = txtBankBranchAddress.Text,
                            BranchId = oBranch_Add.Id,
                            DateOfJoining = txtDateOfJoining.Text,
                            ProIncentivePercentage = txtProIncentivePercentage.Text,
                            MonthTarget = txtMonthTarget.Text,
                            EmpPassword = txtPassword.Text,
                            ext2 = txtDesignation.Text,
                            ext3 = txtDateOfAnniversary.Text,
                            ext4 = txtDateOfBirth.Text
                        };

                        var res = oDataAccess.QuerySingleOrDefaultSP<int>("sp_insert_employee", parameters);

                        string empId = $"{DateTime.Now:yy}{res:D6}";

                        var parameter = new DynamicParameters();
                        parameter.Add("p_EmpId", empId);
                        parameter.Add("p_Id", res);

                        oDataAccess.ExecuteSPDynamic("sp_update_empid", parameter);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added');window.location.href='AddEmployee.aspx';", true);
                    }
                    else
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("EmpId", lblEmployeeId.Text);
                        parameters.Add("Name", txtName.Text);
                        parameters.Add("EmailId", txtEmailId.Text);
                        parameters.Add("EmpLocation", txtLocation.Text);
                        parameters.Add("Address", txtAddress.Text);
                        parameters.Add("BankName", txtBankName.Text);
                        parameters.Add("AccountNo", txtAccountNo.Text);
                        parameters.Add("IFSCCode", txtIFSCCode.Text);
                        parameters.Add("BankBranchAddress", txtBankBranchAddress.Text);
                        parameters.Add("DateOfJoining", txtDateOfJoining.Text);
                        parameters.Add("ProIncentivePercentage", txtProIncentivePercentage.Text);
                        parameters.Add("MonthTarget", txtMonthTarget.Text);
                        parameters.Add("ext2", txtDesignation.Text);
                        parameters.Add("ext3", txtDateOfAnniversary.Text);
                        parameters.Add("ext4", txtDateOfBirth.Text);
                        parameters.Add("Id", Request.QueryString["id"]);


                        oDataAccess.ExecuteSPDynamic("sp_update_employee", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated');window.location.href='ShowEmployee.aspx';", true);
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