using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Branch
{
    public partial class CasesFromConnector : System.Web.UI.Page
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
            if (GridCaseFromConnector.Rows.Count > 0)
            {
                GridCaseFromConnector.UseAccessibleHeader = true;
                GridCaseFromConnector.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridCaseFromConnector.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void BindGrid(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("BranchId", id);
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPDynamic<Case_Add>("sp_getcaseforbranchbyconnectorid", parameters).ToList();
            if (result != null)
            {
                result = result.Where(x => !x.Status.Contains("Disbursed") && !x.Status.Contains("Rejected") && !x.Status.Contains("Denied")).ToList();
                GridCaseFromConnector.DataSource = result;
                GridCaseFromConnector.DataBind();
            }
            if (GridCaseFromConnector.Rows.Count > 0)
            {
                GridCaseFromConnector.UseAccessibleHeader = true;
                GridCaseFromConnector.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridCaseFromConnector.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        protected void btedt_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Response.Redirect($"AddCase.aspx?id={button.CommandArgument}");
        }

        protected void btndel_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            var parameters = new DynamicParameters();
            parameters.Add("Id", button.CommandArgument);
            DataAccess oDataAccess = new DataAccess();
            oDataAccess.ExecuteSPDynamic("sp_delete_case", parameters);
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Deleted');window.location.href='CasesFromConnector.aspx';", true);
        }

        protected void BtnAddEmployee_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            GridViewRow row = (GridViewRow)button.NamingContainer;
            Label lblConnectorId = (Label)row.FindControl("lblConnectorId");

            Response.Redirect($"MapEmpToConnectorCase.aspx?id={button.CommandArgument}&cid={lblConnectorId.Text}");
        }
    }
}