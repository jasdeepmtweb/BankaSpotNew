using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Branch
{
    public partial class ShowBankers : System.Web.UI.Page
    {
        DataAccess oDataAccess = new DataAccess();
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
            if (GridProducts.Rows.Count > 0)
            {
                GridProducts.UseAccessibleHeader = true;
                GridProducts.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridProducts.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void BindGrid()
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_Status", 1);

            var result = oDataAccess.QuerySPListDynamic<BankerModel>("sp_selectall_bankers", parameters);
            GridProducts.DataSource = result;
            GridProducts.DataBind();

            if (GridProducts.Rows.Count > 0)
            {
                GridProducts.UseAccessibleHeader = true;
                GridProducts.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridProducts.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
}