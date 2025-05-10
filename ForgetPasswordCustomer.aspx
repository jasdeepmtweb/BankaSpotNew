<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPasswordCustomer.aspx.cs" Inherits="BankaSpotNew.ForgetPasswordCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Forgot Password</title>
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
<body>
    <form id="form1" runat="server">
        <div class="account-pages mt-5 mb-5">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-md-8 col-lg-6 col-xl-4">
                        <div class="card">

                            <div class="card-body p-4">

                                <div class="text-center w-75 m-auto">
                                    <div class="auth-logo">
                                        <a href="index.html" class="logo logo-dark text-center">
                                            <span class="logo-lg">
                                                <img src="assets/images/logo-dark.png" alt="" class="img-fluid" />
                                            </span>
                                        </a>

                                        <a href="index.html" class="logo logo-light text-center">
                                            <span class="logo-lg">
                                                <img src="assets/images/logo-light.png" alt="" class="img-fluid" />
                                            </span>
                                        </a>
                                    </div>
                                    <p class="text-muted mb-4 mt-3">Enter your Registered Mobile Number and we'll send your password on your mobile number.</p>
                                </div>

                                <div>

                                    <div class="mb-3">
                                        <label for="emailaddress" class="form-label">Registered Mobile No.
                                            <asp:RequiredFieldValidator ControlToValidate="txtMobileNo" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic" ValidationGroup="a"></asp:RequiredFieldValidator>
                                        </label>
                                        <asp:TextBox ID="txtMobileNo" CssClass="form-control" ValidationGroup="a" placeholder="Enter Registered Mobile No." runat="server"></asp:TextBox>
                                    </div>

                                    <div class="d-grid text-center">
                                        <asp:Button ID="BtnForgetPassword" runat="server" Text="Get Password" CssClass="btn btn-primary" ValidationGroup="a" OnClick="BtnForgetPassword_Click" />
                                    </div>

                                </div>

                            </div>
                        </div>
                        <div class="row mt-3">
                            <div class="col-12 text-center">
                                <p class="text-muted">Back to <a href="CustomerLogin.aspx" class="text-primary fw-medium ms-1">Log in</a></p>
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
</body>
</html>
