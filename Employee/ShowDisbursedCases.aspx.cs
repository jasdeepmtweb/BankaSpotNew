using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Employee
{
    public partial class ShowDisbursedCases : System.Web.UI.Page
    {
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["emp"] == null)
            {
                Response.Redirect("../EmployeeLogin.aspx");
            }
            if (!IsPostBack)
            {
                Employee_Add oEmployee_Add = Session["emp"] as Employee_Add;
                BindGrid(oEmployee_Add.Id);
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
            parameters.Add("EmpId", id);

            var result = oDataAccess.QuerySPListDynamic<Case_Add>("sp_getallcaselist_foremp", parameters);
            if (result != null)
            {
                result = result.Where(x => x.Status.Contains("Disbursed") || x.Status.Contains("Tranche")).ToList();

                //foreach (var item in result)
                //{
                //    parameters.Add("CaseId", item.Id);

                //    var History = oDataAccess.QuerySPListDynamic<Case_Status_History>("sp_getcasehistory_bycaseid", parameters);

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
        protected void BtnEditDisbursment_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            Response.Redirect($"EditDisbursement.aspx?id={button.CommandArgument}");
        }
        protected void ShowModalPopup()
        {
            hdnShowModal.Value = "1";
        }
        protected void BtnShowTranche_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            Response.Redirect($"ShowTrancheDetails.aspx?id={button.CommandArgument}");

            //var parameters = new DynamicParameters();
            //parameters.Add("CaseId", button.CommandArgument);

            //var result = oDataAccess.QuerySPListDynamic<Case_Status_History>("sp_getcasehistory_bycaseid", parameters);

            //result = result.Where(x => x.NewStatus.ToLower().Contains("tranche")).ToList();

            //GridCaseHistory.DataSource = result;
            //GridCaseHistory.DataBind();

            //ShowModalPopup();
        }
    }
}