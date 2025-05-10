<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Site.Master" AutoEventWireup="true" CodeBehind="ShowConnector.aspx.cs" Inherits="BankaSpotNew.Employee.ShowConnector" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <img src="" class="img-fluid" />
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="content-page">
        <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-12 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="header-title mb-3">Show Connector</h4>
                                <div class="table-responsive">
                                    <asp:GridView ID="GridShowConnector" runat="server" CssClass="table mb-0" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="btedt" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="btedt_Click" Text="Show" class="btn btn-primary btn-sm" />
                                                    <asp:Button ID="btndel" Visible="false" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="btndel_Click" Text="Delete" class="btn btn-danger btn-sm" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sr.No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Image">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgButton" Width="50px" Height="50px" runat="server" ImageUrl='<%# Eval("ConnectorPic") %>' OnClientClick="return openPopup(this);" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ConnectorId" HeaderText="Connector Id" />
                                            <asp:BoundField DataField="Name" HeaderText=" Name" />
                                            <asp:BoundField DataField="MobileNo" HeaderText=" Mobile No." />
                                            <asp:BoundField DataField="Password" HeaderText=" Password" />
                                            <asp:BoundField DataField="EmailId" HeaderText="Email ID" />
                                            <%--<asp:BoundField DataField="PanNo" HeaderText="Pan No."/>
                                            <asp:BoundField DataField="AdharNo" HeaderText="Adhaar No."/>
                                           

                                             <asp:BoundField DataField="BankName" HeaderText="Bank Name"/>
                                            <asp:BoundField DataField="AccountNo" HeaderText=" Account No." />
                                            <asp:BoundField DataField="IFSCCode" HeaderText=" IFSC Code" />--%>
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
    function openPopup(imgButton) {
        var imgUrl = imgButton.src;
        var imgElement = $('#myModal img');
        imgElement.attr('src', imgUrl);
        $('#myModal').modal('show');
        return false;
    }
    </script>
</asp:Content>
