using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Employee
{
    public partial class ShowTrancheDetails : System.Web.UI.Page
    {
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["emp"] == null)
            {
                Response.Redirect("../EmployeeLogin.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    BindGrid();
                }
            }
            if (GridCase.Rows.Count > 0)
            {
                GridCase.UseAccessibleHeader = true;
                GridCase.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridCase.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        private void BindGrid()
        {
            var parameters = new DynamicParameters();
            parameters.Add("CaseId", Request.QueryString["id"]);

            var result = oDataAccess.QuerySPListDynamic<Case_Status_History>("sp_getcasehistory_bycaseid", parameters);

            result = result.Where(x => x.NewStatus.ToLower().Contains("tranche")).ToList();

            GridCase.DataSource = result;
            GridCase.DataBind();

            if (GridCase.Rows.Count > 0)
            {
                GridCase.UseAccessibleHeader = true;
                GridCase.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridCase.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void BtnEditTranche_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            Response.Redirect($"EditTrancheDetails.aspx?id={button.CommandArgument}");
        }
    }
}