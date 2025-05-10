<%@ Page Title="" Language="C#" MasterPageFile="~/Connector/Site.Master" AutoEventWireup="true" CodeBehind="ShowRejectedCases.aspx.cs" Inherits="BankaSpotNew.Connector.ShowRejectedCases" %>
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
                                <h4 class="header-title mb-3">Rejected Case List</h4>
                                <div class="table-responsive">
                                    <asp:GridView ID="GridCase" runat="server" CssClass="table mb-0" AutoGenerateColumns="false">
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
                                            <asp:BoundField DataField="DisbursedDate" HeaderText="Rejected Date" DataFormatString="{0:dd-MMM-yyyy}" />
                                            <asp:BoundField DataField="Name" HeaderText=" Name" />
                                            <asp:BoundField DataField="MobileNo" HeaderText=" Mobile No." />
                                            <asp:BoundField DataField="City" HeaderText="City" />
                                             <asp:BoundField DataField="ProductName" HeaderText="Product Required" />
                                             <asp:BoundField DataField="Remarks" HeaderText="Rejection Reason" />
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