using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankaSpotNew.Employee
{
    public partial class EditTrancheStatus : System.Web.UI.Page
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DataAccess oDataAccess = new DataAccess();
        static List<Case_Status_History> case_Status_Histories = new List<Case_Status_History>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["emp"] == null)
            {
                Response.Redirect("../EmployeeLogin.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    GetData();
                }
            }
        }

        private void GetData()
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", Request.QueryString["id"].ToString());
            var caseDetails = oDataAccess.QuerySingleOrDefaultSPDynamic<Case_Add>("sp_getcaseby_id", parameters);
            if (caseDetails != null)
            {
                txtFileName.Text = caseDetails.Name;
                txtProduct.Text = caseDetails.ProductName;
                txtTotalAmount.Text = caseDetails.AmountReq.ToString();
            }
            parameters = new DynamicParameters();
            parameters.Add("CaseId", Request.QueryString["id"].ToString());

            var result = oDataAccess.QuerySPListDynamic<Case_Status_History>("sp_getcasehistory_bycaseid", parameters);

            lblTotalAmountDisbursed.Text = Convert.ToDouble(result.Sum(x => Convert.ToDouble(x.ext2))).ToString();

            if (result != null)
            {
                Case_Status_History oCase_Status_History = result.FirstOrDefault();
                if (oCase_Status_History != null)
                {
                    divPreAmountDisbursed.Visible = true;
                    txtPreAmountDisbursed.Text = oCase_Status_History.ext2;
                    divRemainingAmount.Visible = true;
                    txtCaseBookedOn.Text = oCase_Status_History.ext1;
                    txtLoanAccountNo.Text = oCase_Status_History.LoanAccNo;

                    double totalAmount = caseDetails.AmountReq;

                    txtRemainingAmount.Text = (totalAmount - Convert.ToDouble(oCase_Status_History.ext2)).ToString();
                }
                case_Status_Histories = result;
            }
        }

        protected void BtnCaseClose_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (Request.QueryString["id"] != null)
                {
                    try
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("Id", Request.QueryString["id"].ToString());

                        var result = oDataAccess.QuerySingleOrDefaultSPDynamic<Case_Add>("sp_getcaseby_id", parameters);

                        Employee_Add oEmployee_Add = Session["emp"] as Employee_Add;

                        parameters = new DynamicParameters();
                        parameters.Add("CaseId", Request.QueryString["id"].ToString());
                        parameters.Add("EmpId", oEmployee_Add.Id);
                        parameters.Add("NewStatus", "File Disbursed");
                        parameters.Add("PreStatus", "Tranche Released");
                        parameters.Add("CaseFile", "-");
                        parameters.Add("Remarks", txtRemarks.Text);
                        parameters.Add("DateAdded", txtDisbursedDate.Text);
                        parameters.Add("ext1", txtCaseBookedOn.Text);
                        parameters.Add("ext2", txtAmountSanctioned.Text);
                        parameters.Add("ext3", txtLoanAccountNo.Text);

                        oDataAccess.ExecuteSPDynamic("sp_insert_casestatushistory", parameters);

                        double totalAmountDisbursed = Convert.ToDouble(txtAmountSanctioned.Text) + Convert.ToDouble(lblTotalAmountDisbursed.Text);

                        parameters = new DynamicParameters();
                        parameters.Add("Id", Request.QueryString["id"].ToString());
                        parameters.Add("Status", "File Disbursed");
                        parameters.Add("Remarks", txtRemarks.Text);
                        parameters.Add("ext5", totalAmountDisbursed);
                        parameters.Add("ext6", txtLoanAccountNo.Text);
                        parameters.Add("ext2", txtAmountSanctioned.Text);
                        oDataAccess.ExecuteSPDynamic("sp_update_casestatus", parameters);

                        parameters = new DynamicParameters();
                        parameters.Add("CaseId", Request.QueryString["id"].ToString());

                        Product_Add oProduct_Add = oDataAccess.QuerySingleOrDefaultSPDynamic<Product_Add>("sp_getcommbycaseid", parameters);

                        parameters = new DynamicParameters();
                        parameters.Add("p_ProductId", result.ProductReq);
                        var empSlabs = oDataAccess.QuerySPListDynamic<EmployeePayoutSlabModel>("sp_getemppayoutslab", parameters);

                        double amountDisbursed = Convert.ToDouble(txtAmountSanctioned.Text);

                        double newEmpPayout = 0;
                        try
                        {
                            newEmpPayout = empSlabs.Where(x => x.MinAmount <= amountDisbursed && x.MaxAmount >= amountDisbursed).FirstOrDefault().Payout;
                        }
                        catch (Exception ex)
                        {
                            var errorLogger = new Log("ErrorLog.txt");
                            errorLogger.LogError(ex);
                            newEmpPayout = 0;
                        }

                        if (result.ConnectorId != 0)
                        {
                            //double EmpPayout = Math.Round(Convert.ToDouble(txtAmountDisbursed.Text) * (oProduct_Add.EmployeeCom / 100), 2);
                            newEmpPayout = Math.Round(Convert.ToDouble(txtAmountSanctioned.Text) * (newEmpPayout / 100), 2);

                            //EmpPayout = Math.Round(EmpPayout / 2, 2);
                            newEmpPayout = Math.Round(newEmpPayout / 2, 2);

                            parameters = new DynamicParameters();
                            parameters.Add("CaseId", Request.QueryString["id"].ToString());
                            parameters.Add("UserId", oEmployee_Add.Id);
                            parameters.Add("UserType", "Employee");
                            //parameters.Add("PayAmount", EmpPayout);
                            parameters.Add("PayAmount", newEmpPayout);
                            oDataAccess.ExecuteSPDynamic("sp_insert_payouts", parameters);

                            double ConPayout = Math.Round(Convert.ToDouble(txtAmountSanctioned.Text) * (oProduct_Add.ConnectorCom / 100), 2);
                            ConPayout -= (Math.Round(ConPayout * 0.05, 2));
                            parameters = new DynamicParameters();
                            parameters.Add("CaseId", Request.QueryString["id"].ToString());
                            parameters.Add("UserId", result.ConnectorId);
                            parameters.Add("UserType", "Connector");
                            parameters.Add("PayAmount", ConPayout);
                            oDataAccess.ExecuteSPDynamic("sp_insert_payouts", parameters);

                            if (result.ext4 != null && !result.ext4.Equals("") && !result.ext4.Equals("0"))
                            {
                                double marketEmpPayout = Math.Round(Convert.ToDouble(txtAmountSanctioned.Text) * (Convert.ToDouble(oProduct_Add.ext1) / 100), 2);
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
                            //double EmpPayout = Math.Round(Convert.ToDouble(txtAmountDisbursed.Text) * (oProduct_Add.EmployeeCom / 100), 2);
                            newEmpPayout = Math.Round(Convert.ToDouble(txtAmountSanctioned.Text) * (newEmpPayout / 100), 2);

                            //EmpPayout = Math.Round(EmpPayout / 2, 2);
                            newEmpPayout = Math.Round(newEmpPayout / 2, 2);

                            parameters = new DynamicParameters();
                            parameters.Add("CaseId", Request.QueryString["id"].ToString());
                            parameters.Add("UserId", oEmployee_Add.Id);
                            parameters.Add("UserType", "Employee");
                            //parameters.Add("PayAmount", EmpPayout);
                            parameters.Add("PayAmount", newEmpPayout);
                            oDataAccess.ExecuteSPDynamic("sp_insert_payouts", parameters);

                            double Freelancerpayout = Math.Round(Convert.ToDouble(txtAmountSanctioned.Text) * (oProduct_Add.FreelancerCom / 100), 2);
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
                            //double EmpPayout = Math.Round(Convert.ToDouble(txtAmountDisbursed.Text) * (oProduct_Add.EmployeeCom / 100), 2);
                            newEmpPayout = Math.Round(Convert.ToDouble(txtAmountSanctioned.Text) * (newEmpPayout / 100), 2);

                            //EmpPayout = Math.Round(EmpPayout / 2, 2);
                            newEmpPayout = Math.Round(newEmpPayout / 2, 2);

                            parameters = new DynamicParameters();
                            parameters.Add("CaseId", Request.QueryString["id"].ToString());
                            parameters.Add("UserId", oEmployee_Add.Id);
                            parameters.Add("UserType", "Employee");
                            //parameters.Add("PayAmount", EmpPayout);
                            parameters.Add("PayAmount", newEmpPayout);
                            oDataAccess.ExecuteSPDynamic("sp_insert_payouts", parameters);

                            double marketEmpPayout = Math.Round(Convert.ToDouble(txtAmountSanctioned.Text) * (Convert.ToDouble(oProduct_Add.ext1) / 100), 2);
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
                            //double EmpPayout = Math.Round(Convert.ToDouble(txtAmountDisbursed.Text) * (oProduct_Add.EmployeeCom / 100), 2);
                            newEmpPayout = Math.Round(Convert.ToDouble(txtAmountSanctioned.Text) * (newEmpPayout / 100), 2);

                            parameters = new DynamicParameters();
                            parameters.Add("CaseId", Request.QueryString["id"].ToString());
                            parameters.Add("UserId", oEmployee_Add.Id);
                            parameters.Add("UserType", "Employee");
                            //parameters.Add("PayAmount", EmpPayout);
                            parameters.Add("PayAmount", newEmpPayout);
                            oDataAccess.ExecuteSPDynamic("sp_insert_payouts", parameters);
                        }

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Case Disbursed');window.location.href='ShowTrancheCases.aspx';", true);
                    }
                    catch (Exception ex)
                    {
                        var errorLogger = new Log("ErrorLog.txt");
                        errorLogger.LogError(ex);
                        if (ex.Message.Contains("Duplicate"))
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Valid Mobile No.!!');", true);
                        }
                    }
                }
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (Request.QueryString["id"] != null)
                {
                    try
                    {
                        if (Convert.ToDouble(txtRemainingAmount.Text) < Convert.ToDouble(txtAmountSanctioned.Text))
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Valid Amount!!');", true);
                            return;
                        }

                        var parameters = new DynamicParameters();
                        parameters.Add("Id", Request.QueryString["id"].ToString());

                        var result = oDataAccess.QuerySingleOrDefaultSPDynamic<Case_Add>("sp_getcaseby_id", parameters);

                        Employee_Add oEmployee_Add = Session["emp"] as Employee_Add;

                        parameters = new DynamicParameters();
                        parameters.Add("CaseId", Request.QueryString["id"].ToString());
                        parameters.Add("EmpId", oEmployee_Add.Id);
                        parameters.Add("NewStatus", "Tranche Released");
                        parameters.Add("PreStatus", "Tranche Released");
                        parameters.Add("CaseFile", "-");
                        parameters.Add("Remarks", txtRemarks.Text);
                        parameters.Add("DateAdded", txtDisbursedDate.Text);
                        parameters.Add("ext1", txtCaseBookedOn.Text);
                        parameters.Add("ext2", txtAmountSanctioned.Text);
                        parameters.Add("ext3", txtLoanAccountNo.Text);

                        oDataAccess.ExecuteSPDynamic("sp_insert_casestatushistory", parameters);

                        parameters = new DynamicParameters();
                        parameters.Add("CaseId", Request.QueryString["id"].ToString());

                        Product_Add oProduct_Add = oDataAccess.QuerySingleOrDefaultSPDynamic<Product_Add>("sp_getcommbycaseid", parameters);

                        parameters = new DynamicParameters();
                        parameters.Add("p_ProductId", result.ProductReq);
                        var empSlabs = oDataAccess.QuerySPListDynamic<EmployeePayoutSlabModel>("sp_getemppayoutslab", parameters);

                        double amountDisbursed = Convert.ToDouble(txtAmountSanctioned.Text);
                        double newEmpPayout = 0;
                        try
                        {
                            newEmpPayout = empSlabs.Where(x => x.MinAmount <= amountDisbursed && x.MaxAmount >= amountDisbursed).FirstOrDefault().Payout;
                        }
                        catch (Exception ex)
                        {
                            var errorLogger = new Log("ErrorLog.txt");
                            errorLogger.LogError(ex);
                            newEmpPayout = 0;
                        }

                        if (result.ConnectorId != 0)
                        {
                            //double EmpPayout = Math.Round(Convert.ToDouble(txtAmountDisbursed.Text) * (oProduct_Add.EmployeeCom / 100), 2);
                            newEmpPayout = Math.Round(Convert.ToDouble(txtAmountSanctioned.Text) * (newEmpPayout / 100), 2);

                            //EmpPayout = Math.Round(EmpPayout / 2, 2);
                            newEmpPayout = Math.Round(newEmpPayout / 2, 2);

                            parameters = new DynamicParameters();
                            parameters.Add("CaseId", Request.QueryString["id"].ToString());
                            parameters.Add("UserId", oEmployee_Add.Id);
                            parameters.Add("UserType", "Employee");
                            //parameters.Add("PayAmount", EmpPayout);
                            parameters.Add("PayAmount", newEmpPayout);
                            oDataAccess.ExecuteSPDynamic("sp_insert_payouts", parameters);

                            double ConPayout = Math.Round(Convert.ToDouble(txtAmountSanctioned.Text) * (oProduct_Add.ConnectorCom / 100), 2);
                            ConPayout -= (Math.Round(ConPayout * 0.05, 2));
                            parameters = new DynamicParameters();
                            parameters.Add("CaseId", Request.QueryString["id"].ToString());
                            parameters.Add("UserId", result.ConnectorId);
                            parameters.Add("UserType", "Connector");
                            parameters.Add("PayAmount", ConPayout);
                            oDataAccess.ExecuteSPDynamic("sp_insert_payouts", parameters);

                            if (result.ext4 != null && !result.ext4.Equals("") && !result.ext4.Equals("0"))
                            {
                                double marketEmpPayout = Math.Round(Convert.ToDouble(txtAmountSanctioned.Text) * (Convert.ToDouble(oProduct_Add.ext1) / 100), 2);
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
                            //double EmpPayout = Math.Round(Convert.ToDouble(txtAmountDisbursed.Text) * (oProduct_Add.EmployeeCom / 100), 2);
                            newEmpPayout = Math.Round(Convert.ToDouble(txtAmountSanctioned.Text) * (newEmpPayout / 100), 2);

                            //EmpPayout = Math.Round(EmpPayout / 2, 2);
                            newEmpPayout = Math.Round(newEmpPayout / 2, 2);

                            parameters = new DynamicParameters();
                            parameters.Add("CaseId", Request.QueryString["id"].ToString());
                            parameters.Add("UserId", oEmployee_Add.Id);
                            parameters.Add("UserType", "Employee");
                            //parameters.Add("PayAmount", EmpPayout);
                            parameters.Add("PayAmount", newEmpPayout);
                            oDataAccess.ExecuteSPDynamic("sp_insert_payouts", parameters);

                            double Freelancerpayout = Math.Round(Convert.ToDouble(txtAmountSanctioned.Text) * (oProduct_Add.FreelancerCom / 100), 2);
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
                            //double EmpPayout = Math.Round(Convert.ToDouble(txtAmountDisbursed.Text) * (oProduct_Add.EmployeeCom / 100), 2);
                            newEmpPayout = Math.Round(Convert.ToDouble(txtAmountSanctioned.Text) * (newEmpPayout / 100), 2);

                            //EmpPayout = Math.Round(EmpPayout / 2, 2);
                            newEmpPayout = Math.Round(newEmpPayout / 2, 2);

                            parameters = new DynamicParameters();
                            parameters.Add("CaseId", Request.QueryString["id"].ToString());
                            parameters.Add("UserId", oEmployee_Add.Id);
                            parameters.Add("UserType", "Employee");
                            //parameters.Add("PayAmount", EmpPayout);
                            parameters.Add("PayAmount", newEmpPayout);
                            oDataAccess.ExecuteSPDynamic("sp_insert_payouts", parameters);

                            double marketEmpPayout = Math.Round(Convert.ToDouble(txtAmountSanctioned.Text) * (Convert.ToDouble(oProduct_Add.ext1) / 100), 2);
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
                            //double EmpPayout = Math.Round(Convert.ToDouble(txtAmountDisbursed.Text) * (oProduct_Add.EmployeeCom / 100), 2);
                            newEmpPayout = Math.Round(Convert.ToDouble(txtAmountSanctioned.Text) * (newEmpPayout / 100), 2);

                            parameters = new DynamicParameters();
                            parameters.Add("CaseId", Request.QueryString["id"].ToString());
                            parameters.Add("UserId", oEmployee_Add.Id);
                            parameters.Add("UserType", "Employee");
                            //parameters.Add("PayAmount", EmpPayout);
                            parameters.Add("PayAmount", newEmpPayout);
                            oDataAccess.ExecuteSPDynamic("sp_insert_payouts", parameters);
                        }

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added');window.location.href='ShowTrancheCases.aspx';", true);

                    }
                    catch (Exception ex)
                    {
                        var errorLogger = new Log("ErrorLog.txt");
                        errorLogger.LogError(ex);
                        if (ex.Message.Contains("Duplicate"))
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Valid Mobile No.!!');", true);
                        }
                    }
                }
            }
        }
    }
}