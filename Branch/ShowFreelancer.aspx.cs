using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Branch
{
    public partial class ShowFreelancer : System.Web.UI.Page
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
                foreach (var item in result)
                {
                    item.FreelancerPic = $"../Uploads/FreelancerPics/{item.FreelancerPic}";
                }
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

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Response.Redirect($"AddFreelancer.aspx?id={button.CommandArgument}");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            var parameters = new DynamicParameters();
            parameters.Add("p_Id", button.CommandArgument);
            DataAccess oDataAccess = new DataAccess();
            oDataAccess.ExecuteSPDynamic("sp_delete_freelancer", parameters);

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Deleted');window.location.href='ShowFreelancer.aspx';", true);
        }

        protected void BtnActivate_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            var parameters = new DynamicParameters();
            parameters.Add("p_Id", button.CommandArgument);
            parameters.Add("p_ext4", 1);

            DataAccess oDataAccess = new DataAccess();
            oDataAccess.ExecuteSPDynamic("sp_update_freelancerstatus", parameters);

            Branch_Add oBranch_Add = Session["branch"] as Branch_Add;
            BindGrid(oBranch_Add.Id);
        }

        protected void BtnInactive_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            var parameters = new DynamicParameters();
            parameters.Add("p_Id", button.CommandArgument);
            parameters.Add("p_ext4", 0);

            DataAccess oDataAccess = new DataAccess();
            oDataAccess.ExecuteSPDynamic("sp_update_freelancerstatus", parameters);

            Branch_Add oBranch_Add = Session["branch"] as Branch_Add;
            BindGrid(oBranch_Add.Id);
        }

        protected void BtnUpdateDocs_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            Response.Redirect($"UpdateFreelancerDocs.aspx?id={button.CommandArgument}");
        }

        protected void BtnProPayout_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            Response.Redirect($"AddFreelancerProductPayout.aspx?id={button.CommandArgument}");
        }
    }
}