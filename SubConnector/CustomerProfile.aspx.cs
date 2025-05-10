using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankaSpotNew.SubConnector
{
    public partial class CustomerProfile : System.Web.UI.Page
    {
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["scon"] == null)
            {
                Response.Redirect("../SubconnectorLogin.aspx");
            }
            if (!IsPostBack)
            {
                GetAllBranches();
                GetCustomerData();
            }
        }
        private void GetAllBranches()
        {
            var branches = oDataAccess.QuerySPListDynamic<Branch_Add>("sp_getallbranches");
            ddlLocation.DataSource = branches;
            ddlLocation.DataTextField = "BranchName";
            ddlLocation.DataValueField = "Id";
            ddlLocation.DataBind();
            ddlLocation.Items.Insert(0, new ListItem("Select", "0"));
        }
        private void GetCustomerData()
        {
            CustomerModel oCustomerModel = Session["scon"] as CustomerModel;

            var parameters = new DynamicParameters();
            parameters.Add("p_Id", oCustomerModel.Id);
            parameters.Add("p_Status", 1);

            var res = oDataAccess.QuerySingleOrDefaultSPDynamic<CustomerModel>("sp_getsingle_customerbyid", parameters);

            if (res != null)
            {
                txtAddress.Text = res.Address;
                txtCity.Text = res.City;
                txtEmailId.Text = res.EmailId;
                txtMobileNo.Text = res.CustomerMobileNo;
                txtName.Text = res.CustomerName;
                ddlLocation.SelectedValue = res.BranchId.ToString();
            }
        }
        protected void ShowSweetAlert()
        {
            // Execute JavaScript code to show the SweetAlert and redirect after it is dismissed
            string script = @"
        Swal.fire({
            title: 'Success!',
            text: 'Successfully Updated',
            icon: 'success',
        }).then((result) => {
            if (result.isConfirmed || result.isDismissed) {
                window.location.href = 'CustomerProfile.aspx';
            }
        });
    ";

            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "showSweetAlert", script, true);
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (txtMobileNo.Text.Length < 10)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "showSweetAlert", "Swal.fire('Error!', 'Enter Valid Mobile No.!!', 'warning');", true);
                        return;
                    }
                    CustomerModel oCustomerModel = Session["scon"] as CustomerModel;
                    var parameters = new DynamicParameters();
                    parameters.Add("p_CustomerName", txtName.Text);
                    parameters.Add("p_CustomerMobileNo", txtMobileNo.Text);
                    parameters.Add("p_City", txtCity.Text);
                    parameters.Add("p_Address", txtAddress.Text);
                    parameters.Add("p_BranchId", ddlLocation.SelectedValue);
                    parameters.Add("p_EmailId", txtEmailId.Text);
                    parameters.Add("p_Id", oCustomerModel.Id);

                    oDataAccess.ExecuteSPDynamic("sp_update_customer", parameters);

                    ShowSweetAlert();
                }
                catch (Exception ex)
                {
                    var errorLogger = new Log("ErrorLog.txt");
                    errorLogger.LogError(ex);

                    if (ex.Message.Contains("Duplicate"))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "showSweetAlert", "Swal.fire('Error!', 'Mobile No. Already Exists!', 'warning');", true);
                    }
                }
            }
        }
    }
}