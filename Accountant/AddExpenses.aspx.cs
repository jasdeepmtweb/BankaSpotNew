using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankaSpotNew.Accountant
{
    public partial class AddExpenses : System.Web.UI.Page
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DataAccess oDataAccess = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["acc"] == null)
            {
                Response.Redirect("../AccountantLogin.aspx");
            }
            if (Request.QueryString["id"] == null || Request.QueryString["id"].ToString().Equals(""))
            {
                Response.Redirect("ShowAllCases.aspx");
            }
            if (!IsPostBack)
            {
                PopulateDropdowns();

                GetCaseData(Request.QueryString["id"]);
            }
        }
        private void PopulateDropdowns()
        {
            ddlGSTStatus.Items.Clear();
            ddlGSTStatus.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlGSTStatus.Items.Insert(1, new ListItem("Received", "1"));
            ddlGSTStatus.Items.Insert(2, new ListItem("Pending", "2"));

            ddlBillRaised.Items.Clear();
            ddlBillRaised.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlBillRaised.Items.Insert(1, new ListItem("Yes", "1"));
            ddlBillRaised.Items.Insert(2, new ListItem("No", "2"));

            ddlPayoutStatus.Items.Clear();
            ddlPayoutStatus.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlPayoutStatus.Items.Insert(1, new ListItem("Received", "1"));
            ddlPayoutStatus.Items.Insert(2, new ListItem("Pending", "2"));

            ddlAddPayStatus.Items.Clear();
            ddlAddPayStatus.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlAddPayStatus.Items.Insert(1, new ListItem("Received", "1"));
            ddlAddPayStatus.Items.Insert(2, new ListItem("Pending", "2"));

            ddlLGPayStatus.Items.Clear();
            ddlLGPayStatus.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlLGPayStatus.Items.Insert(1, new ListItem("Received", "1"));
            ddlLGPayStatus.Items.Insert(2, new ListItem("Pending", "2"));

            ddlStaffPayStatus.Items.Clear();
            ddlStaffPayStatus.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlStaffPayStatus.Items.Insert(1, new ListItem("Received", "1"));
            ddlStaffPayStatus.Items.Insert(2, new ListItem("Pending", "2"));
        }

        private void GetCaseData(string caseId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_Id", caseId);
            var caseDetail = oDataAccess.QuerySingleOrDefaultSPDynamic<Case_Add>("sp_getsinglecase_foraccountant", parameters);
            if (caseDetail != null)
            {
                txtBankerMobileNo.Text = caseDetail.BankEmpContactNo;
                txtBankerName.Text = caseDetail.BankEmpName;
                txtLGName.Text = caseDetail.LeadHandling;
                txtLGMobileNo.Text = caseDetail.LeadGenContactNo;
                txtNameWhoHandled.Text = caseDetail.EmpName;
                txtLHMobileNo.Text = caseDetail.LeadGenContactNo;
                txtAmountSanctioned.Text = caseDetail.ext5;
            }

            parameters = new DynamicParameters();
            parameters.Add("p_CaseId", caseId);
            var expenseDetail = oDataAccess.QuerySingleOrDefaultSPDynamic<ExpenseModel>("sp_getexpenseby_caseid", parameters);
            if (expenseDetail != null)
            {
                lblId.Text = expenseDetail.Id.ToString();
                txtAddPayAmt.Text = expenseDetail.AddPayAmt.ToString();
                txtAddPayAmtRec.Text = expenseDetail.AddPayAmtRecPerson;
                txtAddPayDate.Text = expenseDetail.AddPayDate.ToString("yyyy-MM-dd");
                txtAmountCredInBank.Text = expenseDetail.AmtCredBank.ToString();
                txtBillNo.Text = expenseDetail.BillNo.ToString();
                txtCaseExpenses.Text = expenseDetail.CaseExpenses.ToString();
                txtDifference.Text = expenseDetail.AmtDifference.ToString();
                txtGrossPayout.Text = expenseDetail.GrossPayout.ToString();
                txtGST.Text = expenseDetail.GST.ToString();
                txtGSTAmtRecDate.Text = expenseDetail.GstAmtRecDate.ToString("yyyy-MM-dd");
                txtLGExtraPayout.Text = expenseDetail.LGExtraPayout.ToString();
                txtLGPayout.Text = expenseDetail.LGPayout.ToString();
                txtLGPayoutDate.Text = expenseDetail.LGPayoutDate.ToString("yyyy-MM-dd");
                txtNetEarning.Text = expenseDetail.NetEarning.ToString();
                txtNetPayout.Text = expenseDetail.NetPayout.ToString();
                txtPayout.Text = expenseDetail.Payout.ToString();
                txtPayoutRecDate.Text = expenseDetail.PayoutRecDate.ToString("yyyy-MM-dd");
                txtPayoutRecIn.Text = expenseDetail.PayoutRecievedIn;
                txtPayoutSlab.Text = expenseDetail.PayoutSlab;
                txtStaffPayout.Text = expenseDetail.StaffPayout.ToString();
                txtStaffPayoutDate.Text = expenseDetail.StaffPayoutDate.ToString("yyyy-MM-dd");
                txtTDS.Text = expenseDetail.TDS.ToString();

                ddlGSTStatus.Items.FindByText(expenseDetail.GSTStatus).Selected = true;
                ddlBillRaised.Items.FindByText(expenseDetail.BillRaised).Selected = true;
                ddlPayoutStatus.Items.FindByText(expenseDetail.PayoutStatus).Selected = true;
                ddlAddPayStatus.Items.FindByText(expenseDetail.AddPayStatus).Selected = true;
                ddlLGPayStatus.Items.FindByText(expenseDetail.LGPayoutStatus).Selected = true;
                ddlStaffPayStatus.Items.FindByText(expenseDetail.StaffPayoutStatus).Selected = true;
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                AccountantModel oAccountantModel = Session["acc"] as AccountantModel;
                try
                {
                    DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

                    if (lblId.Text.Equals("-"))
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("p_CaseId", Request.QueryString["id"]);
                        parameters.Add("p_AccountantId", oAccountantModel.Id);
                        parameters.Add("p_PFCollected", "-");
                        parameters.Add("p_PayoutSlab", txtPayoutSlab.Text);
                        parameters.Add("p_Payout", txtPayout.Text);
                        parameters.Add("p_TDS", txtTDS.Text);
                        parameters.Add("p_NetPayout", txtNetPayout.Text);
                        parameters.Add("p_GST", txtGST.Text);
                        parameters.Add("p_GrossPayout", txtGrossPayout.Text);
                        parameters.Add("p_GSTStatus", ddlGSTStatus.SelectedItem.Text);
                        parameters.Add("p_AmtCredBank", txtAmountCredInBank.Text);
                        parameters.Add("p_AmtDifference", txtDifference.Text);
                        parameters.Add("p_BillRaised", ddlBillRaised.SelectedItem.Text);
                        parameters.Add("p_BillNo", txtBillNo.Text);
                        parameters.Add("p_PayoutStatus", ddlPayoutStatus.SelectedItem.Text);
                        parameters.Add("p_PayoutRecievedIn", txtPayoutRecIn.Text);
                        parameters.Add("p_PayoutRecDate", txtPayoutRecDate.Text);
                        parameters.Add("p_GstAmtRecDate", txtGSTAmtRecDate.Text);
                        parameters.Add("p_AddPayAmt", txtAddPayAmt.Text);
                        parameters.Add("p_AddPayAmtRecPerson", txtAddPayAmtRec.Text);
                        parameters.Add("p_AddPayStatus", ddlAddPayStatus.SelectedItem.Text);
                        parameters.Add("p_AddPayDate", txtAddPayDate.Text);
                        parameters.Add("p_LGPayout", txtLGPayout.Text);
                        parameters.Add("p_LGExtraPayout", txtLGExtraPayout.Text);
                        parameters.Add("p_LGPayoutStatus", ddlLGPayStatus.SelectedItem.Text);
                        parameters.Add("p_LGPayoutDate", txtLGPayoutDate.Text);
                        parameters.Add("p_StaffPayout", txtStaffPayout.Text);
                        parameters.Add("p_StaffPayoutStatus", ddlStaffPayStatus.SelectedItem.Text);
                        parameters.Add("p_StaffPayoutDate", txtStaffPayoutDate.Text);
                        parameters.Add("p_CaseExpenses", txtCaseExpenses.Text);
                        parameters.Add("p_NetEarning", txtNetEarning.Text);
                        parameters.Add("p_CreatedOn", indianTime);

                        oDataAccess.ExecuteSPDynamic("sp_InsertExpensePayoutDetails", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added');window.location.href='ShowAllCases.aspx';", true);
                    }
                    else
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("p_CaseId", Request.QueryString["id"]);
                        parameters.Add("p_AccountantId", oAccountantModel.Id);
                        parameters.Add("p_PFCollected", "-");
                        parameters.Add("p_PayoutSlab", txtPayoutSlab.Text);
                        parameters.Add("p_Payout", txtPayout.Text);
                        parameters.Add("p_TDS", txtTDS.Text);
                        parameters.Add("p_NetPayout", txtNetPayout.Text);
                        parameters.Add("p_GST", txtGST.Text);
                        parameters.Add("p_GrossPayout", txtGrossPayout.Text);
                        parameters.Add("p_GSTStatus", ddlGSTStatus.SelectedItem.Text);
                        parameters.Add("p_AmtCredBank", txtAmountCredInBank.Text);
                        parameters.Add("p_AmtDifference", txtDifference.Text);
                        parameters.Add("p_BillRaised", ddlBillRaised.SelectedItem.Text);
                        parameters.Add("p_BillNo", txtBillNo.Text);
                        parameters.Add("p_PayoutStatus", ddlPayoutStatus.SelectedItem.Text);
                        parameters.Add("p_PayoutRecievedIn", txtPayoutRecIn.Text);
                        parameters.Add("p_PayoutRecDate", txtPayoutRecDate.Text);
                        parameters.Add("p_GstAmtRecDate", txtGSTAmtRecDate.Text);
                        parameters.Add("p_AddPayAmt", txtAddPayAmt.Text);
                        parameters.Add("p_AddPayAmtRecPerson", txtAddPayAmtRec.Text);
                        parameters.Add("p_AddPayStatus", ddlAddPayStatus.SelectedItem.Text);
                        parameters.Add("p_AddPayDate", txtAddPayDate.Text);
                        parameters.Add("p_LGPayout", txtLGPayout.Text);
                        parameters.Add("p_LGExtraPayout", txtLGExtraPayout.Text);
                        parameters.Add("p_LGPayoutStatus", ddlLGPayStatus.SelectedItem.Text);
                        parameters.Add("p_LGPayoutDate", txtLGPayoutDate.Text);
                        parameters.Add("p_StaffPayout", txtStaffPayout.Text);
                        parameters.Add("p_StaffPayoutStatus", ddlStaffPayStatus.SelectedItem.Text);
                        parameters.Add("p_StaffPayoutDate", txtStaffPayoutDate.Text);
                        parameters.Add("p_CaseExpenses", txtCaseExpenses.Text);
                        parameters.Add("p_NetEarning", txtNetEarning.Text);
                        parameters.Add("p_Id", lblId.Text);

                        oDataAccess.ExecuteSPDynamic("sp_UpdateExpensesPayout", parameters);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated');window.location.href='ShowAllCases.aspx';", true);
                    }
                }
                catch (Exception ex)
                {
                    var errorLogger = new Log("ErrorLog.txt");
                    errorLogger.LogError(ex);
                }
            }
        }

        protected void txtPayout_TextChanged(object sender, EventArgs e)
        {
            //if (!txtPayout.Text.Equals(""))
            //{
            //    bool isValid = double.TryParse(txtPayout.Text, out double payout);

            //    if (isValid)
            //    {
            //        double tds = payout * 0.05;
            //        double netPayout = payout - tds;
            //        double gst = payout * 0.18;
            //        double grossPayout = netPayout - gst;

            //        txtTDS.Text = tds.ToString();
            //        txtNetPayout.Text = netPayout.ToString();
            //        txtGST.Text = gst.ToString();
            //        txtGrossPayout.Text = grossPayout.ToString();
            //    }
            //    else
            //    {
            //        // The input is not a valid double. Display an error message.
            //        txtPayout.Text = "Please enter a valid numeric value.";
            //        txtPayout.ForeColor = System.Drawing.Color.Red;
            //    }
            //}
        }

        protected void txtAmountCredInBank_TextChanged(object sender, EventArgs e)
        {
            if (!txtAmountCredInBank.Text.Equals(""))
            {
                bool isValid = double.TryParse(txtAmountCredInBank.Text, out double amountCredited);

                if (isValid)
                {
                    double sanctionedAmount = Convert.ToDouble(txtAmountSanctioned.Text);

                    if (sanctionedAmount > amountCredited)
                    {
                        txtDifference.Text = (sanctionedAmount - amountCredited).ToString();
                    }
                    else
                    {
                        txtDifference.Text = (amountCredited - sanctionedAmount).ToString();
                    }
                }
                else
                {
                    // The input is not a valid double. Display an error message.
                    txtAmountCredInBank.Text = "Please enter a valid numeric value.";
                    txtAmountCredInBank.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void txtPayoutSlab_TextChanged(object sender, EventArgs e)
        {
            if (!txtPayoutSlab.Text.Equals(""))
            {
                bool isValid = double.TryParse(txtPayoutSlab.Text, out double payoutSlab);

                if (isValid)
                {
                    double amountDisbursed = Convert.ToDouble(txtAmountSanctioned.Text);

                    double payout = Math.Round((amountDisbursed * payoutSlab) / 100);

                    txtPayout.Text = payout.ToString();

                    double tds = payout * 0.05;
                    double netPayout = payout - tds;
                    double gst = payout * 0.18;
                    double grossPayout = netPayout - gst;

                    txtTDS.Text = tds.ToString();
                    txtNetPayout.Text = netPayout.ToString();
                    txtGST.Text = gst.ToString();
                    txtGrossPayout.Text = grossPayout.ToString();
                }
                else
                {
                    // The input is not a valid double. Display an error message.
                    txtPayoutSlab.Text = "Please enter a valid numeric value.";
                    txtPayoutSlab.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}