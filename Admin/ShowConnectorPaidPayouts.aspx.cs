using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Admin
{
    public partial class ShowConnectorPaidPayouts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("../BranchLogin.aspx");
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
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPDynamic<Payouts_Add>("sp_getconnpayoutsfor_admin");
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
                        payouts_s[i].ext1 = "0";
                        payouts_s[i].ext2 = "Pending";
                    }
                    else
                    {
                        if (payouts_s[i].ext1.Equals("0"))
                        {
                            payouts_s[i].ext2 = "Pending";
                        }
                        else
                        {
                            try
                            {
                                payouts_s[i].ext2 = Convert.ToDateTime(payouts_s[i].ext2).ToString("dd/MMM/yyyy");
                            }
                            catch (Exception)
                            {
                                payouts_s[i].ext2 = payouts_s[i].ext2;
                            }
                        }
                    }


                    //if (CaseDetail != null)
                    //{
                    //    payouts_s[i].AmountDisbursed = Convert.ToDouble(CaseDetail.ext5);
                    //    payouts_s[i].CustomerName = CaseDetail.Name;
                    //    payouts_s[i].ProductName = CaseDetail.ProductName;
                    //}
                }

                GridRegion.DataSource = result.Where(x => !x.ext1.Equals("0")).ToList();
                GridRegion.DataBind();
            }
            if (GridRegion.Rows.Count > 0)
            {
                GridRegion.UseAccessibleHeader = true;
                GridRegion.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridRegion.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
}