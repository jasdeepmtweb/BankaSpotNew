using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.MarketingEmp
{
	public partial class ShowCasesFromConnector : System.Web.UI.Page
	{
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["memp"] == null)
			{
				Response.Redirect("../MarketingEmpLogin.aspx");
			}
			if (!IsPostBack)
			{
				GetData();
			}
			if (GridCase.Rows.Count > 0)
			{
				GridCase.UseAccessibleHeader = true;
				GridCase.HeaderRow.TableSection = TableRowSection.TableHeader;
				GridCase.FooterRow.TableSection = TableRowSection.TableFooter;
			}
		}
		private void GetData()
		{
			Marketing_Employee_Add oMarketing_Employee_Add = Session["memp"] as Marketing_Employee_Add;

			var parameters = new DynamicParameters();
			parameters.Add("p_MarketEmpId", oMarketing_Employee_Add.Id);
		
			var result = oDataAccess.QuerySPListDynamic<Case_Add>("sp_getallcases_formarketemp_byconnectors", parameters);
			//var result = oDataAccess.QuerySPListDynamic<Case_Add>("sp_getcasesfor_marketingemp", parameters);
			if (result != null)
			{
				//result = result.Where(x => x.ConnectorId != 0).ToList();
				result = result.Where(x => !x.Status.Contains("Disbursed") && !x.Status.Contains("Rejected") && !x.Status.Contains("Denied")).ToList();
				//foreach (var item in result)
				//{
				//	parameters = new DynamicParameters();
				//	parameters.Add("Id", item.ConnectorId);
				//	var connector = oDataAccess.QuerySingleOrDefaultSPDynamic<Connector_Add>("sp_getconnectorby_id", parameters);
				//	if (connector != null)
				//	{
				//		item.ConnectorName = connector.Name;
				//	}
				//}
				GridCase.DataSource = result;
				GridCase.DataBind();
			}
			if (GridCase.Rows.Count > 0)
			{
				GridCase.UseAccessibleHeader = true;
				GridCase.HeaderRow.TableSection = TableRowSection.TableHeader;
				GridCase.FooterRow.TableSection = TableRowSection.TableFooter;
			}
		}
		protected void ShowModalPopup()
		{
			hdnShowModal.Value = "1";
			hdnShowHistoryModal.Value = "0";
		}
		protected void ShowHistoryModalPopup()
		{
			hdnShowModal.Value = "0";
			hdnShowHistoryModal.Value = "1";
		}
		protected void BtnCheckStatus_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			var parameters = new DynamicParameters();
			parameters.Add("CaseId", button.CommandArgument);
			
			var result = oDataAccess.QuerySPDynamic<Case_Status_History>("sp_getcasehistory_bycaseid", parameters);
			if (result != null)
			{
				GridCaseHistory.DataSource = result;
				GridCaseHistory.DataBind();

				ShowHistoryModalPopup();
			}
		}
	}
}