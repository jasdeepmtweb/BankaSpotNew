<%@ Page Title="" Language="C#" MasterPageFile="~/FreeLancer/Site.Master" AutoEventWireup="true" CodeBehind="AddSubconnector.aspx.cs" Inherits="BankaSpotNew.FreeLancer.AddSubconnector" %>
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
                            <h4 class="header-title mb-3">Add Subconnector</h4>

                            <div class="mb-2">
                                <label for="fullname" class="form-label">
                                    Name
                                    <asp:RequiredFieldValidator ControlToValidate="txtName" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic" ValidationGroup="a"></asp:RequiredFieldValidator>
                                </label>
                                <asp:TextBox ID="txtName" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="mb-2">
                                <label for="emailaddress" class="form-label">
                                    Mobile No.
                                    <asp:RequiredFieldValidator ControlToValidate="txtMobileNo" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic" ValidationGroup="a"></asp:RequiredFieldValidator>
                                </label>
                                <asp:TextBox ID="txtMobileNo" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="mb-2">
                                <label for="emailaddress" class="form-label">
                                    Password
      <asp:RequiredFieldValidator ControlToValidate="txtPassword" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic" ValidationGroup="a"></asp:RequiredFieldValidator>
                                </label>
                                <asp:TextBox ID="txtPassword" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="mb-2" id="divMob" runat="server">
                                <label for="emailaddress" class="form-label">
                                    Email Id
                                    <asp:RequiredFieldValidator ControlToValidate="txtEmailId" ID="RequiredFieldValidator8" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic" ValidationGroup="a"></asp:RequiredFieldValidator>
                                </label>
                                <asp:TextBox ID="txtEmailId" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="mb-2" id="divPassword" runat="server">
                                <label for="emailaddress" class="form-label">
                                    City
                                    <asp:RequiredFieldValidator ControlToValidate="txtCity" ID="RequiredFieldValidator15" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic" ValidationGroup="a"></asp:RequiredFieldValidator>
                                </label>
                                <asp:TextBox ID="txtCity" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="mb-2">
                                <label for="emailaddress" class="form-label">
                                    Address
                                    <asp:RequiredFieldValidator ControlToValidate="txtAddress" ID="RequiredFieldValidator9" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic" ValidationGroup="a"></asp:RequiredFieldValidator>
                                </label>
                                <asp:TextBox ID="txtAddress" ValidationGroup="a" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <asp:Button ID="BtnSubmit" runat="server" ValidationGroup="a" OnClick="BtnSubmit_Click" CssClass="btn btn-primary" Text="Submit" />
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</div>
</asp:Content>
