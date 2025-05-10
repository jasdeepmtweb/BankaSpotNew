using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Admin
{
    public partial class MapConnectorToBranch : System.Web.UI.Page
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
                Response.Redirect("ConnectorsListForMapping.aspx");
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

            var res = oDataAccess.QuerySingleOrDefaultSPDynamic<Connector_Add>("sp_getconnectorby_id", parameters);
            if (res != null)
            {
                lblCurrentBranch.Text = res.BranchName;
                lblOldEmpId.Text = res.EmployeeId.ToString();
                lblOldMarketEmpId.Text = res.MarketEmpId.ToString();
                lblOldBranchId.Text = res.BranchId.ToString();
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
                        parameters.Add("p_EmployeeId", 0);
                        parameters.Add("p_MarketEmpId", 0);
                        parameters.Add("p_Id", Request.QueryString["id"]);

                        oDataAccess.ExecuteSPDynamic("sp_mapconnectorto_branch", parameters);

                        parameters = new DynamicParameters();
                        parameters.Add("p_ConnectorId", Request.QueryString["id"]);
                        parameters.Add("p_MappingDate", indianTime);
                        parameters.Add("p_OldBranchId", lblOldBranchId.Text);
                        parameters.Add("p_OldEmpId", lblOldEmpId.Text);
                        parameters.Add("p_OldMarketEmpId", lblOldMarketEmpId.Text);
                        parameters.Add("p_NewBranchId", ddlBranch.SelectedValue);
                        parameters.Add("p_NewEmpId", 0);
                        parameters.Add("p_NewMarketEmpId", 0);
                        parameters.Add("p_MappedBy", "Admin");

                        oDataAccess.ExecuteSPDynamic("sp_insertconmaphistory", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated');window.location.href='ConnectorsListForMapping.aspx';", true);
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