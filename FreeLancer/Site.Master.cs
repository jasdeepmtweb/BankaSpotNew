using BankaSpotNew.App_Code;
using System;

namespace BankaSpotNew.FreeLancer
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["frl"] == null)
            {
                Response.Redirect("../FreeLancerLogin.aspx");
            }
            Freelancer_Add oFreelancer_Add = Session["frl"] as Freelancer_Add;
            lblName.Text = oFreelancer_Add.Name;

            if (oFreelancer_Add.FreelancerPic.Equals("-") || oFreelancer_Add.FreelancerPic.Equals(""))
            {
                ImgUser.ImageUrl = "../user.png";
            }
            else
            {
                ImgUser.ImageUrl = $"../Uploads/FreelancerPics/{oFreelancer_Add.FreelancerPic}";
            }
        }
    }
}