using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Admin
{
    public partial class AddAccountant : System.Web.UI.Page
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

            var result = oDataAccess.QuerySingleOrDefaultSPDynamic<AccountantModel>("sp_getaccountantby_id", parameters);
            if (result != null)
            {
                txtEmailId.Text = result.EmailId;
                txtPassword.Text = result.Password;
                txtMobileNo.Text = result.MobileNo;
                txtName.Text = result.Name;
            }
        }
        private void GetData()
        {
            var result = oDataAccess.QuerySPListDynamic<AccountantModel>("sp_getallaccountants");
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
                        parameters.Add("p_Name", txtName.Text);
                        parameters.Add("p_MobileNo", txtMobileNo.Text);
                        parameters.Add("p_EmailId", txtEmailId.Text);
                        parameters.Add("p_Password", txtPassword.Text);
                        parameters.Add("p_CreatedOn", indianTime);

                        oDataAccess.ExecuteSPDynamic("sp_insert_accountant", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added');window.location.href='AddAccountant.aspx';", true);
                    }
                    else
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("p_Name", txtName.Text);
                        parameters.Add("p_MobileNo", txtMobileNo.Text);
                        parameters.Add("p_EmailId", txtEmailId.Text);
                        parameters.Add("p_Password", txtPassword.Text);
                        parameters.Add("p_Id", Request.QueryString["id"]);

                        oDataAccess.ExecuteSPDynamic("sp_update_accountant", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated');window.location.href='AddAccountant.aspx';", true);
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Duplicate"))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Mobile No. Already Exists!');", true);
                    }
                    var errorLogger = new Log("ErrorLog.txt");
                    errorLogger.LogError(ex);
                }
            }
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            Response.Redirect($"AddAccountant.aspx?id={button.CommandArgument}");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            var parameters = new DynamicParameters();
            parameters.Add("p_Id", button.CommandArgument);

            oDataAccess.ExecuteSPDynamic("sp_delete_accountant", parameters);

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Deleted');window.location.href='AddAccountant.aspx';", true);
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            var parameters = new DynamicParameters();
            parameters.Add("p_Id", button.CommandArgument);

            var result = oDataAccess.QuerySingleOrDefaultSPDynamic<AccountantModel>("sp_getaccountantby_id", parameters);

            if (result != null)
            {
                Session["acc"] = result;
                Response.Redirect("../Accountant/ShowAllCases.aspx", true);
            }
        }
    }
}