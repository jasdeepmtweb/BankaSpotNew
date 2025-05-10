<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Site.Master" AutoEventWireup="true" CodeBehind="CasesFromFreelancers.aspx.cs" Inherits="BankaSpotNew.Branch.CasesFromFreelancers" %>
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
                                <h4 class="header-title mb-3">Case List</h4>
                                <div class="table-responsive">
                                    <asp:GridView ID="GridCaseFromFreelancer" runat="server" CssClass="table table-hover mb-0" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="btedt" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="btedt_Click" Text="Edit" class="btn btn-primary btn-sm" />
                                                    <asp:Button ID="btndel" OnClientClick="return confirm('Do you want to delete this Case?');" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="btndel_Click" Text="Delete" class="btn btn-danger btn-sm" />
                                               <asp:Button ID="BtnAddEmployee" Enabled='<%# Eval("EmpId").ToString().Equals("0") %>' runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="BtnAddEmployee_Click" Text="Add Employee" class="btn btn-success btn-sm" />
                                                    <asp:Button ID="BtnChangeFreelancer" runat="server" CommandArgument='<%# Eval("Id") %>' Visible="false" OnClick="BtnChangeFreelancer_Click" Text="Change Freelancer" class="btn btn-warning btn-sm" />
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
                                            <asp:BoundField DataField="Name" HeaderText=" Name" />
                                            <asp:BoundField DataField="MobileNo" HeaderText=" Mobile No." />
                                            <asp:BoundField DataField="City" HeaderText="City" />
                                            <asp:BoundField DataField="FreelancerName" HeaderText="Freelancer Name" />
                                            <asp:BoundField DataField="EmpName" HeaderText="Employee" />
                                            <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                             <asp:TemplateField HeaderText="Sr.No" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFreelancerId" runat="server" Text='<%# Eval("ext3") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sr.No" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmpId" runat="server" Text='<%# Eval("EmpId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
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