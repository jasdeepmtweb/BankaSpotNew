using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Branch
{
    public partial class FreelancerCaseCount : System.Web.UI.Page
    {
        static List<Freelancer_Add> allCases = new List<Freelancer_Add>();
        DataAccess oDataAccess = new DataAccess();
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
            if (GridShowConnector.Rows.Count > 0)
            {
                GridShowConnector.UseAccessibleHeader = true;
                GridShowConnector.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridShowConnector.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void BindGrid(int id)
        {
            //string sql = "SELECT a.Name,a.MobileNo,COALESCE(COUNT(b.ext3), 0) AS CaseCount,a.Id,a.CreatedOn FROM tbfreelancer a LEFT JOIN tbcase b ON a.Id = b.ext3 AND a.BranchId=@p_BranchId GROUP BY a.Id ORDER BY CaseCount DESC;";
            allCases.Clear();
            var parameters = new DynamicParameters();
            parameters.Add("p_BranchId", id);

            var result = oDataAccess.QuerySPListDynamic<Freelancer_Add>("sp_getactiveinactive_freelancers", parameters);

            GridShowConnector.DataSource = result;
            GridShowConnector.DataBind();
            allCases = result;
            if (GridShowConnector.Rows.Count > 0)
            {
                GridShowConnector.UseAccessibleHeader = true;
                GridShowConnector.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridShowConnector.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            Branch_Add oBranch_Add = Session["branch"] as Branch_Add;

            //string sql = "SELECT a.Name,a.MobileNo,COALESCE(COUNT(b.ext3), 0) AS CaseCount,a.Id,a.CreatedOn FROM tbfreelancer a LEFT JOIN tbcase b ON a.Id = b.ext3 AND (date(b.CreatedOn) BETWEEN @p_FromDate AND @p_ToDate) AND a.BranchId=@p_BranchId GROUP BY a.Id ORDER BY CaseCount DESC;";
            //var parameters = new DynamicParameters();
            //parameters.Add("p_BranchId", oBranch_Add.Id);
            //parameters.Add("p_FromDate", txtFromDate.Text);
            //parameters.Add("p_ToDate", txtToDate.Text);
            //DataAccess oDataAccess = new DataAccess();
            //var result = oDataAccess.QueryDynamic<Freelancer_Add>(sql, parameters);
            // List<Freelancer_Add> connector_Adds = allCases.Where(x => x.CreatedOn.Date >= Convert.ToDateTime(txtFromDate.Text).Date && x.CreatedOn.Date <= Convert.ToDateTime(txtToDate.Text).Date).ToList();

            var parameters = new DynamicParameters();
            parameters.Add("p_BranchId", oBranch_Add.Id);
            parameters.Add("p_FromDate", txtFromDate.Text);
            parameters.Add("p_ToDate", txtToDate.Text);

            var result = oDataAccess.QueryDynamic<Freelancer_Add>("sp_getactiveinactive_freelancers_usingdate", parameters);

            GridShowConnector.DataSource = result;
            GridShowConnector.DataBind();

            if (GridShowConnector.Rows.Count > 0)
            {
                GridShowConnector.UseAccessibleHeader = true;
                GridShowConnector.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridShowConnector.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
}