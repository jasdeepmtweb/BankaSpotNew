<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Site.Master" AutoEventWireup="true" CodeBehind="ConnectorListForMapping.aspx.cs" Inherits="BankaSpotNew.Branch.ConnectorListForMapping" %>

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
                                <h4 class="header-title mb-3">Connector List</h4>
                                <div class="table-responsive">
                                    <asp:GridView ID="GridConnectorForBranch" runat="server" CssClass="table table-hover mb-0" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="BtnMap" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="BtnMap_Click" Text="Map To Emp/Market Emp." CssClass="btn btn-primary btn-sm" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sr.No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="ConnectorId" HeaderText="Connector Id" />
                                            <asp:BoundField DataField="Name" HeaderText=" Name" />
                                            <asp:BoundField DataField="MobileNo" HeaderText=" Mobile No." />
                                            <asp:BoundField DataField="Password" HeaderText=" Password" />
                                            <asp:BoundField DataField="EmpName" HeaderText=" Emp. Name" />
                                            <asp:BoundField DataField="MarketEmpName" HeaderText=" Market. Emp. Name" />
                                            <asp:BoundField DataField="EmailId" HeaderText="Email ID" />
                                            <asp:BoundField DataField="Address" HeaderText="Address" />
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
