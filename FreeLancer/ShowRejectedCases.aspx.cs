using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.FreeLancer
{
    public partial class ShowRejectedCases : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["frl"] == null)
            {
                Response.Redirect("../FreeLancerLogin.aspx");
            }
            if (!IsPostBack)
            {
                Freelancer_Add oFreelancer_Add = Session["frl"] as Freelancer_Add;
                BindGrid(oFreelancer_Add.Id);
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
            parameters.Add("p_FreelancerId", id);
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPDynamic<Case_Add>("sp_getcasesby_freelancerid", parameters);
            if (result != null)
            {
                result = result.Where(x => x.Status.Contains("Rejected") || x.Status.Contains("Denied"));
                foreach (var item in result)
                {
                    parameters.Add("CaseId", item.Id);
                    oDataAccess = new DataAccess();
                    var History = oDataAccess.QuerySPDynamic<Case_Status_History>("sp_getcasehistory_bycaseid", parameters);

                    item.DisbursedDate = History.Where(p => p.CaseId == item.Id && (p.NewStatus.Contains("Rejected") || p.NewStatus.Contains("Denied"))).FirstOrDefault().DateAdded;
                }
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