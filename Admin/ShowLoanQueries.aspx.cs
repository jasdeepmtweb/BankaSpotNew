using System;
using System.Web.UI.WebControls;
using BankaSpotNew.App_Code;
using Dapper;

namespace BankaSpotNew.Admin
{
    public partial class ShowLoanQueries : System.Web.UI.Page
    {
        DataAccessBankaspotWeb oDataAccessBankaspotWeb = new DataAccessBankaspotWeb();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("../BranchLogin.aspx");
            }
            if (!IsPostBack)
            {
                BindGrid();
            }
            if (GridBranches.Rows.Count > 0)
            {
                GridBranches.UseAccessibleHeader = true;
                GridBranches.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridBranches.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void BindGrid()
        {
            string sql = "SELECT * FROM `tbapply` WHERE formtype=@p_formtype order by id DESC";

            var parameters = new DynamicParameters();
            parameters.Add("p_formtype", "AP");

            var result = oDataAccessBankaspotWeb.QueryDynamic<LoanQueryModel>(sql, parameters);
            if (result != null)
            {
                GridBranches.DataSource = result;
                GridBranches.DataBind();
            }
            if (GridBranches.Rows.Count > 0)
            {
                GridBranches.UseAccessibleHeader = true;
                GridBranches.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridBranches.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            string sql = "DELETE FROM `tbapply` WHERE id=@p_id";

            var parameters = new DynamicParameters();
            parameters.Add("p_id", btn.CommandArgument);

            oDataAccessBankaspotWeb.ExecuteDynamic(sql, parameters);

            BindGrid();
        }
    }
}