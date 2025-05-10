using BankaSpotNew.App_Code;
using System;

namespace BankaSpotNew.Customer
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cust"] == null)
            {
                Response.Redirect("../CustomerLogin.aspx");
            }
            if (!IsPostBack)
            {
                CustomerModel oCustomerModel = Session["cust"] as CustomerModel;
                lblName.Text = oCustomerModel.CustomerName;
            }
        }
    }
}