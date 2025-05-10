<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="AddRegion.aspx.cs" Inherits="BankaSpotNew.Admin.AddRegion" %>
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
                                <h4 class="header-title mb-3">Add Region</h4>


                                <div class="mb-2">
                                    <label for="exampleInputEmail1" class="form-label">
                                        Region ID No.
                                        <asp:RequiredFieldValidator ControlToValidate="txtRegionIdNo" ValidationGroup="a" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtRegionIdNo" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Region Name
                                        <asp:RequiredFieldValidator ControlToValidate="txtRegionName" ValidationGroup="a" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtRegionName" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                 <div class="mb-2" id="divMob" runat="server">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Region Mobile No.
                                        <asp:RequiredFieldValidator ControlToValidate="txtRegionMobileNo" ValidationGroup="a" ID="RequiredFieldValidator8" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtRegionMobileNo" MaxLength="10" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                 <div class="mb-2" id="divPassword" runat="server">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Region Password
                                        <asp:RequiredFieldValidator ControlToValidate="txtRegionPassword" ValidationGroup="a" ID="RequiredFieldValidator9" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtRegionPassword" MaxLength="6" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Regional Manager Name
                                        <asp:RequiredFieldValidator ControlToValidate="txtRegionalManagerName" ValidationGroup="a" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtRegionalManagerName" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
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
                                        Region Location
                                        <asp:RequiredFieldValidator ControlToValidate="txtRegionLocation" ValidationGroup="a" ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtRegionLocation" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                 <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Region Address
                                        <asp:RequiredFieldValidator ControlToValidate="txtRegionAddress" ValidationGroup="a" ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtRegionAddress" TextMode="MultiLine" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                 <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Region Month Wise Target
                                        <asp:RequiredFieldValidator ControlToValidate="txtRegionMonthTarget" ValidationGroup="a" ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtRegionMonthTarget" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                 <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Region Product Wise Target
                                        <asp:RequiredFieldValidator ControlToValidate="txtRegionProTarget" ValidationGroup="a" ID="RequiredFieldValidator7" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtRegionProTarget" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                </div>
                            </div>
                        </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>