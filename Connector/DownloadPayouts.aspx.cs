using BankaSpotNew.App_Code;
using System;

namespace BankaSpotNew.Connector
{
    public partial class DownloadPayouts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cnt"] == null)
            {
                Response.Redirect("../ConnectorLogin.aspx");
            }
            if (!IsPostBack)
            {
                GetPayouts();
            }
        }

        private void GetPayouts()
        {
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPDynamic<Product_Add>("sp_getallproducts");
            GridPayouts.DataSource = result;
            GridPayouts.DataBind();
        }
    }
}