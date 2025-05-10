using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.IO;
using System.Web.UI;

namespace BankaSpotNew.Branch
{
    public partial class AddFreelancer : System.Web.UI.Page
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
            var parameters = new DynamicParameters();
            parameters.Add("p_Id", Id);

            var result = oDataAccess.QuerySingleOrDefaultSPDynamic<Freelancer_Add>("sp_getfreelancerby_id", parameters);
            if (result != null)
            {
                txtAccountNo.Text = result.AccountNo;
                txtAddress.Text = result.Address;
                txtBankBranchAddress.Text = result.BankBranchAddress;
                txtBankName.Text = result.BankName;
                txtAdharNo.Text = result.AdharNo;
                txtEmailId.Text = result.EmailId;
                lblFreelancerIdNo.Text = result.FreelancerId;
                txtIFSCCode.Text = result.IFSCCode;
                txtLocation.Text = result.FreelancerLocation;
                txtPanNo.Text = result.PanNo;
                txtName.Text = result.Name;
                txtProfile.Text = result.Profile;
                txtMobileNo.Text = result.MobileNo;
                txtPassword.Text = result.Password;
                txtDateOfAnniversary.Text = result.DOA.ToString("yyyy-MM-dd");
                txtDateOfBirth.Text = result.DOB.ToString("yyyy-MM-dd");

                txtMobileNo.Enabled = false;
                txtPassword.Enabled = false;

                divMob.Visible = true;
                divPassword.Visible = true;

                lblImage.Text = result.FreelancerPic;
            }
        }
        protected void ShowAddedSweetAlert()
        {
            // Execute JavaScript code to show the SweetAlert and redirect after it is dismissed
            string script = @"
        Swal.fire({
            title: 'Success!',
            text: 'Added',
            icon: 'success',
        }).then((result) => {
            if (result.isConfirmed || result.isDismissed) {
                window.location.href = 'AddFreelancer.aspx';
            }
        });
    ";

            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "showSweetAlert", script, true);
        }
        protected void ShowUpdatedSweetAlert()
        {
            // Execute JavaScript code to show the SweetAlert and redirect after it is dismissed
            string script = @"
        Swal.fire({
            title: 'Success!',
            text: 'Updated',
            icon: 'success',
        }).then((result) => {
            if (result.isConfirmed || result.isDismissed) {
                window.location.href = 'ShowFreelancer.aspx';
            }
        });
    ";

            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "showSweetAlert", script, true);
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string uploadPath = Server.MapPath("~/Uploads/FreelancerPics");

                string profilePic = "";
                DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                try
                {
                    if (txtMobileNo.Text.Length < 10)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "showSweetAlert", "Swal.fire('Error!', 'Enter Valid Mobile No.', 'error');", true);
                        return;
                    }

                    Branch_Add oBranch_Add = Session["branch"] as Branch_Add;
                    if (Request.QueryString["id"] == null)
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
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Select Image');", true);
                            return;
                        }

                        var parameters = new DynamicParameters();
                        parameters.Add("p_FreelancerId", "-");
                        parameters.Add("p_Name", txtName.Text);
                        parameters.Add("p_MobileNo", txtMobileNo.Text);
                        parameters.Add("p_EmailId", txtEmailId.Text);
                        parameters.Add("p_FreelancerLocation", txtLocation.Text);
                        parameters.Add("p_Profile", txtProfile.Text);
                        parameters.Add("p_Address", txtAddress.Text);
                        parameters.Add("p_PanNo", txtPanNo.Text);
                        parameters.Add("p_AdharNo", txtAdharNo.Text);
                        parameters.Add("p_BankName", txtBankName.Text);
                        parameters.Add("p_AccountNo", txtAccountNo.Text);
                        parameters.Add("p_IFSCCode", txtIFSCCode.Text);
                        parameters.Add("p_BankBranchAddress", txtBankBranchAddress.Text);
                        parameters.Add("p_BranchId", oBranch_Add.Id);
                        parameters.Add("p_EmployeeId", 0);
                        parameters.Add("p_CreatedOn", indianTime.ToString("yyyy-MM-dd hh:mm:ss"));

                        parameters.Add("p_Password", txtPassword.Text);
                        parameters.Add("p_ext1", "-");
                        parameters.Add("p_ext2", "-");
                        parameters.Add("p_ext3", "-");
                        parameters.Add("p_ext4", "1");
                        parameters.Add("p_FreelancerPic", profilePic);
                        parameters.Add("p_DOA", txtDateOfAnniversary.Text);
                        parameters.Add("p_DOB", txtDateOfBirth.Text);

                        var res = oDataAccess.QuerySingleOrDefaultSPDynamic<int>("sp_insert_freelancer", parameters);

                        string freelancerId = $"{DateTime.Now:yy}{res:D6}";

                        var parameter = new DynamicParameters();
                        parameter.Add("p_FreelancerId", freelancerId);
                        parameter.Add("p_Id", res);

                        oDataAccess.ExecuteSPDynamic("sp_update_freelancerid", parameter);

                        ShowAddedSweetAlert();
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

                        var parameters = new DynamicParameters();
                        parameters.Add("p_FreelancerId", lblFreelancerIdNo.Text);
                        parameters.Add("p_Name", txtName.Text);

                        parameters.Add("p_EmailId", txtEmailId.Text);
                        parameters.Add("p_FreelancerLocation", txtLocation.Text);
                        parameters.Add("p_Profile", txtProfile.Text);
                        parameters.Add("p_Address", txtAddress.Text);
                        parameters.Add("p_PanNo", txtPanNo.Text);
                        parameters.Add("p_AdharNo", txtAdharNo.Text);
                        parameters.Add("p_BankName", txtBankName.Text);
                        parameters.Add("p_AccountNo", txtAccountNo.Text);
                        parameters.Add("p_IFSCCode", txtIFSCCode.Text);
                        parameters.Add("p_BankBranchAddress", txtBankBranchAddress.Text);
                        //parameters.Add("p_ext1", "-");
                        //parameters.Add("p_ext2", "-");
                        //parameters.Add("p_ext3", "-");
                        //parameters.Add("p_ext4", "1");
                        parameters.Add("p_FreelancerPic", profilePic);
                        parameters.Add("p_DOA", txtDateOfAnniversary.Text);
                        parameters.Add("p_DOB", txtDateOfBirth.Text);
                        parameters.Add("p_Id", Request.QueryString["id"]);

                        oDataAccess.ExecuteSPDynamic("sp_update_freelancer", parameters);

                        ShowUpdatedSweetAlert();
                    }
                }
                catch (Exception ex)
                {
                    var errorLogger = new Log("ErrorLog.txt");
                    errorLogger.LogError(ex);

                    if (ex.Message.Contains("Duplicate"))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "showSweetAlert", "Swal.fire('Error!', 'Mobile No. Already Exists', 'error');", true);
                        //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Mobile No. Already Exists');", true);
                    }
                }
            }
        }
    }
}