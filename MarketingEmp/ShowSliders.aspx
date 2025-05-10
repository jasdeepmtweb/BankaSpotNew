<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingEmp/Site.Master" AutoEventWireup="true" CodeBehind="ShowSliders.aspx.cs" Inherits="BankaSpotNew.MarketingEmp.ShowSliders" %>

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
    <div class="content-page">
        <div class="content">

            <div class="container-fluid">


                <div class="row">
                    <div class="col-12">
                        <div class="page-title-box page-title-box-alt">
                            <h4 class="page-title">Advertisements</h4>
                            <div class="page-title-right">
                            </div>
                        </div>
                    </div>
                </div>


                <div class="row">
                    <asp:Repeater ID="rptSliders" runat="server">
                        <ItemTemplate>
                            <div class="col-lg-6 col-xl-3">
                                <div class="card">

                                    <asp:ImageButton ID="imgButton" CssClass="card-img-top img-fluid" runat="server" ImageUrl='<%# Eval("SliderImage") %>' OnClientClick="return openPopup(this);" />
                                    <div class="card-body">
                                        <asp:Button ID="BtnDownload" CommandArgument='<%# Eval("SliderImage") %>' OnClick="BtnDownload_Click" CssClass="btn btn-primary waves-effect waves-light" runat="server" Text="Download" />
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

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
