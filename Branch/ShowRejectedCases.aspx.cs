using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Branch
{
    public partial class ShowRejectedCases : System.Web.UI.Page
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
            if (GridCase.Rows.Count > 0)
            {
                GridCase.UseAccessibleHeader = true;
                GridCase.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridCase.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void BindGrid(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_BranchId", id);
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPListDynamic<Case_Add>("sp_getrejectedcasesforbranch", parameters);
            if (result != null)
            {
                if (Request.QueryString["conid"] != null && !Request.QueryString["conid"].ToString().Equals(""))
                {
                    result = result.Where(x => x.ConnectorId == Convert.ToInt32(Request.QueryString["conid"])).ToList();
                }
                if (Request.QueryString["frid"] != null && !Request.QueryString["frid"].ToString().Equals(""))
                {
                    result = result.Where(x => x.ext3.Equals(Request.QueryString["frid"])).ToList();
                }
                //result = result.Where(x => x.Status.Contains("Rejected") || x.Status.Contains("Denied")).ToList();
                //foreach (var item in result)
                //{
                //    parameters.Add("CaseId", item.Id);
                //    oDataAccess = new DataAccess();
                //    var History = oDataAccess.QuerySPDynamic<Case_Status_History>("sp_getcasehistory_bycaseid", parameters);

                //    item.DisbursedDate = History.Where(p => p.CaseId == item.Id).FirstOrDefault().DateAdded;
                //    item.CaseBookedIn = History.Where(p => p.CaseId == item.Id).FirstOrDefault().ext1;
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
        protected void ShowHistoryModalPopup()
        {
            hdnShowHistoryModal.Value = "1";
        }
        protected void BtnCheckStatus_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            var parameters = new DynamicParameters();
            parameters.Add("CaseId", button.CommandArgument);
            DataAccess oDataAccess = new DataAccess();
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