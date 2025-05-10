using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI;

namespace BankaSpotNew.Accountant
{
    public partial class MakeConnectorWithDrawal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["acc"] == null)
            {
                Response.Redirect("../AccountantLogin.aspx");
            }
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("ShowConnectors.aspx");
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
            parameters.Add("UserType", "Connector");
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySingleOrDefaultSPDynamic<dynamic>("sp_getpayoutssum_byuseridtype", parameters);
            if (result != null)
            {
                txtTotalPayout.Text = result.Payouts.ToString();
            }

            parameters.Add("UserId", Id);
            oDataAccess = new DataAccess();
            var withdrawal = oDataAccess.QuerySingleOrDefaultSPDynamic<dynamic>("sp_gettotalwithdrawal_forconn", parameters);
            if (withdrawal != null)
            {
                txtTotalWithdrawal.Text = withdrawal.WithDrawal.ToString();
            }

            txtAvailableBalance.Text = "" + (Convert.ToDouble(txtTotalPayout.Text) - Convert.ToDouble(txtTotalWithdrawal.Text));
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (Request.QueryString["id"] != null)
                    {
                        if (Convert.ToDouble(txtWithdrawal.Text) < Convert.ToDouble(txtAvailableBalance.Text))
                        {
                            var parameters = new DynamicParameters();
                            parameters.Add("UserId", Request.QueryString["id"]);
                            parameters.Add("WithdrawalAmount", txtWithdrawal.Text);
                            parameters.Add("WithdrawalType", "withdrawal");
                            parameters.Add("Description", "-");
                            parameters.Add("Remarks", txtRemarks.Text);

                            DataAccess oDataAccess = new DataAccess();
                            oDataAccess.ExecuteSPDynamic("sp_insert_connwithdrawal", parameters);

                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Done');window.location.href='ShowConnectors.aspx';", true);
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