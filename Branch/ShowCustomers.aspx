<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Site.Master" AutoEventWireup="true" CodeBehind="ShowCustomers.aspx.cs" Inherits="BankaSpotNew.Branch.ShowCustomers" %>

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
                                <h4 class="header-title mb-3">Customers List</h4>
                                <div class="table-responsive">
                                    <asp:GridView ID="GridConnector" runat="server" CssClass="table mb-0" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr.No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="CustomerName" HeaderText=" Name" />
                                            <asp:BoundField DataField="EmailId" HeaderText="Email ID" />
                                            <asp:BoundField DataField="City" HeaderText="City" />
                                            <asp:BoundField DataField="Address" HeaderText="Address" />
                                            <asp:BoundField DataField="CustomerMobileNo" HeaderText=" Mobile No." />
                                            <asp:BoundField DataField="Password" HeaderText=" Password" />
                                            <%--<asp:BoundField DataField="BranchName" HeaderText=" Branch" />--%>
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
