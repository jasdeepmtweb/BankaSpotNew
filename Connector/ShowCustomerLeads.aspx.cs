using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Connector
{
    public partial class ShowCustomerLeads : System.Web.UI.Page
    {
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cnt"] == null)
            {
                Response.Redirect("../ConnectorLogin.aspx");
            }
            if (!IsPostBack)
            {
                GetAllCases();
            }
            if (GridAllCases.Rows.Count > 0)
            {
                GridAllCases.UseAccessibleHeader = true;
                GridAllCases.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridAllCases.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void GetAllCases()
        {
            Connector_Add oConnector_Add = Session["cnt"] as Connector_Add;

            var parameters = new DynamicParameters();
            parameters.Add("p_Type", "lead");
            parameters.Add("p_ReferId", oConnector_Add.Id);
            parameters.Add("p_ReferIdType", "Connector");

            var result = oDataAccess.QuerySPListDynamic<LoanModel>("sp_getloansleads_forconnector", parameters);

            GridAllCases.DataSource = result;
            GridAllCases.DataBind();

            if (GridAllCases.Rows.Count > 0)
            {
                GridAllCases.UseAccessibleHeader = true;
                GridAllCases.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridAllCases.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
}