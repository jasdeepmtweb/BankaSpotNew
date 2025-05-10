using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.IO;

namespace BankaSpotNew.Branch
{
    public partial class UpdateConnectorDocs : System.Web.UI.Page
    {
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["branch"] == null)
            {
                Response.Redirect("../BranchLogin.aspx");
            }
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("ShowConnectors.aspx");
            }
            if (!IsPostBack)
            {
                GetConnectorData();
            }
        }

        private void GetConnectorData()
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", Request.QueryString["id"]);

            var result = oDataAccess.QuerySingleOrDefaultSPDynamic<Connector_Add>("sp_getconnectorby_id", parameters);
            if (result != null)
            {
                BtnViewPANCard.Attributes.Add("src", $"../Uploads/{result.ext1}");
                BtnViewAdhaarCard.Attributes.Add("src", $"../Uploads/{result.ext2}");
                BtnViewCancelCheck.Attributes.Add("src", $"../Uploads/{result.ext3}");

                lblPANCard.Text = result.ext1;
                lblAdhaarCard.Text = result.ext2;
                lblCancelCheck.Text = result.ext3;
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (Request.QueryString["id"] != null)
                    {
                        string fileAdharCard = "-";
                        if (fileAdhar.HasFile)
                        {
                            if (fileAdhar.PostedFile.ContentLength <= 1024 * 1024)
                            {
                                string extension = Path.GetExtension(fileAdhar.FileName);
                                if (extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) || extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) || extension.Equals(".png", StringComparison.OrdinalIgnoreCase))
                                {
                                    fileAdharCard = Guid.NewGuid() + extension;
                                    fileAdhar.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fileAdharCard);
                                }
                                else
                                {
                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Only Image OR PDF Is Allowed');", true);
                                    return;
                                }
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('The file size exceeds the maximum limit of 1 MB.');", true);
                                return;
                            }
                        }
                        else
                        {
                            fileAdharCard = lblAdhaarCard.Text;
                        }
                        string fileCancelCheckName = "-";
                        if (fileCancelCheck.HasFile)
                        {
                            if (fileCancelCheck.PostedFile.ContentLength <= 1024 * 1024)
                            {
                                string extension = Path.GetExtension(fileCancelCheck.FileName);
                                if (extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) || extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) || extension.Equals(".png", StringComparison.OrdinalIgnoreCase))
                                {
                                    fileCancelCheckName = Guid.NewGuid() + extension;
                                    fileCancelCheck.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fileCancelCheckName);
                                }
                                else
                                {
                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Only Image OR PDF Is Allowed');", true);
                                    return;
                                }
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('The file size exceeds the maximum limit of 1 MB.');", true);
                                return;
                            }
                        }
                        else
                        {
                            fileCancelCheckName = lblCancelCheck.Text;
                        }
                        string filePanCard = "-";
                        if (filePan.HasFile)
                        {
                            if (filePan.PostedFile.ContentLength <= 1024 * 1024)
                            {
                                string extension = Path.GetExtension(filePan.FileName);
                                if (extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) || extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) || extension.Equals(".png", StringComparison.OrdinalIgnoreCase))
                                {
                                    filePanCard = Guid.NewGuid() + extension;
                                    filePan.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + filePanCard);
                                }
                                else
                                {
                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Only Image OR PDF Is Allowed');", true);
                                    return;
                                }
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('The file size exceeds the maximum limit of 1 MB.');", true);
                                return;
                            }
                        }
                        else
                        {
                            filePanCard = lblPANCard.Text;
                        }

                        var parameters = new DynamicParameters();
                        parameters.Add("ext1", filePanCard);
                        parameters.Add("ext2", fileAdharCard);
                        parameters.Add("ext3", fileCancelCheckName);
                        parameters.Add("Id", Request.QueryString["id"]);

                        oDataAccess.ExecuteSPDynamic("sp_uploadconnector_docs", parameters);

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