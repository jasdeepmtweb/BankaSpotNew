<%@ Page Title="" Language="C#" MasterPageFile="~/Accountant/Site.Master" AutoEventWireup="true" CodeBehind="ShowConnectorPayouts.aspx.cs" Inherits="BankaSpotNew.Accountant.ShowConnectorPayouts" %>
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
                                <h4 class="header-title mb-3">Connector Payouts</h4>
                                <div class="table-responsive">
                                    <asp:GridView ID="GridRegion" runat="server" CssClass="table mb-0" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="btedt" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="btedt_Click" Text="Paid" Enabled='<%# Eval("ext1").ToString().Equals("0") %>' class="btn btn-primary btn-sm" />
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
                                            <asp:TemplateField HeaderText="MobileNo" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMobileNo" runat="server" Text='<%# Eval("MobileNo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="BranchLocation" HeaderText=" Branch Location" />
                                            <asp:BoundField DataField="ConnectorName" HeaderText=" Connector" />
                                            <asp:BoundField DataField="EmpName" HeaderText=" Employee" />
                                            <asp:BoundField DataField="CustomerName" HeaderText=" Name" />
                                            <asp:BoundField DataField="ProductName" HeaderText=" Product" />
                                            <asp:BoundField DataField="AmountDisbursed" HeaderText=" Amount Disbursed" />
                                            <asp:BoundField DataField="OriginalPayout" HeaderText=" Gross Payout" />
                                            <asp:BoundField DataField="TDS" HeaderText=" TDS (5%)" />
                                            <asp:TemplateField HeaderText="Net Payout">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPayAmount" runat="server" Text='<%# Eval("PayAmount") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ConnectorPanNo" HeaderText=" Pan Card No." />
                                            <asp:BoundField DataField="DisbursedDate" HeaderText=" Disbursed Month" DataFormatString="{0:dd/MMM/yyyy}" />
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
