using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Admin
{
    public partial class TransferCaseToBranch : System.Web.UI.Page
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("../BranchLogin.aspx");
            }
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("ShowAllCases.aspx");
            }
            if (!IsPostBack)
            {
                GetAllBranches();
            }
        }
        private void GetAllBranches()
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", Request.QueryString["id"]);

            var res = oDataAccess.QuerySingleOrDefaultSPDynamic<Case_Add>("sp_getcaseby_id", parameters);
            if (res != null)
            {
                lblCurrentBranch.Text = res.BranchName;
                lblOldEmpId.Text = res.EmpId.ToString();
                lblOldMarketEmpId.Text = res.ext4.ToString();
                lblOldBranchId.Text = res.BranchId.ToString();
                lblOldConnectorId.Text = res.ConnectorId.ToString();
                lblOldFreelancerId.Text = res.ext3;
            }

            var branches = oDataAccess.QuerySPListDynamic<Branch_Add>("sp_getallbranches");
            ddlBranch.DataSource = branches;
            ddlBranch.DataTextField = "BranchName";
            ddlBranch.DataValueField = "Id";
            ddlBranch.DataBind();
            ddlBranch.Items.Insert(0, new ListItem("---Select---", "0"));
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
                        parameters.Add("p_BranchId", ddlBranch.SelectedValue);
                        parameters.Add("p_ConnectorId", 0);
                        parameters.Add("p_EmpId", 0);
                        parameters.Add("p_ext3", 0);
                        parameters.Add("p_ext4", 0);
                        parameters.Add("p_Id", Request.QueryString["id"]);

                        oDataAccess.ExecuteSPDynamic("sp_update_casebranchid", parameters);

                        parameters = new DynamicParameters();
                        parameters.Add("p_CaseId", Request.QueryString["id"]);
                        parameters.Add("p_CreatedOn", indianTime);
                        parameters.Add("p_PreBranchId", lblOldBranchId.Text);
                        parameters.Add("p_PreEmpId", lblOldEmpId.Text);
                        parameters.Add("p_PreConnectorId", lblOldConnectorId.Text);
                        parameters.Add("p_PreFreelancerId", lblOldFreelancerId.Text);
                        parameters.Add("p_PreMarketEmpId", lblOldMarketEmpId.Text);
                        parameters.Add("p_NewBranchId", ddlBranch.SelectedValue);

                        oDataAccess.ExecuteSPDynamic("sp_insert_branchcasehistory", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated');window.location.href='ShowAllCases.aspx';", true);
                    }
                }
                catch (Exception ex)
                {
                    var errorLogger = new Log("ErrorLog.txt");
                    errorLogger.LogError(ex);
                }
            }
        }
    }
}