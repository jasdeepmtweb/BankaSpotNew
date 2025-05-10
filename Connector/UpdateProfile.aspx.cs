using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.IO;

namespace BankaSpotNew.Connector
{
    public partial class UpdateProfile : System.Web.UI.Page
    {
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cnt"] == null)
            {
                Response.Redirect("../ConnectorLogin.aspx");
            }
            if (!IsPostBack)
            {
                GetConnectorData();
            }
        }

        private void GetConnectorData()
        {
            Connector_Add oConnector_Add = Session["cnt"] as Connector_Add;

            var parameters = new DynamicParameters();
            parameters.Add("Id", oConnector_Add.Id);

            var result = oDataAccess.QuerySingleOrDefaultSPDynamic<Connector_Add>("sp_getconnectorby_id", parameters);
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

                txtMobileNo.Text = result.MobileNo;
                txtPassword.Text = result.Password;

                lblImage.Text = result.ConnectorPic;

                txtDateOfAnniversary.Text = result.DOA.ToString("yyyy-MM-dd");
                txtDateOfBirth.Text = result.DOB.ToString("yyyy-MM-dd");

                txtPassword.Enabled = false;
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string uploadPath = Server.MapPath("~/Uploads/ConnectorPics");

                    string profilePic = "";
                    Connector_Add oConnector_Add = Session["cnt"] as Connector_Add;

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

                    var parameters = new DynamicParameters();
                    parameters.Add("ConnectorId", txtConnectorIdNo.Text);
                    parameters.Add("Name", txtName.Text);
                    parameters.Add("EmailId", txtEmailId.Text);
                    parameters.Add("ConLocation", txtLocation.Text);
                    parameters.Add("Profile", txtProfile.Text);
                    parameters.Add("Address", txtAddress.Text);
                    parameters.Add("PanNo", txtPanNo.Text);
                    parameters.Add("AdharNo", txtAdharNo.Text);
                    parameters.Add("BankName", txtBankName.Text);
                    parameters.Add("AccountNo", txtAccountNo.Text);
                    parameters.Add("IFSCCode", txtIFSCCode.Text);
                    parameters.Add("BankBranchAddress", txtBankBranchAddress.Text);
                    parameters.Add("ConnectorPic", profilePic);
                    parameters.Add("DOA", txtDateOfAnniversary.Text);
                    parameters.Add("DOB", txtDateOfBirth.Text);
                    parameters.Add("Id", oConnector_Add.Id);

                    oDataAccess.ExecuteSPDynamic("sp_update_connector", parameters);

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated');window.location.href='UpdateProfile.aspx';", true);
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