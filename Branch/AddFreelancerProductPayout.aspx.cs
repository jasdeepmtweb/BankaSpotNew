using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Branch
{
    public partial class AddFreelancerProductPayout : System.Web.UI.Page
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["branch"] == null)
            {
                Response.Redirect("../BranchLogin.aspx");
            }
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("ShowFreelancer.aspx");
            }
            if (!IsPostBack)
            {
                GetData();
                BindGrid();
                if (Request.QueryString["pid"] != null)
                {
                    GetSingleData();
                }
            }
            if (GridStaff.Rows.Count > 0)
            {
                GridStaff.UseAccessibleHeader = true;
                GridStaff.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridStaff.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        private void GetSingleData()
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_Id", Request.QueryString["pid"]);

            var result = oDataAccess.QuerySingleOrDefaultSPDynamic<FreelancerProductPayoutModel>("sp_getsingle_flpropayout", parameters);

            if (result != null)
            {
                txtPayout.Text = result.PayoutPercent.ToString();
                ddlProduct.SelectedValue = result.ProductId.ToString();
            }
        }

        private void GetData()
        {
            var result = oDataAccess.QuerySPListDynamic<Product_Add>("sp_getallproducts");
            ddlProduct.DataSource = result;
            ddlProduct.DataTextField = "ProductName";
            ddlProduct.DataValueField = "Id";
            ddlProduct.DataBind();
        }
        private void BindGrid()
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_FreelancerId", Request.QueryString["id"]);

            var result = oDataAccess.QuerySPListDynamic<FreelancerProductPayoutModel>("sp_getallflprpayout_byflid", parameters);

            GridStaff.DataSource = result;
            GridStaff.DataBind();

            if (GridStaff.Rows.Count > 0)
            {
                GridStaff.UseAccessibleHeader = true;
                GridStaff.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridStaff.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            if (Page.IsValid)
            {
                try
                {
                    if (Request.QueryString["pid"] == null)
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("p_ProductId", ddlProduct.SelectedValue);
                        parameters.Add("p_FreelancerId", Request.QueryString["id"]);
                        parameters.Add("p_PayoutPercent", txtPayout.Text);
                        parameters.Add("p_CreatedOn", indianTime);

                        oDataAccess.ExecuteSPDynamic("sp_insert_freelancerpropayout", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added');window.location.href='AddFreelancerProductPayout.aspx?id=" + Request.QueryString["id"] + "';", true);
                    }
                    else
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("p_ProductId", ddlProduct.SelectedValue);
                        parameters.Add("p_FreelancerId", Request.QueryString["id"]);
                        parameters.Add("p_PayoutPercent", txtPayout.Text);
                        parameters.Add("p_Id", Request.QueryString["pid"]);

                        oDataAccess.ExecuteSPDynamic("sp_update_freelancerpropayout", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated');window.location.href='AddFreelancerProductPayout.aspx?id=" + Request.QueryString["id"] + "';", true);
                    }
                }
                catch (Exception ex)
                {
                    var errorLogger = new Log("ErrorLog.txt");
                    errorLogger.LogError(ex);
                    if (ex.Message.Contains("Duplicate"))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Mobile No. Already Exists');", true);
                    }
                }
            }
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Response.Redirect($"AddFreelancerProductPayout.aspx?id={Request.QueryString["id"]}&pid={button.CommandArgument}");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            var parameters = new DynamicParameters();
            parameters.Add("p_Id", button.CommandArgument);

            oDataAccess.ExecuteSPDynamic("sp_delete_flpropayout", parameters);

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Deleted');window.location.href='AddFreelancerProductPayout.aspx?id=" + Request.QueryString["id"] + "';", true);
        }
    }
}