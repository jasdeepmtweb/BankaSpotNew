using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Employee
{
    public partial class ShowPayouts : System.Web.UI.Page
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
            parameters.Add("UserId", id);
            parameters.Add("UserType", "Employee");
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPDynamic<Payouts_Add>("sp_getpayoutsby_useridtype", parameters);
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
        protected void btedt_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            var parameters = new DynamicParameters();
            parameters.Add("Id", button.CommandArgument);
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySingleOrDefaultSPDynamic<Case_Add>("sp_getcaseby_id", parameters);

            if (result != null)
            {
                lblAddress.Text = result.Address;
                lblAmountRequired.Text = "" + result.AmountReq;
                lblCity.Text = result.City;
                //lblConnector.Text = result.ConnectorName;
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
        }
    }
}