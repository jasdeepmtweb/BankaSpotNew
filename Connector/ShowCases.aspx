<%@ Page Title="" Language="C#" MasterPageFile="~/Connector/Site.Master" AutoEventWireup="true" CodeBehind="ShowCases.aspx.cs" Inherits="BankaSpotNew.Connector.ShowCases" %>
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

    <asp:HiddenField runat="server" ID="hdnShowHistoryModal" Value="0" />


    <br />
    <div class="content-page">
        <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-12 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="header-title mb-3">Case List</h4>
                                <div class="table-responsive">
                                    <asp:GridView ID="GridCase" runat="server" CssClass="table mb-0" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="btedt" runat="server" CommandArgument='<%# Eval("Id") %>' Enabled='<%# Eval("Status").ToString().Equals("-") %>' OnClick="btedt_Click" Text="Edit" class="btn btn-primary btn-sm" />
                                                    <asp:Button ID="btndel" Visible="false" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="btndel_Click" Text="Delete" class="btn btn-danger btn-sm" />
                                                    <asp:Button ID="BtnCheckStatus" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="BtnCheckStatus_Click" Text="Check Status" class="btn btn-success btn-sm" />
                                                    <asp:Button ID="BtnCaseStatusHistory" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="BtnCaseStatusHistory_Click" Text="Case History" class="btn btn-info btn-sm" />
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
                                            <asp:BoundField DataField="Name" HeaderText=" Name" />
                                            <asp:BoundField DataField="MobileNo" HeaderText=" Mobile No." />
                                            <asp:BoundField DataField="City" HeaderText="City" />
                                             <asp:BoundField DataField="ProductName" HeaderText="Product Required" />
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