<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Site.Master" AutoEventWireup="true" CodeBehind="ShowTrancheCases.aspx.cs" Inherits="BankaSpotNew.Employee.ShowTrancheCases" %>
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
                            <h4 class="header-title mb-3">Tranche Cases</h4>
                            <div class="table-responsive">
                                <asp:GridView ID="GridCase" runat="server" CssClass="table table-bordered mb-0" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                 <asp:Button ID="BtnUpdateStatus" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="BtnUpdateStatus_Click" Text="Update Status" CssClass="btn btn-success btn-sm" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sr.No">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:BoundField DataField="DisbursedDate" HeaderText="Disbursed Date" DataFormatString="{0:dd-MMM-yyyy}" />--%>
                                        <asp:BoundField DataField="ext6" HeaderText="Loan Account No." />
                                        <asp:BoundField DataField="Name" HeaderText="File Name" />
                                        <asp:BoundField DataField="MobileNo" HeaderText=" Mobile No." />
                                        <asp:BoundField DataField="City" HeaderText="City" />
                                        <asp:BoundField DataField="ProductName" HeaderText=" Product" />
                                        <asp:BoundField DataField="ext5" HeaderText="Amount Disbursed" />
                                        <asp:BoundField DataField="CustomerProfile" HeaderText=" Customer Profile" />
                                        <asp:BoundField DataField="MarketingEmpName" HeaderText="Market. Emp. Name" />
                                        <asp:BoundField DataField="BankName" HeaderText="Bank Name" />
                                        <asp:BoundField DataField="BankEmpName" HeaderText=" Banker Name" />
                                        <asp:BoundField DataField="CaseBookedIn" HeaderText=" File Booked In" />

                                        <asp:BoundField DataField="BankEmpContactNo" HeaderText="Banker Contact No." />
                                        <asp:BoundField DataField="LeadHandling" HeaderText="Lead Handling" />
                                        <asp:BoundField DataField="LeadGenerated" HeaderText=" LG Name" />
                                        <asp:BoundField DataField="LeadGenContactNo" HeaderText="LG Contact No." />
                                        <asp:BoundField DataField="Status" HeaderText=" Status" />
                                        <asp:BoundField DataField="Remarks" HeaderText=" Status Remarks" />
                                        <asp:BoundField DataField="CreatedOn" HeaderText=" File Entry Date" DataFormatString="{0:dd-MM-yyyy}" />
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
