<%@ Page Title="" Language="C#" MasterPageFile="~/FreeLancer/Site.Master" AutoEventWireup="true" CodeBehind="ShowDisbursedCases.aspx.cs" Inherits="BankaSpotNew.FreeLancer.ShowDisbursedCases" %>

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
                                <h4 class="header-title mb-3">Disbursed Case List</h4>
                                <div class="table-responsive">
                                    <asp:GridView ID="GridCase" runat="server" CssClass="table table-bordered mb-0" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="BtnSCPayout" runat="server" Text="SC Payout" CssClass="btn btn-primary btn-sm" OnClick="BtnSCPayout_Click" CommandArgument='<%# Eval("Id") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sr.No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DisbursedDate" HeaderText="Disbursed Date" DataFormatString="{0:dd-MMM-yyyy}" />
                                            <asp:BoundField DataField="Name" HeaderText=" Name" />
                                            <asp:BoundField DataField="MobileNo" HeaderText=" Mobile No." />
                                            <asp:BoundField DataField="ext5" HeaderText="Amount Disbursed" />
                                            <asp:BoundField DataField="City" HeaderText="City" />
                                            <asp:BoundField DataField="ProductName" HeaderText="Product Required" />
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
