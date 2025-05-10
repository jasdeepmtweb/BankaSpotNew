using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Branch
{
    public partial class ShowMarketEmpPayout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["branch"] == null)
            {
                Response.Redirect("../BranchLogin.aspx");
            }
            if (!IsPostBack)
            {
                Branch_Add oBranch_Add = Session["branch"] as Branch_Add;
                BindGrid(oBranch_Add.Id);
            }
            if (GridMarketEmpPayout.Rows.Count > 0)
            {
                GridMarketEmpPayout.UseAccessibleHeader = true;
                GridMarketEmpPayout.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridMarketEmpPayout.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void BindGrid(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_BranchId", id);
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPListDynamic<Payouts_Add>("sp_getmarketemp_payoutsforbranch", parameters);
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


                    //if (CaseDetail != null)
                    //{
                    //    payouts_s[i].AmountDisbursed = Convert.ToDouble(CaseDetail.ext5);
                    //    payouts_s[i].CustomerName = CaseDetail.Name;
                    //    payouts_s[i].ProductName = CaseDetail.ProductName;
                    //}
                }

                payouts_s = payouts_s.OrderByDescending(x => x.DisbursedDate.Date).ToList();

                payouts_s = payouts_s.OrderByDescending(x => x.ext1).ToList();

                GridMarketEmpPayout.DataSource = payouts_s;
                GridMarketEmpPayout.DataBind();
            }
            if (GridMarketEmpPayout.Rows.Count > 0)
            {
                GridMarketEmpPayout.UseAccessibleHeader = true;
                GridMarketEmpPayout.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridMarketEmpPayout.FooterRow.TableSection = TableRowSection.TableFooter;
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