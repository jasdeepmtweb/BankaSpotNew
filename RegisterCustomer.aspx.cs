using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankaSpotNew
{
    public partial class RegisterCustomer : System.Web.UI.Page
    {
        DataAccess oDataAccess = new DataAccess();
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllBranches();
            }
        }

        private void GetAllBranches()
        {
            var branches = oDataAccess.QuerySPListDynamic<Branch_Add>("sp_getallbranches");
            ddlLocation.DataSource = branches;
            ddlLocation.DataTextField = "BranchName";
            ddlLocation.DataValueField = "Id";
            ddlLocation.DataBind();
            ddlLocation.Items.Insert(0, new ListItem("Select", "0"));
        }

        protected void ShowSweetAlert()
        {
            // Execute JavaScript code to show the SweetAlert and redirect after it is dismissed
            string script = @"
        Swal.fire({
            title: 'Success!',
            text: 'Successfully Registered',
            icon: 'success',
        }).then((result) => {
            if (result.isConfirmed || result.isDismissed) {
                window.location.href = 'RegisterCustomer.aspx';
            }
        });
    ";

            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "showSweetAlert", script, true);
        }
        protected void BtnSignUp_Click(object sender, EventArgs e)
        {
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_CustomerName", txtName.Text);
                parameters.Add("p_CustomerMobileNo", txtMobileNo.Text);
                parameters.Add("p_City", txtCity.Text);
                parameters.Add("p_Address", "-");
                parameters.Add("p_BranchId", ddlLocation.SelectedValue);
                parameters.Add("p_CreatedOn", indianTime);
                parameters.Add("p_EmailId", "-");
                parameters.Add("p_IsLoanAgent", 0);
                parameters.Add("p_Status", 1);
                parameters.Add("p_Password", txtPassword.Text);
                if (Request.QueryString["id"] != null && !Request.QueryString["id"].ToString().Equals(""))
                {
                    parameters.Add("p_ReferId", Request.QueryString["id"]);
                }
                else
                {
                    parameters.Add("p_ReferId", 0);
                }

                if (Request.QueryString["reftyp"] != null && !Request.QueryString["reftyp"].ToString().Equals(""))
                {
                    if (Request.QueryString["reftyp"].ToString().Equals("con"))
                    {
                        parameters.Add("p_ReferIdType", "Connector");
                    }
                    else
                    {
                        parameters.Add("p_ReferIdType", "-");
                    }
                }
                else
                {
                    parameters.Add("p_ReferIdType", "-");
                }
                parameters.Add("p_Type", "Customer");
                oDataAccess.ExecuteSPDynamic("sp_insert_customer", parameters);

                ShowSweetAlert();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "showSweetAlert", "Swal.fire('Error!', 'Mobile No. Already Exists!', 'warning');", true);
                }
                var errorLogger = new Log("ErrorLog.txt");
                errorLogger.LogError(ex);
            }
        }
    }
}