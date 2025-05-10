using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Employee
{
    public partial class ShowTrancheCases : System.Web.UI.Page
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
            parameters.Add("p_EmpId", id);

            var result = oDataAccess.QuerySPListDynamic<Case_Add>("sp_gettranchecaselist_foremp", parameters);
            if (result != null)
            {
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

        protected void BtnUpdateStatus_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            Response.Redirect($"EditTrancheStatus.aspx?id={btn.CommandArgument}");
        }
    }
}