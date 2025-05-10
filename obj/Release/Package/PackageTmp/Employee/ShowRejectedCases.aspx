<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Site.Master" AutoEventWireup="true" CodeBehind="ShowRejectedCases.aspx.cs" Inherits="BankaSpotNew.Employee.ShowRejectedCases" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
    <div class="content-page">
        <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-12 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="header-title mb-3">Rejected Cases</h4>
                                <div class="table-responsive">
                                    <asp:GridView ID="GridCase" runat="server" CssClass="table mb-0" AutoGenerateColumns="false">
                                        <Columns>
                                             <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="BtnRelogin" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="BtnRelogin_Click" Text="ReLogin" class="btn btn-primary btn-sm" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sr.No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sr.No" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblid" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:BoundField DataField="CreatedOn" HeaderText=" File Entry Date" DataFormatString="{0:dd-MM-yyyy}"/>
                                            <asp:BoundField DataField="Name" HeaderText="File Name" />
                                            <asp:BoundField DataField="MobileNo" HeaderText=" Mobile No." />
                                             <asp:BoundField DataField="City" HeaderText="City" />
                                             <asp:BoundField DataField="ProductName" HeaderText=" Product" />
                                            <asp:BoundField DataField="AmountReq" HeaderText="Amount Req." />
                                            <asp:BoundField DataField="CustomerProfile" HeaderText=" Customer Profile" />
                                            <asp:BoundField DataField="Status" HeaderText=" Status" />
                                            <asp:BoundField DataField="Remarks" HeaderText=" Reason" />
                                           
                                            <asp:BoundField DataField="BankName" HeaderText="Bank Name" />
                                            
                                             <asp:BoundField DataField="BankEmpName" HeaderText=" Banker Name" />
                                            <asp:BoundField DataField="BankEmpContactNo" HeaderText="Banker Contact No." />
                                             <asp:BoundField DataField="LeadHandling" HeaderText="Lead Handling" />
                                            <asp:BoundField DataField="LeadGenerated" HeaderText=" LG Name" />
                                            <asp:BoundField DataField="LeadGenContactNo" HeaderText="LG Contact No." />
                                             
                                            <%--<asp:BoundField DataField="CreatedOn" HeaderText=" File Entry Date" DataFormatString="{0:dd-MM-yyyy}" />
                                             <asp:BoundField DataField="Address" HeaderText=" Address" />
                                           
                                            
                                            
                                            <asp:BoundField DataField="MonthlyIncome" HeaderText=" Monthly Income" />--%>
                                            <%--<asp:BoundField DataField="ext1" HeaderText="Case Remarks" />--%>
                                            <%--<asp:BoundField DataField="FileLogInDate" HeaderText="File LogIn Date" DataFormatString="{0:dd-M-yyyy}" />
                                            <asp:BoundField DataField="ExpectedDisbursedDate" HeaderText=" Expected Disbursed Date" DataFormatString="{0:dd-M-yyyy}" />--%>
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