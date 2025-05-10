using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Connector
{
    public partial class Dashboard : System.Web.UI.Page
    {
        public string referralLink = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cnt"] == null)
            {
                Response.Redirect("../ConnectorLogin.aspx");
            }

            GenerateReferralLink();
           
            if (!IsPostBack)
            {
                Connector_Add oConnector_Add = Session["cnt"] as Connector_Add;
                if (oConnector_Add.ext1 == null || oConnector_Add.ext2 == null || oConnector_Add.ext3 == null)
                {
                    Response.Redirect("UploadDocuments.aspx");
                }
                else
                {
                    BindGrid(oConnector_Add.Id);
                }
            }
            if (GridIncentiveMonthConnector.Rows.Count > 0)
            {
                GridIncentiveMonthConnector.UseAccessibleHeader = true;
                GridIncentiveMonthConnector.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridIncentiveMonthConnector.FooterRow.TableSection = TableRowSection.TableFooter;
            }
            if (GridIncentiveCaseConnector.Rows.Count > 0)
            {
                GridIncentiveCaseConnector.UseAccessibleHeader = true;
                GridIncentiveCaseConnector.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridIncentiveCaseConnector.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        private void GenerateReferralLink()
        {
            Connector_Add oConnector_Add = Session["cnt"] as Connector_Add;

            referralLink = string.Format("{0}://{1}:{2}", Request.Url.Scheme, Request.Url.Host, Request.Url.Port);
            //referralLink = string.Format("{0}://{1}", Request.Url.Scheme, Request.Url.Host);
            referralLink = $"{referralLink}/RegisterCustomer.aspx?id={oConnector_Add.Id}&reftyp=con";
        }

        private void BindGrid(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ConnectorID", id);
            DataAccess oDataAccess = new DataAccess();
            var resultSets = oDataAccess.QueryMultipleSPDynamic<Employee_Dashboard>("sp_connector_dashboard", parameters);
            if (resultSets != null)
            {
                lblCompletedCases.Text = resultSets.TotalCasesCompleted == null ? "-" : resultSets.TotalCasesCompleted.ToString();
                lblPendingCases.Text = resultSets.TotalCasesPending == null ? "-" : resultSets.TotalCasesPending.ToString();
                lblRejectedCases.Text = resultSets.TotalCasesRejected == null ? "-" : resultSets.TotalCasesRejected.ToString();
                lblTotalCases.Text = resultSets.TotalCases == null ? "-" : resultSets.TotalCases.ToString();
                //lblTotalIncentiveAmount.Text = resultSets.TotalPayout == null ? "-" : resultSets.TotalPayout.ToString();

                GridIncentiveMonthConnector.DataSource = resultSets.MonthWisePayout == null ? new List<dynamic>() : resultSets.MonthWisePayout;
                GridIncentiveMonthConnector.DataBind();
            }
            if (GridIncentiveMonthConnector.Rows.Count > 0)
            {
                GridIncentiveMonthConnector.UseAccessibleHeader = true;
                GridIncentiveMonthConnector.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridIncentiveMonthConnector.FooterRow.TableSection = TableRowSection.TableFooter;
            }

            oDataAccess = new DataAccess();
            var products = oDataAccess.QuerySPDynamic<Product_Add>("sp_getallproducts");

            parameters = new DynamicParameters();
            parameters.Add("ConnectorId", id);
            oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPDynamic<Case_Add>("sp_getcasesby_conid", parameters);
            List<Case_Add> CompleteCases = result.Where(p => p.Status.Contains("Disbursed")).ToList();

            for (int i = 0; i < CompleteCases.Count; i++)
            {
                var product = products.FirstOrDefault(p => p.Id == CompleteCases[i].ProductReq);

                CompleteCases[i].ProductName = product.ProductName;

                if (CompleteCases[i].ext5 == null)
                {
                    CompleteCases[i].ext5 = "0";
                }
                else
                {
                    if (CompleteCases[i].ext5.Equals("") || CompleteCases[i].ext5.Equals("-"))
                    {
                        CompleteCases[i].ext5 = "0";
                    }
                }


                CompleteCases[i].Incentive = Math.Round(Convert.ToDouble(CompleteCases[i].ext5) * (product.ConnectorCom / 100), 2);
            }
            GridIncentiveCaseConnector.DataSource = CompleteCases;
            GridIncentiveCaseConnector.DataBind();

            parameters = new DynamicParameters();
            parameters.Add("UserId", id);
            parameters.Add("UserType", "Connector");
            oDataAccess = new DataAccess();
            var payouts = oDataAccess.QuerySingleOrDefaultSPDynamic<dynamic>("sp_getpayoutssum_byuseridtype", parameters);
            if (payouts != null)
            {
                lblTotalIncentive.Text = payouts.Payouts.ToString();
            }

            parameters.Add("UserId", id);
            oDataAccess = new DataAccess();
            var withdrawal = oDataAccess.QuerySingleOrDefaultSPDynamic<dynamic>("sp_gettotalwithdrawal_forconn", parameters);
            if (withdrawal != null)
            {
                lblTotalWithdrawal.Text = withdrawal.WithDrawal.ToString();
            }

            lblPayoutBalance.Text = "" + (Convert.ToDouble(lblTotalIncentive.Text) - Convert.ToDouble(lblTotalWithdrawal.Text));
        }

        protected void BtnExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "IncentiveMonthWise" + DateTime.Now.Ticks + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GridIncentiveMonthConnector.GridLines = GridLines.Both;
            GridIncentiveMonthConnector.HeaderStyle.Font.Bold = true;
            GridIncentiveMonthConnector.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }

        protected void BtnExcel2_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "IncentiveCaseWise" + DateTime.Now.Ticks + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GridIncentiveCaseConnector.GridLines = GridLines.Both;
            GridIncentiveCaseConnector.HeaderStyle.Font.Bold = true;
            GridIncentiveCaseConnector.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //
        }
    }
}