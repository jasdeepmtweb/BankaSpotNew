<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="AddAccountant.aspx.cs" Inherits="BankaSpotNew.Admin.AddAccountant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="content-page">
        <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-4 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="header-title mb-3">Add Accountant</h4>


                                <div class="mb-2">
                                    <label for="exampleInputEmail1" class="form-label">
                                        Name
                                    <asp:RequiredFieldValidator ControlToValidate="txtName" ValidationGroup="a" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtName" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Mobile No.
                                    <asp:RequiredFieldValidator ControlToValidate="txtMobileNo" ValidationGroup="a" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtMobileNo" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Email Id
                                    <asp:RequiredFieldValidator ControlToValidate="txtEmailId" ValidationGroup="a" ID="RequiredFieldValidator8" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtEmailId" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Password
                                    <asp:RequiredFieldValidator ControlToValidate="txtPassword" ValidationGroup="a" ID="RequiredFieldValidator9" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtPassword" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>

                                <asp:Button ID="BtnSubmit" runat="server" ValidationGroup="a" OnClick="BtnSubmit_Click" CssClass="btn btn-primary" Text="Submit" />
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-8 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="header-title mb-3">List</h4>
                                <div class="table-responsive">
                                    <asp:GridView ID="GridBankCodes" runat="server" CssClass="table table-bordered mb-0" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="BtnEdit" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="BtnEdit_Click" Text="Edit" class="btn btn-primary btn-sm" />
                                                    <asp:Button ID="BtnDelete" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="BtnDelete_Click" Text="Delete" class="btn btn-danger btn-sm" />
                                                    <asp:Button ID="BtnLogin" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="BtnLogin_Click" Text="Login" class="btn btn-dark btn-sm" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sr.No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Name" HeaderText="Name" />
                                            <asp:BoundField DataField="MobileNo" HeaderText="Mobile No." />
                                            <asp:BoundField DataField="EmailId" HeaderText="Email Id" />
                                            <asp:BoundField DataField="Password" HeaderText="Password" />
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
