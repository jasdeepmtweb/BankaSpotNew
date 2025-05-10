using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI.WebControls;

namespace BankaSpotNew.SubConnector
{
    public partial class ShowAllCases : System.Web.UI.Page
    {
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["scon"] == null)
            {
                Response.Redirect("../SubconnectorLogin.aspx");
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
            CustomerModel oCustomerModel = Session["scon"] as CustomerModel;

            var parameters = new DynamicParameters();
            parameters.Add("p_CustomerMobileNo", oCustomerModel.CustomerMobileNo);

            var result = oDataAccess.QuerySPListDynamic<Case_Add>("sp_getallcasesfor_customer", parameters);

            GridAllCases.DataSource = result;
            GridAllCases.DataBind();

            if (GridAllCases.Rows.Count > 0)
            {
                GridAllCases.UseAccessibleHeader = true;
                GridAllCases.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridAllCases.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        protected void ShowHistoryModalPopup()
        {
            hdnShowHistoryModal.Value = "1";
        }
        protected void BtnCheckStatus_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            var parameters = new DynamicParameters();
            parameters.Add("CaseId", button.CommandArgument);

            var result = oDataAccess.QuerySPDynamic<Case_Status_History>("sp_getcasehistory_bycaseid", parameters);
            if (result != null)
            {
                GridCaseHistory.DataSource = result;
                GridCaseHistory.DataBind();

                ShowHistoryModalPopup();
            }
        }
    }
}