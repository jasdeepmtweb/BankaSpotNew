using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI.WebControls;

namespace BankaSpotNew.SubConnector
{
    public partial class ShowPayouts : System.Web.UI.Page
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
            parameters.Add("p_SCId", oCustomerModel.Id);

            var result = oDataAccess.QuerySPListDynamic<SubconnectorPayoutModel>("sp_getallscpayouts_byscid", parameters);

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