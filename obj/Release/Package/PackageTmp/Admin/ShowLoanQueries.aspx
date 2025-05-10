<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="ShowLoanQueries.aspx.cs" Inherits="BankaSpotNew.Admin.ShowLoanQueries" %>
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
                            <h4 class="header-title mb-3">Loan Queries</h4>
                            <div class="table-responsive">
                                <asp:GridView ID="GridBranches" runat="server" CssClass="table mb-0" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:Button ID="BtnDelete" runat="server" CommandArgument='<%# Eval("id") %>' OnClick="BtnDelete_Click" Text="Delete" class="btn btn-danger btn-sm" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sr.No">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="name" HeaderText="Name" />
                                        <asp:BoundField DataField="contactno" HeaderText="Contact No." />
                                        <asp:BoundField DataField="amount" HeaderText="Amount Req." />
                                        <asp:BoundField DataField="city" HeaderText="City" />
                                        <asp:BoundField DataField="profile" HeaderText="Profile" />
                                        <asp:BoundField DataField="prorequired" HeaderText="Loan Type" />
                                        <asp:BoundField DataField="experience" HeaderText="Remarks" />
                                        <asp:BoundField DataField="dateadded" HeaderText="Date" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false"/>
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
