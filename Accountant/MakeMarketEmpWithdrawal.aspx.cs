using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI;

namespace BankaSpotNew.Accountant
{
    public partial class MakeMarketEmpWithdrawal : System.Web.UI.Page
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["acc"] == null)
            {
                Response.Redirect("../AccountantLogin.aspx");
            }
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("ShowMarketingEmp.aspx");
            }
            if (!IsPostBack)
            {
                GetPayoutsAndWithdrawal(Request.QueryString["id"]);
            }
        }
        private void GetPayoutsAndWithdrawal(string Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("UserId", Id);
            parameters.Add("UserType", "MEMP");
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySingleOrDefaultSPDynamic<dynamic>("sp_getpayoutssum_byuseridtype", parameters);
            if (result != null)
            {
                txtTotalPayout.Text = result.Payouts.ToString();
            }

            parameters.Add("p_UserId", Id);
            oDataAccess = new DataAccess();
            var withdrawal = oDataAccess.QuerySingleOrDefaultSPDynamic<dynamic>("sp_gettotalwithdrawal_formarketemp", parameters);
            if (withdrawal != null)
            {
                txtTotalWithdrawal.Text = withdrawal.WithDrawal.ToString();
            }

            txtAvailableBalance.Text = "" + (Convert.ToDouble(txtTotalPayout.Text) - Convert.ToDouble(txtTotalWithdrawal.Text));
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            if (Page.IsValid)
            {
                try
                {
                    if (Request.QueryString["id"] != null)
                    {
                        if (Convert.ToDouble(txtWithdrawal.Text) < Convert.ToDouble(txtAvailableBalance.Text))
                        {
                            var parameters = new DynamicParameters();
                            parameters.Add("p_UserId", Request.QueryString["id"]);
                            parameters.Add("p_WithdrawalDate", indianTime);
                            parameters.Add("p_WithdrawalAmount", txtWithdrawal.Text);
                            parameters.Add("p_WithdrawalType", "withdrawal");
                            parameters.Add("p_Description", "-");
                            parameters.Add("p_Remarks", txtRemarks.Text);
                            parameters.Add("p_ext1", "-");
                            parameters.Add("p_ext2", "-");

                            DataAccess oDataAccess = new DataAccess();
                            oDataAccess.ExecuteSPDynamic("sp_insert_marketemp_withdrawal", parameters);

                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Done');window.location.href='ShowMarketingEmp.aspx';", true);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Valid Amount');", true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    var errorLogger = new Log("ErrorLog.txt");
                    errorLogger.LogError(ex);
                }
            }
        }
    }
}