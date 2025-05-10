using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI.WebControls;

namespace BankaSpotNew.SubConnector
{
    public partial class ShowLeads : System.Web.UI.Page
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
            parameters.Add("p_CustomerId", oCustomerModel.Id);
            parameters.Add("p_Type", "lead");

            var result = oDataAccess.QuerySPListDynamic<LoanModel>("sp_getallloans", parameters);

            GridAllCases.DataSource = result;
            GridAllCases.DataBind();

            if (GridAllCases.Rows.Count > 0)
            {
                GridAllCases.UseAccessibleHeader = true;
                GridAllCases.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridAllCases.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            Response.Redirect($"AddLead.aspx?id={button.CommandArgument}");
        }
    }
}