<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Site.Master" AutoEventWireup="true" CodeBehind="ShowMarketingEmp.aspx.cs" Inherits="BankaSpotNew.Branch.ShowMarketingEmp" %>

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
                                <h4 class="header-title mb-3">Show Marketing Employee</h4>
                                <div class="table-responsive">
                                    <asp:GridView ID="GridEmployee" runat="server" CssClass="table table-hover mb-0" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="BtnEdit" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="BtnEdit_Click" Text="Edit/Show" CssClass="btn btn-primary btn-sm" />
                                                    <asp:Button ID="BtnDelete" Visible="false" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="BtnDelete_Click" Text="Delete" CssClass="btn btn-danger btn-sm" />
                                                    <%--<asp:Button ID="BtnActivate" Visible='<%# Eval("EmployeeStatus").ToString().Equals("0") %>' runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="BtnActivate_Click" Text="Active" class="btn btn-success btn-sm" />--%>
                                                    <asp:Button ID="BtnInactive" runat="server" Visible='<%# Eval("EmployeeStatus").ToString().Equals("1") %>' CommandArgument='<%# Eval("Id") %>' OnClick="BtnInactive_Click" OnClientClick="return confirm('Do you want to inactive this User?');" Text="Deactivate" class="btn btn-danger btn-sm" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sr.No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="EmpId" HeaderText="Employee Id" />
                                            <asp:BoundField DataField="Name" HeaderText=" Name" />
                                            <asp:BoundField DataField="EmailId" HeaderText="Email ID" />
                                            <asp:TemplateField HeaderText="Date Of Joining">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDateOfJoining" runat="server" Text='<%# Eval("DateOfJoining", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText=" Mobile No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMobileNo" runat="server" Text='<%# Eval("MobileNo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="EmpPassword" HeaderText=" Password" />
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("EmployeeStatus").ToString()== "1" ? "Active" : "Inactive" %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ext3" HeaderText=" DOA" />
                                            <asp:BoundField DataField="ext4" HeaderText=" DOB" />
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
