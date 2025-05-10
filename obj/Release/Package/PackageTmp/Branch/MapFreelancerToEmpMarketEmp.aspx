<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Site.Master" AutoEventWireup="true" CodeBehind="MapFreelancerToEmpMarketEmp.aspx.cs" Inherits="BankaSpotNew.Branch.MapFreelancerToEmpMarketEmp" %>

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
                                <h4 class="header-title mb-3">Map Freelancer To Employee And Market Employee</h4>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Branch
                                    </label>
                                    <asp:Label ID="lblBranch" CssClass="form-control" runat="server"></asp:Label>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Current Employee
                                    </label>
                                    <asp:Label ID="lblCurrentEmployee" CssClass="form-control" runat="server"></asp:Label>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Current Marketing Employee
                                    </label>
                                    <asp:Label ID="lblCurrentMarketEmp" CssClass="form-control" runat="server"></asp:Label>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Employee
                            <asp:RequiredFieldValidator ControlToValidate="ddlEmployee" InitialValue="0" ValidationGroup="a" ID="RequiredFieldValidator9" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:DropDownList ID="ddlEmployee" ValidationGroup="a" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Market Employee
                                        <asp:RequiredFieldValidator ControlToValidate="ddlMarketEmployee" ValidationGroup="a" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:DropDownList ID="ddlMarketEmployee" ValidationGroup="a" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>

                                <asp:Label ID="lblOldEmpId" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblOldMarketEmpId" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblOldBranchId" runat="server" Visible="false"></asp:Label>

                                <asp:Button ID="BtnSubmit" runat="server" ValidationGroup="a" OnClick="BtnSubmit_Click" CssClass="btn btn-primary" Text="Submit" />

                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
