<%@ Page Title="" Language="C#" MasterPageFile="~/FreeLancer/Site.Master" AutoEventWireup="true" CodeBehind="PayoutListMonthCaseWise.aspx.cs" Inherits="BankaSpotNew.FreeLancer.PayoutListMonthCaseWise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="myModal" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true" style="display: none;">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Case Details</h4>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body p-4">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="mb-3">
                                <label for="field-1" class="form-label">Name</label>
                                <asp:Label ID="lblName" CssClass="form-control" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="mb-3">
                                <label for="field-2" class="form-label">Mobile No.</label>
                                <asp:Label ID="lblMobile" CssClass="form-control" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="mb-3">
                                <label for="field-1" class="form-label">City</label>
                                <asp:Label ID="lblCity" CssClass="form-control" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="mb-3">
                                <label for="field-2" class="form-label">Product Required</label>
                                <asp:Label ID="lblProReq" CssClass="form-control" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="mb-3">
                                <label for="field-1" class="form-label">Amount Required</label>
                                <asp:Label ID="lblAmountRequired" CssClass="form-control" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="mb-3">
                                <label for="field-2" class="form-label">Monthly Income</label>
                                <asp:Label ID="lblMonthlyIncome" CssClass="form-control" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="mb-3">
                                <label for="field-2" class="form-label">Profile</label>
                                <asp:Label ID="lblProfile" CssClass="form-control" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="mb-3">
                                <label for="field-3" class="form-label">Address</label>
                                <asp:Label ID="lblAddress" CssClass="form-control" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                    </div>


                </div>
            </div>
        </div>
    </div>


    <asp:HiddenField runat="server" ID="hdnShowModal" Value="0" />


    <br />
    <div class="content-page">
        <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-12 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="header-title mb-3">Payouts Case Wise Month Wise (TDS 5% Will BE Deducted From Your Final Payout)</h4>
                                <div class="table-responsive">
                                    <asp:GridView ID="GridCase" runat="server" CssClass="table table-hover mb-0" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="btedt" runat="server" CommandArgument='<%# Eval("CaseId") %>' OnClick="btedt_Click" Text="Case Details" class="btn btn-primary btn-sm" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sr.No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sr.No" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblid" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="CustomerName" HeaderText=" Name" />
                                            <asp:BoundField DataField="ProductName" HeaderText=" Product" />
                                            <asp:BoundField DataField="AmountDisbursed" HeaderText=" Amount Disbursed" />
                                            <asp:BoundField DataField="OriginalPayout" HeaderText=" Gross Payout" />
                                            <asp:BoundField DataField="TDS" HeaderText=" TDS (5%)" />
                                            <asp:BoundField DataField="ext3" HeaderText=" Extra Payout" />
                                            <asp:BoundField DataField="ext4" HeaderText=" Deduction" />
                                            <asp:BoundField DataField="AnyReason" HeaderText=" Reason" />
                                            <asp:BoundField DataField="PayAmount" HeaderText=" Net Payout" />
                                            <asp:BoundField DataField="DisbursedDate" HeaderText=" Disbursed Month" DataFormatString="{0:dd/MMM/yyyy}" />
                                            <asp:BoundField DataField="ext1" HeaderText=" Payout Status" />
                                            <asp:BoundField DataField="ext2" HeaderText=" Payout Date" DataFormatString="{0:dd/MM/yyyy}" />
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
    <script type="text/javascript">
        $(function () {
            if ($('#<%= hdnShowModal.ClientID %>').val() == "1") {
                $('#myModal').modal('show');
            }
        });
    </script>
</asp:Content>
