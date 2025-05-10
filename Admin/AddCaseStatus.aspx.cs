using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Admin
{
    public partial class AddCaseStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("../BranchLogin.aspx");
            }
            if (!IsPostBack)
            {
                GetData();
            }
            if (GridProducts.Rows.Count > 0)
            {
                GridProducts.UseAccessibleHeader = true;
                GridProducts.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridProducts.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void GetData()
        {
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySP<Case_Status_Add>("sp_getallstatus");
            GridProducts.DataSource = result;
            GridProducts.DataBind();

            if (GridProducts.Rows.Count > 0)
            {
                GridProducts.UseAccessibleHeader = true;
                GridProducts.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridProducts.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("CaseStatus", txtStatus.Text.Trim());
                    DataAccess oDataAccess = new DataAccess();
                    oDataAccess.ExecuteSPDynamic("sp_insert_case_status", parameters);

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added');window.location.href='AddCaseStatus.aspx';", true);
                }
                catch (Exception ex)
                {
                   var errorLogger = new Log("ErrorLog.txt");
                    errorLogger.LogError(ex);
                }
            }
        }
    }
}