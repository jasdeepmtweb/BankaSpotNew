using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Branch
{
    public partial class CasesFromFreelancers : System.Web.UI.Page
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
            if (GridCaseFromFreelancer.Rows.Count > 0)
            {
                GridCaseFromFreelancer.UseAccessibleHeader = true;
                GridCaseFromFreelancer.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridCaseFromFreelancer.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void BindGrid(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("BranchId", id);
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPDynamic<Case_Add>("sp_getcasesbyfreelancer_forbranch", parameters);

            result = result.Where(x => !x.Status.Contains("Disbursed") && !x.Status.Contains("Rejected") && !x.Status.Contains("Denied"));
            GridCaseFromFreelancer.DataSource = result;
            GridCaseFromFreelancer.DataBind();

            if (GridCaseFromFreelancer.Rows.Count > 0)
            {
                GridCaseFromFreelancer.UseAccessibleHeader = true;
                GridCaseFromFreelancer.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridCaseFromFreelancer.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        protected void btedt_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Response.Redirect($"AddCase.aspx?id={button.CommandArgument}&typ=freelancer");
        }

        protected void btndel_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            var parameters = new DynamicParameters();
            parameters.Add("Id", button.CommandArgument);
            DataAccess oDataAccess = new DataAccess();
            oDataAccess.ExecuteSPDynamic("sp_delete_case", parameters);
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Deleted');window.location.href='CasesFromFreelancers.aspx';", true);
        }

        protected void BtnAddEmployee_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            GridViewRow row = (GridViewRow)button.NamingContainer;
            Label lblFreelancerId = (Label)row.FindControl("lblFreelancerId");

            Response.Redirect($"MapEmployeeToCase.aspx?id={button.CommandArgument}&fid={lblFreelancerId.Text}");
        }

        protected void BtnChangeFreelancer_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            GridViewRow row = (GridViewRow)button.NamingContainer;
            Label lblEmpId = (Label)row.FindControl("lblEmpId");

            Response.Redirect($"ChangeFreelancerFromCase.aspx?id={button.CommandArgument}&eid={lblEmpId.Text}");
        }
    }
}