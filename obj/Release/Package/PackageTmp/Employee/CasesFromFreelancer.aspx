<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Site.Master" AutoEventWireup="true" CodeBehind="CasesFromFreelancer.aspx.cs" Inherits="BankaSpotNew.Employee.CasesFromFreelancer" %>

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
                        <div class="col-md-4">
                            <div class="mb-3">
                                <label for="field-2" class="form-label">Monthly Income</label>
                                <asp:Label ID="lblMonthlyIncome" CssClass="form-control" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="mb-3">
                                <label for="field-2" class="form-label">Profile</label>
                                <asp:Label ID="lblProfile" CssClass="form-control" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="mb-3">
                                <label for="field-2" class="form-label">Freelancer</label>
                                <asp:Label ID="lblConnector" CssClass="form-control" runat="server" Text="Label"></asp:Label>
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

    <div id="myHistoryModal" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true" style="display: none;">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Case History</h4>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body p-4">
                    <div class="table-responsive">
                        <asp:GridView ID="GridCaseHistory" runat="server" CssClass="table table-striped table-nowrap table-centered mb-0" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="Name" HeaderText=" File Name" />
                                <asp:BoundField DataField="ProductName" HeaderText=" Product" />
                                <asp:BoundField DataField="DateAdded" DataFormatString="{0:dd-MM-yyyy}" HeaderText=" Date" />
                                <asp:BoundField DataField="NewStatus" HeaderText=" Status" />
                                <asp:BoundField DataField="Remarks" HeaderText=" Remarks" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <asp:HiddenField runat="server" ID="hdnShowModal" Value="0" />
    <asp:HiddenField runat="server" ID="hdnShowHistoryModal" Value="0" />

    <br />
    <div class="content-page">
        <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-12 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="header-title mb-3">Cases From Freelancers</h4>
                                <div class="table-responsive">
                                    <asp:GridView ID="GridCase" runat="server" CssClass="table mb-0" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="btedt" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="btedt_Click" Text="Details" class="btn btn-primary btn-sm" />
                                                    <asp:Button ID="BtnCaseStatus" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="BtnCaseStatus_Click" Text="Update Status" class="btn btn-success btn-sm" />
                                                    <asp:Button ID="BtnCaseHistory" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="BtnCaseHistory_Click" Text="Case History" class="btn btn-secondary btn-sm" />
                                                    <asp:Button ID="BtnEdit" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="BtnEdit_Click" Text="Edit" class="btn btn-danger btn-sm" />
                                                    <asp:Button ID="BtnDelete" runat="server" CommandArgument='<%# Eval("Id") %>' Enabled='<%# Eval("Status").ToString().Equals("-") %>' OnClick="BtnDelete_Click" OnClientClick="return confirm('Do you want to delete this Case?');" Text="Delete" class="btn btn-danger btn-sm" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sr.No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sr.No" Visible="false">
                                                <ItemTemplate>
                                                   <asp:Label ID="lblAmountReq" runat="server" Text='<%# Eval("AmountReq") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Name" HeaderText=" Name" />
                                            <asp:BoundField DataField="MobileNo" HeaderText=" Mobile No." />
                                            <asp:BoundField DataField="ProductName" HeaderText="Product" />
                                            <asp:BoundField DataField="ConnectorName" HeaderText="Freelancer" />
                                            <asp:BoundField DataField="City" HeaderText="City" />
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
        $(function () {
            if ($('#<%= hdnShowHistoryModal.ClientID %>').val() == "1") {
                $('#myHistoryModal').modal('show');
            }
        });
    </script>
</asp:Content>
