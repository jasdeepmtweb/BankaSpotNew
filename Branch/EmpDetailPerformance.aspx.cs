using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Branch
{
    public partial class EmpDetailPerformance : System.Web.UI.Page
    {
        //static List<Employee_Target> employee_Targets = new List<Employee_Target>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["branch"] == null)
            {
                Response.Redirect("../BranchLogin.aspx");
            }
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("EmployeePerformanceReport.aspx");
            }
            if (!IsPostBack)
            {
                BindGrid(Convert.ToInt32(Request.QueryString["id"]));
            }
        }
        private void BindGrid(int id)
        {
            //employee_Targets.Clear();

            var parameters = new DynamicParameters();
            parameters.Add("Empid", id);
            DataAccess oDataAccess = new DataAccess();
            var newResult = oDataAccess.QuerySPListDynamic<Employee_Target>("sp_gettargetfor_employee", parameters);
            if (newResult != null)
            {
                //foreach (var item in newResult)
                //{
                //    Employee_Target oEmployee_Target = new Employee_Target();
                //    oEmployee_Target.Id = item.Id;
                //    oEmployee_Target.Proid = item.Proid;
                //    oEmployee_Target.Empid = item.Empid;
                //    oEmployee_Target.EmpTarget = item.EmpTarget;
                //    oEmployee_Target.ProductName = item.ProductName;
                //    oEmployee_Target.ext1 = item.ext1;
                //    oEmployee_Target.AddedOn = item.AddedOn;

                //    item.CaseList = GetTargetAchieved(id, item.Proid, item.AddedOn);

                //    oEmployee_Target.ext5 = item.CaseList.Sum(x => Convert.ToInt32(x.ext5));
                //    oEmployee_Target.ShortFall = oEmployee_Target.EmpTarget - oEmployee_Target.ext5;
                //    employee_Targets.Add(oEmployee_Target);
                //}

                for (int i = 0; i < newResult.Count; i++)
                {
                    parameters = new DynamicParameters();
                    parameters.Add("p_ProductId", newResult[i].Proid);
                    parameters.Add("p_EmpId", newResult[i].Empid);
                    var amountAndDate = oDataAccess.QuerySPListDynamic<EmployeeProductWiseTargetModel>("sp_gettargetachievedbyemp", parameters);
                    newResult[i].TargetAchieved = amountAndDate.Where(x => x.DisbursedDate.ToString("yyyy-MM").Equals(newResult[i].AddedOn.ToString("yyyy-MM"))).Sum(x => x.DisbursedAmount);

                    newResult[i].ShortFall = newResult[i].EmpTarget - newResult[i].TargetAchieved;
                }

                GridPerformanceReport.DataSource = newResult;
                GridPerformanceReport.DataBind();
            }
            double SumTarget = newResult.Sum(p => p.EmpTarget);
            double SumTargetCompleted = newResult.Sum(p => p.TargetAchieved);

            lblTotalTarget.Text = SumTarget.ToString();
            lblTotalTargetAchieved.Text = SumTargetCompleted.ToString();
            lblTotalShortfall.Text = newResult.Sum(x => x.ShortFall).ToString();

            lblTotalAchievement.Text = $"{Math.Round((SumTargetCompleted / SumTarget) * 100, 2)}%";
        }
        private List<Case_Add> GetTargetAchieved(int empId, int proid, DateTime addedOn)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Empid", empId);
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPListDynamic<Case_Add>("sp_getcasesby_empid", parameters);
            result = result.Where(c => c.Status.Contains("Disbursed") && c.ProductReq == proid).ToList();

            for (int i = 0; i < result.Count; i++)
            {
                parameters = new DynamicParameters();
                parameters.Add("CaseId", result[i].Id);

                var CaseHistory = oDataAccess.QuerySPListDynamic<Case_Status_History>("sp_getcasehistory_bycaseid", parameters);

                if (CaseHistory != null && CaseHistory.Count > 0)
                {
                    if (addedOn.ToString("MM-yyyy").Equals(CaseHistory.FirstOrDefault().DateAdded.ToString("MM-yyyy")) && CaseHistory.FirstOrDefault().NewStatus.Contains("Disbursed"))
                    {

                    }
                    else
                    {
                        result.RemoveAt(i);
                    }
                }
            }
            return result;
        }
    }
}