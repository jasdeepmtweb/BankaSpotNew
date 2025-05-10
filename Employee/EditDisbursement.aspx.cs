using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Employee
{
    public partial class EditDisbursement : System.Web.UI.Page
    {
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["emp"] == null)
            {
                Response.Redirect("../EmployeeLogin.aspx");
            }
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("ShowDisbursedCases.aspx");
            }
            if (!IsPostBack)
            {
                GetDisbursementData();
            }
        }

        private void GetDisbursementData()
        {
            var result = oDataAccess.QuerySPDynamic<Case_Status_Add>("sp_getallstatus");
            ddlStatus.DataSource = result;
            ddlStatus.DataTextField = "CaseStatus";
            ddlStatus.DataValueField = "Id";
            ddlStatus.DataBind();
            ddlStatus.Items.Insert(0, new ListItem("---Select---", "0"));

            var parameters = new DynamicParameters();
            parameters.Add("p_CaseId", Request.QueryString["id"]);

            var res = oDataAccess.QuerySingleOrDefaultSPDynamic<Case_Status_History>("sp_getdisbursement_data", parameters);
            if (res != null)
            {
                txtAmountDisbursed.Text = res.ext5;
                txtCaseBookedOn.Text = res.ext1;
                txtDisbursedDate.Text = res.DateAdded.ToString("yyyy-MM-dd");
                txtLoanAccountNo.Text = res.LoanAccNo;
                txtPreStatus.Text = res.PreStatus;
                txtProduct.Text = res.ProductName;
                txtRemarks.Text = res.Remarks;
                txtFileName.Text = res.Name;

                ddlStatus.Items.FindByText(res.NewStatus).Selected = true;
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No Data Found!!');", true);
                BtnSubmit.Visible = false;
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("p_CaseId", Request.QueryString["id"]);

                    oDataAccess.ExecuteSPDynamic("sp_delete_disbursement", parameters);

                    parameters = new DynamicParameters();
                    parameters.Add("Id", Request.QueryString["id"].ToString());

                    var result = oDataAccess.QuerySingleOrDefaultSPDynamic<Case_Add>("sp_getcaseby_id", parameters);

                    Employee_Add oEmployee_Add = Session["emp"] as Employee_Add;

                    parameters = new DynamicParameters();
                    parameters.Add("CaseId", Request.QueryString["id"].ToString());
                    parameters.Add("EmpId", oEmployee_Add.Id);
                    parameters.Add("NewStatus", ddlStatus.SelectedItem.Text);
                    parameters.Add("PreStatus", txtPreStatus.Text);
                    parameters.Add("CaseFile", "-");
                    parameters.Add("Remarks", txtRemarks.Text);
                    parameters.Add("DateAdded", txtDisbursedDate.Text);
                    parameters.Add("ext1", txtCaseBookedOn.Text);
                    if (ddlStatus.SelectedItem.Text.Contains("Disbursed") || ddlStatus.SelectedItem.Text.Contains("Tranche"))
                    {
                        parameters.Add("ext2", txtAmountDisbursed.Text);
                    }
                    else
                    {
                        parameters.Add("ext2", txtAmountSanctioned.Text);
                    }
                    parameters.Add("ext3", txtLoanAccountNo.Text);

                    oDataAccess.ExecuteSPDynamic("sp_insert_casestatushistory", parameters);

                    parameters = new DynamicParameters();
                    parameters.Add("Id", Request.QueryString["id"].ToString());
                    parameters.Add("Status", ddlStatus.SelectedItem.Text);
                    parameters.Add("Remarks", txtRemarks.Text);
                    parameters.Add("ext5", txtAmountDisbursed.Text);
                    parameters.Add("ext6", txtLoanAccountNo.Text);
                    parameters.Add("ext2", txtAmountSanctioned.Text);
                    oDataAccess.ExecuteSPDynamic("sp_update_casestatus", parameters);

                    if (ddlStatus.SelectedItem.Text.Contains("Disbursed") || ddlStatus.SelectedItem.Text.Contains("Tranche"))
                    {
                        parameters = new DynamicParameters();
                        parameters.Add("CaseId", Request.QueryString["id"].ToString());

                        Product_Add oProduct_Add = oDataAccess.QuerySingleOrDefaultSPDynamic<Product_Add>("sp_getcommbycaseid", parameters);

                        if (result.ConnectorId != 0)
                        {
                            double EmpPayout = Math.Round(Convert.ToDouble(txtAmountDisbursed.Text) * (oProduct_Add.EmployeeCom / 100), 2);

                            EmpPayout = Math.Round(EmpPayout / 2, 2);

                            parameters = new DynamicParameters();
                            parameters.Add("CaseId", Request.QueryString["id"].ToString());
                            parameters.Add("UserId", oEmployee_Add.Id);
                            parameters.Add("UserType", "Employee");
                            parameters.Add("PayAmount", EmpPayout);
                            oDataAccess.ExecuteSPDynamic("sp_insert_payouts", parameters);

                            double ConPayout = Math.Round(Convert.ToDouble(txtAmountDisbursed.Text) * (oProduct_Add.ConnectorCom / 100), 2);
                            ConPayout -= (Math.Round(ConPayout * 0.05, 2));
                            parameters = new DynamicParameters();
                            parameters.Add("CaseId", Request.QueryString["id"].ToString());
                            parameters.Add("UserId", result.ConnectorId);
                            parameters.Add("UserType", "Connector");
                            parameters.Add("PayAmount", ConPayout);
                            oDataAccess.ExecuteSPDynamic("sp_insert_payouts", parameters);

                            if (result.ext4 != null && !result.ext4.Equals("") && !result.ext4.Equals("0"))
                            {
                                double marketEmpPayout = Math.Round(Convert.ToDouble(txtAmountDisbursed.Text) * (Convert.ToDouble(oProduct_Add.ext1) / 100), 2);
                                marketEmpPayout = Math.Round(marketEmpPayout / 2, 2);
                                parameters = new DynamicParameters();
                                parameters.Add("CaseId", Request.QueryString["id"].ToString());
                                parameters.Add("UserId", result.ext4);
                                parameters.Add("UserType", "MEMP");
                                parameters.Add("PayAmount", marketEmpPayout);
                                oDataAccess.ExecuteSPDynamic("sp_insert_payouts", parameters);
                            }
                        }
                        else if (result.ext3 != null && !result.ext3.ToString().Equals("0"))
                        {
                            double EmpPayout = Math.Round(Convert.ToDouble(txtAmountDisbursed.Text) * (oProduct_Add.EmployeeCom / 100), 2);

                            EmpPayout = Math.Round(EmpPayout / 2, 2);

                            parameters = new DynamicParameters();
                            parameters.Add("CaseId", Request.QueryString["id"].ToString());
                            parameters.Add("UserId", oEmployee_Add.Id);
                            parameters.Add("UserType", "Employee");
                            parameters.Add("PayAmount", EmpPayout);
                            oDataAccess.ExecuteSPDynamic("sp_insert_payouts", parameters);

                            double Freelancerpayout = Math.Round(Convert.ToDouble(txtAmountDisbursed.Text) * (oProduct_Add.FreelancerCom / 100), 2);
                            Freelancerpayout -= (Math.Round(Freelancerpayout * 0.05, 2));
                            parameters = new DynamicParameters();
                            parameters.Add("CaseId", Request.QueryString["id"].ToString());
                            parameters.Add("UserId", result.ext3);
                            parameters.Add("UserType", "Freelancer");
                            parameters.Add("PayAmount", Freelancerpayout);
                            oDataAccess.ExecuteSPDynamic("sp_insert_payouts", parameters);
                        }
                        else if (result.ext4 != null && !result.ext4.Equals("") && !result.ext4.Equals("0"))
                        {
                            double EmpPayout = Math.Round(Convert.ToDouble(txtAmountDisbursed.Text) * (oProduct_Add.EmployeeCom / 100), 2);

                            EmpPayout = Math.Round(EmpPayout / 2, 2);

                            parameters = new DynamicParameters();
                            parameters.Add("CaseId", Request.QueryString["id"].ToString());
                            parameters.Add("UserId", oEmployee_Add.Id);
                            parameters.Add("UserType", "Employee");
                            parameters.Add("PayAmount", EmpPayout);
                            oDataAccess.ExecuteSPDynamic("sp_insert_payouts", parameters);

                            double marketEmpPayout = Math.Round(Convert.ToDouble(txtAmountDisbursed.Text) * (Convert.ToDouble(oProduct_Add.ext1) / 100), 2);
                            marketEmpPayout -= (Math.Round(marketEmpPayout * 0.05, 2));
                            parameters = new DynamicParameters();
                            parameters.Add("CaseId", Request.QueryString["id"].ToString());
                            parameters.Add("UserId", result.ext4);
                            parameters.Add("UserType", "MEMP");
                            parameters.Add("PayAmount", marketEmpPayout);
                            oDataAccess.ExecuteSPDynamic("sp_insert_payouts", parameters);
                        }
                        else
                        {
                            double EmpPayout = Math.Round(Convert.ToDouble(txtAmountDisbursed.Text) * (oProduct_Add.EmployeeCom / 100), 2);

                            parameters = new DynamicParameters();
                            parameters.Add("CaseId", Request.QueryString["id"].ToString());
                            parameters.Add("UserId", oEmployee_Add.Id);
                            parameters.Add("UserType", "Employee");
                            parameters.Add("PayAmount", EmpPayout);
                            oDataAccess.ExecuteSPDynamic("sp_insert_payouts", parameters);
                        }
                    }
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated');window.location.href='ShowDisbursedCases.aspx';", true);
                }
                catch (Exception ex)
                {
                    var errorLogger = new Log("ErrorLog.txt");
                    errorLogger.LogError(ex);
                }
            }
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}