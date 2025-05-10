using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Accountant
{
    public partial class ShowConnectorPayouts : System.Web.UI.Page
    {
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["acc"] == null)
            {
                Response.Redirect("../AccountantLogin.aspx");
            }
            if (!IsPostBack)
            {
                GetData();
            }
            if (GridRegion.Rows.Count > 0)
            {
                GridRegion.UseAccessibleHeader = true;
                GridRegion.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridRegion.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void GetData()
        {
            var parameters = new DynamicParameters();

            var result = oDataAccess.QuerySPDynamic<Payouts_Add>("sp_getconnpayoutsfor_admin");
            if (result != null)
            {
                List<Payouts_Add> payouts_s = result.ToList();

                for (int i = 0; i < payouts_s.Count; i++)
                {
                    //parameters.Add("Id", payouts_s[i].CaseId);

                    //var CaseDetail = oDataAccess.QuerySingleOrDefaultSPDynamic<Case_Add>("sp_getcaseby_id", parameters);

                    if (payouts_s[i].ext1 == null)
                    {
                        payouts_s[i].ext1 = "0";
                        payouts_s[i].ext2 = "Pending";
                    }
                    else
                    {
                        if (payouts_s[i].ext1.Equals("0"))
                        {
                            payouts_s[i].ext2 = "Pending";
                        }
                    }


                    //if (CaseDetail != null)
                    //{
                    //    payouts_s[i].AmountDisbursed = Convert.ToDouble(CaseDetail.ext5);
                    //    payouts_s[i].CustomerName = CaseDetail.Name;
                    //    payouts_s[i].ProductName = CaseDetail.ProductName;
                    //}

                    //parameters = new DynamicParameters();
                    //parameters.Add("CaseId", payouts_s[i].CaseId);
                    //Product_Add oProduct_Add = oDataAccess.QuerySingleOrDefaultSPDynamic<Product_Add>("sp_getcommbycaseid", parameters);

                    //if (oProduct_Add != null)
                    //{
                    payouts_s[i].OriginalPayout = payouts_s[i].AmountDisbursed * (payouts_s[i].ConnectorCom / 100);
                    payouts_s[i].TDS = (payouts_s[i].OriginalPayout * 0.05);
                    //}
                }

                GridRegion.DataSource = payouts_s.Where(x => x.ext1.Equals("0")).ToList(); ;
                GridRegion.DataBind();
            }
            if (GridRegion.Rows.Count > 0)
            {
                GridRegion.UseAccessibleHeader = true;
                GridRegion.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridRegion.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void btedt_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow row = (GridViewRow)button.NamingContainer;
            Label lblMobileNo = (Label)row.FindControl("lblMobileNo");
            Label lblPayAmount = (Label)row.FindControl("lblPayAmount");
            //var parameters = new DynamicParameters();
            //parameters.Add("ext1", "1");
            //parameters.Add("Id", button.CommandArgument);

            //
            //oDataAccess.ExecuteSPDynamic("sp_update_payout_status", parameters);

            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Done');window.location.href='ShowConnectorPayouts.aspx';", true);

            Session["lastPage"] = "ShowConnectorPayouts.aspx";

            Response.Redirect($"UpdatePayoutStatus.aspx?id={button.CommandArgument}&mob={lblMobileNo.Text}&amt={lblPayAmount.Text}");
        }
    }
}