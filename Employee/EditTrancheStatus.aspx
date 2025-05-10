<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Site.Master" AutoEventWireup="true" CodeBehind="EditTrancheStatus.aspx.cs" Inherits="BankaSpotNew.Employee.EditTrancheStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="content-page">
        <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-6 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                <asp:Label ID="lblTotalAmountDisbursed" CssClass="form-control" Visible="false" runat="server" Text="0"></asp:Label>
                                <h4 class="header-title mb-3">Update Tranche</h4>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        File Name
      <asp:RequiredFieldValidator ControlToValidate="txtFileName" ValidationGroup="a" ID="RequiredFieldValidator8" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtFileName" ValidationGroup="a" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Product
      <asp:RequiredFieldValidator ControlToValidate="txtProduct" ValidationGroup="a" ID="RequiredFieldValidator10" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtProduct" ValidationGroup="a" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                </div>

                                <div class="mb-2" id="divAmountSanctioned" runat="server" visible="true">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Amount Sanctioned
                                     <asp:RequiredFieldValidator ControlToValidate="txtAmountSanctioned" ValidationGroup="a" ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAmountSanctioned" Display="Dynamic" ForeColor="Red" ValidationGroup="a" ErrorMessage="Please enter a valid decimal or integer number." ValidationExpression="^(\d+)?(\.\d+)?$"></asp:RegularExpressionValidator>
                                    </label>
                                    <asp:TextBox ID="txtAmountSanctioned" ValidationGroup="a" Text="0" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Total Amount
                                        <asp:RequiredFieldValidator ControlToValidate="txtTotalAmount" ValidationGroup="a" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtPreAmountDisbursed" Display="Dynamic" ForeColor="Red" ValidationGroup="a" ErrorMessage="Please enter a valid decimal or integer number." ValidationExpression="^(\d+)?(\.\d+)?$"></asp:RegularExpressionValidator>
                                    </label>
                                    <asp:TextBox ID="txtTotalAmount" ValidationGroup="a" Enabled="false" Text="0" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2" id="divPreAmountDisbursed" runat="server" visible="true">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Previous Amount Disbursed
      <asp:RequiredFieldValidator ControlToValidate="txtPreAmountDisbursed" ValidationGroup="a" ID="RequiredFieldValidator7" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPreAmountDisbursed" Display="Dynamic" ForeColor="Red" ValidationGroup="a" ErrorMessage="Please enter a valid decimal or integer number." ValidationExpression="^(\d+)?(\.\d+)?$"></asp:RegularExpressionValidator>
                                    </label>
                                    <asp:TextBox ID="txtPreAmountDisbursed" ValidationGroup="a" Enabled="false" Text="0" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2" id="divRemainingAmount" runat="server" visible="true">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Remaining Amount 
                                     <asp:RequiredFieldValidator ControlToValidate="txtRemainingAmount" ValidationGroup="a" ID="RequiredFieldValidator11" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtRemainingAmount" Display="Dynamic" ForeColor="Red" ValidationGroup="a" ErrorMessage="Please enter a valid decimal or integer number." ValidationExpression="^(\d+)?(\.\d+)?$"></asp:RegularExpressionValidator>
                                    </label>
                                    <asp:TextBox ID="txtRemainingAmount" ValidationGroup="a" Enabled="false" Text="0" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2" id="divDisbursedDate" runat="server" visible="true">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Date
                                        <asp:RequiredFieldValidator ControlToValidate="txtDisbursedDate" ValidationGroup="a" ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtDisbursedDate" ValidationGroup="a" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2" id="divLoanAcc" runat="server" visible="true">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Loan Account Number
                                     <asp:RequiredFieldValidator ControlToValidate="txtLoanAccountNo" ValidationGroup="a" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtLoanAccountNo" ValidationGroup="a" CssClass="form-control" Text="0" runat="server"></asp:TextBox>
                                </div>

                                <div class="mb-2" id="divCaseBooked" runat="server" visible="true">
                                    <label for="exampleInputPassword1" class="form-label">
                                        File Booked In
       <asp:RequiredFieldValidator ControlToValidate="txtCaseBookedOn" ValidationGroup="a" ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtCaseBookedOn" ValidationGroup="a" CssClass="form-control" Text="0" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Remarks
                                     <asp:RequiredFieldValidator ControlToValidate="txtRemarks" ValidationGroup="a" ID="RequiredFieldValidator15" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtRemarks" TextMode="MultiLine" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>

                                <asp:Button ID="BtnSubmit" runat="server" ValidationGroup="a" OnClick="BtnSubmit_Click" CssClass="btn btn-success" Text="Submit" />
                                <asp:Button ID="BtnCaseClose" runat="server" ValidationGroup="a" OnClick="BtnCaseClose_Click" CssClass="btn btn-danger" Text="Case Close" />


                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
