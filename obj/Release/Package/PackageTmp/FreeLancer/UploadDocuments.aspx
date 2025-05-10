<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadDocuments.aspx.cs" Inherits="BankaSpotNew.FreeLancer.UploadDocuments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Upload Documents</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta content="A fully featured admin theme" name="description" />
    <meta content="Bankaspot" name="author" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />

    <link rel="shortcut icon" href="../assets/images/favicon.ico" />

    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/app.min.css" rel="stylesheet" type="text/css" />

    <link href="../assets/css/icons.min.css" rel="stylesheet" type="text/css" />
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
                                        <a href="index.html" class="logo logo-dark text-center">
                                            <span class="logo-lg">
                                                <img src="../assets/images/logo-dark.png" alt="" height="22" />
                                            </span>
                                        </a>

                                        <a href="index.html" class="logo logo-light text-center">
                                            <span class="logo-lg">
                                                <img src="../assets/images/logo-light.png" alt="" height="22" />
                                            </span>
                                        </a>
                                    </div>
                                    <p class="text-muted mb-4 mt-3">Submit Your Documents For Timely Payout!</p>
                                </div>



                                <div class="mb-2">
                                    <label for="fullname" class="form-label">Pan Card (Max. Size 1MB)
                                        <asp:RequiredFieldValidator ControlToValidate="filePan" ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ValidationGroup="a" ForeColor="Red" ErrorMessage="*Required"></asp:RequiredFieldValidator>
                                    </label>

                                    <asp:FileUpload ID="filePan" accept=".jpg,.jpeg,.png,.pdf" CssClass="form-control" runat="server" />
                                </div>
                                <div class="mb-2">
                                    <label for="emailaddress" class="form-label">Adhar Card (Max. Size 1MB)
                                        <asp:RequiredFieldValidator ControlToValidate="fileAdhar" ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ValidationGroup="a" ForeColor="Red" ErrorMessage="*Required"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:FileUpload ID="fileAdhar" accept=".jpg,.jpeg,.png,.pdf" CssClass="form-control" runat="server" />
                                </div>
                                <div class="mb-2">
                                    <label for="emailaddress" class="form-label">Cancel Check (Max. Size 1MB)
                                        <asp:RequiredFieldValidator ControlToValidate="fileCancelCheck" ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ValidationGroup="a" ForeColor="Red" ErrorMessage="*Required"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:FileUpload ID="fileCancelCheck" accept=".jpg,.jpeg,.png,.pdf" CssClass="form-control" runat="server" />
                                </div>
                                
                                <div class="d-grid text-center">
                                    <asp:Button ID="BtnSubmit" runat="server" OnClick="BtnSubmit_Click" ValidationGroup="a" CssClass="btn btn-primary" Text="Submit" />
                                </div>
                            </div>
                        </div>

                        <div class="row mt-3">
                            <div class="col-12 text-center">
                                <p class="text-muted">Logout<a href="Logout.aspx" class="text-primary fw--medium ms-1">Click Here</a></p>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <footer class="footer footer-alt">
            <script>document.write(new Date().getFullYear())</script>
            &copy; <a href="#" class="text-dark">MT Web Technologies</a>
        </footer>
    </form>
    <script src="../assets/js/vendor.min.js"></script>
    <script src="../assets/js/app.min.js"></script>
</body>
</html>
