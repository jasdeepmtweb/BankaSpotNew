using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI.WebControls;

namespace BankaSpotNew.MarketingEmp
{
    public partial class WithdrawalSummary : System.Web.UI.Page
    {
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
            if (GridConnector.Rows.Count > 0)
            {
                GridConnector.UseAccessibleHeader = true;
                GridConnector.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridConnector.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        private void BindGrid()
        {
            Marketing_Employee_Add oMarketing_Employee_Add = Session["memp"] as Marketing_Employee_Add;

            var parameters = new DynamicParameters();
            parameters.Add("p_UserId", oMarketing_Employee_Add.Id);
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPDynamic<Marketing_Employee_Withdrawal>("sp_getmarketemp_withsummary", parameters);
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
    }
}