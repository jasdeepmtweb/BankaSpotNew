using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Accountant
{
    public partial class AddBanker : System.Web.UI.Page
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["acc"] == null)
            {
                Response.Redirect("../AccountantLogin.aspx");
            }
            if (!IsPostBack)
            {
                GetData();
                if (Request.QueryString["id"] != null)
                {
                    GetDetails(Request.QueryString["id"]);
                }
            }
            if (GridProducts.Rows.Count > 0)
            {
                GridProducts.UseAccessibleHeader = true;
                GridProducts.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridProducts.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void GetDetails(string Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_Status", 1);
            parameters.Add("p_Id", Id);

            var result = oDataAccess.QuerySingleOrDefaultSPDynamic<BankerModel>("sp_selectsingle_banker", parameters);
            if (result != null)
            {
                txtAreaCovered.Text = result.AreaCovered;
                txtCity.Text = result.City;
                txtEmailId.Text = result.EmailId;
                txtMobileNo.Text = result.MobileNo;
                txtName.Text = result.Name;
                ddlLocation.SelectedValue = result.LocationId.ToString();
                ddlProduct.SelectedValue = result.ProductId.ToString();
                txtBankName.Text = result.BankName;
            }
        }
        private void GetData()
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_Status", 1);

            var result = oDataAccess.QuerySPListDynamic<BankerModel>("sp_selectall_bankers", parameters);
            GridProducts.DataSource = result;
            GridProducts.DataBind();

            string sql = "SELECT * FROM tbbranch WHERE Role=0 order by Id DESC";

            var branches = oDataAccess.QueryDynamic<Branch_Add>(sql);
            ddlLocation.DataSource = branches;
            ddlLocation.DataTextField = "BranchName";
            ddlLocation.DataValueField = "Id";
            ddlLocation.DataBind();
            ddlLocation.Items.Insert(0, new ListItem("---Select---", "0"));


            var products = oDataAccess.QuerySPListDynamic<Product_Add>("sp_getallproducts");
            ddlProduct.DataSource = products;
            ddlProduct.DataTextField = "ProductName";
            ddlProduct.DataValueField = "Id";
            ddlProduct.DataBind();
            ddlProduct.Items.Insert(0, new ListItem("---Select---", "0"));

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
                    DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                    if (Request.QueryString["id"] == null)
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("p_Name", txtName.Text);
                        parameters.Add("p_MobileNo", txtMobileNo.Text);
                        parameters.Add("p_EmailId", txtEmailId.Text);
                        parameters.Add("p_ProductId", ddlProduct.SelectedValue);
                        parameters.Add("p_City", txtCity.Text);
                        parameters.Add("p_AreaCovered", txtAreaCovered.Text);
                        parameters.Add("p_LocationId", ddlLocation.SelectedValue);
                        parameters.Add("p_Status", 1);
                        parameters.Add("p_CreatedOn", indianTime);
                        parameters.Add("p_BankName", txtBankName.Text);

                        oDataAccess.ExecuteSPDynamic("sp_InsertBanker", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added');window.location.href='AddBanker.aspx';", true);
                    }
                    else
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("p_Name", txtName.Text);
                        parameters.Add("p_MobileNo", txtMobileNo.Text);
                        parameters.Add("p_EmailId", txtEmailId.Text);
                        parameters.Add("p_ProductId", ddlProduct.SelectedValue);
                        parameters.Add("p_City", txtCity.Text);
                        parameters.Add("p_AreaCovered", txtAreaCovered.Text);
                        parameters.Add("p_LocationId", ddlLocation.SelectedValue);
                        parameters.Add("p_BankName", txtBankName.Text);
                        parameters.Add("p_Id", Request.QueryString["id"]);

                        oDataAccess.ExecuteSPDynamic("sp_UpdateBanker", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated');window.location.href='AddBanker.aspx';", true);
                    }
                }
                catch (Exception ex)
                {
                    var errorLogger = new Log("ErrorLog.txt");
                    errorLogger.LogError(ex);
                }
            }
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Response.Redirect($"AddBanker.aspx?id={button.CommandArgument}");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            var parameters = new DynamicParameters();
            parameters.Add("p_Id", button.CommandArgument);
            parameters.Add("p_Status", 0);

            oDataAccess.ExecuteSPDynamic("sp_DeleteBanker", parameters);

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Deleted');window.location.href='AddBanker.aspx';", true);
        }
    }
}