using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Branch
{
    public partial class ShowCases : System.Web.UI.Page
    {
        static List<Case_Add> allCaseList = new List<Case_Add>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["branch"] == null)
            {
                Response.Redirect("../BranchLogin.aspx");
            }
            if (!IsPostBack)
            {
                Branch_Add oBranch_Add = Session["branch"] as Branch_Add;
                BindGrid(oBranch_Add.Id);
            }
            if (GridAllCases.Rows.Count > 0)
            {
                GridAllCases.UseAccessibleHeader = true;
                GridAllCases.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridAllCases.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void BindGrid(int id)
        {
            allCaseList.Clear();

            var parameters = new DynamicParameters();
            parameters.Add("BranchId", id);
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPListDynamic<Case_Add>("sp_allcasesfor_branch", parameters);
            if (result != null)
            {
                if (Request.QueryString["conid"] != null && !Request.QueryString["conid"].ToString().Equals(""))
                {
                    result = result.Where(x => x.ConnectorId == Convert.ToInt32(Request.QueryString["conid"])).ToList();
                }
                if (Request.QueryString["frid"] != null && !Request.QueryString["frid"].ToString().Equals(""))
                {
                    result = result.Where(x => x.ext3.Equals(Request.QueryString["frid"])).ToList();
                }
                //foreach (var item in result)
                //{
                //    parameters = new DynamicParameters();
                //    parameters.Add("Id", item.EmpId);
                //    var employee = oDataAccess.QuerySingleOrDefaultSPDynamic<Employee_Add>("sp_getemployeeby_id", parameters);
                //    if (employee != null)
                //    {
                //        item.EmpName = employee.Name;
                //    }
                //    parameters = new DynamicParameters();
                //    parameters.Add("p_Id", item.ext4);
                //    var markEmployee = oDataAccess.QuerySingleOrDefaultSPDynamic<Marketing_Employee_Add>("sp_getmarketingempby_id", parameters);
                //    if (markEmployee != null)
                //    {
                //        item.MarketingEmpName = markEmployee.Name;
                //    }
                //}

                result = result.Where(x => !x.Status.Contains("Disbursed") && !x.Status.Contains("Rejected") && !x.Status.Contains("Denied")).ToList();
                GridAllCases.DataSource = result;
                GridAllCases.DataBind();

                allCaseList = result;
            }
            if (GridAllCases.Rows.Count > 0)
            {
                GridAllCases.UseAccessibleHeader = true;
                GridAllCases.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridAllCases.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        protected void btedt_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Response.Redirect($"AddCase.aspx?id={button.CommandArgument}");
        }

        protected void btndel_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            var parameters = new DynamicParameters();
            parameters.Add("Id", button.CommandArgument);
            DataAccess oDataAccess = new DataAccess();
            oDataAccess.ExecuteSPDynamic("sp_delete_case", parameters);
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Deleted');window.location.href='ShowCases.aspx';", true);
        }
        protected void ShowHistoryModalPopup()
        {
            hdnShowHistoryModal.Value = "1";
        }
        protected void BtnCheckStatus_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            var parameters = new DynamicParameters();
            parameters.Add("CaseId", button.CommandArgument);
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPDynamic<Case_Status_History>("sp_getcasehistory_bycaseid", parameters);
            if (result != null)
            {
                GridCaseHistory.DataSource = result;
                GridCaseHistory.DataBind();

                ShowHistoryModalPopup();
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

        protected void BtnTransfer_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;


        }
    }
}