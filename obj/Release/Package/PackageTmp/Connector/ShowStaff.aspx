<%@ Page Title="" Language="C#" MasterPageFile="~/Connector/Site.Master" AutoEventWireup="true" CodeBehind="ShowStaff.aspx.cs" Inherits="BankaSpotNew.Connector.ShowStaff" %>

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
                                <h4 class="header-title mb-3">Staff List</h4>
                                <div class="table-responsive">
                                    <asp:GridView ID="GridStaff" runat="server" CssClass="table mb-0" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr.No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="StaffName" HeaderText="Name" />
                                            <asp:BoundField DataField="StaffMobileNo" HeaderText="Mobile No." />
                                            <asp:BoundField DataField="StaffEmailId" HeaderText="Email Id" />
                                            <asp:BoundField DataField="ProductName" HeaderText="Product" />
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
