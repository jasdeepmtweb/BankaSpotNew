using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Branch
{
    public partial class FreelancerListForMapping : System.Web.UI.Page
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
            if (GridFreelancerForBranch.Rows.Count > 0)
            {
                GridFreelancerForBranch.UseAccessibleHeader = true;
                GridFreelancerForBranch.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridFreelancerForBranch.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void BindGrid(int Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_BranchId", Id);
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPListDynamic<Freelancer_Add>("sp_getallfreelancersby_branchid", parameters);
            if (result != null)
            {
                result = result.OrderByDescending(x => x.ext4).ToList();
                GridFreelancerForBranch.DataSource = result;
                GridFreelancerForBranch.DataBind();
            }

            if (GridFreelancerForBranch.Rows.Count > 0)
            {
                GridFreelancerForBranch.UseAccessibleHeader = true;
                GridFreelancerForBranch.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridFreelancerForBranch.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        protected void BtnMap_Click(object sender, EventArgs e)
        {
            Button Btn = (Button)sender;
            Response.Redirect($"MapFreelancerToEmpMarketEmp.aspx?id={Btn.CommandArgument}");
        }
    }
}