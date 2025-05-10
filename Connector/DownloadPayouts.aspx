<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DownloadPayouts.aspx.cs" Inherits="BankaSpotNew.Connector.DownloadPayouts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payouts</title>
    <link rel='stylesheet' type='text/css' href="../Print/css/style.css" />
    <link rel='stylesheet' type='text/css' href='../print/css/print.css' media="print" />

    <script language="Javascript">

        function printit() {
            if (window.print) {
                var btn1 = document.getElementById('Button1');
                btn1.style.display = "none";        //line1
                window.print();
            } else {
                var WebBrowser = '<OBJECT ID="WebBrowser1" WIDTH=0 HEIGHT=0 CLASSID="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2"></OBJECT>';
                document.body.insertAdjacentHTML('beforeEnd', WebBrowser);
                WebBrowser1.ExecWB(6, 2); //Use a 1 vs. a 2 for a prompting dialog box WebBrowser1.outerHTML = ""; 
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <div id="page-wrap">
            <a class="text-center" href="Dashboard.aspx">Back</a>
            <textarea id="header">PAYOUTS</textarea>



            <div style="text-align: center; width: 100%;">
                <img id="image" height="80px" class="img-responsive" src="../PrintLogo.jpeg" alt="logo" />
            </div>

            <div id="logo">
                <div id="logohelp">
                </div>

            </div>



            <div style="clear: both"></div>


            <br />
            <asp:GridView ID="GridPayouts" runat="server" Width="100%" AutoGenerateColumns="false" CssClass="table table-bordered">
                <Columns>
                    <asp:BoundField DataField="ProductName" HeaderText=" Product" />
                    <asp:BoundField DataField="ConnectorCom" HeaderText=" Commission%" />
                </Columns>
            </asp:GridView>
            <br />
            <table style="float: right; width: 100%">
                <tbody>
                    <tr>
                    </tr>
                </tbody>
            </table>
            <hr />
            <br />
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
	<div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12">
            <strong>Terms &amp; Conditions: </strong>
            <ol>
                <li>Payout will be Calculate on Disbursement Amount of File not on sanctioned amount.
                </li>
                <li>There are two type of payouts one is Normal (Non Affordable) Payout and 2nd is Affordable payout. Clarification of both payouts mentioned in Note. Details of Affordable products and banks are as below:   
                    <br />
                    Affordable Home Loan/LAP (AU SMF, IIFL, INDIA BULLS, ICICI BANK, LIC and other GOVT.   BANKS).
                    <br />
                    Affordable Education Loan (ICICI Bank)
                    <br />
                    Affordable Used Commercial Vehicle Loan (Kotak Bank)
                </li>
                <li>New car loan incentive structure applicable on the cases which will be disbursed on minimum required ROI (Min ROI 9.25%) 
                    In case of case disbursed On below minimum required ROI then your payout will be decreased according to ROI. 
                </li>
                <li>Used car loan incentive structure applicable on the cases which will be disbursed on minimum required ROI
                    (Min ROI 15% for kotak and Min ROI 21% for AU Bank Reducing). In case of case disbursed On below minimum required ROI then Weightage will be considered 50%

                </li>
                <li>TDS will be deducted in given payouts (If Applicable)
                </li>
                <li>Payout will be given 0+1 month i.e. for the case disbursed In Dec. payout will be given till 10th Feb.
                </li>
                <li>In takeover cases payout will be given after completion of takeover and compliance of all sanctioned terms and conditions.
                   <br />
                    <b>No payout will be given in takeover fail cases.</b>

                </li>
                <li>Bankaspot.com reserves the right to change the above payout structure without prior intimation.
                </li>
            </ol>
            <h5>Note:- Affordable payout means some banks giving lower payout in some products which is very less than normal payouts in the bank. 
            </h5>
        </div>

    </div>

            <br />
            <footer class="footer">
                <div class="container">
                    <div class="text-center">
                    </div>
                </div>
            </footer>
            <div class="col-xs-12 col-sm-12 col-md-12 text-left">
                <div class="receipt-right">
                    <center>
                        <a class="text-center" id="Button1" onclick="printit();">Print</a> | <a class="text-center" href="Dashboard.aspx">Back</a></center>
                </div>
            </div>
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
        </div>
    </form>
</body>
</html>
