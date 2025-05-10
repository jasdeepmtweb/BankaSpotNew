<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/Site.Master" AutoEventWireup="true" CodeBehind="ApplyLoan.aspx.cs" Inherits="BankaSpotNew.Customer.ApplyLoan" %>

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
                                <h4 class="header-title mb-3">Apply Loan</h4>

                                <div class="mb-2">
                                    <label for="fullname" class="form-label">
                                        Name
 <asp:RequiredFieldValidator ControlToValidate="txtName" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic" ValidationGroup="a"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtName" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="emailaddress" class="form-label">
                                        Mobile No.
    <asp:RequiredFieldValidator ControlToValidate="txtMobileNo" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic" ValidationGroup="a"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtMobileNo" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="emailaddress" class="form-label">
                                        Loan Required
                                        <asp:RequiredFieldValidator ControlToValidate="ddlProduct" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic" ValidationGroup="a"></asp:RequiredFieldValidator>
                                    </label>
                                    <%--<asp:TextBox ID="txtLoanRequired" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>--%>
                                    <asp:DropDownList ID="ddlProduct" ValidationGroup="a" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="mb-2">
                                    <label for="emailaddress" class="form-label">
                                        Amount Required
         <asp:RequiredFieldValidator ControlToValidate="txtAmountRequired" ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic" ValidationGroup="a"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ControlToValidate="txtAmountRequired" Operator="DataTypeCheck" Type="Double" ID="CompareValidator1" runat="server" ErrorMessage="*Enter Only Numbers" ForeColor="Red" Display="Dynamic" ValidationGroup="a"></asp:CompareValidator>
                                    </label>
                                    <asp:TextBox ID="txtAmountRequired" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="emailaddress" class="form-label">
                                        Profile
         <asp:RequiredFieldValidator ControlToValidate="txtProfile" ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic" ValidationGroup="a"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtProfile" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="emailaddress" class="form-label">
                                        Monthly Income
                                        <asp:RequiredFieldValidator ControlToValidate="txtMonthlyIncome" ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic" ValidationGroup="a"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ControlToValidate="txtMonthlyIncome" Operator="DataTypeCheck" Type="Double" ID="CompareValidator2" runat="server" ErrorMessage="*Enter Only Numbers" ForeColor="Red" Display="Dynamic" ValidationGroup="a"></asp:CompareValidator>
                                    </label>
                                    <asp:TextBox ID="txtMonthlyIncome" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2" id="divPassword" runat="server">
                                    <label for="emailaddress" class="form-label">
                                        City
 <asp:RequiredFieldValidator ControlToValidate="txtCity" ID="RequiredFieldValidator15" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic" ValidationGroup="a"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtCity" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
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
