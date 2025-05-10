using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Employee
{
    public partial class CasesFromFreelancer : System.Web.UI.Page
    {
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
            var result = oDataAccess.QuerySPDynamic<Case_Add>("sp_getcasesfromfreelancer_forEmp", parameters);
            if (result != null)
            {
                result = result.Where(x => !x.Status.Contains("Disbursed") && !x.Status.Contains("Rejected"));
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

            var parameters = new DynamicParameters();
            parameters.Add("Id", button.CommandArgument);
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySingleOrDefaultSPDynamic<Case_Add>("sp_getcasedetails_freelancer", parameters);

            if (result != null)
            {
                lblAddress.Text = result.Address;
                lblAmountRequired.Text = "" + result.AmountReq;
                lblCity.Text = result.City;
                lblConnector.Text = result.ConnectorName;
                lblMobile.Text = result.MobileNo;
                lblMonthlyIncome.Text = result.MonthlyIncome;
                lblName.Text = result.Name;
                lblProfile.Text = result.CustomerProfile;
                lblProReq.Text = result.ProductName;

                ShowModalPopup();
            }
        }
        protected void ShowModalPopup()
        {
            hdnShowModal.Value = "1";
            hdnShowHistoryModal.Value = "0";
        }
        protected void ShowHistoryModalPopup()
        {
            hdnShowModal.Value = "0";
            hdnShowHistoryModal.Value = "1";
        }
        protected void BtnCaseStatus_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow row = (GridViewRow)button.NamingContainer;
            Label lblAmountReq = (Label)row.FindControl("lblAmountReq");
            Response.Redirect($"EditCaseStatus.aspx?id={button.CommandArgument}&pgtyp=2&amt={lblAmountReq.Text}");
        }
        protected void BtnCaseHistory_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            var parameters = new DynamicParameters();
            parameters.Add("CaseId", button.CommandArgument);
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPDynamic<Case_Status_History>("sp_getcasehistory_bycaseid", parameters);
            if (result != null)
            {
                GridCaseHistory.DataSource = result;
                GridCaseHistory.DataBind();

                ShowHistoryModalPopup();
            }
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Response.Redirect($"EditCase.aspx?id={button.CommandArgument}&typ=freelancer");
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            var parameters = new DynamicParameters();
            parameters.Add("Id", button.CommandArgument);
            DataAccess oDataAccess = new DataAccess();
            oDataAccess.ExecuteSPDynamic("sp_delete_case", parameters);
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Deleted');window.location.href='CasesFromFreelancer.aspx';", true);
        }
    }
}