using BankaSpotNew.App_Code;
using Dapper;
using System;

namespace BankaSpotNew.Admin
{
    public partial class UpdatePayoutStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("../BranchLogin.aspx");
            }
            if (Session["lastPage"] == null)
            {
                Response.Redirect("../BranchLogin.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect(Session["lastPage"].ToString());
                }
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ext1", "1");
            parameters.Add("Id", Request.QueryString["id"]);
            parameters.Add("ext2", txtPayoutDate.Text);

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