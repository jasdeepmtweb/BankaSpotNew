using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Branch
{
    public partial class AddEmployeeTarget : System.Web.UI.Page
    {
        DataAccess oDataAccess = new DataAccess();
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
                    BindGrid(Request.QueryString["id"]);
                }
            }
            if (GridEmployeeTarget.Rows.Count > 0)
            {
                GridEmployeeTarget.UseAccessibleHeader = true;
                GridEmployeeTarget.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridEmployeeTarget.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void GetData()
        {
            var result = oDataAccess.QuerySPListDynamic<Product_Add>("sp_getallproducts");
            ddlProduct.DataSource = result;
            ddlProduct.DataTextField = "ProductName";
            ddlProduct.DataValueField = "Id";
            ddlProduct.DataBind();
        }
        private void BindGrid(string EmpId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", EmpId);

            var emp = oDataAccess.QuerySingleOrDefaultSPDynamic<Employee_Add>("sp_getemployeeby_id", parameters);
            if (emp != null)
            {
                txtEmpName.Text = emp.Name;
            }

            parameters = new DynamicParameters();
            parameters.Add("Empid", EmpId);

            var result = oDataAccess.QuerySPListDynamic<Employee_Target>("sp_gettargetfor_employee", parameters);
            GridEmployeeTarget.DataSource = result;
            GridEmployeeTarget.DataBind();

            if (GridEmployeeTarget.Rows.Count > 0)
            {
                GridEmployeeTarget.UseAccessibleHeader = true;
                GridEmployeeTarget.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridEmployeeTarget.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (Request.QueryString["id"] != null)
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("Proid", ddlProduct.SelectedValue);
                        parameters.Add("Empid", Request.QueryString["id"]);
                        parameters.Add("EmpTarget", txtTarget.Text);
                        parameters.Add("ext1", txtForMonth.Text);

                        oDataAccess.ExecuteSPDynamic("sp_insert_emptarget", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added');", true);

                        txtTarget.Text = "";

                        BindGrid(Request.QueryString["id"]);

                        //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added');window.location.href='ShowEmployee.aspx';", true);
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

        protected void btndel_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            var parameters = new DynamicParameters();
            parameters.Add("Id", button.CommandArgument);


            oDataAccess.ExecuteSPDynamic("sp_delete_emptarget", parameters);

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Deleted');window.location.href='ShowEmployee.aspx';", true);

        }
    }
}