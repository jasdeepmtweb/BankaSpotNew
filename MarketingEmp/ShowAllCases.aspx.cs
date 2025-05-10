using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankaSpotNew.MarketingEmp
{
    public partial class ShowAllCases : System.Web.UI.Page
    {
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["memp"] == null)
            {
                Response.Redirect("../MarketingEmpLogin.aspx");
            }
            if (!IsPostBack)
            {
                GetData();
            }
            if (GridAllCases.Rows.Count > 0)
            {
                GridAllCases.UseAccessibleHeader = true;
                GridAllCases.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridAllCases.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        private void GetData()
        {
            Marketing_Employee_Add oMarketing_Employee_Add = Session["memp"] as Marketing_Employee_Add;
            List<Case_Add> allCases = new List<Case_Add>();

            if ((Request.QueryString["conid"] == null || Request.QueryString["conid"].ToString().Equals("")) && (Request.QueryString["typ"] == null || Request.QueryString["typ"].ToString().Equals("")))
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_MarketingEmpId", oMarketing_Employee_Add.Id);
                allCases = oDataAccess.QuerySPListDynamic<Case_Add>("sp_getcasesfor_marketingemp", parameters);
                allCases = allCases.Where(x => !x.Status.Contains("Disbursed") && !x.Status.Contains("Rejected") && !x.Status.Contains("Denied")).ToList();
            }
            else if (Request.QueryString["conid"] != null && !Request.QueryString["conid"].ToString().Equals("") && Request.QueryString["typ"] != null && !Request.QueryString["typ"].ToString().Equals(""))
            {
                var parameters = new DynamicParameters();
                parameters.Add("ConnectorId", Request.QueryString["conid"]);
                allCases = oDataAccess.QuerySPListDynamic<Case_Add>("sp_getcasesby_conid", parameters);

                if (Request.QueryString["typ"].ToString().Equals("all"))
                {
                    allCases = allCases.Where(x => !x.Status.Contains("Disbursed") && !x.Status.Contains("Rejected") && !x.Status.Contains("Denied")).ToList();
                }
                if (Request.QueryString["typ"].ToString().Equals("dis"))
                {
                    allCases = allCases.Where(x => x.Status.Contains("Disbursed")).ToList();
                }
                if (Request.QueryString["typ"].ToString().Equals("rej"))
                {
                    allCases = allCases.Where(x => x.Status.Contains("Rejected") || x.Status.Contains("Denied")).ToList();
                }
            }
            else if (Request.QueryString["frid"] != null && !Request.QueryString["frid"].ToString().Equals("") && Request.QueryString["typ"] != null && !Request.QueryString["typ"].ToString().Equals(""))
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_FreelancerId", Request.QueryString["frid"]);
                allCases = oDataAccess.QuerySPListDynamic<Case_Add>("sp_getcasesby_freelancerid", parameters);

                if (Request.QueryString["typ"].ToString().Equals("all"))
                {
                    allCases = allCases.Where(x => !x.Status.Contains("Disbursed") && !x.Status.Contains("Rejected") && !x.Status.Contains("Denied")).ToList();
                }
                if (Request.QueryString["typ"].ToString().Equals("dis"))
                {
                    allCases = allCases.Where(x => x.Status.Contains("Disbursed")).ToList();
                }
                if (Request.QueryString["typ"].ToString().Equals("rej"))
                {
                    allCases = allCases.Where(x => x.Status.Contains("Rejected") || x.Status.Contains("Denied")).ToList();
                }
            }

            if (allCases != null)
            {
                GridAllCases.DataSource = allCases;
                GridAllCases.DataBind();
            }
            if (GridAllCases.Rows.Count > 0)
            {
                GridAllCases.UseAccessibleHeader = true;
                GridAllCases.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridAllCases.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        public bool SetButtonVisibility()
        {
            if (Request.QueryString["conid"] != null && !Request.QueryString["conid"].ToString().Equals(""))
            {
                return false;
            }
            if (Request.QueryString["frid"] != null && !Request.QueryString["frid"].ToString().Equals(""))
            {
                return false;
            }
            return true;
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
        protected void BtnCheckStatus_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            var parameters = new DynamicParameters();
            parameters.Add("CaseId", button.CommandArgument);

            var result = oDataAccess.QuerySPDynamic<Case_Status_History>("sp_getcasehistory_bycaseid", parameters);
            if (result != null)
            {
                GridCaseHistory.DataSource = result;
                GridCaseHistory.DataBind();

                ShowHistoryModalPopup();
            }
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            Response.Redirect($"AddCase.aspx?id={button.CommandArgument}");
        }
    }
}