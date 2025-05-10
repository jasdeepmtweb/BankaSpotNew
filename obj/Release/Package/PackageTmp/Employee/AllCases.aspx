<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Site.Master" AutoEventWireup="true" CodeBehind="AllCases.aspx.cs" Inherits="BankaSpotNew.Employee.AllCases" %>

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
                                <label for="field-2" class="form-label">Connector</label>
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
                                <asp:BoundField DataField="DateAdded" HeaderText=" DateTime" />
                                <asp:BoundField DataField="NewStatus" HeaderText=" Status" />
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
                   <%-- <div class="col-lg-3 mx-auto">
                        <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                     <div class="col-lg-3 mx-auto">
                        <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                     <div class="col-lg-3 mx-auto">
                        <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                     <div class="col-lg-3 mx-auto">
                        <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                     <div class="col-lg-4 mx-auto">
                        <asp:TextBox ID="TextBox5" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                     <div class="col-lg-4 mx-auto">
                        <asp:TextBox ID="TextBox6" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                     <div class="col-lg-4 mx-auto">
                        <asp:TextBox ID="TextBox7" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    <br />--%>
                    <div class="col-lg-12 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                 <div class="form-group">
                                    <asp:Button ID="BtnExcel" style="float:right;" OnClick="BtnExcel_Click" CssClass="btn btn-success btn-sm" runat="server" Text="Export To Excel" />
                                </div>
                                <h4 class="header-title mb-3">All Cases</h4>
                                <div class="table-responsive">
                                    <asp:GridView ID="GridAllCases" runat="server" CssClass="table table-hover" AutoGenerateColumns="false">
                                        <Columns>
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
                                            <asp:BoundField DataField="CreatedOn" HeaderText=" File Entry Date" DataFormatString="{0:dd-MM-yyyy}"/>
                                            <asp:BoundField DataField="Name" HeaderText="File Name" />
                                            <asp:BoundField DataField="MobileNo" HeaderText=" Mobile No." />
                                            <asp:BoundField DataField="City" HeaderText="City" />

                                             
                                            <asp:BoundField DataField="ProductName" HeaderText=" Product" />
                                            <asp:BoundField DataField="AmountReq" HeaderText="Amount Req." />
                                             <asp:BoundField DataField="CustomerProfile" HeaderText=" Customer Profile" />
                                             <asp:BoundField DataField="Status" HeaderText=" Status" />
                                            <asp:BoundField DataField="Remarks" HeaderText=" Status Remarks" />
                                             <asp:BoundField DataField="ext2" HeaderText=" Sanctioned Amount" />
                                            <asp:BoundField DataField="Address" HeaderText=" Address" />
                                            <asp:BoundField DataField="MonthlyIncome" HeaderText=" Monthly Income" />
                                              <asp:BoundField DataField="BankName" HeaderText="Bank Name" />
                                             <asp:BoundField DataField="BankEmpName" HeaderText=" Banker Name" />
                                            <asp:BoundField DataField="BankEmpContactNo" HeaderText="Banker Contact No." />
                                             <asp:BoundField DataField="LeadHandling" HeaderText="Lead Handling" />
                                             <asp:BoundField DataField="LeadGenerated" HeaderText=" LG Name" />
                                            <asp:BoundField DataField="LeadGenContactNo" HeaderText="LG Contact No." />
                                            <asp:BoundField DataField="FileLogInDate" HeaderText="File LogIn Date" DataFormatString="{0:dd-MM-yyyy}"/>
                                             <asp:BoundField DataField="ExpectedDisbursedDate" HeaderText="Expected Disbursement Date" DataFormatString="{0:dd-MM-yyyy}"/>
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
