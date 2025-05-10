using BankaSpotNew.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankaSpotNew.FreeLancer
{
    public partial class DownloadPayouts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["frl"] == null)
            {
                Response.Redirect("../FreeLancerLogin.aspx");
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