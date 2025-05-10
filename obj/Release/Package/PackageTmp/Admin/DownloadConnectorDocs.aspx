<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="DownloadConnectorDocs.aspx.cs" Inherits="BankaSpotNew.Admin.DownloadConnectorDocs" %>
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
                                <h4 class="header-title mb-3">Connector Docs</h4>
                                <div class="table-responsive">
                                    <asp:GridView ID="GridConnector" runat="server" CssClass="table mb-0" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="btedt" runat="server" CommandArgument='<%# Eval("ext1") %>' OnClick="btedt_Click" Text="Download Pan" class="btn btn-primary btn-sm" />
                                                    <asp:Button ID="BtnAdhar" runat="server" CommandArgument='<%# Eval("ext2") %>' OnClick="BtnAdhar_Click" Text="Download Adhar" class="btn btn-primary btn-sm" />
                                                    <asp:Button ID="BtnCancelCheck" runat="server" CommandArgument='<%# Eval("ext3") %>' OnClick="BtnCancelCheck_Click" Text="Download Cancel Check" class="btn btn-primary btn-sm" />
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
                                            <asp:BoundField DataField="ConnectorId" HeaderText="Connector Id" />
                                            <asp:BoundField DataField="Name" HeaderText=" Name" />
                                            <asp:BoundField DataField="EmailId" HeaderText="Email ID" />
                                            <asp:BoundField DataField="PanNo" HeaderText="Pan No." />
                                            <asp:BoundField DataField="AdharNo" HeaderText="Adhaar No." />
                                            <asp:BoundField DataField="MobileNo" HeaderText=" Mobile No." />
                                            <asp:BoundField DataField="Password" HeaderText=" Password" />
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