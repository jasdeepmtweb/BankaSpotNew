using BankaSpotNew.App_Code;
using Dapper;
using System;

namespace BankaSpotNew.FreeLancer
{
    public partial class AddCase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["frl"] == null)
            {
                Response.Redirect("../FreeLancerLogin.aspx");
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
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPDynamic<Product_Add>("sp_getallproducts");
            ddlProduct.DataSource = result;
            ddlProduct.DataTextField = "ProductName";
            ddlProduct.DataValueField = "Id";
            ddlProduct.DataBind();
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
            }
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (txtMobileNo.Text.Length < 10)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Valid Mobile No.');", true);
                        return;
                    }

                    Freelancer_Add oFreelancer_Add = Session["frl"] as Freelancer_Add;
                    if (Request.QueryString["id"] == null)
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
                        parameters.Add("ConnectorId", 0);
                        parameters.Add("EmpId", 0);
                        parameters.Add("BranchId", oFreelancer_Add.BranchId);
                        parameters.Add("CaseRemarks", txtRemarks.Text);
                        parameters.Add("ext3", oFreelancer_Add.Id);

                        DataAccess oDataAccess = new DataAccess();
                        oDataAccess.ExecuteSPDynamic("sp_insert_caseby_freelancer", parameters);

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