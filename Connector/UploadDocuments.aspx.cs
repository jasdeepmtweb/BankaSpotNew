using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.IO;
using System.Web.UI;

namespace BankaSpotNew.Connector
{
    public partial class UploadDocuments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cnt"] == null)
            {
                Response.Redirect("../ConnectorLogin.aspx");
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string fileAdharCard = "-";
                    if (fileAdhar.HasFile)
                    {
                        if (fileAdhar.PostedFile.ContentLength <= 1024 * 1024)
                        {
                            string extension = Path.GetExtension(fileAdhar.FileName);
                            fileAdharCard = Guid.NewGuid() + extension;
                            fileAdhar.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fileAdharCard);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('The file size exceeds the maximum limit of 1 MB.');", true);
                            return;
                        }
                    }
                    string fileCancelCheckName = "-";
                    if (fileCancelCheck.HasFile)
                    {
                        if (fileCancelCheck.PostedFile.ContentLength <= 1024 * 1024)
                        {
                            string extension = Path.GetExtension(fileCancelCheck.FileName);
                            fileCancelCheckName = Guid.NewGuid() + extension;
                            fileCancelCheck.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fileCancelCheckName);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('The file size exceeds the maximum limit of 1 MB.');", true);
                            return;
                        }
                    }
                    string filePanCard = "-";
                    if (filePan.HasFile)
                    {
                        if (filePan.PostedFile.ContentLength <= 1024 * 1024)
                        {
                            string extension = Path.GetExtension(filePan.FileName);
                            filePanCard = Guid.NewGuid() + extension;
                            filePan.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + filePanCard);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('The file size exceeds the maximum limit of 1 MB.');", true);
                            return;
                        }
                    }


                    Connector_Add oConnector_Add = Session["cnt"] as Connector_Add;

                    var parameters = new DynamicParameters();
                    parameters.Add("ext1", filePanCard);
                    parameters.Add("ext2", fileAdharCard);
                    parameters.Add("ext3", fileCancelCheckName);
                    parameters.Add("Id", oConnector_Add.Id);

                    DataAccess oDataAccess = new DataAccess();
                    oDataAccess.ExecuteSPDynamic("sp_uploadconnector_docs", parameters);

                    string sql = "SELECT * FROM tbconnector WHERE MobileNo = @MobileNo AND Password = @Password";
                    parameters = new DynamicParameters();
                    parameters.Add("Password", oConnector_Add.Password);
                    parameters.Add("MobileNo", oConnector_Add.MobileNo);

                    var result = oDataAccess.QuerySingleOrDefaultDynamic<Connector_Add>(sql, parameters);

                    Session.Remove("cnt");

                    Session["cnt"] = result;

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added');window.location.href='Dashboard.aspx';", true);
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