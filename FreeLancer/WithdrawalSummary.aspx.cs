using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI.WebControls;

namespace BankaSpotNew.FreeLancer
{
    public partial class WithdrawalSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["frl"] == null)
            {
                Response.Redirect("../FreeLancerLogin.aspx");
            }
            if (!IsPostBack)
            {
                Freelancer_Add oFreelancer_Add = Session["frl"] as Freelancer_Add;
                BindGrid(oFreelancer_Add.Id);
            }
            if (GridConnector.Rows.Count > 0)
            {
                GridConnector.UseAccessibleHeader = true;
                GridConnector.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridConnector.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void BindGrid(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("UserId", id);
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPDynamic<Freelancer_Withdrawal>("sp_freelancer_withdrawalsummary", parameters);
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
    }
}