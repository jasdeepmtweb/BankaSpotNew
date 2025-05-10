using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Admin
{
    public partial class ShowBranches : System.Web.UI.Page
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
            string sql = "SELECT * FROM tbbranch WHERE Role=0 order by Id DESC";

            var result = oDataAccess.Query<Branch_Add>(sql);
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

        protected void btndel_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string sql = "DELETE FROM tbbranch WHERE Id=@Id";
            var parameters = new
            {
                Id = button.CommandArgument
            };

            oDataAccess.Execute(sql, parameters);
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Deleted');window.location.href='ShowBranches.aspx';", true);
        }

        protected void btedt_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Response.Redirect($"AddBranch.aspx?id={button.CommandArgument}");
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            var parameters = new DynamicParameters();
            parameters.Add("Id", button.CommandArgument);

            var result = oDataAccess.QuerySingleOrDefaultSPDynamic<Branch_Add>("sp_getbranchby_id", parameters);

            if (result != null)
            {
                Session["branch"] = result;
                Response.Redirect("../Branch/Dashboard.aspx", true);
            }
        }
    }
}