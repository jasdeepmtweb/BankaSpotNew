using BankaSpotNew.App_Code;
using System;
using System.IO;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Admin
{
    public partial class DownloadConnectorDocs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("../BranchLogin.aspx");
            }
            if (!IsPostBack)
            {
                BindGrid();
            }
            if (GridConnector.Rows.Count > 0)
            {
                GridConnector.UseAccessibleHeader = true;
                GridConnector.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridConnector.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void BindGrid()
        {
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPDynamic<Connector_Add>("sp_getconnectorsforadmin");
            if (result != null)
            {
                GridConnector.DataSource = result;
                GridConnector.DataBind();
            }
            if (GridConnector.Rows.Count > 0)
            {
                GridConnector.UseAccessibleHeader = true;
                GridConnector.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridConnector.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void btedt_Click(object sender, EventArgs e)
        {
            Button Btn = (Button)sender;

            try
            {
                string panCard = Server.MapPath("~/Uploads/") + Btn.CommandArgument;
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(panCard));
                Response.WriteFile(panCard);
                Response.End();
            }
            catch (Exception ex)
            {
                var errorLogger = new Log("ErrorLog.txt");
                errorLogger.LogError(ex);
            }
        }

        protected void BtnAdhar_Click(object sender, EventArgs e)
        {
            Button Btn = (Button)sender;

            try
            {
                string adharCard = Server.MapPath("~/Uploads/") + Btn.CommandArgument;
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(adharCard));
                Response.WriteFile(adharCard);
                Response.End();
            }
            catch (Exception ex)
            {
                var errorLogger = new Log("ErrorLog.txt");
                errorLogger.LogError(ex);
            }
        }

        protected void BtnCancelCheck_Click(object sender, EventArgs e)
        {
            Button Btn = (Button)sender;

            try
            {
                string cancelCheck = Server.MapPath("~/Uploads/") + Btn.CommandArgument;
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(cancelCheck));
                Response.WriteFile(cancelCheck);
                Response.End();
            }
            catch (Exception ex)
            {
                var errorLogger = new Log("ErrorLog.txt");
                errorLogger.LogError(ex);
            }
        }
    }
}