<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="AddBranch.aspx.cs" Inherits="BankaSpotNew.Admin.AddBranch" %>

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
                                <h4 class="header-title mb-3">Add Branch</h4>


                                <div class="mb-2" runat="server" id="divBranchId" visible="false">
                                    <label for="exampleInputEmail1" class="form-label">
                                        Branch ID No.
                                        <asp:RequiredFieldValidator ControlToValidate="txtBranchIdNo" ValidationGroup="a" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtBranchIdNo" Enabled="false" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Branch Name
                                        <asp:RequiredFieldValidator ControlToValidate="txtBranchName" ValidationGroup="a" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtBranchName" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                 <div class="mb-2" id="divMob" runat="server">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Branch Mobile No.
                                        <asp:RequiredFieldValidator ControlToValidate="txtBranchMobileNo" ValidationGroup="a" ID="RequiredFieldValidator8" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtBranchMobileNo" MaxLength="10" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                 <div class="mb-2" id="divPassword" runat="server">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Branch Password
                                        <asp:RequiredFieldValidator ControlToValidate="txtBranchPassword" ValidationGroup="a" ID="RequiredFieldValidator9" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtBranchPassword" MaxLength="6" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Branch Manager Name
                                        <asp:RequiredFieldValidator ControlToValidate="txtBranchManagerName" ValidationGroup="a" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtBranchManagerName" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                
                                <asp:Button ID="BtnSubmit" runat="server" ValidationGroup="a" OnClick="BtnSubmit_Click" CssClass="btn btn-primary" Text="Submit" />
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="header-title mb-3">&nbsp</h4>
                                 <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Region
                                        <asp:RequiredFieldValidator ControlToValidate="ddlRegion" InitialValue="0" ValidationGroup="a" ID="RequiredFieldValidator10" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:DropDownList ID="ddlRegion" ValidationGroup="a" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                 <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Branch Location
                                        <asp:RequiredFieldValidator ControlToValidate="txtBranchLocation" ValidationGroup="a" ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtBranchLocation" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                 <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Branch Address
                                        <asp:RequiredFieldValidator ControlToValidate="txtBranchAddress" ValidationGroup="a" ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtBranchAddress" TextMode="MultiLine" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                 <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Branch Month Wise Target
                                        <asp:RequiredFieldValidator ControlToValidate="txtBranchMonthTarget" ValidationGroup="a" ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtBranchMonthTarget" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                 <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Branch Product Wise Target
                                        <asp:RequiredFieldValidator ControlToValidate="txtBranchProTarget" ValidationGroup="a" ID="RequiredFieldValidator7" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtBranchProTarget" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                </div>
                            </div>
                        </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
