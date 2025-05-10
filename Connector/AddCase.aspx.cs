using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Connector
{
	public partial class AddCase : System.Web.UI.Page
	{
		private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["cnt"] == null)
			{
				Response.Redirect("../ConnectorLogin.aspx");
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
		private void GetData()
		{
			Connector_Add oConnector_Add = Session["cnt"] as Connector_Add;

			DataAccess oDataAccess = new DataAccess();
			var result = oDataAccess.QuerySPDynamic<Product_Add>("sp_getallproducts");
			ddlProduct.DataSource = result;
			ddlProduct.DataTextField = "ProductName";
			ddlProduct.DataValueField = "Id";
			ddlProduct.DataBind();

			var parameters = new DynamicParameters();
			parameters.Add("p_BranchId", oConnector_Add.BranchId);
			var employees = oDataAccess.QuerySPListDynamic<Marketing_Employee_Add>("sp_getall_marketingemp", parameters);
            employees = employees.Where(x => x.EmployeeStatus.Equals("1")).ToList();
            ddlMarketEmployee.DataSource = employees;
			ddlMarketEmployee.DataTextField = "Name";
			ddlMarketEmployee.DataValueField = "Id";
			ddlMarketEmployee.DataBind();
			ddlMarketEmployee.Items.Insert(0, new ListItem("---Select---", "0"));
		}
		private void GetDetails(string Id)
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
				ddlProfile.SelectedItem.Text = result.CustomerProfile;
				txtMonthlyIncome.Text = result.MonthlyIncome;
				txtRemarks.Text = result.ext1;
				ddlMarketEmployee.SelectedValue = result.ext4;

				ddlMarketEmployee.Enabled = false;
			}
		}
		protected void BtnSubmit_Click(object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
				DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
				try
				{
					if (txtMobileNo.Text.Length < 10)
					{
						ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Valid Mobile No.');", true);
						return;
					}

					Connector_Add oConnector_Add = Session["cnt"] as Connector_Add;
					if (Request.QueryString["id"] == null)
					{
						var parameters = new DynamicParameters();
						//parameters.Add("Name", txtName.Text);
						//parameters.Add("MobileNo", txtMobileNo.Text);
						//parameters.Add("City", txtCity.Text);
						//parameters.Add("Address", txtAddress.Text);
						//parameters.Add("ProductReq", ddlProduct.SelectedValue);
						//parameters.Add("AmountReq", txtAmount.Text);
						//parameters.Add("CustomerProfile", ddlProfile.SelectedItem.Text);
						//parameters.Add("MonthlyIncome", txtMonthlyIncome.Text);
						//parameters.Add("ConnectorId", oConnector_Add.Id);
						//parameters.Add("EmpId", 0);
						//parameters.Add("BranchId", oConnector_Add.BranchId);
						//parameters.Add("CaseRemarks", txtRemarks.Text);

						parameters.Add("p_Name", txtName.Text);
						parameters.Add("p_MobileNo", txtMobileNo.Text);
						parameters.Add("p_City", txtCity.Text);
						parameters.Add("p_Address", txtAddress.Text);
						parameters.Add("p_ProductReq", Convert.ToInt32(ddlProduct.SelectedValue));
						parameters.Add("p_AmountReq", Convert.ToDouble(txtAmount.Text));
						parameters.Add("p_CustomerProfile", ddlProfile.SelectedItem.Text);
						parameters.Add("p_MonthlyIncome", txtMonthlyIncome.Text);
						parameters.Add("p_ConnectorId", oConnector_Add.Id);
						parameters.Add("p_EmpId", 0);
						parameters.Add("p_BranchId", oConnector_Add.BranchId);
						parameters.Add("p_CreatedOn", indianTime);
						parameters.Add("p_Status", "-");
						parameters.Add("p_Remarks", txtRemarks.Text);
						parameters.Add("p_ext1", "-");
						parameters.Add("p_BankName", "-");
						parameters.Add("p_BankEmpName", "-");
						parameters.Add("p_BankEmpContactNo", "-");
						parameters.Add("p_LeadHandling", "-");
						parameters.Add("p_LeadGenerated", "-");
						parameters.Add("p_LeadGenContactNo", "-");
						parameters.Add("p_FileLogInDate", indianTime);
						parameters.Add("p_ExpectedDisbursedDate", indianTime); // Assuming today's date as default
						parameters.Add("p_ext5", 0);
						parameters.Add("p_ext6", 0);
						parameters.Add("p_ext2", 0);
						parameters.Add("p_ext3", 0);
						parameters.Add("p_ext4", ddlMarketEmployee.SelectedValue);

						DataAccess oDataAccess = new DataAccess();
						oDataAccess.ExecuteSPDynamic("sp_insertcase_marketingemp", parameters);

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
						parameters.Add("CustomerProfile", ddlProfile.SelectedItem.Text);
						parameters.Add("MonthlyIncome", txtMonthlyIncome.Text);
						parameters.Add("Id", Request.QueryString["id"]);
						parameters.Add("CaseRemarks", txtRemarks.Text);

						DataAccess oDataAccess = new DataAccess();
						oDataAccess.ExecuteSPDynamic("sp_update_case", parameters);

						ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated');window.location.href='ShowCases.aspx';", true);
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