using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Branch
{
    public partial class MapConnectorToEmp : System.Web.UI.Page
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["branch"] == null)
            {
                Response.Redirect("../BranchLogin.aspx");
            }
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("ConnectorListForMapping.aspx");
            }
            if (!IsPostBack)
            {
                GetAllData();
            }
        }

        private void GetAllData()
        {
            Branch_Add oBranch_Add = Session["branch"] as Branch_Add;

            var parameters = new DynamicParameters();
            parameters.Add("Id", Request.QueryString["id"]);

            var res = oDataAccess.QuerySingleOrDefaultSPDynamic<Connector_Add>("sp_getconnectorby_id", parameters);
            if (res != null)
            {
                lblBranch.Text = res.BranchName;
                lblOldEmpId.Text = res.EmployeeId.ToString();
                lblOldMarketEmpId.Text = res.MarketEmpId.ToString();
                lblOldBranchId.Text = res.BranchId.ToString();
                lblCurrentEmployee.Text = res.EmpName;
                lblCurrentMarketEmp.Text = res.MarketEmpName;
            }

            parameters = new DynamicParameters();
            parameters.Add("BranchId", oBranch_Add.Id);
            var employees = oDataAccess.QuerySPListDynamic<Employee_Add>("sp_getallemployee", parameters);
            ddlEmployee.DataSource = employees;
            ddlEmployee.DataTextField = "Name";
            ddlEmployee.DataValueField = "Id";
            ddlEmployee.DataBind();
            ddlEmployee.Items.Insert(0, new ListItem("---Select---", "0"));

            parameters = new DynamicParameters();
            parameters.Add("p_BranchId", oBranch_Add.Id);
            var marketemp = oDataAccess.QuerySPListDynamic<Marketing_Employee_Add>("sp_getall_marketingemp", parameters);
            ddlMarketEmployee.DataSource = marketemp;
            ddlMarketEmployee.DataTextField = "Name";
            ddlMarketEmployee.DataValueField = "Id";
            ddlMarketEmployee.DataBind();
            ddlMarketEmployee.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    Branch_Add oBranch_Add = Session["branch"] as Branch_Add;
                    DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                    if (Request.QueryString["id"] != null)
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("p_EmployeeId", ddlEmployee.SelectedValue);
                        parameters.Add("p_MarketEmpId", ddlMarketEmployee.SelectedValue);
                        parameters.Add("p_Id", Request.QueryString["id"]);

                        oDataAccess.ExecuteSPDynamic("sp_mapconnector_toempmarketemp", parameters);

                        parameters = new DynamicParameters();
                        parameters.Add("p_ConnectorId", Request.QueryString["id"]);
                        parameters.Add("p_MappingDate", indianTime);
                        parameters.Add("p_OldBranchId", lblOldBranchId.Text);
                        parameters.Add("p_OldEmpId", lblOldEmpId.Text);
                        parameters.Add("p_OldMarketEmpId", lblOldMarketEmpId.Text);
                        parameters.Add("p_NewBranchId", lblOldBranchId.Text);
                        parameters.Add("p_NewEmpId", ddlEmployee.SelectedValue);
                        parameters.Add("p_NewMarketEmpId", ddlMarketEmployee.SelectedValue);
                        parameters.Add("p_MappedBy", $"{oBranch_Add.Id}|{oBranch_Add.BranchName}");

                        oDataAccess.ExecuteSPDynamic("sp_insertconmaphistory", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated');window.location.href='ConnectorListForMapping.aspx';", true);
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