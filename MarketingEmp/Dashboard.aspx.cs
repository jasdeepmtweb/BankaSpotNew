using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.MarketingEmp
{
    public partial class Dashboard : System.Web.UI.Page
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["memp"] == null)
            {
                Response.Redirect("../MarketingEmpLogin.aspx");
            }
            if (!IsPostBack)
            {
                Marketing_Employee_Add oMarketing_Employee_Add = Session["memp"] as Marketing_Employee_Add;
                lblName.Text = oMarketing_Employee_Add.Name;

                GetDashboardData();
            }
            if (GridCase.Rows.Count > 0)
            {
                GridCase.UseAccessibleHeader = true;
                GridCase.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridCase.FooterRow.TableSection = TableRowSection.TableFooter;
            }

        }

        private void GetDashboardData()
        {
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            Marketing_Employee_Add oMarketing_Employee_Add = Session["memp"] as Marketing_Employee_Add;

            var parameters = new DynamicParameters();
            parameters.Add("UserId", oMarketing_Employee_Add.Id);
            parameters.Add("UserType", "MEMP");
            DataAccess oDataAccess = new DataAccess();
            var payoutsList = oDataAccess.QuerySPListDynamic<Payouts_Add>("sp_getpayoutsby_useridtype", parameters);

            lblTotalIncentiveAmount.Text = payoutsList.Sum(x => x.PayAmount).ToString();

            var groupedAndSummedData = payoutsList.GroupBy(item => item.PayDate.Month)
                .Select(group => new
                {
                    GroupingKey = group.Key,
                    SummedValue = group.Sum(item => item.PayAmount),
                    Month = group.FirstOrDefault().PayDate.ToString("MMMM-yyyy")
                })
            .ToList();
            GridCase.DataSource = groupedAndSummedData;
            GridCase.DataBind();

            parameters = new DynamicParameters();
            parameters.Add("p_MarketingEmpId", oMarketing_Employee_Add.Id);
            var allCases = oDataAccess.QuerySPListDynamic<Case_Add>("sp_getcasesfor_marketingemp", parameters);

            lblTotalCases.Text = allCases.Count.ToString();
            lblPendingCases.Text = allCases.Where(x => !x.Status.Contains("Disbursed") && !x.Status.Contains("Rejected") && !x.Status.Contains("Denied")).ToList().Count.ToString();
            lblRejectedCases.Text = allCases.Where(x => x.Status.Contains("Rejected") || x.Status.Contains("Denied")).ToList().Count.ToString();
            lblTodaysCases.Text = allCases.Where(x => x.CreatedOn.ToString("yyyy-MM-dd").Equals(indianTime.ToString("yyyy-MM-dd"))).ToList().Count.ToString();
            lblCompletedCases.Text = allCases.Where(x => x.Status.Contains("Disbursed")).ToList().Count.ToString();
        }
    }
}