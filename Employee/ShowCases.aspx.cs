using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Employee
{
    public partial class ShowCases : System.Web.UI.Page
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

            var result = oDataAccess.QuerySPDynamic<Case_Add>("sp_getcasesby_empid", parameters);
            if (result != null)
            {
                result = result.Where(x => !x.Status.Contains("Disbursed") && !x.Status.Contains("Rejected") && !x.Status.Contains("Denied"));
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
        protected void btedt_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Response.Redirect($"AddCase.aspx?id={button.CommandArgument}");
        }

        protected void btndel_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            var parameters = new DynamicParameters();
            parameters.Add("Id", button.CommandArgument);

            oDataAccess.ExecuteSPDynamic("sp_delete_case", parameters);
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Deleted');window.location.href='ShowCases.aspx';", true);
        }
        protected void BtnCaseStatus_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow row = (GridViewRow)button.NamingContainer;
            Label lblAmountReq = (Label)row.FindControl("lblAmountReq");
            Response.Redirect($"EditCaseStatus.aspx?id={button.CommandArgument}&pgtyp=0&amt={lblAmountReq.Text}");
        }

        protected void BtnCaseHistory_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            var parameters = new DynamicParameters();
            parameters.Add("CaseId", button.CommandArgument);

            var result = oDataAccess.QuerySPListDynamic<Case_Status_History>("sp_getcasehistory_bycaseid", parameters);
            if (result != null)
            {
                GridCaseHistory.DataSource = result;
                GridCaseHistory.DataBind();

                ShowModalPopup();
            }
        }
        protected void ShowModalPopup()
        {
            hdnShowModal.Value = "1";
        }
    }
}