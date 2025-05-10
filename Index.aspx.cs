using System;

namespace BankaSpotNew
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BtnBranchLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("BranchLogin.aspx");
        }

        protected void BtnEmployeeLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeLogin.aspx");
        }

        protected void BtnConnectorLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConnectorLogin.aspx");
        }

        protected void BtnRegionLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegionLogin.aspx");
        }

        protected void BtnFreeLancerLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("FreeLancerLogin.aspx");
        }

        protected void BtnMarketingEmpLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("MarketingEmpLogin.aspx");
        }

        protected void BtnAccountantLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountantLogin.aspx");
        }

        protected void BtnCustomerLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerLogin.aspx");
        }

        protected void BtnSubconnectorLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("SubconnectorLogin.aspx");
        }
    }
}