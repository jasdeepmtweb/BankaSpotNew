using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Employee
{
    public partial class AllCases : System.Web.UI.Page
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
            if (GridAllCases.Rows.Count > 0)
            {
                GridAllCases.UseAccessibleHeader = true;
                GridAllCases.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridAllCases.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void BindGrid(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("EmpId", id);
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPDynamic<Case_Add>("sp_getallcaselist_foremp", parameters);
            if (result != null)
            {
                result = result.Where(x => !x.Status.Contains("Disbursed") && !x.Status.Contains("Rejected"));
                GridAllCases.DataSource = result;
                GridAllCases.DataBind();
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

            //var parameters = new DynamicParameters();
            //parameters.Add("Id", button.CommandArgument);
            //DataAccess oDataAccess = new DataAccess();
            //var result = oDataAccess.QuerySingleOrDefaultSPDynamic<Case_Add>("sp_getcase_details", parameters);

            //if (result != null)
            //{
            //    lblAddress.Text = result.Address;
            //    lblAmountRequired.Text = "" + result.AmountReq;
            //    lblCity.Text = result.City;
            //    lblConnector.Text = result.ConnectorName;
            //    lblMobile.Text = result.MobileNo;
            //    lblMonthlyIncome.Text = result.MonthlyIncome;
            //    lblName.Text = result.Name;
            //    lblProfile.Text = result.CustomerProfile;
            //    lblProReq.Text = result.ProductName;

            //    ShowModalPopup();
            //}

            Response.Redirect($"EditCase.aspx?id={button.CommandArgument}");
        }
        protected void ShowModalPopup()
        {
            hdnShowModal.Value = "1";
            hdnShowHistoryModal.Value = "0";
        }
        protected void ShowHistoryModalPopup()
        {
            hdnShowModal.Value = "0";
            hdnShowHistoryModal.Value = "1";
        }
        protected void BtnCaseHistory_Click(object sender, EventArgs e)
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

        protected void BtnExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "AllCases" + DateTime.Now.Ticks + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GridAllCases.GridLines = GridLines.Both;
            GridAllCases.HeaderStyle.Font.Bold = true;
            GridAllCases.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //
        }
    }
}