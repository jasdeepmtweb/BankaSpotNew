using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Branch
{
    public partial class ConnectorCaseCount : System.Web.UI.Page
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        static List<Connector_Add> allCases = new List<Connector_Add>();
        DataAccess oDataAccess = new DataAccess();
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
            if (GridShowConnector.Rows.Count > 0)
            {
                GridShowConnector.UseAccessibleHeader = true;
                GridShowConnector.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridShowConnector.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void BindGrid(int id)
        {
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

            allCases.Clear();

            var parameters = new DynamicParameters();
            parameters.Add("p_BranchId", id);

            var result = oDataAccess.QuerySPListDynamic<Connector_Add>("sp_getactiveinactive_connectors", parameters);

            GridShowConnector.DataSource = result;
            GridShowConnector.DataBind();

            allCases = result;

            if (GridShowConnector.Rows.Count > 0)
            {
                GridShowConnector.UseAccessibleHeader = true;
                GridShowConnector.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridShowConnector.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            Branch_Add oBranch_Add = Session["branch"] as Branch_Add;

            //string sql = "SELECT a.Name,a.MobileNo,COALESCE(COUNT(b.ConnectorId), 0) AS CaseCount,a.Id,a.CreatedOn FROM tbconnector a LEFT JOIN tbcase b ON a.Id = b.ConnectorId AND (date(b.CreatedOn) BETWEEN @p_FromDate AND @p_ToDate) AND a.BranchId=@p_BranchId GROUP BY a.Id ORDER BY CaseCount DESC;";
            //var parameters = new DynamicParameters();
            //parameters.Add("p_BranchId", oBranch_Add.Id);
            //parameters.Add("p_FromDate", txtFromDate.Text);
            //parameters.Add("p_ToDate", txtToDate.Text);
            //DataAccess oDataAccess = new DataAccess();
            //var result = oDataAccess.QueryDynamic<Connector_Add>(sql, parameters);

            //List<Connector_Add> connector_Adds = allCases.Where(x => x.CreatedOn.Date >= Convert.ToDateTime(txtFromDate.Text).Date && x.CreatedOn.Date <= Convert.ToDateTime(txtToDate.Text).Date).ToList();

            var parameters = new DynamicParameters();
            parameters.Add("p_BranchId", oBranch_Add.Id);
            parameters.Add("p_FromDate", txtFromDate.Text);
            parameters.Add("p_ToDate", txtToDate.Text);

            var result = oDataAccess.QueryDynamic<Connector_Add>("sp_getactiveinactive_connectorsusingdate", parameters);

            GridShowConnector.DataSource = result;
            GridShowConnector.DataBind();

            if (GridShowConnector.Rows.Count > 0)
            {
                GridShowConnector.UseAccessibleHeader = true;
                GridShowConnector.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridShowConnector.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
}