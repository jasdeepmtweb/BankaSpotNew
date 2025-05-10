using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using BankaSpotNew.App_Code;
using Dapper;

namespace BankaSpotNew.Admin
{
    public partial class AddProducts : System.Web.UI.Page
    {
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
            parameters.Add("Id", Id);

            var result = oDataAccess.QuerySingleOrDefaultSPDynamic<Product_Add>("sp_getproductby_id", parameters);
            if (result != null)
            {
                txtConnectorCom.Text = "" + result.ConnectorCom;
                txtEmployeeCom.Text = "" + result.EmployeeCom;
                txtFreelancerCom.Text = "" + result.FreelancerCom;
                txtProduct.Text = result.ProductName;
                txtMarketingEmpComm.Text = result.ext1;
            }
        }
        private void GetData()
        {

            var result = oDataAccess.QuerySPListDynamic<Product_Add>("sp_getallproducts");
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
                    if (Request.QueryString["id"] == null)
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("p_ConnectorCom", txtConnectorCom.Text);
                        parameters.Add("p_EmployeeCom", txtEmployeeCom.Text);
                        parameters.Add("p_FreelancerCom", txtFreelancerCom.Text);
                        parameters.Add("p_ProductName", txtProduct.Text);
                        parameters.Add("p_ext1", txtMarketingEmpComm.Text);
                        parameters.Add("p_ext2", 0);
                        parameters.Add("p_ext3", 0);
                        parameters.Add("p_ext4", 0);


                        oDataAccess.ExecuteSPDynamic("sp_insert_product", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added');window.location.href='AddProducts.aspx';", true);
                    }
                    else
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("p_ConnectorCom", txtConnectorCom.Text);
                        parameters.Add("p_EmployeeCom", txtEmployeeCom.Text);
                        parameters.Add("p_FreelancerCom", txtFreelancerCom.Text);
                        parameters.Add("p_ProductName", txtProduct.Text);
                        parameters.Add("p_ext1", txtMarketingEmpComm.Text);
                        parameters.Add("p_ext2", 0);
                        parameters.Add("p_ext3", 0);
                        parameters.Add("p_ext4", 0);
                        parameters.Add("p_Id", Request.QueryString["id"]);


                        oDataAccess.ExecuteSPDynamic("sp_update_product", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated');window.location.href='AddProducts.aspx';", true);
                    }
                }
                catch (Exception ex)
                {
                    var errorLogger = new Log("ErrorLog.txt");
                    errorLogger.LogError(ex);
                }
            }
        }

        protected void btedt_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Response.Redirect($"AddProducts.aspx?id={button.CommandArgument}");
        }

        protected void BtnEmpPaySlab_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow row = (GridViewRow)button.NamingContainer;
            Label lblProductName = (Label)row.FindControl("lblProductName");
            Response.Redirect($"AddEmpPayoutSlab.aspx?id={button.CommandArgument}&pro={lblProductName.Text}");
        }

        protected void BtnConnectorPaySlab_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow row = (GridViewRow)button.NamingContainer;
            Label lblProductName = (Label)row.FindControl("lblProductName");
            Response.Redirect($"AddConnectorPayoutSlab.aspx?id={button.CommandArgument}&pro={lblProductName.Text}");
        }
    }
}