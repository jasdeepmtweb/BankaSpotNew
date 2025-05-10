using System;
using System.Linq;
using System.Web.UI.WebControls;
using BankaSpotNew.App_Code;
using Dapper;

namespace BankaSpotNew.Branch
{
    public partial class ShowCustomers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["branch"] == null)
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
            var parameters = new DynamicParameters();
            parameters.Add("p_Status", 1);
            parameters.Add("p_Type", "Customer");

            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPListDynamic<CustomerModel>("sp_getallcustomers", parameters);
            result = result.Where(x => x.BranchId == ((Branch_Add)(Session["branch"])).Id).ToList();
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