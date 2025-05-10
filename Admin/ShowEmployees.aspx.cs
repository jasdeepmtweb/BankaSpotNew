using BankaSpotNew.App_Code;
using System;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Admin
{
    public partial class ShowEmployees : System.Web.UI.Page
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
            if (GridRegion.Rows.Count > 0)
            {
                GridRegion.UseAccessibleHeader = true;
                GridRegion.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridRegion.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void BindGrid()
        {
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPDynamic<Employee_Add>("sp_getemployeelist_foradmin");
            if (result != null)
            {
                GridRegion.DataSource = result;
                GridRegion.DataBind();
            }
            if (GridRegion.Rows.Count > 0)
            {
                GridRegion.UseAccessibleHeader = true;
                GridRegion.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridRegion.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        protected void btedt_Click(object sender, EventArgs e)
        {
            Button Btn = (Button)sender;
            Response.Redirect($"MakeEmployeeWithdrawal.aspx?id={Btn.CommandArgument}");
        }
    }
}