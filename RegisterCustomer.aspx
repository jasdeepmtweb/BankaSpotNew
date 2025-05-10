<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCustomer.aspx.cs" Inherits="BankaSpotNew.RegisterCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Customer Register</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta content="Bankaspot" name="description" />
    <meta content="Bankaspot" name="author" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />

    <link rel="shortcut icon" href="assets/images/favicon.ico" />

    <link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/app.min.css" rel="stylesheet" type="text/css" />

    <link href="assets/css/icons.min.css" rel="stylesheet" type="text/css" />

    <link href="https://cdn.jsdelivr.net/npm/sweetalert2@11.0.18/dist/sweetalert2.min.css" rel="stylesheet" />

    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11.0.18/dist/sweetalert2.all.min.js"></script>
</head>
<body class="loading">
    <form id="form1" runat="server">
        <div class="account-pages mt-5 mb-5">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-md-8 col-lg-6 col-xl-4">
                        <div class="card">
                            <div class="card-body p-4">
                                <div class="text-center w-75 m-auto">
                                    <div class="auth-logo">
                                        <a href="Index.aspx" class="logo logo-dark text-center">
                                            <span class="logo-lg">
                                                <img src="assets/images/logo-dark.png" alt="" class="img-fluid" />
                                            </span>
                                        </a>

                                        <a href="Index.aspx" class="logo logo-light text-center">
                                            <span class="logo-lg">
                                                <img src="assets/images/logo-light.png" alt="" class="img-fluid" />
                                            </span>
                                        </a>
                                    </div>
                                    <p class="text-muted mb-4 mt-3">Don't have an account? Create your own account, it takes less than a minute</p>
                                </div>

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
         <asp:RequiredFieldValidator ControlToValidate="txtPassword" ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic" ValidationGroup="a"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtPassword" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                               <%-- <div class="mb-2">
                                    <label for="emailaddress" class="form-label">
                                        Email Id
                                        <asp:RequiredFieldValidator ControlToValidate="txtEmailId" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic" ValidationGroup="a"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtEmailId" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>--%>
                                <div class="mb-2">
                                    <label for="emailaddress" class="form-label">
                                        City
                                        <asp:RequiredFieldValidator ControlToValidate="txtCity" ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic" ValidationGroup="a"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtCity" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                               <%-- <div class="mb-2">
                                    <label for="emailaddress" class="form-label">
                                        Address
                                        <asp:RequiredFieldValidator ControlToValidate="txtAddress" ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic" ValidationGroup="a"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtAddress" ValidationGroup="a" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>--%>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Branch
                                        <asp:RequiredFieldValidator ControlToValidate="ddlLocation" InitialValue="0" ValidationGroup="a" ID="RequiredFieldValidator7" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:DropDownList ID="ddlLocation" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="d-grid text-center">
                                    <asp:Button ID="BtnSignUp" ValidationGroup="a" OnClick="BtnSignUp_Click" runat="server" CssClass="btn btn-primary" Text="Sign Up" />
                                </div>

                            </div>
                        </div>
                        <div class="row mt-3">
                            <div class="col-12 text-center">
                                <p class="text-muted">Already have account? <a href="CustomerLogin.aspx" class="text-primary fw--medium ms-1">Sign In</a></p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <footer class="footer footer-alt">
            <script>document.write(new Date().getFullYear())</script>
            &copy; Copyright by <a href="#">MT Web Technologies</a>
        </footer>
    </form>
    <script src="assets/js/vendor.min.js"></script>
    <script src="assets/js/app.min.js"></script>
</body>
</html>
