using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Admin
{
    public partial class AddStaff : System.Web.UI.Page
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("../BranchLogin.aspx");
            }
            if (!IsPostBack)
            {
                GetData();
                //if (Request.QueryString["id"] != null)
                //{
                //    GetDetails(Request.QueryString["id"]);
                //}
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
            var result = oDataAccess.QuerySPListDynamic<StaffModel>("sp_getall_staff");
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

            CheckProducts.Items.Clear();
            CheckProducts.DataSource = products;
            CheckProducts.DataTextField = "ProductName";
            CheckProducts.DataValueField = "Id";
            CheckProducts.DataBind();

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
                        foreach (ListItem item in CheckProducts.Items.Cast<ListItem>().Where(i => i.Selected))
                        {
                            var parameters = new DynamicParameters();
                            parameters.Add("p_StaffName", txtName.Text);
                            parameters.Add("p_StaffMobileNo", txtMobileNo.Text);
                            parameters.Add("p_ProductId", item.Value);
                            parameters.Add("p_StaffEmailId", txtEmailId.Text);
                            parameters.Add("p_StaffAddress", txtAddress.Text);
                            parameters.Add("p_CreatedOn", indianTime);
                            parameters.Add("p_BranchId", ddlLocation.SelectedValue);

                            oDataAccess.ExecuteSPDynamic("sp_insert_staff", parameters);
                        }

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added');window.location.href='AddStaff.aspx';", true);
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

            oDataAccess.ExecuteSPDynamic("sp_delete_staff", parameters);

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Deleted');window.location.href='AddStaff.aspx';", true);
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}