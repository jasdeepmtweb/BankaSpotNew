using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Branch
{
    public partial class ShowTrancheDetails : System.Web.UI.Page
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
                if (Request.QueryString["id"] != null)
                {
                    BindGrid();
                }
            }
            if (GridTranche.Rows.Count > 0)
            {
                GridTranche.UseAccessibleHeader = true;
                GridTranche.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridTranche.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void BindGrid()
        {
            var parameters = new DynamicParameters();
            parameters.Add("CaseId", Request.QueryString["id"]);

            var result = oDataAccess.QuerySPListDynamic<Case_Status_History>("sp_getcasehistory_bycaseid", parameters);

            result = result.Where(x => x.NewStatus.ToLower().Contains("tranche")).ToList();

            GridTranche.DataSource = result;
            GridTranche.DataBind();

            if (GridTranche.Rows.Count > 0)
            {
                GridTranche.UseAccessibleHeader = true;
                GridTranche.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridTranche.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
}