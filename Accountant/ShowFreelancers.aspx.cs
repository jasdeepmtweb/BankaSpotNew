using BankaSpotNew.App_Code;
using System;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Accountant
{
    public partial class ShowFreelancers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["acc"] == null)
            {
                Response.Redirect("../AccountantLogin.aspx");
            }
            if (!IsPostBack)
            {
                BindGrid();
            }
            if (GridConnector.Rows.Count > 0)
            {
                GridConnector.UseAccessibleHeader = true;
                GridConnector.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridConnector.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void BindGrid()
        {
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPDynamic<Freelancer_Add>("sp_getallfreelancersfor_admin");
            if (result != null)
            {
                GridConnector.DataSource = result;
                GridConnector.DataBind();
            }
            if (GridConnector.Rows.Count > 0)
            {
                GridConnector.UseAccessibleHeader = true;
                GridConnector.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridConnector.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void btedt_Click(object sender, EventArgs e)
        {
            Button Btn = (Button)sender;
            Response.Redirect($"MakeFreealncerWithdrawal.aspx?id={Btn.CommandArgument}");
        }
    }
}