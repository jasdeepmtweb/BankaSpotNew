using BankaSpotNew.App_Code;
using Newtonsoft.Json;
using System;
using System.Web.UI;

namespace BankaSpotNew.Admin
{
    public partial class AddRegion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("../BranchLogin.aspx");
            }
            if (!IsPostBack)
            {
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
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySingleOrDefaultSP<Region_Add>("sp_getregionby_id", parameters);
            if (result != null)
            {
                txtRegionIdNo.Text = result.RegionIdNo;
                txtRegionName.Text = result.RegionName;
                txtRegionalManagerName.Text = result.RegionalManager;
                txtRegionLocation.Text = result.RegionLocation;
                txtRegionAddress.Text = result.RegionAddress;
                txtRegionMonthTarget.Text = result.RegionMonthTarget;
                txtRegionProTarget.Text = result.RegionProTarget;
                txtRegionMobileNo.Text = result.RegionMobileNumber;
                txtRegionPassword.Text = result.RegionPassword;

                divMob.Visible = false;
                divPassword.Visible = false;
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (Request.QueryString["id"] == null)
                    {
                        var parameters = new
                        {
                            RegionIdNo = txtRegionIdNo.Text,
                            RegionName = txtRegionName.Text,
                            RegionalManager = txtRegionalManagerName.Text,
                            RegionLocation = txtRegionLocation.Text,
                            RegionAddress = txtRegionAddress.Text,
                            RegionMonthTarget = txtRegionMonthTarget.Text,
                            RegionProTarget = txtRegionProTarget.Text,
                            RegionMobileNumber = txtRegionMobileNo.Text,
                            RegionPassword = txtRegionPassword.Text,
                        };
                        DataAccess oDataAccess = new DataAccess();
                        oDataAccess.ExecuteSP("sp_insert_region", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added');window.location.href='AddRegion.aspx';", true);
                    }
                    else
                    {
                        var parameters = new
                        {
                            RegionIdNo = txtRegionIdNo.Text,
                            RegionName = txtRegionName.Text,
                            RegionalManager = txtRegionalManagerName.Text,
                            RegionLocation = txtRegionLocation.Text,
                            RegionAddress = txtRegionAddress.Text,
                            RegionMonthTarget = txtRegionMonthTarget.Text,
                            RegionProTarget = txtRegionProTarget.Text,
                            Id = Request.QueryString["id"]
                        };
                        DataAccess oDataAccess = new DataAccess();
                        oDataAccess.ExecuteSP("sp_update_region", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated');window.location.href='ShowRegion.aspx';", true);
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