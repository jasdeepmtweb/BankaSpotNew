using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Branch
{
    public partial class ShowDisbursedCases : System.Web.UI.Page
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
        public bool IsTrancheButtonVisible(object caseId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("CaseId", caseId);

            var History = oDataAccess.QuerySPListDynamic<Case_Status_History>("sp_getcasehistory_bycaseid", parameters);
            foreach (var item in History)
            {
                if (item.NewStatus.Contains("Tranche"))
                {
                    return true;
                }
            }
            return false;
        }
        private void BindGrid(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("BranchId", id);
            
            var result = oDataAccess.QuerySPDynamic<Case_Add>("sp_getdisbursedcasesfor_branch", parameters);
            if (result != null)
            {
                //result = result.Where(x => x.Status.Contains("Disbursed")|| x.Status.Contains("Tranche"));

                if (Request.QueryString["conid"] != null && !Request.QueryString["conid"].ToString().Equals(""))
                {
                    result = result.Where(x => x.ConnectorId == Convert.ToInt32(Request.QueryString["conid"]));
                }
                if (Request.QueryString["frid"] != null && !Request.QueryString["frid"].ToString().Equals(""))
                {
                    result = result.Where(x => x.ext3.Equals(Request.QueryString["frid"]));
                }

                //foreach (var item in result)
                //{
                //    parameters.Add("CaseId", item.Id);
                //    oDataAccess = new DataAccess();
                //    var History = oDataAccess.QuerySPDynamic<Case_Status_History>("sp_getcasehistory_bycaseid", parameters);

                //    item.DisbursedDate = History.Where(p => p.CaseId == item.Id).FirstOrDefault().DateAdded;
                //    item.CaseBookedIn = History.Where(p => p.CaseId == item.Id).FirstOrDefault().ext1;
                //}

                result = result.OrderByDescending(x => x.DisbursedDate.Date);

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
            
            var result = oDataAccess.QuerySPDynamic<Case_Status_History>("sp_getcasehistory_bycaseid", parameters);
            if (result != null)
            {
                GridCaseHistory.DataSource = result;
                GridCaseHistory.DataBind();

                ShowHistoryModalPopup();
            }
        }

        protected void BtnShowTranche_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            Response.Redirect($"ShowTrancheDetails.aspx?id={button.CommandArgument}");
        }
    }
}