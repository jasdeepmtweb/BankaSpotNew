using BankaSpotNew.App_Code;
using System;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Employee
{
    public partial class ShowConnector : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["emp"] == null)
            {
                Response.Redirect("../EmployeeLogin.aspx");
            }
            if (!IsPostBack)
            {
                Employee_Add oEmployee_Add = Session["emp"] as Employee_Add;
                BindGrid(oEmployee_Add.Id);
            }
            if (GridShowConnector.Rows.Count > 0)
            {
                GridShowConnector.UseAccessibleHeader = true;
                GridShowConnector.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridShowConnector.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        private void BindGrid(int id)
        {
            var parameters = new
            {
                EmployeeId = id
            };
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySP<Connector_Add>("sp_getallconnectors", parameters);
            if (result != null)
            {
                foreach (var item in result)
                {
                    item.ConnectorPic = $"../Uploads/ConnectorPics/{item.ConnectorPic}";
                }
                GridShowConnector.DataSource = result;
                GridShowConnector.DataBind();
            }
            if (GridShowConnector.Rows.Count > 0)
            {
                GridShowConnector.UseAccessibleHeader = true;
                GridShowConnector.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridShowConnector.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        protected void btedt_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Response.Redirect($"AddConnector.aspx?id={button.CommandArgument}");
        }

        protected void btndel_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            var parameters = new
            {
                Id = button.CommandArgument
            };
            DataAccess oDataAccess = new DataAccess();
            oDataAccess.ExecuteSP("sp_delete_connector", parameters);
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Deleted');window.location.href='ShowConnector.aspx';", true);
        }
    }
}