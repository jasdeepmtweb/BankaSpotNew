using System;
using System.Web.UI.WebControls;
using BankaSpotNew.App_Code;
using Dapper;

namespace BankaSpotNew.Admin
{
    public partial class AddEmpPayoutSlab : System.Web.UI.Page
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("../BranchLogin.aspx");
            }
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("AddProducts.aspx");
            }
            if (!IsPostBack)
            {
                BindGrid();

                lblProductName.Text = Request.QueryString["pro"];

                if (Request.QueryString["sid"] != null)
                {
                    GetDetails(Request.QueryString["sid"]);
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
            parameters.Add("p_Id", Id);

            var result = oDataAccess.QuerySingleOrDefaultSPDynamic<EmployeePayoutSlabModel>("sp_get_singleemppayoutslab", parameters);
            if (result != null)
            {
                txtMaxAmount.Text = "" + result.MaxAmount;
                txtMinAmount.Text = "" + result.MinAmount;
                txtPayout.Text = "" + result.Payout;
            }
        }
        private void BindGrid()
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_ProductId", Request.QueryString["id"]);

            var result = oDataAccess.QuerySPListDynamic<EmployeePayoutSlabModel>("sp_getemppayoutslab", parameters);

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
                DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                try
                {
                    if (Request.QueryString["sid"] == null)
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("p_ProductId", Request.QueryString["id"]);
                        parameters.Add("p_MinAmount", txtMinAmount.Text.Trim());
                        parameters.Add("p_MaxAmount", txtMaxAmount.Text.Trim());
                        parameters.Add("p_Payout", txtPayout.Text.Trim());
                        parameters.Add("p_CreatedOn", indianTime);

                        oDataAccess.ExecuteSPDynamic("sp_insert_emppayoutslab", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added');window.location.href='AddEmpPayoutSlab.aspx?id=" + Request.QueryString["id"] + "&pro=" + Request.QueryString["pro"] + "';", true);
                    }
                    else
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("p_MinAmount", txtMinAmount.Text.Trim());
                        parameters.Add("p_MaxAmount", txtMaxAmount.Text.Trim());
                        parameters.Add("p_Payout", txtPayout.Text.Trim());
                        parameters.Add("p_Id", Request.QueryString["sid"]);

                        oDataAccess.ExecuteSPDynamic("sp_update_emppayoutslab", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated');window.location.href='AddEmpPayoutSlab.aspx?id=" + Request.QueryString["id"] + "&pro=" + Request.QueryString["pro"] + "';", true);
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
            Response.Redirect($"AddEmpPayoutSlab.aspx?id={Request.QueryString["id"]}&sid={button.CommandArgument}&pro={Request.QueryString["pro"]}");
        }
    }
}