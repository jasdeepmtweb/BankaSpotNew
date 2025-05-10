<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="TransferCaseToBranch.aspx.cs" Inherits="BankaSpotNew.Admin.TransferCaseToBranch" %>

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
                                <h4 class="header-title mb-3">Transfer Case To Other Branch<b class="text-danger">(Transfer Reset Employee ID And Marketing Employee ID)</b></h4>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Current Branch
                                    </label>
                                    <asp:Label ID="lblCurrentBranch" CssClass="form-control" runat="server"></asp:Label>
                                </div>

                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        New Branch
                            <asp:RequiredFieldValidator ControlToValidate="ddlBranch" InitialValue="0" ValidationGroup="a" ID="RequiredFieldValidator9" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:DropDownList ID="ddlBranch" ValidationGroup="a" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>

                                <asp:Label ID="lblOldEmpId" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblOldMarketEmpId" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblOldBranchId" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblOldConnectorId" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblOldFreelancerId" runat="server" Visible="false"></asp:Label>

                                <asp:Button ID="BtnSubmit" runat="server" ValidationGroup="a" OnClick="BtnSubmit_Click" CssClass="btn btn-primary" Text="Submit" />

                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
