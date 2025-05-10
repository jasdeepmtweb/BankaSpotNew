using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Admin
{
    public partial class AddBankCodes : System.Web.UI.Page
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
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
            if (GridBankCodes.Rows.Count > 0)
            {
                GridBankCodes.UseAccessibleHeader = true;
                GridBankCodes.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridBankCodes.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void GetDetails(string Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_Id", Id);
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySingleOrDefaultSPDynamic<BankCodes_Add>("sp_getbankcodeby_id", parameters);
            if (result != null)
            {
                txtBankCode.Text = result.BankCode;
                txtBankName.Text = result.BankName;
                txtCode.Text = result.CodeName;
                txtProduct.Text = result.ProductName;
            }
        }
        private void GetData()
        {
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPListDynamic<BankCodes_Add>("sp_getallbankcodes");
            GridBankCodes.DataSource = result;
            GridBankCodes.DataBind();

            if (GridBankCodes.Rows.Count > 0)
            {
                GridBankCodes.UseAccessibleHeader = true;
                GridBankCodes.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridBankCodes.FooterRow.TableSection = TableRowSection.TableFooter;
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
                        parameters.Add("p_BankName", txtBankName.Text);
                        parameters.Add("p_ProductName", txtProduct.Text);
                        parameters.Add("p_CodeName", txtCode.Text);
                        parameters.Add("p_BankCode", txtBankCode.Text);
                        parameters.Add("p_CreatedOn", indianTime);

                        DataAccess oDataAccess = new DataAccess();
                        oDataAccess.ExecuteSPDynamic("sp_insert_bankcodes", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added');window.location.href='AddBankCodes.aspx';", true);
                    }
                    else
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("p_BankName", txtBankName.Text);
                        parameters.Add("p_ProductName", txtProduct.Text);
                        parameters.Add("p_CodeName", txtCode.Text);
                        parameters.Add("p_BankCode", txtBankCode.Text);
                        parameters.Add("p_Id", Request.QueryString["id"]);

                        DataAccess oDataAccess = new DataAccess();
                        oDataAccess.ExecuteSPDynamic("sp_update_bankcodes", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated');window.location.href='AddBankCodes.aspx';", true);
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

            Response.Redirect($"AddBankCodes.aspx?id={button.CommandArgument}");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            var parameters = new DynamicParameters();
            parameters.Add("p_Id", button.CommandArgument);

            DataAccess oDataAccess = new DataAccess();
            oDataAccess.ExecuteSPDynamic("sp_delete_bankcode", parameters);

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Deleted');window.location.href='AddBankCodes.aspx';", true);
        }
    }
}