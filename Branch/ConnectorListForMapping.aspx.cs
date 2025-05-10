using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Branch
{
    public partial class ConnectorListForMapping : System.Web.UI.Page
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
            if (GridConnectorForBranch.Rows.Count > 0)
            {
                GridConnectorForBranch.UseAccessibleHeader = true;
                GridConnectorForBranch.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridConnectorForBranch.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void BindGrid(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("BranchId", id);
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPListDynamic<Connector_Add>("sp_getconnectors_bybranchid", parameters);
            if (result != null)
            {
                result = result.OrderByDescending(x => x.ext4).ToList();
                GridConnectorForBranch.DataSource = result;
                GridConnectorForBranch.DataBind();
            }
            if (GridConnectorForBranch.Rows.Count > 0)
            {
                GridConnectorForBranch.UseAccessibleHeader = true;
                GridConnectorForBranch.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridConnectorForBranch.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        protected void BtnMap_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            Response.Redirect($"MapConnectorToEmpMarketEmp.aspx?id={button.CommandArgument}");
        }
    }
}