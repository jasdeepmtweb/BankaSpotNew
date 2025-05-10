<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Site.Master" AutoEventWireup="true" CodeBehind="EditDisbursement.aspx.cs" Inherits="BankaSpotNew.Employee.EditDisbursement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
 <div class="content-page">
     <div class="content">
         <div class="container-fluid">
             <div class="row">
                 <div>

                 </div>
                 <div class="col-lg-6 mx-auto">
                     <div class="card">
                         <div class="card-body">
                             <h4 class="header-title mb-3">Add Case Status</h4>
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
                             <div class="mb-2">
                                 <label for="exampleInputPassword1" class="form-label">
                                     New Status
                                     <asp:RequiredFieldValidator ControlToValidate="ddlStatus" InitialValue="0" ValidationGroup="a" ID="RequiredFieldValidator9" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                 </label>
                                 <asp:DropDownList ID="ddlStatus" ValidationGroup="a" Enabled="false" CssClass="form-control" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                             </div>

                             <div class="mb-2" id="divPreStatus" runat="server" visible="false">
                                 <label for="exampleInputPassword1" class="form-label">
                                     Previous Status
                                     <asp:RequiredFieldValidator ControlToValidate="txtPreStatus" ValidationGroup="a" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                 </label>
                                 <asp:TextBox ID="txtPreStatus" Enabled="false" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                             </div>
                             <div class="mb-2" id="divAmountSanctioned" runat="server" visible="false">
                                 <label for="exampleInputPassword1" class="form-label">
                                     Amount Sanctioned
                                     <asp:RequiredFieldValidator ControlToValidate="txtAmountSanctioned" ValidationGroup="a" ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAmountSanctioned" Display="Dynamic" ForeColor="Red" ValidationGroup="a" ErrorMessage="Please enter a valid decimal or integer number." ValidationExpression="^(\d+)?(\.\d+)?$"></asp:RegularExpressionValidator>
                                 </label>
                                 <asp:TextBox ID="txtAmountSanctioned" ValidationGroup="a" Text="0" CssClass="form-control" runat="server"></asp:TextBox>
                             </div>
                             <div class="mb-2" id="divPreAmountDisbursed" runat="server" visible="false">
                                 <label for="exampleInputPassword1" class="form-label">
                                     Previous Amount Disbursed
      <asp:RequiredFieldValidator ControlToValidate="txtPreAmountDisbursed" ValidationGroup="a" ID="RequiredFieldValidator7" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtAmountDisbursed" Display="Dynamic" ForeColor="Red" ValidationGroup="a" ErrorMessage="Please enter a valid decimal or integer number." ValidationExpression="^(\d+)?(\.\d+)?$"></asp:RegularExpressionValidator>
                                 </label>
                                 <asp:TextBox ID="txtPreAmountDisbursed" ValidationGroup="a" Enabled="false" Text="0" CssClass="form-control" runat="server"></asp:TextBox>
                             </div>
                             <div class="mb-2" id="divAmount" runat="server" visible="true">
                                 <label for="exampleInputPassword1" class="form-label">
                                     Amount Disbursed
                                     <asp:RequiredFieldValidator ControlToValidate="txtAmountDisbursed" ValidationGroup="a" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator ID="myRegexValidator" runat="server" ControlToValidate="txtAmountDisbursed" Display="Dynamic" ForeColor="Red" ValidationGroup="a" ErrorMessage="Please enter a valid decimal or integer number." ValidationExpression="^(\d+)?(\.\d+)?$"></asp:RegularExpressionValidator>
                                 </label>
                                 <asp:TextBox ID="txtAmountDisbursed" ValidationGroup="a" Text="0" CssClass="form-control" runat="server"></asp:TextBox>
                             </div>
                             <div class="mb-2" id="divLoanAcc" runat="server" visible="true">
                                 <label for="exampleInputPassword1" class="form-label">
                                     Loan Account Number
                                     <asp:RequiredFieldValidator ControlToValidate="txtLoanAccountNo" ValidationGroup="a" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                 </label>
                                 <asp:TextBox ID="txtLoanAccountNo" ValidationGroup="a" CssClass="form-control" Text="0" runat="server"></asp:TextBox>
                             </div>
                             <div class="mb-2" id="divDisbursedDate" runat="server" visible="true">
                                 <label for="exampleInputPassword1" class="form-label">
                                     Disbursed Date
       <asp:RequiredFieldValidator ControlToValidate="txtDisbursedDate" ValidationGroup="a" ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                 </label>
                                 <asp:TextBox ID="txtDisbursedDate" ValidationGroup="a" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
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
                             <asp:Button ID="BtnSubmit" runat="server" ValidationGroup="a" OnClick="BtnSubmit_Click" CssClass="btn btn-primary" Text="Final Submit" />

                         </div>
                     </div>
                 </div>

             </div>
         </div>
     </div>
 </div>
</asp:Content>
