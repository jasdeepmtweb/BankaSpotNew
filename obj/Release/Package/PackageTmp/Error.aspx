<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="BankaSpotNew.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
        <title>Error Page</title>
        <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
       
        <link rel="shortcut icon" href="assets/images/favicon.ico"/>

		<link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
		<link href="assets/css/app.min.css" rel="stylesheet" type="text/css" />

		<link href="assets/css/icons.min.css" rel="stylesheet" type="text/css" />
</head>
<body class="loading">
    <form id="form1" runat="server">
       <div class="account-pages my-5">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-md-8 col-lg-6 col-xl-4">
                        <div class="card">

                            <div class="card-body p-4">

                                <div class="error-ghost text-center">
                                    <img src="assets/images/error.svg" width="200" alt="error-image"/>
                                </div>

                                <div class="text-center">
                                    <h3 class="mt-4 text-uppercase fw-bold">An Error Occurred </h3>
                                    <p class="text-muted mb-0 mt-3" style="line-height: 20px;">It's looking like you may have taken a wrong turn. Don't worry...
                                        it happens to the best of us.</p>

           <asp:LinkButton ID="LinkReturn" runat="server" CssClass="btn btn-primary mt-3" OnClick="LinkReturn_Click"><i class="mdi mdi-reply me-1"></i> Return</asp:LinkButton>
                                </div>
                
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
        <script src="assets/js/vendor.min.js"></script>

        <script src="assets/js/app.min.js"></script>
    </form>
</body>
</html>
