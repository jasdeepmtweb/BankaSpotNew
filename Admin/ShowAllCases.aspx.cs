using BankaSpotNew.App_Code;
using System;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Admin
{
    public partial class ShowAllCases : System.Web.UI.Page
    {
        DataAccess oDataAccess = new DataAccess();
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
            if (GridAllCases.Rows.Count > 0)
            {
                GridAllCases.UseAccessibleHeader = true;
                GridAllCases.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridAllCases.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        private void BindGrid()
        {
            var result = oDataAccess.QuerySPListDynamic<Case_Add>("sp_getallcaseswithoutstatus_foradmin");

            GridAllCases.DataSource = result;
            GridAllCases.DataBind();

            if (GridAllCases.Rows.Count > 0)
            {
                GridAllCases.UseAccessibleHeader = true;
                GridAllCases.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridAllCases.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void BtnTransfer_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            Response.Redirect($"TransferCaseToBranch.aspx?id={button.CommandArgument}");
        }
    }
}