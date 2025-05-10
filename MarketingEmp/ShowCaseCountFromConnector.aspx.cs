using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI.WebControls;

namespace BankaSpotNew.MarketingEmp
{
    public partial class ShowCaseCountFromConnector : System.Web.UI.Page
    {
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["memp"] == null)
            {
                Response.Redirect("../MarketingEmpLogin.aspx");
            }
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            Marketing_Employee_Add oMarketing_Employee_Add = Session["memp"] as Marketing_Employee_Add;

            var parameters = new DynamicParameters();
            parameters.Add("p_MarketEmpId", oMarketing_Employee_Add.Id);

            var result = oDataAccess.QuerySPListDynamic<Connector_Add>("sp_getactiveinactive_connectorsformarketemp", parameters);

            GridShowConnector.DataSource = result;
            GridShowConnector.DataBind();

            if (GridShowConnector.Rows.Count > 0)
            {
                GridShowConnector.UseAccessibleHeader = true;
                GridShowConnector.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridShowConnector.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            Marketing_Employee_Add oMarketing_Employee_Add = Session["memp"] as Marketing_Employee_Add;

            var parameters = new DynamicParameters();
            parameters.Add("p_MarketEmpId", oMarketing_Employee_Add.Id);
            parameters.Add("p_FromDate", txtFromDate.Text);
            parameters.Add("p_ToDate", txtToDate.Text);

            var result = oDataAccess.QueryDynamic<Connector_Add>("sp_getconcasecountformarketemp_usingdate", parameters);

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