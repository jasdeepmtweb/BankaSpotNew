using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Branch
{
	public partial class CaseFromMaketEmp : System.Web.UI.Page
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
			if (GridCaseFromMarketEmp.Rows.Count > 0)
			{
				GridCaseFromMarketEmp.UseAccessibleHeader = true;
				GridCaseFromMarketEmp.HeaderRow.TableSection = TableRowSection.TableHeader;
				GridCaseFromMarketEmp.FooterRow.TableSection = TableRowSection.TableFooter;
			}
		}
		private void BindGrid(int id)
		{
			var parameters = new DynamicParameters();
			parameters.Add("p_BranchId", id);
			DataAccess oDataAccess = new DataAccess();
			var result = oDataAccess.QuerySPDynamic<Case_Add>("sp_getallcasesbymarketemp_forbranch", parameters);
			if (result != null)
			{
				result = result.Where(x => !x.Status.Contains("Disbursed") && !x.Status.Contains("Rejected") && !x.Status.Contains("Denied"));
				GridCaseFromMarketEmp.DataSource = result;
				GridCaseFromMarketEmp.DataBind();
			}
			if (GridCaseFromMarketEmp.Rows.Count > 0)
			{
				GridCaseFromMarketEmp.UseAccessibleHeader = true;
				GridCaseFromMarketEmp.HeaderRow.TableSection = TableRowSection.TableHeader;
				GridCaseFromMarketEmp.FooterRow.TableSection = TableRowSection.TableFooter;
			}
		}
		protected void btedt_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			Response.Redirect($"AddCase.aspx?id={button.CommandArgument}&pgtyp=memp");
		}

		protected void btndel_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;

			var parameters = new DynamicParameters();
			parameters.Add("Id", button.CommandArgument);
			DataAccess oDataAccess = new DataAccess();
			oDataAccess.ExecuteSPDynamic("sp_delete_case", parameters);
			ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Deleted');window.location.href='CaseFromMaketEmp.aspx';", true);
		}
	}
}