using BankaSpotNew.App_Code;
using System;

namespace BankaSpotNew.SubConnector
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["scon"] == null)
            {
                Response.Redirect("../SubconnectorLogin.aspx");
            }
            if (!IsPostBack)
            {
                CustomerModel oCustomerModel = Session["scon"] as CustomerModel;
                lblName.Text = oCustomerModel.CustomerName;
            }
        }
    }
}