<%@ Page Title="" Language="C#" MasterPageFile="~/Accountant/Site.Master" AutoEventWireup="true" CodeBehind="ShowAllCases.aspx.cs" Inherits="BankaSpotNew.Accountant.ShowAllCases" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
    <div class="content-page">
        <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtSearchByEmpName" AutoPostBack="true" OnTextChanged="txtSearchByEmpName_TextChanged" placeholder="Search By Emp. Name" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtSearchByLGName" AutoPostBack="true" OnTextChanged="txtSearchByLGName_TextChanged" placeholder="Search By LG Name" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtSearchByCaseStatus" AutoPostBack="true" OnTextChanged="txtSearchByCaseStatus_TextChanged" placeholder="Search By Case Status" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtSearchByBankName" AutoPostBack="true" OnTextChanged="txtSearchByBankName_TextChanged" placeholder="Search By Bank Name" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtSearchByProduct" AutoPostBack="true" OnTextChanged="txtSearchByProduct_TextChanged" placeholder="Search By Product" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="header-title mb-3">All Cases List</h4>
                                <div class="">
                                    <asp:GridView ID="GridAllCases" runat="server" CssClass="table table-bordered mb-0" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button Text="Show/Edit Expenses" ID="BtnAddExpenses" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary btn-sm" OnClick="BtnAddExpenses_Click" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sr.No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           <asp:BoundField DataField="DisbursedDate" HeaderText="Disbursed Date" DataFormatString="{0:dd-M-yyyy}"/>
                                            <asp:BoundField DataField="Name" HeaderText="File Name" />
                                            <asp:BoundField DataField="MobileNo" HeaderText=" Mobile No." />
                                            <asp:BoundField DataField="City" HeaderText="City" />

                                            <asp:BoundField DataField="ProductName" HeaderText=" Product" />
                                            <asp:BoundField DataField="AmountReq" HeaderText="Amount Req." />
                                            <%--<asp:BoundField DataField="CustomerProfile" HeaderText=" Customer Profile" />--%>
                                            <asp:BoundField DataField="Status" HeaderText=" Status" />
                                            <%--<asp:BoundField DataField="Remarks" HeaderText=" Status Remarks" />--%>
                                            <asp:BoundField DataField="LeadHandling" HeaderText="Lead Handling" />
                                            <asp:BoundField DataField="MarketingEmpName" HeaderText="MKT Emp." />
                                            <asp:BoundField DataField="ext2" HeaderText=" Sanctioned Amount" />
                                            <%--<asp:BoundField DataField="Address" HeaderText=" Address" />
                                            <asp:BoundField DataField="MonthlyIncome" HeaderText=" Monthly Income" />--%>
                                            <asp:BoundField DataField="BankName" HeaderText="Bank Name" />
                                            <asp:BoundField DataField="BankEmpName" HeaderText=" Banker Name" />
                                            <asp:BoundField DataField="BankEmpContactNo" HeaderText="Banker Contact No." />

                                            <asp:BoundField DataField="LeadGenerated" HeaderText=" LG Name" />
                                            <asp:BoundField DataField="LeadGenContactNo" HeaderText="LG Contact No." />
                                            <asp:BoundField DataField="FileLogInDate" HeaderText="File LogIn Date" DataFormatString="{0:dd-M-yyyy}" />
                                             <asp:BoundField DataField="CreatedOn" HeaderText=" File Entry Date" DataFormatString="{0:dd-MM-yyyy}" />
                                            <%--<asp:BoundField DataField="ExpectedDisbursedDate" HeaderText=" Expected Disbursement Date" DataFormatString="{0:dd-M-yyyy}" />--%>
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
