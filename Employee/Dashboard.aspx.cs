using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Employee
{
    public partial class Dashboard : System.Web.UI.Page
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
            if (GridConnector.Rows.Count > 0)
            {
                GridConnector.UseAccessibleHeader = true;
                GridConnector.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridConnector.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void BindGrid(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("EmpID", id);

            var resultSets = oDataAccess.QueryMultipleSPDynamic<Employee_Dashboard>("sp_employee_dashboard", parameters);
            if (resultSets != null)
            {
                lblCompletedCases.Text = resultSets.TotalCasesCompleted == null ? "-" : resultSets.TotalCasesCompleted.ToString();
                lblPendingCases.Text = resultSets.TotalCasesPending == null ? "-" : resultSets.TotalCasesPending.ToString();
                lblRejectedCases.Text = resultSets.TotalCasesRejected == null ? "-" : resultSets.TotalCasesRejected.ToString();
                lblTotalCases.Text = resultSets.TotalCases == null ? "-" : resultSets.TotalCases.ToString();
                lblTotalIncentiveAmount.Text = resultSets.TotalPayout == null ? "-" : resultSets.TotalPayout.ToString();
                lblTodaysCases.Text = resultSets.TodaysCases == null ? "-" : resultSets.TodaysCases.ToString();

                GridCase.DataSource = resultSets.MonthWisePayout ?? new List<dynamic>();
                GridCase.DataBind();
            }
            if (GridCase.Rows.Count > 0)
            {
                GridCase.UseAccessibleHeader = true;
                GridCase.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridCase.FooterRow.TableSection = TableRowSection.TableFooter;
            }

            var products = oDataAccess.QuerySPDynamic<Product_Add>("sp_getallproducts");

            parameters = new DynamicParameters();
            parameters.Add("Empid", id);

            var result = oDataAccess.QuerySPListDynamic<Employee_Target>("sp_gettargetfor_employee", parameters);

            for (int i = 0; i < result.Count; i++)
            {
                var product = products.FirstOrDefault(p => p.Id == result[i].Proid);
                result[i].Incentive = Math.Round(result[i].EmpTarget * (product.EmployeeCom / 100), 2);

                parameters = new DynamicParameters();
                parameters.Add("p_ProductId", result[i].Proid);
                parameters.Add("p_EmpId", result[i].Empid);
                var amountAndDate = oDataAccess.QuerySPListDynamic<EmployeeProductWiseTargetModel>("sp_gettargetachievedbyemp", parameters);
                result[i].TargetAchieved = amountAndDate.Where(x => x.DisbursedDate.Date.ToString("yyyy-MM").Equals(result[i].AddedOn.Date.ToString("yyyy-MM"))).Sum(x => x.DisbursedAmount);
                result[i].IncentiveEarned= Math.Round(result[i].TargetAchieved * (product.EmployeeCom / 100), 2);
            }

            GridConnector.DataSource = result;
            GridConnector.DataBind();

            if (GridConnector.Rows.Count > 0)
            {
                GridConnector.UseAccessibleHeader = true;
                GridConnector.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridConnector.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
}