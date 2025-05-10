using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Branch
{
    public partial class TransferCaseFromEmpToEmp : System.Web.UI.Page
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["branch"] == null)
            {
                Response.Redirect("../BranchLogin.aspx");
            }
            if (!IsPostBack)
            {
                Branch_Add oBranch_Add = Session["branch"] as Branch_Add;

                if (Request.QueryString["id"] != null && Request.QueryString["empid"] != null)
                {
                    BindGrid(oBranch_Add.Id);
                }
            }
        }
        private void BindGrid(int Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("BranchId", Id);

            var result = oDataAccess.QuerySPListDynamic<Employee_Add>("sp_getallemployee", parameters).ToList();
            result = result.Where(x => x.EmployeeStatus.Equals("1")).ToList();
            lblPreviousEmp.Text = result.Where(x => x.Id == Convert.ToInt32(Request.QueryString["empid"])).FirstOrDefault()?.Name;
            result = result.Where(x => x.Id != Convert.ToInt32(Request.QueryString["empid"])).ToList();
            ddlEmployee.DataSource = result;
            ddlEmployee.DataTextField = "Name";
            ddlEmployee.DataValueField = "Id";
            ddlEmployee.DataBind();
            ddlEmployee.Items.Insert(0, new ListItem("---Select---", "0"));

            parameters.Add("Id", Request.QueryString["id"]);
            oDataAccess = new DataAccess();
            var CaseDetail = oDataAccess.QuerySingleOrDefaultSPDynamic<Case_Add>("sp_getcaseby_id", parameters);

            if (CaseDetail != null)
            {
                lblCustomerName.Text = CaseDetail.Name;
                lblProductName.Text = CaseDetail.ProductName;
            }
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                    if (Request.QueryString["id"] != null)
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("p_EmpId", ddlEmployee.SelectedValue);
                        parameters.Add("p_LeadHandling", ddlEmployee.SelectedItem.Text);
                        parameters.Add("p_Id", Request.QueryString["id"]);


                        oDataAccess.ExecuteSPDynamic("sp_addemployeeto_freelancercase", parameters);

                        parameters = new DynamicParameters();
                        parameters.Add("p_CaseId", Request.QueryString["id"]);
                        parameters.Add("p_EmployeeId", ddlEmployee.SelectedValue);
                        parameters.Add("p_CreatedOn", indianTime);

                        oDataAccess.ExecuteSPDynamic("sp_insert_empcasehistory", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added');window.location.href='CasesFromEmployee.aspx';", true);
                    }
                }
                catch (Exception ex)
                {
                    var errorLogger = new Log("ErrorLog.txt");
                    errorLogger.LogError(ex);
                    if (ex.Message.Contains("Duplicate"))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Mobile No. Already Exists');", true);
                    }
                }
            }
        }
    }
}