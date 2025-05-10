<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="AddSliders.aspx.cs" Inherits="BankaSpotNew.Admin.AddSliders" %>

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
                    <div class="col-lg-4 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="header-title mb-3">Add Sliders</h4>


                                <%-- <div class="mb-2">
                                    <label for="exampleInputEmail1" class="form-label">
                                        Title
                                        <asp:RequiredFieldValidator ControlToValidate="txtTitle" ValidationGroup="a" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtTitle" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>--%>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Image (Image Should be less Than 1mb)
                                        <asp:RequiredFieldValidator ControlToValidate="FileImage" ValidationGroup="a" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:FileUpload ID="FileImage" accept=".jpg,.jpeg,.png" CssClass="form-control" runat="server"></asp:FileUpload>
                                </div>

                                <asp:Button ID="BtnSubmit" runat="server" ValidationGroup="a" OnClick="BtnSubmit_Click" CssClass="btn btn-primary" Text="Submit" />
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-8 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="header-title mb-3">List</h4>
                                <div class="table-responsive">
                                    <asp:GridView ID="GridProducts" runat="server" CssClass="table mb-0" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="BtnDelete" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="BtnDelete_Click" Text="Delete" class="btn btn-danger btn-sm" />
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
                                            <asp:TemplateField HeaderText="Image">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgButton" Width="50px" Height="50px" runat="server" ImageUrl='<%# Eval("SliderImage") %>' OnClientClick="return openPopup(this);" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
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
