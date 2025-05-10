<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Site.Master" AutoEventWireup="true" CodeBehind="ShowCases.aspx.cs" Inherits="BankaSpotNew.Branch.ShowCases" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                                <asp:BoundField DataField="DateAdded" HeaderText=" DateTime" DataFormatString="{0:dd-MM-yyyy}" />
                                <asp:BoundField DataField="NewStatus" HeaderText=" Status" />
                                <asp:BoundField DataField="Remarks" HeaderText=" Remarks" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField runat="server" ID="hdnShowHistoryModal" Value="0" />
    <br />
    <div class="content-page">
        <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtSearchByEmpName" AutoPostBack="true" OnTextChanged="txtSearchByEmpName_TextChanged" placeholder="Search By Emp. Name" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtSearchByLGName" AutoPostBack="true" OnTextChanged="txtSearchByLGName_TextChanged" placeholder="Search By LG Name" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtSearchByCaseStatus" AutoPostBack="true" OnTextChanged="txtSearchByCaseStatus_TextChanged" placeholder="Search By Case Status" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtSearchByBankName" AutoPostBack="true" OnTextChanged="txtSearchByBankName_TextChanged" placeholder="Search By Bank Name" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtSearchByProduct" AutoPostBack="true" OnTextChanged="txtSearchByProduct_TextChanged" placeholder="Search By Product" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="header-title mb-3">Active Cases List</h4>
                                <div class="">
                                    <asp:GridView ID="GridAllCases" runat="server" CssClass="table table-bordered mb-0" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="btedt" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="btedt_Click" Text="Edit" class="btn btn-primary btn-sm" />

                                                    <asp:Button ID="btndel" runat="server" Visible="false" CommandArgument='<%# Eval("Id") %>' OnClick="btndel_Click" Text="Delete" class="btn btn-danger btn-sm" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="BtnCheckStatus" CommandArgument='<%# Eval("Id") %>' OnClick="BtnCheckStatus_Click" CssClass="btn btn-success btn-sm" runat="server" Text="Check Status" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                          <%--  <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="BtnTransfer" CommandArgument='<%# Eval("Id") %>' OnClick="BtnTransfer_Click" CssClass="btn btn-dark btn-sm" runat="server" Text="Transfer" />
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Sr.No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="CreatedOn" HeaderText=" File Entry Date" DataFormatString="{0:dd-MM-yyyy}" />
                                            <asp:BoundField DataField="Name" HeaderText="File Name" />
                                            <asp:BoundField DataField="MobileNo" HeaderText=" Mobile No." />
                                            <asp:BoundField DataField="City" HeaderText="City" />


                                            <asp:BoundField DataField="ProductName" HeaderText=" Product" />
                                            <asp:BoundField DataField="AmountReq" HeaderText="Amount Req." />
                                            <asp:BoundField DataField="CustomerProfile" HeaderText=" Customer Profile" />
                                            <asp:BoundField DataField="Status" HeaderText=" Status" />
                                            <asp:BoundField DataField="Remarks" HeaderText=" Status Remarks" />
                                            <asp:BoundField DataField="LeadHandling" HeaderText="Lead Handling" />
                                            <%--<asp:BoundField DataField="EmpName" HeaderText="Emp. Name" />--%>
                                            <asp:BoundField DataField="MarketingEmpName" HeaderText="MKT Emp." />
                                            <%--<asp:BoundField DataField="ConnnectorName" HeaderText="Connnector" />--%>
                                            <asp:BoundField DataField="ext2" HeaderText=" Sanctioned Amount" />
                                            <asp:BoundField DataField="Address" HeaderText=" Address" />
                                            <asp:BoundField DataField="MonthlyIncome" HeaderText=" Monthly Income" />
                                            <asp:BoundField DataField="BankName" HeaderText="Bank Name" />
                                            <asp:BoundField DataField="BankEmpName" HeaderText=" Banker Name" />
                                            <asp:BoundField DataField="BankEmpContactNo" HeaderText="Banker Contact No." />

                                            <asp:BoundField DataField="LeadGenerated" HeaderText=" LG Name" />
                                            <asp:BoundField DataField="LeadGenContactNo" HeaderText="LG Contact No." />
                                            <asp:BoundField DataField="FileLogInDate" HeaderText="File LogIn Date" DataFormatString="{0:dd-M-yyyy}" />
                                            <asp:BoundField DataField="ExpectedDisbursedDate" HeaderText=" Expected Disbursement Date" DataFormatString="{0:dd-M-yyyy}" />
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
            if ($('#<%= hdnShowHistoryModal.ClientID %>').val() == "1") {
                $('#myHistoryModal').modal('show');
            }
        });
    </script>
</asp:Content>
