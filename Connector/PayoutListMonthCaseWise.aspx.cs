using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Connector
{
    public partial class PayoutListMonthCaseWise : System.Web.UI.Page
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
            parameters.Add("UserId", id);
            parameters.Add("UserType", "Connector");
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPDynamic<Payouts_Add>("sp_getpayoutsby_useridtype", parameters);
            if (result != null)
            {
                List<Payouts_Add> payouts_s = result.ToList();

                for (int i = 0; i < payouts_s.Count; i++)
                {
                    //parameters.Add("Id", payouts_s[i].CaseId);
                    //oDataAccess = new DataAccess();
                    //var CaseDetail = oDataAccess.QuerySingleOrDefaultSPDynamic<Case_Add>("sp_getcaseby_id", parameters);

                    if (payouts_s[i].ext1 == null)
                    {
                        payouts_s[i].ext1 = "Pending";
                        payouts_s[i].ext2 = "Pending";
                    }
                    else
                    {
                        if (payouts_s[i].ext1.Equals("0"))
                        {
                            payouts_s[i].ext1 = "Pending";
                            payouts_s[i].ext2 = "Pending";
                        }
                        else
                        {
                            payouts_s[i].ext1 = "Paid";
                        }
                    }
                    try
                    {
                        payouts_s[i].ext2 = Convert.ToDateTime(payouts_s[i].ext2).ToString("dd/MM/yyyy");
                    }
                    catch (Exception ex)
                    {
                        payouts_s[i].ext2 = "Pending";
                    }

                    //if (CaseDetail != null)
                    //{
                    //    payouts_s[i].AmountDisbursed = Convert.ToDouble(CaseDetail.ext5);
                    //    payouts_s[i].CustomerName = CaseDetail.Name;
                    //    payouts_s[i].ProductName = CaseDetail.ProductName;
                    //}

                    parameters = new DynamicParameters();
                    parameters.Add("CaseId", payouts_s[i].CaseId);
                    Product_Add oProduct_Add = oDataAccess.QuerySingleOrDefaultSPDynamic<Product_Add>("sp_getcommbycaseid", parameters);

                    if (oProduct_Add != null)
                    {
                        payouts_s[i].OriginalPayout = payouts_s[i].AmountDisbursed * (oProduct_Add.ConnectorCom / 100);
                        payouts_s[i].TDS = (payouts_s[i].OriginalPayout * 0.05);
                    }
                }

                GridCase.DataSource = payouts_s;
                GridCase.DataBind();
            }
            if (GridCase.Rows.Count > 0)
            {
                GridCase.UseAccessibleHeader = true;
                GridCase.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridCase.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        protected void btedt_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            var parameters = new DynamicParameters();
            parameters.Add("Id", button.CommandArgument);
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySingleOrDefaultSPDynamic<Case_Add>("sp_getcaseby_id", parameters);

            if (result != null)
            {
                lblAddress.Text = result.Address;
                lblAmountRequired.Text = "" + result.AmountReq;
                lblCity.Text = result.City;
                //lblConnector.Text = result.ConnectorName;
                lblMobile.Text = result.MobileNo;
                lblMonthlyIncome.Text = result.MonthlyIncome;
                lblName.Text = result.Name;
                lblProfile.Text = result.CustomerProfile;
                lblProReq.Text = result.ProductName;

                ShowModalPopup();
            }
        }
        protected void ShowModalPopup()
        {
            hdnShowModal.Value = "1";
        }
    }
}