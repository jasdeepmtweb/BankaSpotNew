using BankaSpotNew.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Accountant
{
    public partial class ShowAllCases : System.Web.UI.Page
    {
        static List<Case_Add> allCaseList = new List<Case_Add>();
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["acc"] == null)
            {
                Response.Redirect("../AccountantLogin.aspx");
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
            allCaseList.Clear();

            var result = oDataAccess.QuerySPListDynamic<Case_Add>("sp_getallcases_foraccountant");
            GridAllCases.DataSource = result;
            GridAllCases.DataBind();

            allCaseList = result;

            if (GridAllCases.Rows.Count > 0)
            {
                GridAllCases.UseAccessibleHeader = true;
                GridAllCases.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridAllCases.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void txtSearchByEmpName_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearchByEmpName.Text;

            List<Case_Add> filteredCaseList = allCaseList.Where(x => x.EmpName != null && x.EmpName.ToLower().Contains(searchValue.ToLower())).ToList();

            GridAllCases.DataSource = filteredCaseList;
            GridAllCases.DataBind();

            if (GridAllCases.Rows.Count > 0)
            {
                GridAllCases.UseAccessibleHeader = true;
                GridAllCases.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridAllCases.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void txtSearchByLGName_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearchByLGName.Text;

            List<Case_Add> filteredCaseList = allCaseList.Where(x => x.LeadGenerated != null && x.LeadGenerated.ToLower().Contains(searchValue.ToLower())).ToList();
            GridAllCases.DataSource = filteredCaseList;
            GridAllCases.DataBind();

            if (GridAllCases.Rows.Count > 0)
            {
                GridAllCases.UseAccessibleHeader = true;
                GridAllCases.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridAllCases.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void txtSearchByCaseStatus_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearchByCaseStatus.Text;

            List<Case_Add> filteredCaseList = allCaseList.Where(x => x.Status != null && x.Status.ToLower().Contains(searchValue.ToLower())).ToList();
            GridAllCases.DataSource = filteredCaseList;
            GridAllCases.DataBind();

            if (GridAllCases.Rows.Count > 0)
            {
                GridAllCases.UseAccessibleHeader = true;
                GridAllCases.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridAllCases.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void txtSearchByBankName_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearchByBankName.Text;

            List<Case_Add> filteredCaseList = allCaseList.Where(x => x.BankName != null && x.BankName.ToLower().Contains(searchValue.ToLower())).ToList();
            GridAllCases.DataSource = filteredCaseList;
            GridAllCases.DataBind();

            if (GridAllCases.Rows.Count > 0)
            {
                GridAllCases.UseAccessibleHeader = true;
                GridAllCases.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridAllCases.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void txtSearchByProduct_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearchByProduct.Text;

            List<Case_Add> filteredCaseList = allCaseList.Where(x => x.ProductName != null && x.ProductName.ToLower().Contains(searchValue.ToLower())).ToList();
            GridAllCases.DataSource = filteredCaseList;
            GridAllCases.DataBind();

            if (GridAllCases.Rows.Count > 0)
            {
                GridAllCases.UseAccessibleHeader = true;
                GridAllCases.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridAllCases.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void BtnAddExpenses_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            Response.Redirect($"AddExpenses.aspx?id={button.CommandArgument}");
        }
    }
}