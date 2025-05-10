using BankaSpotNew.App_Code;
using System;
using System.Web.UI.WebControls;

namespace BankaSpotNew.MarketingEmp
{
    public partial class ShowBankCodes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["memp"] == null)
            {
                Response.Redirect("../MarketingEmpLogin.aspx");
            }
            if (!IsPostBack)
            {
                BindGrid();
            }
            if (GridBankCodes.Rows.Count > 0)
            {
                GridBankCodes.UseAccessibleHeader = true;
                GridBankCodes.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridBankCodes.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void BindGrid()
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
    }
}