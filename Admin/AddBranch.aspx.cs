using BankaSpotNew.App_Code;
using Dapper;
using Newtonsoft.Json;
using System;
using System.Web.UI;

namespace BankaSpotNew.Admin
{
    public partial class AddBranch : System.Web.UI.Page
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("../BranchLogin.aspx");
            }
            if (!IsPostBack)
            {
                GetData();
                if (Request.QueryString["id"] != null)
                {
                    GetDetails(Request.QueryString["id"]);
                }
            }
        }
        private void GetDetails(string Id)
        {
            var parameters = new
            {
                Id
            };
            var result = oDataAccess.QuerySingleOrDefaultSP<Branch_Add>("sp_getbranchby_id", parameters);
            if (result != null)
            {
                txtBranchIdNo.Text = result.BranchId;
                txtBranchName.Text = result.BranchName;
                txtBranchManagerName.Text = result.BranchManager;
                txtBranchLocation.Text = result.BranchLocation;
                txtBranchAddress.Text = result.BranchAddress;
                txtBranchMonthTarget.Text = result.BranchMonthTarget;
                txtBranchProTarget.Text = result.BranchProTraget;
                ddlRegion.SelectedValue = "" + result.RegionId;

                divMob.Visible = false;
                divPassword.Visible = false;
                divBranchId.Visible = true;
            }
        }
        private void GetData()
        {
            var result = oDataAccess.QuerySP<Region_Add>("sp_getallregions");
            ddlRegion.DataSource = result;
            ddlRegion.DataTextField = "RegionName";
            ddlRegion.DataValueField = "Id";
            ddlRegion.DataBind();
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

                try
                {
                    if (Request.QueryString["id"] == null)
                    {
                        string sql = "INSERT INTO tbbranch(BranchName,BranchManager,BranchLocation,BranchAddress,BranchMonthTarget,BranchProTraget,BranchMobileNo,BranchPassword,CreatedOn,Role,RegionId) VALUES (@BranchName,@BranchManager,@BranchLocation,@BranchAddress,@BranchMonthTarget,@BranchProTraget,@BranchMobileNo,@BranchPassword,@CreatedOn,@Role,@RegionId);SELECT LAST_INSERT_ID();";
                        var parameters = new
                        {
                            //BranchId = txtBranchIdNo.Text,
                            BranchName = txtBranchName.Text,
                            BranchManager = txtBranchManagerName.Text,
                            BranchLocation = txtBranchLocation.Text,
                            BranchAddress = txtBranchAddress.Text,
                            BranchMonthTarget = txtBranchMonthTarget.Text,
                            BranchProTraget = txtBranchProTarget.Text,
                            BranchMobileNo = txtBranchMobileNo.Text,
                            BranchPassword = txtBranchPassword.Text,
                            CreatedOn = indianTime,
                            Role = 0,
                            RegionId = ddlRegion.SelectedValue
                        };

                        var res = oDataAccess.QuerySingleOrDefault<int>(sql, parameters);

                        string branchId = $"{DateTime.Now:yy}{res:D6}";

                        var parameter = new DynamicParameters();
                        parameter.Add("p_BranchId", branchId);
                        parameter.Add("p_Id", res);

                        oDataAccess.ExecuteSPDynamic("sp_update_branchid", parameter);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added');window.location.href='AddBranch.aspx';", true);
                    }
                    else
                    {
                        var parameters = new
                        {
                            //BranchId = txtBranchIdNo.Text,
                            BranchName = txtBranchName.Text,
                            BranchManager = txtBranchManagerName.Text,
                            BranchLocation = txtBranchLocation.Text,
                            BranchAddress = txtBranchAddress.Text,
                            BranchMonthTarget = txtBranchMonthTarget.Text,
                            BranchProTraget = txtBranchProTarget.Text,
                            RegionId = ddlRegion.SelectedValue,
                            Id = Request.QueryString["id"]
                        };

                        oDataAccess.ExecuteSP("sp_update_branch", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated');window.location.href='ShowBranches.aspx';", true);
                    }
                }
                catch (Exception ex)
                {
                    var errorLogger = new Log("ErrorLog.txt");
                    errorLogger.LogError(ex);

                    if (ex.Message.Contains("Duplicate"))
                    {
                        //Response.Write("<script>alert('Mobile No. Already Exists')</script>");
                        var options = new
                        {
                            positionClass = "toast-top-center",
                            progressBar = true,
                            timeOut = 3000,
                            extendedTimeOut = 1000,
                            closeButton = true,
                            showMethod = "slideDown",
                            hideMethod = "slideUp",
                            showDuration = 300,
                            hideDuration = 300,
                            showEasing = "linear",
                            hideEasing = "linear",
                            tapToDismiss = false,
                            preventDuplicates = true,
                            newestOnTop = true,
                            target = "body"
                        };
                        ScriptManager.RegisterStartupScript(this, GetType(), "showtoast", $"toastr.error('Mobile No. Already Exists', null, {JsonConvert.SerializeObject(options)});", true);
                    }
                }
            }
        }
    }
}