using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.MarketingEmp
{
    public partial class ShowDisbursedCases : System.Web.UI.Page
    {
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
            parameters.Add("p_MarketingEmpId", oMarketing_Employee_Add.Id);
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPListDynamic<Case_Add>("sp_getdisbursedcasesfor_marketingemp", parameters);
            if (result != null)
            {
                //result = result.Where(x => x.Status.Contains("Disbursed")).ToList();
                //foreach (var item in result)
                //{
                //    parameters.Add("CaseId", item.Id);
                //    oDataAccess = new DataAccess();
                //    var History = oDataAccess.QuerySPListDynamic<Case_Status_History>("sp_getcasehistory_bycaseid", parameters);

                //    item.DisbursedDate = History.Where(p => p.CaseId == item.Id).FirstOrDefault().DateAdded;
                //}

                result = result.OrderByDescending(x => x.DisbursedDate.Date).ToList();

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
    }
}