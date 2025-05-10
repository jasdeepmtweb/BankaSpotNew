<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Site.Master" AutoEventWireup="true" CodeBehind="AddEmployeeTarget.aspx.cs" Inherits="BankaSpotNew.Branch.AddEmployeeTarget" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="content-page">
        <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-6 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="header-title mb-3">Add Target</h4>

                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Employee Name
        <asp:RequiredFieldValidator ControlToValidate="txtEmpName" ValidationGroup="a" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtEmpName" Enabled="false" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Product Name
                                        <asp:RequiredFieldValidator ControlToValidate="ddlProduct" InitialValue="0" ValidationGroup="a" ID="RequiredFieldValidator9" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:DropDownList ID="ddlProduct" ValidationGroup="a" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        For Month(Date)
                                        <asp:RequiredFieldValidator ControlToValidate="txtForMonth" ValidationGroup="a" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtForMonth" TextMode="Date" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Product Target
                                        <asp:RequiredFieldValidator ControlToValidate="txtTarget" ValidationGroup="a" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="myRegexValidator" runat="server" ControlToValidate="txtTarget" Display="Dynamic" ForeColor="Red" ValidationGroup="a" ErrorMessage="Please enter a valid decimal or integer number." ValidationExpression="^(\d+)?(\.\d+)?$"></asp:RegularExpressionValidator>
                                    </label>
                                    <asp:TextBox ID="txtTarget" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>

                                <asp:Button ID="BtnSubmit" runat="server" ValidationGroup="a" OnClick="BtnSubmit_Click" CssClass="btn btn-primary" Text="Submit" />

                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="header-title mb-3">List</h4>
                                <div class="table-responsive">
                                    <asp:GridView ID="GridEmployeeTarget" runat="server" CssClass="table table-hover" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="btndel" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="btndel_Click" Text="Delete" class="btn btn-danger btn-sm" />
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
                                            <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                            <asp:BoundField DataField="EmpTarget" HeaderText="Product Target" />
                                            <asp:BoundField DataField="ext1" HeaderText="Month Year" />
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
