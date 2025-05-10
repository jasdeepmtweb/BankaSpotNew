<%@ Page Title="" Language="C#" MasterPageFile="~/FreeLancer/Site.Master" AutoEventWireup="true" CodeBehind="AddLeadOrLoan.aspx.cs" Inherits="BankaSpotNew.FreeLancer.AddLeadOrLoan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br />
<div class="content-page">
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-4">
                    <div class="card">
                        <div class="card-body">
                            <h4 class="header-title mb-3">Add Lead Or Loan</h4>
                            <div class="mb-2">
                                <label for="emailaddress" class="form-label">
                                    Type
    <asp:RequiredFieldValidator ControlToValidate="ddlType" ID="RequiredFieldValidator7" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic" ValidationGroup="a"></asp:RequiredFieldValidator>
                                </label>
                                <asp:DropDownList ID="ddlType" ValidationGroup="a" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
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
                <div class="col-lg-8">
                    <div class="card">
                        <div class="card-body">
                            <h4 class="header-title mb-3">List</h4>
                            <div class="table-responsive">
                                <asp:GridView ID="GridAllCases" runat="server" CssClass="table table-bordered mb-0" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:Button ID="BtnEdit" CommandArgument='<%# Eval("Id")+","+Eval("Type") %>' OnClick="BtnEdit_Click" CssClass="btn btn-success btn-sm" runat="server" Text="Edit" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sr.No">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Name" HeaderText=" Name" />
                                        <asp:BoundField DataField="MobileNo" HeaderText=" Mobile No." />
                                        <asp:BoundField DataField="LoanReq" HeaderText="Loan Req." />
                                        <asp:BoundField DataField="AmountReq" HeaderText=" Amount Req." />
                                        <asp:BoundField DataField="Profile" HeaderText="Profile" />
                                        <asp:BoundField DataField="MonthlyIncome" HeaderText=" Monthly Income" />
                                        <asp:BoundField DataField="City" HeaderText=" City" />
                                        <asp:BoundField DataField="Type" HeaderText=" Type" />
                                        <asp:BoundField DataField="CreatedOn" HeaderText="Date" DataFormatString="{0:dd-MMM-yyyy}" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
