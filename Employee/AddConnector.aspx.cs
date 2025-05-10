using BankaSpotNew.App_Code;
using System;

namespace BankaSpotNew.Employee
{
    public partial class AddConnector : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["emp"] == null)
            {
                Response.Redirect("../EmployeeLogin.aspx");
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
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySingleOrDefaultSP<Connector_Add>("sp_getconnectorby_id", parameters);
            if (result != null)
            {
                txtAccountNo.Text = result.AccountNo;
                txtAddress.Text = result.Address;
                txtBankBranchAddress.Text = result.BankBranchAddress;
                txtBankName.Text = result.BankName;
                txtAdharNo.Text = result.AdharNo;
                txtEmailId.Text = result.EmailId;
                txtConnectorIdNo.Text = result.ConnectorId;
                txtIFSCCode.Text = result.IFSCCode;
                txtLocation.Text = result.ConLocation;
                txtPanNo.Text = result.PanNo;
                txtName.Text = result.Name;
                txtProfile.Text = result.Profile;
                txtDateOfAnniversary.Text = result.DOA.ToString("yyyy-MM-dd");
                txtDateOfBirth.Text = result.DOB.ToString("yyyy-MM-dd");

                divMob.Visible = false;
                divPassword.Visible = false;
            }
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {

                    Employee_Add oEmployee_Add = Session["emp"] as Employee_Add;
                    if (Request.QueryString["id"] == null)
                    {
                        if (txtMobileNo.Text.Length < 10)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Valid Mobile No.');", true);
                            return;
                        }
                        var parameters = new
                        {
                            ConnectorId = txtConnectorIdNo.Text,
                            Name = txtName.Text,
                            MobileNo = txtMobileNo.Text,
                            EmailId = txtEmailId.Text,
                            ConLocation = txtLocation.Text,
                            Profile = txtProfile.Text,
                            Address = txtAddress.Text,
                            PanNo = txtPanNo.Text,
                            AdharNo = txtAdharNo.Text,
                            BankName = txtBankName.Text,
                            AccountNo = txtAccountNo.Text,
                            IFSCCode = txtIFSCCode.Text,
                            BankBranchAddress = txtBankBranchAddress.Text,
                            oEmployee_Add.BranchId,
                            EmployeeId = oEmployee_Add.Id,
                            Password = txtPassword.Text
                        };
                        DataAccess oDataAccess = new DataAccess();
                        oDataAccess.ExecuteSP("sp_insert_connector", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added');window.location.href='AddConnector.aspx';", true);
                    }
                    else
                    {
                        var parameters = new
                        {
                            ConnectorId = txtConnectorIdNo.Text,
                            Name = txtName.Text,
                            EmailId = txtEmailId.Text,
                            ConLocation = txtLocation.Text,
                            Profile = txtProfile.Text,
                            Address = txtAddress.Text,
                            PanNo = txtPanNo.Text,
                            AdharNo = txtAdharNo.Text,
                            BankName = txtBankName.Text,
                            AccountNo = txtAccountNo.Text,
                            IFSCCode = txtIFSCCode.Text,
                            BankBranchAddress = txtBankBranchAddress.Text,
                            DOA = txtDateOfAnniversary.Text,
                            DOB = txtDateOfBirth.Text,
                            Id = Request.QueryString["id"]
                        };
                        DataAccess oDataAccess = new DataAccess();
                        oDataAccess.ExecuteSP("sp_update_connector", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated');window.location.href='ShowConnector.aspx';", true);
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