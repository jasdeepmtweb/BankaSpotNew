using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Branch
{
    public partial class ShowEmployee : System.Web.UI.Page
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
            if (GridEmployeeForBranch.Rows.Count > 0)
            {
                GridEmployeeForBranch.UseAccessibleHeader = true;
                GridEmployeeForBranch.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridEmployeeForBranch.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        private void BindGrid(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("BranchId", id);

            var result = oDataAccess.QuerySPListDynamic<Employee_Add>("sp_getallemployee", parameters);
            if (result != null)
            {
                //result = result.OrderByDescending(x => x.EmployeeStatus).ToList();
                result = result.Where(c => c.EmployeeStatus.Equals("1")).ToList();
                GridEmployeeForBranch.DataSource = result;
                GridEmployeeForBranch.DataBind();
            }
            if (GridEmployeeForBranch.Rows.Count > 0)
            {
                GridEmployeeForBranch.UseAccessibleHeader = true;
                GridEmployeeForBranch.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridEmployeeForBranch.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void btedt_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Response.Redirect($"AddEmployee.aspx?id={button.CommandArgument}");
        }

        protected void btndel_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            var parameters = new
            {
                Id = button.CommandArgument
            };
           
            oDataAccess.ExecuteSP("sp_delete_employee", parameters);
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Deleted');window.location.href='ShowEmployee.aspx';", true);
        }

        protected void BtnAddTarget_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Response.Redirect($"AddEmployeeTarget.aspx?id={button.CommandArgument}");
        }

        protected void BtnActivate_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            var parameters = new DynamicParameters();
            parameters.Add("p_Id", button.CommandArgument);
            parameters.Add("p_ext1", 1);

           
            oDataAccess.ExecuteSPDynamic("sp_update_empstatus", parameters);

            Branch_Add oBranch_Add = Session["branch"] as Branch_Add;
            BindGrid(oBranch_Add.Id);
        }

        protected void BtnInactive_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            GridViewRow row = (GridViewRow)button.NamingContainer;
            Label lblMobileNo = (Label)row.FindControl("lblMobileNo");

            var parameters = new DynamicParameters();
            parameters.Add("p_Id", button.CommandArgument);
            parameters.Add("p_MobileNo", $"{lblMobileNo.Text}_Archived_{button.CommandArgument}");
            parameters.Add("p_ext1", 0);

           
            oDataAccess.ExecuteSPDynamic("sp_update_empstatus", parameters);

            Branch_Add oBranch_Add = Session["branch"] as Branch_Add;
            BindGrid(oBranch_Add.Id);
        }
    }
}