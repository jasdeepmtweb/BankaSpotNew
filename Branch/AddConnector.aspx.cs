using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.IO;
using System.Web.UI;

namespace BankaSpotNew.Branch
{
    public partial class AddConnector : System.Web.UI.Page
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
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

            var result = oDataAccess.QuerySingleOrDefaultSP<Connector_Add>("sp_getconnectorby_id", parameters);
            if (result != null)
            {
                txtAccountNo.Text = result.AccountNo;
                txtAddress.Text = result.Address;
                txtBankBranchAddress.Text = result.BankBranchAddress;
                txtBankName.Text = result.BankName;
                txtAdharNo.Text = result.AdharNo;
                txtEmailId.Text = result.EmailId;
                lblConnectorIdNo.Text = result.ConnectorId;
                txtIFSCCode.Text = result.IFSCCode;
                txtLocation.Text = result.ConLocation;
                txtPanNo.Text = result.PanNo;
                txtName.Text = result.Name;
                txtProfile.Text = result.Profile;
                lblImage.Text = result.ConnectorPic;
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
                DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                try
                {
                    string uploadPath = Server.MapPath("~/Uploads/ConnectorPics");
                    Branch_Add oBranch_Add = Session["branch"] as Branch_Add;
                    string profilePic = "";
                    if (Request.QueryString["id"] == null)
                    {
                        if (txtMobileNo.Text.Length < 10)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Valid Mobile No.');", true);
                            return;
                        }
                        if (FilePhoto.HasFile)
                        {
                            string extension = Path.GetExtension(FilePhoto.FileName);
                            if (extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) || extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) || extension.Equals(".png", StringComparison.OrdinalIgnoreCase))
                            {
                                profilePic = ImageCompressor.SaveFile(FilePhoto.FileName, FilePhoto.FileBytes, uploadPath);
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Only Image is Allowed');", true);
                                return;
                            }
                        }
                        else
                        {
                            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Select Image');", true);
                            //return;
                            profilePic = "-";
                        }
                        var parameters = new
                        {
                            ConnectorId = "-",
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
                            BranchId = oBranch_Add.Id,
                            EmployeeId = 0,
                            Password = txtPassword.Text,
                            ConnectorPic = profilePic,
                            CreatedOn = indianTime,
                            DOA = txtDateOfAnniversary.Text,
                            DOB = txtDateOfBirth.Text
                        };

                        var res = oDataAccess.QuerySingleOrDefaultSP<int>("sp_insert_connector", parameters);

                        string connectorId = $"{DateTime.Now:yy}{res:D6}";

                        var parameter = new DynamicParameters();
                        parameter.Add("ConnectorId", connectorId);
                        parameter.Add("Id", res);

                        oDataAccess.ExecuteSPDynamic("sp_update_connectorid", parameter);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added');window.location.href='AddConnector.aspx';", true);
                    }
                    else
                    {
                        if (FilePhoto.HasFile)
                        {
                            string extension = Path.GetExtension(FilePhoto.FileName);
                            if (extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) || extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) || extension.Equals(".png", StringComparison.OrdinalIgnoreCase))
                            {
                                profilePic = ImageCompressor.SaveFile(FilePhoto.FileName, FilePhoto.FileBytes, uploadPath);
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Only Image is Allowed');", true);
                                return;
                            }
                        }
                        else
                        {
                            profilePic = lblImage.Text;
                        }
                        var parameters = new
                        {
                            ConnectorId = lblConnectorIdNo.Text,
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
                            ConnectorPic = profilePic,
                            DOA = txtDateOfAnniversary.Text,
                            DOB = txtDateOfBirth.Text,
                            Id = Request.QueryString["id"]
                        };

                        oDataAccess.ExecuteSP("sp_update_connector", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated');window.location.href='ShowConnectors.aspx';", true);
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