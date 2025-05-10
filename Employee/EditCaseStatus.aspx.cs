using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Employee
{
    public partial class EditCaseStatus : System.Web.UI.Page
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
                DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

                txtDisbursedDate.Text = indianTime.ToString("yyyy-MM-dd");
                if (Request.QueryString["id"] != null)
                {
                    GetData();
                    GetPreviousCaseStatus(Request.QueryString["id"].ToString());
                }
            }
        }

        private void GetPreviousCaseStatus(string Id)
        {
            case_Status_Histories.Clear();
            var parameters = new DynamicParameters();
            parameters.Add("CaseId", Id);

            var result = oDataAccess.QuerySPListDynamic<Case_Status_History>("sp_getcasehistory_bycaseid", parameters);
            if (result != null)
            {
                Case_Status_History oCase_Status_History = result.FirstOrDefault();
                if (oCase_Status_History != null)
                {
                    divPreStatus.Visible = true;
                    txtPreStatus.Text = oCase_Status_History.NewStatus.ToString();
                    if (txtPreStatus.Text.Contains("Tranche"))
                    {
                        divPreAmountDisbursed.Visible = true;
                        txtPreAmountDisbursed.Text = oCase_Status_History.ext2;
                        divRemainingAmount.Visible = true;
                        if (Request.QueryString["amt"] != null)
                        {
                            double totalAmount = Convert.ToDouble(Request.QueryString["amt"]);

                            txtRemainingAmount.Text = (totalAmount - Convert.ToDouble(oCase_Status_History.ext2)).ToString();
                        }
                    }
                }
                else
                {
                    divPreStatus.Visible = false;
                    txtPreStatus.Text = "-";
                }
                case_Status_Histories = result;
            }
            if (txtPreStatus.Text.Contains("Disbursed") || txtPreStatus.Text.Contains("Tranche"))
            {
                BtnSubmit.Visible = false;
                BtnFirstSubmit.Visible = false;
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
            }

            var result = oDataAccess.QuerySPDynamic<Case_Status_Add>("sp_getallstatus");
            ddlStatus.DataSource = result;
            ddlStatus.DataTextField = "CaseStatus";
            ddlStatus.DataValueField = "Id";
            ddlStatus.DataBind();
            ddlStatus.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (!case_Status_Histories.Any(x => x.NewStatus.Contains("Tranche")))
            {
                if (ddlStatus.SelectedItem.Text.Contains("Disbursed"))
                {
                    if (/*txtAmountDisbursed.Text.Equals("0") ||*/ txtLoanAccountNo.Text.Equals("0"))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Loan Account No.');", true);
                        return;
                    }
                }
            }

            if (Page.IsValid)
            {
                if (Request.QueryString["id"] != null)
                {
                    try
                    {
                        //string fileName = "-";
                        //if (fileSlip.HasFile)
                        //{
                        //    if (fileSlip.PostedFile.ContentLength <= 1024 * 1024)
                        //    {
                        //        string extension = Path.GetExtension(fileSlip.FileName);
                        //        fileName = Guid.NewGuid() + extension;
                        //        fileSlip.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fileName);
                        //    }
                        //    else
                        //    {
                        //        Response.Write("<script>alert('The file size exceeds the maximum limit of 1 MB.')</script>");
                        //        return;
                        //    }
                        //}

                        var parameters = new DynamicParameters();
                        parameters.Add("Id", Request.QueryString["id"].ToString());

                        var result = oDataAccess.QuerySingleOrDefaultSPDynamic<Case_Add>("sp_getcaseby_id", parameters);

                        if (result.BankName.Equals("") || result.BankName.Equals("-") || result.BankEmpName.Equals("") || result.BankEmpName.Equals("-") || result.BankEmpContactNo.Equals("-") || result.BankEmpContactNo.Equals(""))
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Fill All Necessary Bank Details Before Updating Status');window.location.href='EditCase.aspx?id=" + Request.QueryString["id"].ToString() + "&pgtyp=" + Request.QueryString["pgtyp"].ToString() + "';", true);
                            return;
                        }

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

                            parameters = new DynamicParameters();
                            parameters.Add("p_ProductId", result.ProductReq);
                            var empSlabs = oDataAccess.QuerySPListDynamic<EmployeePayoutSlabModel>("sp_getemppayoutslab",parameters);

                            double amountDisbursed = Convert.ToDouble(txtAmountDisbursed.Text);

                            double newEmpPayout = 0;
                            try
                            {
                                newEmpPayout = empSlabs.Where(x => x.MinAmount <= amountDisbursed && x.MaxAmount >= amountDisbursed).FirstOrDefault().Payout;
                            }
                            catch (Exception)
                            {
                                newEmpPayout = Math.Round(Convert.ToDouble(txtAmountDisbursed.Text) * (oProduct_Add.EmployeeCom / 100), 2);
                            }

                            if (result.ConnectorId != 0)
                            {
                                //double EmpPayout = Math.Round(Convert.ToDouble(txtAmountDisbursed.Text) * (oProduct_Add.EmployeeCom / 100), 2);
                                newEmpPayout = Math.Round(Convert.ToDouble(txtAmountDisbursed.Text) * (newEmpPayout / 100), 2);

                                //EmpPayout = Math.Round(EmpPayout / 2, 2);
                                newEmpPayout = Math.Round(newEmpPayout / 2, 2);

                                parameters = new DynamicParameters();
                                parameters.Add("CaseId", Request.QueryString["id"].ToString());
                                parameters.Add("UserId", oEmployee_Add.Id);
                                parameters.Add("UserType", "Employee");
                                //parameters.Add("PayAmount", EmpPayout);
                                parameters.Add("PayAmount", newEmpPayout);
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
                                //double EmpPayout = Math.Round(Convert.ToDouble(txtAmountDisbursed.Text) * (oProduct_Add.EmployeeCom / 100), 2);
                                newEmpPayout = Math.Round(Convert.ToDouble(txtAmountDisbursed.Text) * (newEmpPayout / 100), 2);

                                //EmpPayout = Math.Round(EmpPayout / 2, 2);
                                newEmpPayout = Math.Round(newEmpPayout / 2, 2);

                                parameters = new DynamicParameters();
                                parameters.Add("CaseId", Request.QueryString["id"].ToString());
                                parameters.Add("UserId", oEmployee_Add.Id);
                                parameters.Add("UserType", "Employee");
                                //parameters.Add("PayAmount", EmpPayout);
                                parameters.Add("PayAmount", newEmpPayout);
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
                                //double EmpPayout = Math.Round(Convert.ToDouble(txtAmountDisbursed.Text) * (oProduct_Add.EmployeeCom / 100), 2);
                                newEmpPayout = Math.Round(Convert.ToDouble(txtAmountDisbursed.Text) * (newEmpPayout / 100), 2);

                                //EmpPayout = Math.Round(EmpPayout / 2, 2);
                                newEmpPayout = Math.Round(newEmpPayout / 2, 2);

                                parameters = new DynamicParameters();
                                parameters.Add("CaseId", Request.QueryString["id"].ToString());
                                parameters.Add("UserId", oEmployee_Add.Id);
                                parameters.Add("UserType", "Employee");
                                //parameters.Add("PayAmount", EmpPayout);
                                parameters.Add("PayAmount", newEmpPayout);
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
                                //double EmpPayout = Math.Round(Convert.ToDouble(txtAmountDisbursed.Text) * (oProduct_Add.EmployeeCom / 100), 2);
                                newEmpPayout = Math.Round(Convert.ToDouble(txtAmountDisbursed.Text) * (newEmpPayout / 100), 2);

                                parameters = new DynamicParameters();
                                parameters.Add("CaseId", Request.QueryString["id"].ToString());
                                parameters.Add("UserId", oEmployee_Add.Id);
                                parameters.Add("UserType", "Employee");
                                //parameters.Add("PayAmount", EmpPayout);
                                parameters.Add("PayAmount", newEmpPayout);
                                oDataAccess.ExecuteSPDynamic("sp_insert_payouts", parameters);
                            }
                        }

                        if (Request.QueryString["pgtyp"].ToString().Equals("1"))
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added');window.location.href='ShowCasesFromConnectors.aspx';", true);
                        }
                        else if (Request.QueryString["pgtyp"].ToString().Equals("2"))
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added');window.location.href='CasesFromFreelancer.aspx';", true);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added');window.location.href='ShowCases.aspx';", true);
                        }
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

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlStatus.SelectedItem.Text.Contains("Disbursed") || ddlStatus.SelectedItem.Text.Contains("Tranche"))
            {
                divAmount.Visible = true;
                divLoanAcc.Visible = true;
                divAmountSanctioned.Visible = false;

                BtnFirstSubmit.Visible = true;
                BtnSubmit.Visible = false;

                divCaseBooked.Visible = true;
                divDisbursedDate.Visible = true;
            }
            else if (ddlStatus.SelectedItem.Text.Contains("Sanctioned"))
            {
                divAmount.Visible = false;
                divLoanAcc.Visible = false;
                divAmountSanctioned.Visible = true;

                BtnFirstSubmit.Visible = false;
                BtnSubmit.Visible = true;

                divCaseBooked.Visible = false;
                divDisbursedDate.Visible = false;
            }
            else
            {
                divAmount.Visible = false;
                divLoanAcc.Visible = false;
                divAmountSanctioned.Visible = false;

                BtnFirstSubmit.Visible = false;
                BtnSubmit.Visible = true;
                divCaseBooked.Visible = false;
                divDisbursedDate.Visible = false;
            }
        }

        protected void BtnFirstSubmit_Click(object sender, EventArgs e)
        {
            divMessage.Visible = true;
            BtnFirstSubmit.Visible = false;
            BtnSubmit.Visible = true;
        }
    }
}