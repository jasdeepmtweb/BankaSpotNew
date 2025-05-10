using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Linq;

namespace BankaSpotNew.Branch
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["branch"] == null)
            {
                Response.Redirect("../BranchLogin.aspx");
            }
            if (!IsPostBack)
            {
                GetDashBoardData();
            }
        }

        private void GetDashBoardData()
        {
            Branch_Add oBranch_Add = Session["branch"] as Branch_Add;

            var parameters = new DynamicParameters();
            parameters.Add("BranchId", oBranch_Add.Id);
            DataAccess oDataAccess = new DataAccess();
            var resultSets = oDataAccess.QueryMultipleSPDynamicBranch<Employee_Dashboard>("sp_branch_dashboard", parameters);
            if (resultSets != null)
            {
                lblCompletedCases.Text = resultSets.TotalCasesCompleted == null ? "-" : resultSets.TotalCasesCompleted.ToString();
                lblPendingCases.Text = resultSets.TotalCasesPending == null ? "-" : resultSets.TotalCasesPending.ToString();
                lblRejectedCases.Text = resultSets.TotalCasesRejected == null ? "-" : resultSets.TotalCasesRejected.ToString();
                lblTotalCases.Text = resultSets.TotalCases == null ? "-" : resultSets.TotalCases.ToString();
                lblTodaysCases.Text = resultSets.TodaysCases == null ? "-" : resultSets.TodaysCases.ToString();

            }

            parameters = new DynamicParameters();
            parameters.Add("BranchId", oBranch_Add.Id);
            oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPDynamic<Employee_Target>("sp_getempperformance_rep_forbranch", parameters);
            double SumTarget = result.Sum(p => p.EmpTarget);
            double SumTargetCompleted = result.Sum(p => p.ext5);
            double TotalShortFall = result.Sum(p => p.ShortFall);

            lblTotalTarget.Text = SumTarget.ToString();
            lblTotalTargetAchieved.Text = SumTargetCompleted.ToString();
            lblTotalShortFall.Text = TotalShortFall.ToString();
        }
    }
}
