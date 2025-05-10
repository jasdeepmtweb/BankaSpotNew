<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MarketingEmpLogin.aspx.cs" Inherits="BankaSpotNew.MarketingEmpLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Marketing Employee Login</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta content="Bankaspot" name="description" />
    <meta content="Bankaspot" name="author" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link rel="shortcut icon" href="assets/images/favicon.ico" />
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/app.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/icons.min.css" rel="stylesheet" type="text/css" />
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
                                        <a href="#" class="logo logo-dark text-center">
                                            <span class="logo-lg">
                                                <img src="assets/images/logo-dark.png" class="img-fluid" />
                                            </span>
                                        </a>

                                        <a href="#" class="logo logo-light text-center">
                                            <span class="logo-lg">
                                                <img src="assets/images/logo-light.png" class="img-fluid" />
                                            </span>
                                        </a>
                                    </div>
                                    <p class="text-muted mb-4 mt-3">Enter your Mobile Number and password for login.</p>
                                </div>
                                <div class="mb-2">
                                    <label for="emailaddress" class="form-label">
                                        Mobile Number
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtMobileNo" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic" ValidationGroup="a"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtMobileNo" ValidationGroup="a" CssClass="form-control" runat="server" placeholder="Mobile Number"></asp:TextBox>
                                </div>

                                <div class="mb-2">
                                    <label for="password" class="form-label">
                                        Password
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPassword" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic" ValidationGroup="a"></asp:RequiredFieldValidator>
                                    </label>
                                    <div class="input-group input-group-merge">
                                        <asp:TextBox ID="txtPassword" TextMode="Password" ValidationGroup="a" CssClass="form-control" runat="server" placeholder="Password"></asp:TextBox>

                                        <div class="input-group-text" data-password="false">
                                            <span class="password-eye"></span>
                                        </div>
                                    </div>
                                </div>



                                <div class="d-grid mb-0 text-center">
                                    <asp:Button ID="BtnLogin" CssClass="btn btn-primary" runat="server" Text="Log In" OnClick="BtnLogin_Click" ValidationGroup="a" />
                                </div>

                            </div>
                        </div>
                        <div class="row mt-3">
                            <div class="col-12 text-center">
                                <%--<p><a href="auth-recoverpw.html" class="text-muted ms-1">Forgot your password?</a></p>--%>
                                <%--<p class="text-muted">Back To Home <a href="Index.aspx" class="text-primary fw-medium ms-1">Click Here</a></p>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <footer class="footer footer-alt">
            <script>document.write(new Date().getFullYear())</script>
            &copy; Copyright by <a href="#" class="text-dark">MT Web Technologies</a>
        </footer>
    </form>
    <script src="assets/js/vendor.min.js"></script>
    <script src="assets/js/app.min.js"></script>
</body>
</html>
