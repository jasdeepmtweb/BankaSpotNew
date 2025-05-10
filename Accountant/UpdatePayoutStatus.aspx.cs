using BankaSpotNew.App_Code;
using Dapper;
using System;

namespace BankaSpotNew.Accountant
{
    public partial class UpdatePayoutStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["acc"] == null)
            {
                Response.Redirect("../AccountantLogin.aspx");
            }
            if (Session["lastPage"] == null)
            {
                Response.Redirect("../AccountantLogin.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect(Session["lastPage"].ToString());
                }
                else
                {
                    if (Session["lastPage"].ToString().Contains("Freelancer"))
                    {
                        divAmount.Visible = true;
                        divReason.Visible = true;
                        divType.Visible = true;
                    }
                    else
                    {
                        divAmount.Visible = false;
                        divReason.Visible = false;
                        divType.Visible = false;
                    }
                }
            }
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ext1", "1");
            parameters.Add("Id", Request.QueryString["id"]);
            parameters.Add("ext2", txtPayoutDate.Text);

            if (ddlPayoutType.SelectedValue.Equals("1"))
            {
                parameters.Add("ext3", txtPayoutDeduction.Text);
                parameters.Add("ext4", 0);
            }
            else
            {
                parameters.Add("ext3", 0);
                parameters.Add("ext4", txtPayoutDeduction.Text);
            }

            parameters.Add("AnyReason", txtAnyReason.Text);

            DataAccess oDataAccess = new DataAccess();
            oDataAccess.ExecuteSPDynamic("sp_update_payout_status", parameters);

            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Done');window.location.href='" + Session["lastPage"].ToString() + "';", true);

            if (Request.QueryString["mob"] != null && !Request.QueryString["mob"].ToString().Equals(""))
            {
                string mobileNo = Request.QueryString["mob"];

                if (!mobileNo.StartsWith("91"))
                {
                    mobileNo = $"91{mobileNo}";
                }

                string message = $"Payout Paid Of Rs {Request.QueryString["amt"]}";

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Done');window.location.href='https://api.whatsapp.com/send?phone=" + mobileNo + "&text=" + message + "';", true);
            }

            Session.Remove("lastPage");
        }
    }
}