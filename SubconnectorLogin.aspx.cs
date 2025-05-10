using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI;

namespace BankaSpotNew
{
    public partial class SubconnectorLogin : System.Web.UI.Page
    {
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_CustomerMobileNo", txtMobileNo.Text.Trim());
            parameters.Add("p_Password", txtPassword.Text.Trim());
            parameters.Add("p_Status", 1);

            var res = oDataAccess.QuerySingleOrDefaultSPDynamic<CustomerModel>("sp_customer_login", parameters);

            if (res != null)
            {
                if (res.Type.Equals("SC"))
                {
                    Session["scon"] = res;

                    Response.Redirect("SubConnector/ShowAllCases.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "showSweetAlert", "Swal.fire('Error!', 'Invalid Mobile No. Or Password', 'warning');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "showSweetAlert", "Swal.fire('Error!', 'Invalid Mobile No. Or Password', 'warning');", true);
            }
        }
    }
}