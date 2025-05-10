using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Branch
{
    public partial class CasesFromEmployee : System.Web.UI.Page
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
            if (GridCaseFromEmp.Rows.Count > 0)
            {
                GridCaseFromEmp.UseAccessibleHeader = true;
                GridCaseFromEmp.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridCaseFromEmp.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void BindGrid(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("BranchId", id);
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPListDynamic<Case_Add>("sp_getcasesby_empidforbranch", parameters);
            if (result != null)
            {
                result = result.Where(x => !x.Status.Contains("Disbursed") && !x.Status.Contains("Rejected") && !x.Status.Contains("Denied")).ToList();

                GridCaseFromEmp.DataSource = result;
                GridCaseFromEmp.DataBind();
            }
            if (GridCaseFromEmp.Rows.Count > 0)
            {
                GridCaseFromEmp.UseAccessibleHeader = true;
                GridCaseFromEmp.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridCaseFromEmp.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        protected void btedt_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Response.Redirect($"AddCase.aspx?id={button.CommandArgument}&pgtyp=emp");
        }

        protected void btndel_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            var parameters = new DynamicParameters();
            parameters.Add("Id", button.CommandArgument);
            DataAccess oDataAccess = new DataAccess();
            oDataAccess.ExecuteSPDynamic("sp_delete_case", parameters);
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Deleted');window.location.href='CasesFromEmployee.aspx';", true);
        }

        protected void BtnTranferCase_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow row = (GridViewRow)button.NamingContainer;
            Label lblEmpid = (Label)row.FindControl("lblEmpid");

            Response.Redirect($"TransferCaseFromEmpToEmp.aspx?id={button.CommandArgument}&empid={lblEmpid.Text}");
        }
    }
}