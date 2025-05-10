using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Connector
{
    public partial class AddSCPayout : System.Web.UI.Page
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cnt"] == null)
            {
                Response.Redirect("../ConnectorLogin.aspx");
            }
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("ShowDisbursedCases.aspx");
            }
            if (!IsPostBack)
            {
                GetAllSubconnectors();
            }
        }

        private void GetAllSubconnectors()
        {
            Connector_Add oConnector_Add = Session["cnt"] as Connector_Add;

            var parameters = new DynamicParameters();
            parameters.Add("p_Type", "SC");
            parameters.Add("p_ReferId", oConnector_Add.Id);
            parameters.Add("p_ReferIdType", "Connector");
            parameters.Add("p_Status", 1);

            var result = oDataAccess.QuerySPListDynamic<CustomerModel>("sp_getallsubconnectors_byreferid", parameters);

            ddlSubconnector.DataSource = result;
            ddlSubconnector.DataTextField = "CustomerName";
            ddlSubconnector.DataValueField = "Id";
            ddlSubconnector.DataBind();
            ddlSubconnector.Items.Insert(0, new ListItem("Select", "0"));
        }

        private void GetPayout()
        {
            Connector_Add oConnector_Add = Session["cnt"] as Connector_Add;

            lblId.Text = "";

            var parameters = new DynamicParameters();
            parameters.Add("p_CaseId", Request.QueryString["id"]);
            parameters.Add("p_SCId", ddlSubconnector.SelectedValue);

            var result = oDataAccess.QuerySPListDynamic<SubconnectorPayoutModel>("sp_getscpayout_bycaseidscid", parameters);
            SubconnectorPayoutModel oSubconnectorPayoutModel = result.Where(x => x.AddedBy == oConnector_Add.Id && x.AddedByType.Equals("Connector")).FirstOrDefault();
            if (oSubconnectorPayoutModel != null)
            {
                txtPayoutAmount.Text = oSubconnectorPayoutModel.PayoutAmount.ToString();
                txtRemarks.Text = oSubconnectorPayoutModel.Remarks;
                lblId.Text = oSubconnectorPayoutModel.Id.ToString();
            }
        }
        protected void ShowSweetAlert()
        {
            // Execute JavaScript code to show the SweetAlert and redirect after it is dismissed
            string script = @"
        Swal.fire({
            title: 'Success!',
            text: 'Added',
            icon: 'success',
        }).then((result) => {
            if (result.isConfirmed || result.isDismissed) {
                window.location.href = 'ShowDisbursedCases.aspx';
            }
        });
    ";

            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "showSweetAlert", script, true);
        }
        protected void ShowUpdateSweetAlert()
        {
            // Execute JavaScript code to show the SweetAlert and redirect after it is dismissed
            string script = @"
        Swal.fire({
            title: 'Success!',
            text: 'Updated',
            icon: 'success',
        }).then((result) => {
            if (result.isConfirmed || result.isDismissed) {
                window.location.href = 'ShowDisbursedCases.aspx';
            }
        });
    ";

            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "showSweetAlert", script, true);
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            Connector_Add oConnector_Add = Session["cnt"] as Connector_Add;
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    if (lblId.Text.Equals(""))
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("p_CaseId", Request.QueryString["id"]);
                        parameters.Add("p_PayoutAmount", txtPayoutAmount.Text);
                        parameters.Add("p_Remarks", txtRemarks.Text);
                        parameters.Add("p_AddedByType", "Connector");
                        parameters.Add("p_AddedBy", oConnector_Add.Id);
                        parameters.Add("p_CreatedOn", indianTime);
                        parameters.Add("p_SCId", ddlSubconnector.SelectedValue);

                        oDataAccess.ExecuteSPDynamic("sp_insert_scpayout", parameters);

                        ShowSweetAlert();
                    }
                    else
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("p_PayoutAmount", txtPayoutAmount.Text);
                        parameters.Add("p_Remarks", txtRemarks.Text);
                        parameters.Add("p_SCId", ddlSubconnector.SelectedValue);
                        parameters.Add("p_Id", lblId.Text);

                        oDataAccess.ExecuteSPDynamic("sp_update_scpayout", parameters);

                        ShowUpdateSweetAlert();
                    }
                }
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

        protected void ddlSubconnector_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetPayout();
        }
    }
}