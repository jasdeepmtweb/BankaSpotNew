<%@ Page Title="" Language="C#" MasterPageFile="~/Accountant/Site.Master" AutoEventWireup="true" CodeBehind="MarketingEmpPaidPayouts.aspx.cs" Inherits="BankaSpotNew.Accountant.MarketingEmpPaidPayouts" %>
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
                            <h4 class="header-title mb-3">Marketing Employee Paid Payouts</h4>
                            <div class="table-responsive">
                                <asp:GridView ID="GridRegion" runat="server" CssClass="table mb-0" AutoGenerateColumns="false">
                                    <Columns>
                                       
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
                                        <asp:BoundField DataField="BranchLocation" HeaderText=" Branch Location" />
                                        <asp:BoundField DataField="EmpName" HeaderText=" Marketing Emp." />
                                        <asp:BoundField DataField="CustomerName" HeaderText=" Name" />
                                        <asp:BoundField DataField="ProductName" HeaderText=" Product" />
                                         <asp:BoundField DataField="AmountDisbursed" HeaderText=" Amount Disbursed" />
                                        <asp:BoundField DataField="PayAmount" HeaderText=" Incentive" />
                                        <asp:BoundField DataField="PayDate" HeaderText=" Disbursed Month" DataFormatString = "{0:dd/MMM/yyyy}"/>
                                         <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("ext1").ToString()=="0" ? "Pending" : "Paid" %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ext2" HeaderText=" Payout Date" />
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
