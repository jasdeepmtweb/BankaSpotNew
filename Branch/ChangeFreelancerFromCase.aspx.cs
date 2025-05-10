using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Branch
{
    public partial class ChangeFreelancerFromCase : System.Web.UI.Page
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["branch"] == null)
            {
                Response.Redirect("../BranchLogin.aspx");
            }
            if (!IsPostBack)
            {
                Branch_Add oBranch_Add = Session["branch"] as Branch_Add;

                if (Request.QueryString["id"] != null)
                {
                    BindGrid(oBranch_Add.Id);
                }
            }
        }
        private void BindGrid(int Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_BranchId", Id);
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPDynamic<Freelancer_Add>("sp_getallfreelancersby_branchid", parameters);
            ddlFreelancer.DataSource = result;
            ddlFreelancer.DataTextField = "Name";
            ddlFreelancer.DataValueField = "Id";
            ddlFreelancer.DataBind();
            ddlFreelancer.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                    if (Request.QueryString["id"] != null)
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("p_FreelancerId", ddlFreelancer.SelectedValue);
                        parameters.Add("p_Id", Request.QueryString["id"]);

                        DataAccess oDataAccess = new DataAccess();
                        oDataAccess.ExecuteSPDynamic("sp_update_freelancer_case", parameters);

                        parameters = new DynamicParameters();
                        parameters.Add("p_CaseId", Request.QueryString["id"]);
                        parameters.Add("p_FreelancerId", ddlFreelancer.SelectedValue);
                        parameters.Add("p_EmployeeId", Request.QueryString["eid"]);
                        parameters.Add("p_CreatedOn", indianTime);

                        oDataAccess.ExecuteSPDynamic("sp_insert_freelancercasehistory", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added');window.location.href='CasesFromFreelancers.aspx';", true);
                    }
                }
                catch (Exception ex)
                {
                    var errorLogger = new Log("ErrorLog.txt");
                    errorLogger.LogError(ex);
                    if (ex.Message.Contains("Duplicate"))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Mobile No. Already Exists');", true);
                    }
                }
            }
        }
    }
}