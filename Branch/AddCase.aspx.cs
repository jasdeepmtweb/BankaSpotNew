using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Branch
{
	public partial class AddCase : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["branch"] == null)
			{
				Response.Redirect("../BranchLogin.aspx");
			}
			if (!IsPostBack)
			{
				GetData();
				if (Request.QueryString["id"] != null)
				{
					GetDetails(Request.QueryString["id"]);
				}
			}
		}
		private void GetDetails(string Id)
		{
			if (Request.QueryString["typ"] == null)
			{
				var parameters = new DynamicParameters();
				parameters.Add("Id", Id);
				DataAccess oDataAccess = new DataAccess();
				var result = oDataAccess.QuerySingleOrDefaultSPDynamic<Case_Add>("sp_getcaseby_id", parameters);
				if (result != null)
				{
					txtName.Text = result.Name;
					txtMobileNo.Text = result.MobileNo;
					txtCity.Text = result.City;
					txtAddress.Text = result.Address;
					ddlProduct.SelectedValue = "" + result.ProductReq;
					txtAmount.Text = "" + result.AmountReq;
					txtProfile.Text = result.CustomerProfile;
					txtMonthlyIncome.Text = result.MonthlyIncome;
					//txtRemarks.Text = result.ext1;

					txtBankName.Text = result.BankName;
					txtBankEmpName.Text = result.BankEmpName;
					txtBankEmpContact.Text = result.BankEmpContactNo;
					txtLeadHandling.Text = result.LeadHandling;
					//txtLeadHandling.Text = oEmployee_Add.Name;

					//txtLeadGenerated.Text = result.LeadGenerated;
					//txtLeadGeneratedContactNo.Text = result.LeadGenContactNo;

					ddlMarketEmployee.SelectedValue = result.ext4;
					if (result.ConnectorId != 0)
					{
						parameters = new DynamicParameters();
						parameters.Add("Id", result.ConnectorId);
						var connector = oDataAccess.QuerySingleOrDefaultSPDynamic<Connector_Add>("sp_getconnectorby_id", parameters);

						txtLeadGenerated.Text = connector.Name;
						txtLeadGeneratedContactNo.Text = connector.MobileNo;
					}
					else
					{
						txtLeadGenerated.Text = result.LeadGenerated;
						txtLeadGeneratedContactNo.Text = result.LeadGenContactNo;
					}
					try
					{
						txtFileLoginDate.Text = Convert.ToDateTime(result.FileLogInDate).ToString("yyyy-MM-dd");
						txtExpectedDisbursedDate.Text = Convert.ToDateTime(result.ExpectedDisbursedDate).ToString("yyyy-MM-dd");
					}
					catch (Exception ex)
					{
						var errorLogger = new Log("ErrorLog.txt");
						errorLogger.LogError(ex);
					}
				}
			}
			else
			{
				var parameters = new DynamicParameters();
				parameters.Add("Id", Id);
				DataAccess oDataAccess = new DataAccess();
				var result = oDataAccess.QuerySingleOrDefaultSPDynamic<Case_Add>("sp_getcase_byidfor_freelancer", parameters);
				if (result != null)
				{
					txtName.Text = result.Name;
					txtMobileNo.Text = result.MobileNo;
					txtCity.Text = result.City;
					txtAddress.Text = result.Address;
					ddlProduct.SelectedValue = "" + result.ProductReq;
					txtAmount.Text = "" + result.AmountReq;
					txtProfile.Text = result.CustomerProfile;
					txtMonthlyIncome.Text = result.MonthlyIncome;
					//txtRemarks.Text = result.ext1;

					txtBankName.Text = result.BankName;
					txtBankEmpName.Text = result.BankEmpName;
					txtBankEmpContact.Text = result.BankEmpContactNo;
					txtLeadHandling.Text = result.LeadHandling;
					//txtLeadHandling.Text = oEmployee_Add.Name;

					//txtLeadGenerated.Text = result.LeadGenerated;
					//txtLeadGeneratedContactNo.Text = result.LeadGenContactNo;
					txtLeadGenerated.Text = result.ConnectorName;
					txtLeadGeneratedContactNo.Text = result.ConnectorMobileNo;
					ddlMarketEmployee.SelectedValue = result.ext4;
					try
					{
						txtFileLoginDate.Text = Convert.ToDateTime(result.FileLogInDate).ToString("yyyy-MM-dd");
						txtExpectedDisbursedDate.Text = Convert.ToDateTime(result.ExpectedDisbursedDate).ToString("yyyy-MM-dd");
					}
					catch (Exception ex)
					{
						var errorLogger = new Log("ErrorLog.txt");
						errorLogger.LogError(ex);
					}
				}
			}

		}
		private void GetData()
		{
			Branch_Add oBranch_Add = Session["branch"] as Branch_Add;

			DataAccess oDataAccess = new DataAccess();
			var result = oDataAccess.QuerySPDynamic<Product_Add>("sp_getallproducts");
			ddlProduct.DataSource = result;
			ddlProduct.DataTextField = "ProductName";
			ddlProduct.DataValueField = "Id";
			ddlProduct.DataBind();

			var parameters = new DynamicParameters();
			parameters.Add("p_BranchId", oBranch_Add.Id);
			var employees = oDataAccess.QuerySPListDynamic<Marketing_Employee_Add>("sp_getall_marketingemp", parameters);
			employees = employees.Where(x => x.EmployeeStatus.Equals("1")).ToList();
			ddlMarketEmployee.DataSource = employees;
			ddlMarketEmployee.DataTextField = "Name";
			ddlMarketEmployee.DataValueField = "Id";
			ddlMarketEmployee.DataBind();
			ddlMarketEmployee.Items.Insert(0, new ListItem("---Select---", "0"));
		}
		protected void BtnSubmit_Click(object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
				try
				{
					if (txtMobileNo.Text.Length < 10)
					{
						ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Valid Mobile No.!!');", true);
						return;
					}
					if (txtBankEmpContact.Text.Length < 10)
					{
						ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Valid Contact No.!!');", true);
						return;
					}
					if (txtLeadGeneratedContactNo.Text.Length < 10)
					{
						ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Valid Contact No.!!');", true);
						return;
					}

					Branch_Add oBranch_Add = Session["branch"] as Branch_Add;
					if (Request.QueryString["id"] == null)
					{
						var parameters = new DynamicParameters();
						parameters.Add("Name", txtName.Text);
						parameters.Add("MobileNo", txtMobileNo.Text);
						parameters.Add("City", txtCity.Text);
						parameters.Add("Address", txtAddress.Text);
						parameters.Add("ProductReq", ddlProduct.SelectedValue);
						parameters.Add("AmountReq", txtAmount.Text);
						parameters.Add("CustomerProfile", txtProfile.Text);
						parameters.Add("MonthlyIncome", txtMonthlyIncome.Text);
						parameters.Add("ConnectorId", 0);
						parameters.Add("EmpId", 0);
						parameters.Add("BranchId", oBranch_Add.Id);

						DataAccess oDataAccess = new DataAccess();
						oDataAccess.ExecuteSPDynamic("sp_insert_case", parameters);

						ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added');window.location.href='AddCase.aspx';", true);
					}
					else
					{
						var parameters = new DynamicParameters();
						parameters.Add("Name", txtName.Text);
						parameters.Add("MobileNo", txtMobileNo.Text);
						parameters.Add("City", txtCity.Text);
						parameters.Add("Address", txtAddress.Text);
						parameters.Add("ProductReq", ddlProduct.SelectedValue);
						parameters.Add("AmountReq", txtAmount.Text);
						parameters.Add("CustomerProfile", txtProfile.Text);
						parameters.Add("MonthlyIncome", txtMonthlyIncome.Text);
						parameters.Add("Id", Request.QueryString["id"]);
						//parameters.Add("ext1", txtRemarks.Text);

						parameters.Add("BankName", txtBankName.Text);
						parameters.Add("BankEmpName", txtBankEmpName.Text);
						parameters.Add("BankEmpContactNo", txtBankEmpContact.Text);
						parameters.Add("LeadHandling", txtLeadHandling.Text);
						parameters.Add("LeadGenerated", txtLeadGenerated.Text);
						parameters.Add("LeadGenContactNo", txtLeadGeneratedContactNo.Text);
						parameters.Add("FileLogInDate", txtFileLoginDate.Text);
						parameters.Add("ExpectedDisbursedDate", txtExpectedDisbursedDate.Text);
						parameters.Add("p_ext4", ddlMarketEmployee.SelectedValue);

						DataAccess oDataAccess = new DataAccess();
						oDataAccess.ExecuteSPDynamic("sp_update_case_bybranch", parameters);

						if (Request.QueryString["pgtyp"] == null)
						{
							ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated');window.location.href='ShowCases.aspx';", true);
						}
						else if (Request.QueryString["pgtyp"].ToString().Equals("emp"))
						{
							ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated');window.location.href='CasesFromEmployee.aspx';", true);
						}
						else if (Request.QueryString["pgtyp"].ToString().Equals("memp"))
						{
							ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated');window.location.href='CaseFromMaketEmp.aspx';", true);
						}
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