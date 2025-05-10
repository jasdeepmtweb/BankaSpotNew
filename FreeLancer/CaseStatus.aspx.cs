using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Linq;

namespace BankaSpotNew.FreeLancer
{
    public partial class CaseStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["frl"] == null)
            {
                Response.Redirect("../FreeLancerLogin.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    GetCaseStatus(Request.QueryString["id"].ToString());
                }
            }
        }
        private void GetCaseStatus(string CaseId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("CaseId", CaseId);
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPDynamic<Case_Status_History>("sp_get_case_status_forconn", parameters);
            if (result != null)
            {
                Case_Status_History oCase_Status_History = result.FirstOrDefault();
                if (oCase_Status_History != null)
                {
                    txtPreStatus.Text = oCase_Status_History.NewStatus.ToString();
                    txtRemarks.Text = oCase_Status_History.Remarks.ToString();
                    txtBankaspotEmp.Text = oCase_Status_History.Name.ToString();
                    txtBankName.Text = oCase_Status_History.BankName.ToString();
                    txtEmpMobileNo.Text = oCase_Status_History.MobileNo.ToString();

                    if (txtPreStatus.Text.Contains("Disbursed"))
                    {
                        txtAmount.Text = oCase_Status_History.ext5.ToString();
                    }
                    if (txtPreStatus.Text.Contains("Sanctioned"))
                    {
                        txtAmount.Text = oCase_Status_History.ext2.ToString();
                    }
                }
            }
        }
    }
}