using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Branch
{
    public partial class ShowMarketingEmp : System.Web.UI.Page
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
            if (GridEmployee.Rows.Count > 0)
            {
                GridEmployee.UseAccessibleHeader = true;
                GridEmployee.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridEmployee.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void BindGrid(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_BranchId", id);

            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPListDynamic<Marketing_Employee_Add>("sp_getall_marketingemp", parameters);
            if (result != null)
            {
                result = result.Where(x => x.EmployeeStatus.Equals("1")).ToList();
                //result.ForEach(x =>
                //{
                //    try
                //    {
                //        x.DateOfJoining = Convert.ToDateTime(x.DateOfJoining).ToString("dd/MM/yyyy");
                //    }
                //    catch (Exception)
                //    {

                //    }
                //});
                result = result.OrderByDescending(x => x.EmployeeStatus).ToList();
                GridEmployee.DataSource = result;
                GridEmployee.DataBind();
            }
            if (GridEmployee.Rows.Count > 0)
            {
                GridEmployee.UseAccessibleHeader = true;
                GridEmployee.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridEmployee.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Response.Redirect($"AddMarketingEmp.aspx?id={button.CommandArgument}");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            //Button button = (Button)sender;

            //var parameters = new
            //{
            //    Id = button.CommandArgument
            //};
            //DataAccess oDataAccess = new DataAccess();
            //oDataAccess.ExecuteSPDynamic("sp_delete_employee", parameters);

            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Deleted');window.location.href='ShowMarketingEmp.aspx';", true);
        }

        protected void BtnActivate_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            var parameters = new DynamicParameters();
            parameters.Add("p_Id", button.CommandArgument);
            parameters.Add("p_ext1", 1);

            DataAccess oDataAccess = new DataAccess();
            oDataAccess.ExecuteSPDynamic("sp_update_markempstatus", parameters);

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

            DataAccess oDataAccess = new DataAccess();
            oDataAccess.ExecuteSPDynamic("sp_update_markempstatus", parameters);

            Branch_Add oBranch_Add = Session["branch"] as Branch_Add;
            BindGrid(oBranch_Add.Id);
        }
    }
}