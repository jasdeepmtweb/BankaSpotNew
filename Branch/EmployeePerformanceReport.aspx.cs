using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Branch
{
    public partial class EmployeePerformanceReport : System.Web.UI.Page
    {
        static List<Employee_Target> employee_Targets = new List<Employee_Target>();
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

            //if (GridPerformanceReport.Rows.Count > 0)
            //{
            //    GridPerformanceReport.UseAccessibleHeader = true;
            //    GridPerformanceReport.HeaderRow.TableSection = TableRowSection.TableHeader;
            //    GridPerformanceReport.FooterRow.TableSection = TableRowSection.TableFooter;
            //}
        }
        private void BindGrid(int id)
        {
            employee_Targets.Clear();

            var parameters = new DynamicParameters();
            parameters.Add("BranchId", id);
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPListDynamic<Employee_Target>("sp_getempperformance_rep_forbranch", parameters);
            if (result != null)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    parameters = new DynamicParameters();
                    parameters.Add("EmpId", result[i].Empid);
                    //var caseDetail = oDataAccess.QuerySPListDynamic<Case_Add>("sp_getallcaselist_foremp", parameters);

                    //caseDetail = caseDetail.Where(x => x.CreatedOn.ToString("yyyy-MM-dd").Equals(result[i].AddedOn.ToString("yyyy-MM-dd"))).ToList();

                    //result[i].ext5 = caseDetail.Sum(x => Convert.ToDouble(x.ext5));
                    //result[i].ShortFall = result[i].EmpTarget - result[i].ext5;
                    parameters = new DynamicParameters();
                    parameters.Add("p_ProductId", result[i].Proid);
                    parameters.Add("p_EmpId", result[i].Empid);
                    var amountAndDate = oDataAccess.QuerySPListDynamic<EmployeeProductWiseTargetModel>("sp_gettargetachievedbyemp", parameters);
                    result[i].TargetAchieved = amountAndDate.Where(x => x.DisbursedDate.ToString("yyyy-MM").Equals(result[i].AddedOn.ToString("yyyy-MM"))).Sum(x => x.DisbursedAmount);
                    result[i].ShortFall = result[i].EmpTarget - result[i].TargetAchieved;
                }
                employee_Targets = result.ToList();

                GridPerformanceReport.DataSource = employee_Targets;
                GridPerformanceReport.DataBind();
            }
            double SumTarget = result.Sum(p => p.EmpTarget);
            double SumTargetCompleted = result.Sum(p => p.TargetAchieved);

            lblTotalAchievement.Text = $"{Math.Round((SumTargetCompleted / SumTarget) * 100, 2)}%";

            //if (GridPerformanceReport.Rows.Count > 0)
            //{
            //    GridPerformanceReport.UseAccessibleHeader = true;
            //    GridPerformanceReport.HeaderRow.TableSection = TableRowSection.TableHeader;
            //    GridPerformanceReport.FooterRow.TableSection = TableRowSection.TableFooter;
            //}
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            List<Employee_Target> EmpTargetList = new List<Employee_Target>();


            //if (!string.IsNullOrEmpty(txtEmployeeName.Text))
            //{
            //    EmpTargetList = employee_Targets.Where(p => p.EmployeeName.ToLower().Contains(txtEmployeeName.Text.ToLower())).ToList();
            //}
            //if (!string.IsNullOrEmpty(txtMonthYear.Text))
            //{
            //    EmpTargetList = employee_Targets.Where(p => p.ext1.ToLower().Contains(txtMonthYear.Text.ToLower())).ToList();
            //}

            if (EmpTargetList.Count == 0 || EmpTargetList == null)
            {
                EmpTargetList = employee_Targets;

                GridPerformanceReport.DataSource = EmpTargetList;
                GridPerformanceReport.DataBind();
            }
            else
            {
                GridPerformanceReport.DataSource = EmpTargetList;
                GridPerformanceReport.DataBind();
            }


            double SumTarget = EmpTargetList.Sum(p => p.EmpTarget);
            double SumTargetCompleted = EmpTargetList.Sum(p => p.ext5);

            lblTotalAchievement.Text = $"{Math.Round((SumTargetCompleted / SumTarget) * 100, 2)}%";
        }

        protected void BtnDetail_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Response.Redirect($"EmpDetailPerformance.aspx?id={button.CommandArgument}");
        }
    }
}