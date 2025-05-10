<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Site.Master" AutoEventWireup="true" CodeBehind="AddMarketingEmp.aspx.cs" Inherits="BankaSpotNew.Branch.AddMarketingEmp" %>

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
                                <h4 class="header-title mb-3">Add Marketing Employee</h4>


                                <div class="mb-2">
                                    <label for="exampleInputEmail1" class="form-label">
                                        Employee ID No.
                                     <asp:RequiredFieldValidator ControlToValidate="txtEmpIdNo" ValidationGroup="a" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtEmpIdNo" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Name
                                     <asp:RequiredFieldValidator ControlToValidate="txtName" ValidationGroup="a" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtName" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2" id="divMob" runat="server">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Mobile No.
                                     <asp:RequiredFieldValidator ControlToValidate="txtMobileNo" ValidationGroup="a" ID="RequiredFieldValidator8" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtMobileNo" MaxLength="10" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2" id="divPassword" runat="server">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Password
                                     <asp:RequiredFieldValidator ControlToValidate="txtPassword" ValidationGroup="a" ID="RequiredFieldValidator15" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtPassword" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Email Id
                                     <asp:RequiredFieldValidator ControlToValidate="txtEmailId" ValidationGroup="a" ID="RequiredFieldValidator9" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtEmailId" TextMode="Email" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Location
                                     <asp:RequiredFieldValidator ControlToValidate="txtLocation" ValidationGroup="a" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtLocation" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Date Of Joining
                                     <asp:RequiredFieldValidator ControlToValidate="txtDateOfJoining" ValidationGroup="a" ID="RequiredFieldValidator12" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtDateOfJoining" TextMode="Date" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Date Of Anniversary
        <asp:RequiredFieldValidator ControlToValidate="txtDateOfAnniversary" ValidationGroup="a" ID="RequiredFieldValidator10" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtDateOfAnniversary" TextMode="Date" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Date Of Birth
        <asp:RequiredFieldValidator ControlToValidate="txtDateOfBirth" ValidationGroup="a" ID="RequiredFieldValidator16" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtDateOfBirth" TextMode="Date" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="header-title mb-3">&nbsp</h4>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Address
                                     <asp:RequiredFieldValidator ControlToValidate="txtAddress" ValidationGroup="a" ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtAddress" ValidationGroup="a" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Bank Name
                                     <asp:RequiredFieldValidator ControlToValidate="txtBankName" ValidationGroup="a" ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtBankName" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Bank Account No.
                                     <asp:RequiredFieldValidator ControlToValidate="txtAccountNo" ValidationGroup="a" ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtAccountNo" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        IFSC Code
                                     <asp:RequiredFieldValidator ControlToValidate="txtIFSCCode" ValidationGroup="a" ID="RequiredFieldValidator7" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtIFSCCode" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Bank Branch Address
                                     <asp:RequiredFieldValidator ControlToValidate="txtBankBranchAddress" ValidationGroup="a" ID="RequiredFieldValidator11" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtBankBranchAddress" TextMode="MultiLine" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>

                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Pan Card
                                     <asp:RequiredFieldValidator ControlToValidate="txtProIncentivePercentage" ValidationGroup="a" ID="RequiredFieldValidator13" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <%--<asp:RegularExpressionValidator ID="myRegexValidator2" runat="server" ControlToValidate="txtProIncentivePercentage" Display="Dynamic" ForeColor="Red" ValidationGroup="a" ErrorMessage="Please enter a valid decimal or integer number." ValidationExpression="^(\d+)?(\.\d+)?$"></asp:RegularExpressionValidator>--%>
                                    </label>
                                    <asp:TextBox ID="txtProIncentivePercentage" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Adhaar Card
                                     <asp:RequiredFieldValidator ControlToValidate="txtMonthTarget" ValidationGroup="a" ID="RequiredFieldValidator14" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="myRegexValidator" runat="server" ControlToValidate="txtMonthTarget" Display="Dynamic" ForeColor="Red" ValidationGroup="a" ErrorMessage="Please enter a valid decimal or integer number." ValidationExpression="^(\d+)?(\.\d+)?$"></asp:RegularExpressionValidator>
                                    </label>
                                    <asp:TextBox ID="txtMonthTarget" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
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
