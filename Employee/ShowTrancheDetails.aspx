<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Site.Master" AutoEventWireup="true" CodeBehind="ShowTrancheDetails.aspx.cs" Inherits="BankaSpotNew.Employee.ShowTrancheDetails" %>

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
                                <h4 class="header-title mb-3">Tranche Details</h4>
                                <div class="table-responsive">
                                    <asp:GridView ID="GridCase" runat="server" CssClass="table mb-0" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Button ID="BtnEditTranche" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="BtnEditTranche_Click" Text="Edit" CssClass="btn btn-primary btn-sm" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sr.No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Name" HeaderText=" File Name" />
                                            <asp:BoundField DataField="ProductName" HeaderText=" Product" />
                                            <asp:BoundField DataField="DateAdded" DataFormatString="{0:dd-MM-yyyy}" HeaderText=" Date" />
                                            <asp:BoundField DataField="NewStatus" HeaderText=" Status" />
                                            <asp:BoundField DataField="Remarks" HeaderText=" Remarks" />
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
