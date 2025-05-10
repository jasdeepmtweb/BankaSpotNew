using BankaSpotNew.App_Code;
using System;

namespace BankaSpotNew.Connector
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cnt"] == null)
            {
                Response.Redirect("../ConnectorLogin.aspx");
            }
            if (!IsPostBack)
            {
                Connector_Add oConnector_Add = Session["cnt"] as Connector_Add;
                lblName.Text = oConnector_Add.Name;

                if (oConnector_Add.ConnectorPic.Equals("-") || oConnector_Add.ConnectorPic.Equals(""))
                {
                    ImgUser.ImageUrl = "../user.png";
                }
                else
                {
                    ImgUser.ImageUrl = $"../Uploads/ConnectorPics/{oConnector_Add.ConnectorPic}";
                }
            }
        }
    }
}