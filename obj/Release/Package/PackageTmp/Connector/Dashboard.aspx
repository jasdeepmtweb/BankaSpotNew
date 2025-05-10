<%@ Page Title="" Language="C#" MasterPageFile="~/Connector/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="BankaSpotNew.Connector.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-page">
        <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-12">
                        <div class="page-title-box page-title-box-alt">
                            <h4 class="page-title">Connector</h4>
                            <h4 class="page-title">Help Desk No. 7097964000/0164-3500070</h4>
                            <div class="page-title-right">
                                <ol class="breadcrumb m-0">

                                    <li class="breadcrumb-item active">Dashboard</li>
                                </ol>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xl-12 col-md-12">
                        <div class="d-flex justify-content-center">
                            <div id="div-target" class="link-success"><%=referralLink %></div>
                            <button class="btn btn-success btn-sm ms-2" data-clipboard-target="#div-target" data-clipboard-action="copy"><i class="mdi mdi-content-copy"></i></button>
                        </div>
                        <br />
                    </div>
                    <%-- <div class="col-xl-6 col-md-6">
                        <div class="card">
                            <div class="card-body">
                                <div class="d-flex justify-content-between">
                                    <div>
                                        <h5 class="text-muted fw-normal mt-0 text-truncate" title="Campaign Sent">Total Incentive Amount</h5>
                                        <h3 class="my-2 py-1"><span data-plugin="counterup">
                                            <asp:Literal ID="lblTotalIncentiveAmount" runat="server" Text="0"></asp:Literal></span></h3>
                                        <p class="mb-0 text-muted">
                                        </p>
                                    </div>
                                    <div class="avatar-sm">
                                        <span class="avatar-title bg-soft-primary rounded">
                                            <i class="ri-stack-line font-20 text-primary"></i>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>--%>


                    <div class="col-xl-3 col-md-6">
                        <div class="card">
                            <div class="card-body">
                                <div class="d-flex justify-content-between">
                                    <div>
                                        <h5 class="text-muted fw-normal mt-0 text-truncate" title="New Leads">Total Cases</h5>
                                        <h3 class="my-2 py-1"><span data-plugin="counterup">
                                            <asp:Literal ID="lblTotalCases" runat="server" Text="0"></asp:Literal></span></h3>
                                        <p class="mb-0 text-muted">
                                        </p>
                                    </div>
                                    <div class="avatar-sm">
                                        <span class="avatar-title bg-soft-primary rounded">
                                            <i class="ri-slideshow-2-line font-20 text-primary"></i>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-xl-3 col-md-6">
                        <div class="card">
                            <div class="card-body">
                                <div class="d-flex justify-content-between">
                                    <div>
                                        <a href="ShowDisbursedCases.aspx">
                                            <h5 class="text-muted fw-normal mt-0 text-truncate" title="Deals">Disbursed Cases</h5>
                                        </a>
                                        <h3 class="my-2 py-1"><span data-plugin="counterup">
                                            <asp:Literal ID="lblCompletedCases" runat="server" Text="0"></asp:Literal></span></h3>
                                        <p class="mb-0 text-muted">
                                        </p>
                                    </div>
                                    <div class="avatar-sm">
                                        <span class="avatar-title bg-soft-primary rounded">
                                            <i class="ri-hand-heart-line font-20 text-primary"></i>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="col-xl-3 col-md-6">
                        <div class="card">
                            <div class="card-body">
                                <div class="d-flex justify-content-between">
                                    <div>
                                        <a href="ShowCases.aspx">
                                            <h5 class="text-muted fw-normal mt-0 text-truncate" title="Booked Revenue">Pending Cases</h5>
                                        </a>
                                        <h3 class="my-2 py-1"><span data-plugin="counterup">
                                            <asp:Literal ID="lblPendingCases" runat="server" Text="0"></asp:Literal></span></h3>
                                        <p class="mb-0 text-muted">
                                        </p>
                                    </div>
                                    <div class="avatar-sm">
                                        <span class="avatar-title bg-soft-primary rounded">
                                            <i class="ri-money-dollar-box-line font-20 text-primary"></i>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-xl-3 col-md-6">
                        <div class="card">
                            <div class="card-body">
                                <div class="d-flex justify-content-between">
                                    <div>
                                        <a href="ShowRejectedCases.aspx">
                                            <h5 class="text-muted fw-normal mt-0 text-truncate" title="Booked Revenue">Rejected Cases</h5>
                                        </a>
                                        <h3 class="my-2 py-1"><span data-plugin="counterup">
                                            <asp:Literal ID="lblRejectedCases" runat="server" Text="0"></asp:Literal></span></h3>
                                        <p class="mb-0 text-muted">
                                        </p>
                                    </div>
                                    <div class="avatar-sm">
                                        <span class="avatar-title bg-soft-primary rounded">
                                            <i class="ri-money-dollar-box-line font-20 text-primary"></i>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-4 col-md-6">
                        <div class="card">
                            <div class="card-body">
                                <div class="d-flex justify-content-between">
                                    <div>
                                        <h5 class="text-muted fw-normal mt-0 text-truncate" title="Deals">Total Incentive</h5>
                                        <h3 class="my-2 py-1"><span data-plugin="counterup">
                                            <asp:Literal ID="lblTotalIncentive" runat="server" Text="0"></asp:Literal></span></h3>
                                        <p class="mb-0 text-muted">
                                        </p>
                                    </div>
                                    <div class="avatar-sm">
                                        <span class="avatar-title bg-soft-primary rounded">
                                            <i class="ri-hand-heart-line font-20 text-primary"></i>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="col-xl-4 col-md-6">
                        <div class="card">
                            <div class="card-body">
                                <div class="d-flex justify-content-between">
                                    <div>
                                        <h5 class="text-muted fw-normal mt-0 text-truncate">Total Withdrawal</h5>
                                        <h3 class="my-2 py-1"><span data-plugin="counterup">
                                            <asp:Literal ID="lblTotalWithdrawal" runat="server" Text="0"></asp:Literal></span></h3>
                                        <p class="mb-0 text-muted">
                                        </p>
                                    </div>
                                    <div class="avatar-sm">
                                        <span class="avatar-title bg-soft-primary rounded">
                                            <i class="ri-money-dollar-box-line font-20 text-primary"></i>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-xl-4 col-md-6">
                        <div class="card">
                            <div class="card-body">
                                <div class="d-flex justify-content-between">
                                    <div>
                                        <h5 class="text-muted fw-normal mt-0 text-truncate" title="Booked Revenue">Balance</h5>
                                        <h3 class="my-2 py-1"><span data-plugin="counterup">
                                            <asp:Literal ID="lblPayoutBalance" runat="server" Text="0"></asp:Literal></span></h3>
                                        <p class="mb-0 text-muted">
                                        </p>
                                    </div>
                                    <div class="avatar-sm">
                                        <span class="avatar-title bg-soft-primary rounded">
                                            <i class="ri-money-dollar-box-line font-20 text-primary"></i>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xl-6 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                <div class="form-group">
                                    <asp:Button ID="BtnExcel" Style="float: right;" OnClick="BtnExcel_Click" CssClass="btn btn-success btn-sm" runat="server" Text="Export To Excel" />
                                </div>
                                <h4 class="header-title mb-3">Incentive Month Wise</h4>
                                <div class="table-responsive">

                                    <asp:GridView ID="GridIncentiveMonthConnector" runat="server" CssClass="table table-striped table-nowrap table-centered mb-0" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr.No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Month" HeaderText="Month" />
                                            <asp:BoundField DataField="Payout" HeaderText="Incentives (After 5% TDS)" />
                                        </Columns>
                                    </asp:GridView>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-6 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                <div class="form-group">
                                    <asp:Button ID="BtnExcel2" Style="float: right;" OnClick="BtnExcel2_Click" CssClass="btn btn-success btn-sm" runat="server" Text="Export To Excel" />
                                </div>
                                <h4 class="header-title mb-3">Incentive Case Wise</h4>
                                <div class="table-responsive">

                                    <asp:GridView ID="GridIncentiveCaseConnector" runat="server" CssClass="table table-striped table-nowrap table-centered mb-0" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr.No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Name" HeaderText="Name" />
                                            <asp:BoundField DataField="ProductName" HeaderText="Product" />

                                            <asp:BoundField DataField="Incentive" HeaderText="Incentive" />
                                        </Columns>
                                    </asp:GridView>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="../clipboard.min.js"></script>
    <script>
        var clipboard = new Clipboard('.btn');

        clipboard.on('success', function (e) {
            console.log(e);
        });

        clipboard.on('error', function (e) {
            console.log(e);
        });
    </script>
</asp:Content>
