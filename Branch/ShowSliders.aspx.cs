using BankaSpotNew.App_Code;
using System;
using System.IO;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Branch
{
    public partial class ShowSliders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["branch"] == null)
            {
                Response.Redirect("../BranchLogin.aspx");
            }
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPListDynamic<Sliders_Add>("sp_getall_sliders");

            foreach (var item in result)
            {
                item.SliderImage = $"../Uploads/{item.SliderImage}";
            }

            rptSliders.DataSource = result;
            rptSliders.DataBind();
        }

        protected void BtnDownload_Click(object sender, EventArgs e)
        {
            Button Btn = (Button)sender;

            try
            {
                string SliderImage = Btn.CommandArgument;
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(SliderImage));
                Response.WriteFile(SliderImage);
                Response.End();
            }
            catch (Exception ex)
            {
                var errorLogger = new Log("ErrorLog.txt");
                errorLogger.LogError(ex);
            }
        }
    }
}