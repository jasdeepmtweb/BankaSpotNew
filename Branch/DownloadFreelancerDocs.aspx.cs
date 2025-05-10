using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.IO;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Branch
{
    public partial class DownloadFreelancerDocs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["branch"] == null)
            {
                Response.Redirect("../BranchLogin.aspx");
            }
            if (!IsPostBack)
            {
                Branch_Add oBranch_Add = Session["branch"] as Branch_Add;
                BindGrid(oBranch_Add.Id);
            }
            if (GridConnector.Rows.Count > 0)
            {
                GridConnector.UseAccessibleHeader = true;
                GridConnector.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridConnector.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        private void BindGrid(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_BranchId", id);
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPDynamic<Freelancer_Add>("sp_getallfreelancersby_branchid", parameters);
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

        protected void BtnPan_Click(object sender, EventArgs e)
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