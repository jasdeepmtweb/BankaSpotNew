using BankaSpotNew.App_Code;
using Dapper;
using System;

namespace BankaSpotNew.Employee
{
    public partial class UpdateProfile : System.Web.UI.Page
    {
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["emp"] == null)
            {
                Response.Redirect("../EmployeeLogin.aspx");
            }
            if (!IsPostBack)
            {
                GetEmployeeData();
            }
        }

        private void GetEmployeeData()
        {
            Employee_Add oEmployee_Add = Session["emp"] as Employee_Add;

            var parameters = new DynamicParameters();
            parameters.Add("Id", oEmployee_Add.Id);

            var emp = oDataAccess.QuerySingleOrDefaultSPDynamic<Employee_Add>("sp_getemployeeby_id", parameters);
            if (emp != null)
            {
                txtAccountNo.Text = emp.AccountNo;
                txtAddress.Text = emp.Address;
                txtBankBranchAddress.Text = emp.BankBranchAddress;
                txtBankName.Text = emp.BankName;
                txtDateOfJoining.Text = emp.DateOfJoining.ToString("yyyy-MM-dd");
                txtEmailId.Text = emp.EmailId;
                txtEmpIdNo.Text = emp.EmpId;
                txtIFSCCode.Text = emp.IFSCCode;
                txtLocation.Text = emp.EmpLocation;
                txtMonthTarget.Text = emp.MonthTarget;
                txtName.Text = emp.Name;
                txtMobileNo.Text = emp.MobileNo;
                txtPassword.Text = emp.EmpPassword;
                txtProIncentivePercentage.Text = "" + emp.ProIncentivePercentage;
                txtDesignation.Text = emp.ext2;
                txtDateOfAnniversary.Text = emp.ext3;
                txtDateOfBirth.Text = emp.ext4;

                txtPassword.Enabled = false;
                txtDateOfJoining.Enabled = false;
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
                    Employee_Add oEmployee_Add = Session["emp"] as Employee_Add;
                    var parameters = new DynamicParameters();
                    parameters.Add("EmpId", txtEmpIdNo.Text);
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
                    parameters.Add("Id", oEmployee_Add.Id);

                    oDataAccess.ExecuteSPDynamic("sp_update_employee", parameters);

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated');window.location.href='UpdateProfile.aspx';", true);
                }
                catch (Exception ex)
                {
                    var errorLogger = new Log("ErrorLog.txt");
                    errorLogger.LogError(ex);

                    if (ex.Message.Contains("Duplicate"))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Mobile No. Already Exists!!');", true);
                    }
                }
            }
        }
    }
}