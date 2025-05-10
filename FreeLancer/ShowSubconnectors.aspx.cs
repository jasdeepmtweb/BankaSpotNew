using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI.WebControls;

namespace BankaSpotNew.FreeLancer
{
    public partial class ShowSubconnectors : System.Web.UI.Page
    {
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["frl"] == null)
            {
                Response.Redirect("../FreeLancerLogin.aspx");
            }
            if (!IsPostBack)
            {
                GetAllCases();
            }
            if (GridAllCases.Rows.Count > 0)
            {
                GridAllCases.UseAccessibleHeader = true;
                GridAllCases.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridAllCases.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void GetAllCases()
        {
            Freelancer_Add oFreelancer_Add = Session["frl"] as Freelancer_Add;

            var parameters = new DynamicParameters();
            parameters.Add("p_Type", "SC");
            parameters.Add("p_ReferId", oFreelancer_Add.Id);
            parameters.Add("p_ReferIdType", "Freelancer");
            parameters.Add("p_Status", 1);

            var result = oDataAccess.QuerySPListDynamic<CustomerModel>("sp_getallsubconnectors_byreferid", parameters);

            GridAllCases.DataSource = result;
            GridAllCases.DataBind();

            if (GridAllCases.Rows.Count > 0)
            {
                GridAllCases.UseAccessibleHeader = true;
                GridAllCases.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridAllCases.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            Response.Redirect($"AddSubconnector.aspx?id={button.CommandArgument}");
        }
    }
}