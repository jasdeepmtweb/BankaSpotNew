<%@ Page Title="" Language="C#" MasterPageFile="~/Accountant/Site.Master" AutoEventWireup="true" CodeBehind="AddExpenses.aspx.cs" Inherits="BankaSpotNew.Accountant.AddExpenses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="content-page">
        <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-4 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="header-title mb-3">Add Expenses</h4>
                                <asp:Label Text="-" runat="server" ID="lblId" Visible="false"></asp:Label>
                                <div class="mb-2">
                                    <label for="exampleInputEmail1" class="form-label">
                                        Payout Slab
                                    <asp:RequiredFieldValidator ControlToValidate="txtPayoutSlab" ValidationGroup="a" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:UpdatePanel runat="server" ID="UpdatePanel7">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtPayoutSlab" AutoPostBack="true" OnTextChanged="txtPayoutSlab_TextChanged" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Payout
                                    <asp:RequiredFieldValidator ControlToValidate="txtPayout" ValidationGroup="a" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ControlToValidate="txtPayout" ID="CompareValidator1" runat="server" ErrorMessage="*Enter Only Numbers" ForeColor="Red" Display="Dynamic" ValidationGroup="a" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
                                    </label>
                                    <asp:UpdatePanel runat="server" ID="up1">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtPayout" AutoPostBack="true" OnTextChanged="txtPayout_TextChanged" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        TDS
                                    <asp:RequiredFieldValidator ControlToValidate="txtTDS" ValidationGroup="a" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ControlToValidate="txtTDS" ID="CompareValidator2" runat="server" ErrorMessage="*Enter Only Numbers" ForeColor="Red" Display="Dynamic" ValidationGroup="a" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
                                    </label>
                                    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtTDS" Enabled="false" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>

                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Net Payout
     <asp:RequiredFieldValidator ControlToValidate="txtNetPayout" ValidationGroup="a" ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ControlToValidate="txtNetPayout" ID="CompareValidator3" runat="server" ErrorMessage="*Enter Only Numbers" ForeColor="Red" Display="Dynamic" ValidationGroup="a" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
                                    </label>
                                    <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtNetPayout" Enabled="false" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        GST
     <asp:RequiredFieldValidator ControlToValidate="txtGST" ValidationGroup="a" ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ControlToValidate="txtGST" ID="CompareValidator4" runat="server" ErrorMessage="*Enter Only Numbers" ForeColor="Red" Display="Dynamic" ValidationGroup="a" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
                                    </label>
                                    <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtGST" Enabled="false" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Gross Payout
     <asp:RequiredFieldValidator ControlToValidate="txtGrossPayout" ValidationGroup="a" ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ControlToValidate="txtGrossPayout" ID="CompareValidator5" runat="server" ErrorMessage="*Enter Only Numbers" ForeColor="Red" Display="Dynamic" ValidationGroup="a" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
                                    </label>
                                    <asp:UpdatePanel runat="server" ID="UpdatePanel4">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtGrossPayout" Enabled="false" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        GST Status
     <asp:RequiredFieldValidator ControlToValidate="ddlGSTStatus" ValidationGroup="a" InitialValue="0" ID="RequiredFieldValidator7" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:DropDownList runat="server" ID="ddlGSTStatus" ValidationGroup="a" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Amount Sanctioned
                                        <asp:RequiredFieldValidator ControlToValidate="txtAmountSanctioned" ValidationGroup="a" ID="RequiredFieldValidator35" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtAmountSanctioned" Enabled="false" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Amount Credited In Bank
     <asp:RequiredFieldValidator ControlToValidate="txtAmountCredInBank" ValidationGroup="a" ID="RequiredFieldValidator8" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ControlToValidate="txtAmountCredInBank" ID="CompareValidator6" runat="server" ErrorMessage="*Enter Only Numbers" ForeColor="Red" Display="Dynamic" ValidationGroup="a" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
                                    </label>
                                    <asp:UpdatePanel runat="server" ID="UpdatePanel5">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtAmountCredInBank" AutoPostBack="true" OnTextChanged="txtAmountCredInBank_TextChanged" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Difference
     <asp:RequiredFieldValidator ControlToValidate="txtDifference" ValidationGroup="a" ID="RequiredFieldValidator9" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ControlToValidate="txtDifference" ID="CompareValidator7" runat="server" ErrorMessage="*Enter Only Numbers" ForeColor="Red" Display="Dynamic" ValidationGroup="a" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
                                    </label>
                                    <asp:UpdatePanel runat="server" ID="UpdatePanel6">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtDifference" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Bill Raised
     <asp:RequiredFieldValidator ControlToValidate="ddlBillRaised" ValidationGroup="a" InitialValue="0" ID="RequiredFieldValidator10" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:DropDownList runat="server" ID="ddlBillRaised" ValidationGroup="a" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Bill No.
     <asp:RequiredFieldValidator ControlToValidate="txtBillNo" ValidationGroup="a" ID="RequiredFieldValidator11" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtBillNo" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>




                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="header-title mb-3">&nbsp</h4>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Banker Name
                                        <asp:RequiredFieldValidator ControlToValidate="txtBankerName" ValidationGroup="a" ID="RequiredFieldValidator12" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtBankerName" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Banker Mobile No.
                                        <asp:RequiredFieldValidator ControlToValidate="txtBankerMobileNo" ValidationGroup="a" ID="RequiredFieldValidator13" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtBankerMobileNo" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Payout Status
                                        <asp:RequiredFieldValidator ControlToValidate="ddlPayoutStatus" InitialValue="0" ValidationGroup="a" ID="RequiredFieldValidator14" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:DropDownList runat="server" ID="ddlPayoutStatus" ValidationGroup="a" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Payout Received In
                                        <asp:RequiredFieldValidator ControlToValidate="txtPayoutRecIn" ValidationGroup="a" ID="RequiredFieldValidator15" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtPayoutRecIn" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Payout Received Date
                                        <asp:RequiredFieldValidator ControlToValidate="txtPayoutRecDate" ValidationGroup="a" ID="RequiredFieldValidator16" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtPayoutRecDate" TextMode="Date" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        GST Amount Received Date
                                        <asp:RequiredFieldValidator ControlToValidate="txtGSTAmtRecDate" ValidationGroup="a" ID="RequiredFieldValidator17" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtGSTAmtRecDate" TextMode="Date" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Additional Payout Amount
                                        <asp:RequiredFieldValidator ControlToValidate="txtAddPayAmt" ValidationGroup="a" ID="RequiredFieldValidator18" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ControlToValidate="txtAddPayAmt" ID="CompareValidator8" runat="server" ErrorMessage="*Enter Only Numbers" ForeColor="Red" Display="Dynamic" ValidationGroup="a" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
                                    </label>
                                    <asp:TextBox ID="txtAddPayAmt" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Additional Payout Amount Received
                                        <asp:RequiredFieldValidator ControlToValidate="txtAddPayAmtRec" ValidationGroup="a" ID="RequiredFieldValidator19" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtAddPayAmtRec" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Additional Payout Status
                                        <asp:RequiredFieldValidator ControlToValidate="ddlAddPayStatus" InitialValue="0" ValidationGroup="a" ID="RequiredFieldValidator20" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:DropDownList runat="server" ID="ddlAddPayStatus" ValidationGroup="a" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Additional Payout Date
                                        <asp:RequiredFieldValidator ControlToValidate="txtAddPayDate" ValidationGroup="a" ID="RequiredFieldValidator21" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtAddPayDate" TextMode="Date" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        LG Name
                                        <asp:RequiredFieldValidator ControlToValidate="txtLGName" ValidationGroup="a" ID="RequiredFieldValidator22" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtLGName" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        LG Mobile No.
                                        <asp:RequiredFieldValidator ControlToValidate="txtLGMobileNo" ValidationGroup="a" ID="RequiredFieldValidator23" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtLGMobileNo" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>



                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="header-title mb-3">&nbsp</h4>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        LG Payout
        <asp:RequiredFieldValidator ControlToValidate="txtLGPayout" ValidationGroup="a" ID="RequiredFieldValidator24" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ControlToValidate="txtLGPayout" ID="CompareValidator9" runat="server" ErrorMessage="*Enter Only Numbers" ForeColor="Red" Display="Dynamic" ValidationGroup="a" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
                                    </label>
                                    <asp:TextBox ID="txtLGPayout" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        LG Extra Payout
 <asp:RequiredFieldValidator ControlToValidate="txtLGExtraPayout" ValidationGroup="a" ID="RequiredFieldValidator25" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ControlToValidate="txtLGExtraPayout" ID="CompareValidator10" runat="server" ErrorMessage="*Enter Only Numbers" ForeColor="Red" Display="Dynamic" ValidationGroup="a" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
                                    </label>
                                    <asp:TextBox ID="txtLGExtraPayout" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        LG Payout Status
                                <asp:RequiredFieldValidator ControlToValidate="ddlLGPayStatus" InitialValue="0" ValidationGroup="a" ID="RequiredFieldValidator26" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:DropDownList runat="server" ID="ddlLGPayStatus" ValidationGroup="a" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        LG Payout Date
                                <asp:RequiredFieldValidator ControlToValidate="txtLGPayoutDate" ValidationGroup="a" ID="RequiredFieldValidator27" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtLGPayoutDate" TextMode="Date" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Name Who Handled
                                <asp:RequiredFieldValidator ControlToValidate="txtNameWhoHandled" ValidationGroup="a" ID="RequiredFieldValidator28" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtNameWhoHandled" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        LH Mobile No.
                                <asp:RequiredFieldValidator ControlToValidate="txtLHMobileNo" ValidationGroup="a" ID="RequiredFieldValidator29" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtLHMobileNo" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Staff Payout
                                <asp:RequiredFieldValidator ControlToValidate="txtStaffPayout" ValidationGroup="a" ID="RequiredFieldValidator30" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ControlToValidate="txtStaffPayout" ID="CompareValidator11" runat="server" ErrorMessage="*Enter Only Numbers" ForeColor="Red" Display="Dynamic" ValidationGroup="a" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
                                    </label>
                                    <asp:TextBox ID="txtStaffPayout" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Staff Payout Status
                                <asp:RequiredFieldValidator ControlToValidate="ddlStaffPayStatus" InitialValue="0" ValidationGroup="a" ID="RequiredFieldValidator31" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:DropDownList runat="server" ID="ddlStaffPayStatus" ValidationGroup="a" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Staff Payout Date
                                        <asp:RequiredFieldValidator ControlToValidate="txtStaffPayoutDate" ValidationGroup="a" ID="RequiredFieldValidator32" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtStaffPayoutDate" TextMode="Date" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Case Expenses
                                        <asp:RequiredFieldValidator ControlToValidate="txtCaseExpenses" ValidationGroup="a" ID="RequiredFieldValidator33" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ControlToValidate="txtCaseExpenses" ID="CompareValidator12" runat="server" ErrorMessage="*Enter Only Numbers" ForeColor="Red" Display="Dynamic" ValidationGroup="a" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
                                    </label>
                                    <asp:TextBox ID="txtCaseExpenses" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Net Earning
                                        <asp:RequiredFieldValidator ControlToValidate="txtNetEarning" ValidationGroup="a" ID="RequiredFieldValidator34" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ControlToValidate="txtNetEarning" ID="CompareValidator13" runat="server" ErrorMessage="*Enter Only Numbers" ForeColor="Red" Display="Dynamic" ValidationGroup="a" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
                                    </label>
                                    <asp:TextBox ID="txtNetEarning" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>


                                <asp:Button ID="BtnSubmit" runat="server" ValidationGroup="a" OnClick="BtnSubmit_Click" CssClass="btn btn-primary" Text="Submit" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
