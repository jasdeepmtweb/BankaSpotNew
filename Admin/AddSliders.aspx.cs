using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Admin
{
    public partial class AddSliders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("../BranchLogin.aspx");
            }
            if (!IsPostBack)
            {
                GetData();
            }
            if (GridProducts.Rows.Count > 0)
            {
                GridProducts.UseAccessibleHeader = true;
                GridProducts.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridProducts.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void GetData()
        {
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPListDynamic<Sliders_Add>("sp_getall_sliders");

            foreach (var item in result)
            {
                item.SliderImage = $"../Uploads/{item.SliderImage}";
            }

            GridProducts.DataSource = result;
            GridProducts.DataBind();

            if (GridProducts.Rows.Count > 0)
            {
                GridProducts.UseAccessibleHeader = true;
                GridProducts.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridProducts.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (FileImage.HasFile)
                    {
                        if (FileImage.PostedFile.ContentLength <= 1024 * 1024)
                        {

                            string extension = Path.GetExtension(FileImage.FileName);
                            string fileName = Guid.NewGuid() + extension;
                            FileImage.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fileName);

                            var parameters = new DynamicParameters();
                            parameters.Add("p_SliderImage", fileName);
                            parameters.Add("p_SliderTitle", "-");

                            DataAccess oDataAccess = new DataAccess();
                            oDataAccess.ExecuteSPDynamic("sp_insert_sliders", parameters);

                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added');window.location.href='AddSliders.aspx';", true);

                        }
                        else
                        {
                            Response.Write("<script>alert('The file size exceeds the maximum limit of 1 MB.')</script>");
                        }
                    }
                }
                catch (Exception ex)
                {
                    var errorLogger = new Log("ErrorLog.txt");
                    errorLogger.LogError(ex);
                }
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            var parameters = new DynamicParameters();
            parameters.Add("p_Id", button.CommandArgument);

            DataAccess oDataAccess = new DataAccess();
            oDataAccess.ExecuteSPDynamic("sp_delete_slider", parameters);

            GetData();
        }
    }
}