<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BankaSpotNew.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Home</title>
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
                <br />
                <br />
                <br />
                <div class="row">
                   <%-- <div class="col-md-3">
                        <div class="card">
                            <div class="card-body p-4">
                                <div class="d-grid mb-0 text-center">
                                    <asp:Button ID="BtnRegionLogin" CssClass="btn btn-primary" runat="server" Text="Region LogIn" OnClick="BtnRegionLogin_Click" />
                                </div>
                            </div>
                        </div>
                    </div>--%>
                    <div class="col-md-3">
                        <div class="card">
                            <div class="card-body p-4">
                                <div class="d-grid mb-0 text-center">
                                    <asp:Button ID="BtnBranchLogin" CssClass="btn btn-primary" runat="server" Text="Branch LogIn" OnClick="BtnBranchLogin_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="card">
                            <div class="card-body p-4">
                                <div class="d-grid mb-0 text-center">
                                    <asp:Button ID="BtnEmployeeLogin" CssClass="btn btn-primary" runat="server" Text="Employee LogIn" OnClick="BtnEmployeeLogin_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="card">
                            <div class="card-body p-4">
                                <div class="d-grid mb-0 text-center">
                                    <asp:Button ID="BtnConnectorLogin" CssClass="btn btn-primary" runat="server" Text="Connector LogIn" OnClick="BtnConnectorLogin_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="card">
                            <div class="card-body p-4">
                                <div class="d-grid mb-0 text-center">
                                    <asp:Button ID="BtnFreeLancerLogin" CssClass="btn btn-primary" runat="server" Text="FreeLancer LogIn" OnClick="BtnFreeLancerLogin_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="card">
                            <div class="card-body p-4">
                                <div class="d-grid mb-0 text-center">
                                    <asp:Button ID="BtnMarketingEmpLogin" CssClass="btn btn-primary" runat="server" Text="Marketing Employee LogIn" OnClick="BtnMarketingEmpLogin_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="card">
                            <div class="card-body p-4">
                                <div class="d-grid mb-0 text-center">
                                    <asp:Button ID="BtnAccountantLogin" CssClass="btn btn-primary" runat="server" Text="Accountant LogIn" OnClick="BtnAccountantLogin_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="card">
                            <div class="card-body p-4">
                                <div class="d-grid mb-0 text-center">
                                    <asp:Button ID="BtnCustomerLogin" CssClass="btn btn-primary" runat="server" Text="Customer LogIn" OnClick="BtnCustomerLogin_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="card">
                            <div class="card-body p-4">
                                <div class="d-grid mb-0 text-center">
                                    <asp:Button ID="BtnSubconnectorLogin" CssClass="btn btn-primary" runat="server" Text="Subconnector LogIn" OnClick="BtnSubconnectorLogin_Click" />
                                </div>
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
