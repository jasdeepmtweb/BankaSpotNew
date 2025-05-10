using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Employee
{
    public partial class ShowRejectedCases : System.Web.UI.Page
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
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
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPDynamic<Case_Add>("sp_getallcaselist_foremp", parameters);
            if (result != null)
            {
                result = result.Where(x => x.Status.Contains("Rejected") || x.Status.Contains("Denied"));
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

        protected void BtnRelogin_Click(object sender, EventArgs e)
        {
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

            Button button = sender as Button;

            var parameters = new DynamicParameters();
            parameters.Add("CaseId", button.CommandArgument);
            parameters.Add("EmpId", 0);
            parameters.Add("NewStatus", "ReLogin");
            parameters.Add("PreStatus", "Rejected");
            parameters.Add("CaseFile", "-");
            parameters.Add("Remarks", "ReLogin By Employee");
            parameters.Add("DateAdded", indianTime);
            parameters.Add("ext1", "-");
            parameters.Add("ext2", 0);
            parameters.Add("ext3", "-");

            DataAccess oDataAccess = new DataAccess();
            oDataAccess.ExecuteSPDynamic("sp_insert_casestatushistory", parameters);

            parameters = new DynamicParameters();
            parameters.Add("Id", button.CommandArgument);
            parameters.Add("Status", "ReLogin");
            parameters.Add("Remarks", "ReLogin By Employee");
            parameters.Add("ext5", 0);
            parameters.Add("ext6", 0);
            parameters.Add("ext2", 0);
            oDataAccess.ExecuteSPDynamic("sp_update_casestatus", parameters);

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated');window.location.href='ShowRejectedCases.aspx';", true);
        }
    }
}