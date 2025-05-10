using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Connector
{
    public partial class ShowDisbursedCases : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cnt"] == null)
            {
                Response.Redirect("../ConnectorLogin.aspx");
            }
            if (!IsPostBack)
            {
                Connector_Add oConnector_Add = Session["cnt"] as Connector_Add;
                BindGrid(oConnector_Add.Id);
            }
            if (GridCase.Rows.Count > 0)
            {
                GridCase.UseAccessibleHeader = true;
                GridCase.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridCase.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void BindGrid(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ConnectorId", id);
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPDynamic<Case_Add>("sp_getcasesby_conid", parameters);
            if (result != null)
            {
                result = result.Where(x => x.Status.Contains("Disbursed"));
                //foreach (var item in result)
                //{
                //    parameters.Add("CaseId", item.Id);
                //    oDataAccess = new DataAccess();
                //    var History = oDataAccess.QuerySPDynamic<Case_Status_History>("sp_getcasehistory_bycaseid", parameters);

                //    item.DisbursedDate = History.Where(p => p.CaseId == item.Id).FirstOrDefault().DateAdded;
                //}

                GridCase.DataSource = result;
                GridCase.DataBind();
            }
            if (GridCase.Rows.Count > 0)
            {
                GridCase.UseAccessibleHeader = true;
                GridCase.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridCase.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void BtnSCPayout_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            Response.Redirect($"AddSCPayout.aspx?id={button.CommandArgument}");
        }
    }
}