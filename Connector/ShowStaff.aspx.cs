using BankaSpotNew.App_Code;
using System;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Connector
{
    public partial class ShowStaff : System.Web.UI.Page
    {
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cnt"] == null)
            {
                Response.Redirect("../ConnectorLogin.aspx");
            }
            if (!IsPostBack)
            {
                BindGrid();
            }
            if (GridStaff.Rows.Count > 0)
            {
                GridStaff.UseAccessibleHeader = true;
                GridStaff.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridStaff.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void BindGrid()
        {
            var result = oDataAccess.QuerySPListDynamic<StaffModel>("sp_getall_staff");
            GridStaff.DataSource = result;
            GridStaff.DataBind();

            if (GridStaff.Rows.Count > 0)
            {
                GridStaff.UseAccessibleHeader = true;
                GridStaff.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridStaff.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
}