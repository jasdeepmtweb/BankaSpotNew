using BankaSpotNew.App_Code;
using Dapper;
using System;

namespace BankaSpotNew.Branch
{
    public partial class EditConnectorId : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["branch"] == null)
            {
                Response.Redirect("../BranchLogin.aspx");
            }
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("ShowConnectors.aspx");
            }
            if (!IsPostBack)
            {
                GetConnectorDetail(Request.QueryString["id"]);
            }
        }

        private void GetConnectorDetail(string connectorId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", connectorId);
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySingleOrDefaultSPDynamic<Connector_Add>("sp_getconnectorby_id", parameters);
            if (result != null)
            {
                txtConnectorId.Text = result.ConnectorId;
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (Request.QueryString["id"] != null)
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("ConnectorId", txtConnectorId.Text);
                        parameters.Add("Id", Request.QueryString["id"]);

                        DataAccess oDataAccess = new DataAccess();
                        oDataAccess.ExecuteSPDynamic("sp_update_connectorid", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated');window.location.href='ShowConnectors.aspx';", true);
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