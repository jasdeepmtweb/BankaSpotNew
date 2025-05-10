<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Site.Master" AutoEventWireup="true" CodeBehind="UpdateFreelancerDocs.aspx.cs" Inherits="BankaSpotNew.Branch.UpdateFreelancerDocs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog">
    <div class="modal-dialog modal-lg" role="document">
        <div class="modal-content">
            <div class="modal-body">
                <iframe src="" style="width: 100%; height: 500px;"></iframe>
            </div>
        </div>
    </div>
</div>

<br />
<div class="content-page">
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-6 mx-auto">
                    <div class="card">
                        <div class="card-body">
                            <h4 class="header-title mb-3">Update Freelancer Docs</h4>
                            <div class="mb-2">
                                <label for="exampleInputPassword1" class="form-label">
                                    PAN Card (Max. Size 1MB)
                                </label>
                                <asp:FileUpload ID="filePan" accept=".jpg,.jpeg,.png,.pdf" CssClass="form-control" runat="server" />
                                <br />
                                <asp:Button ID="BtnViewPANCard" CssClass="btn btn-primary btn-sm" runat="server" OnClientClick="return openPopup(this);" Text="View PAN Card" />
                                <asp:Label ID="lblPANCard" runat="server" Visible="false"></asp:Label>
                            </div>
                            <div class="mb-2" id="divMob" runat="server">
                                <label for="exampleInputPassword1" class="form-label">
                                    Adhaar Card (Max. Size 1MB)
                                </label>
                                <asp:FileUpload ID="fileAdhar" accept=".jpg,.jpeg,.png,.pdf" CssClass="form-control" runat="server" />
                                <br />
                                <asp:Button ID="BtnViewAdhaarCard" CssClass="btn btn-primary btn-sm" runat="server" OnClientClick="return openPopup(this);" Text="View Adhaar Card" />
                                <asp:Label ID="lblAdhaarCard" runat="server" Visible="false"></asp:Label>
                            </div>
                            <div class="mb-2">
                                <label for="exampleInputPassword1" class="form-label">
                                    Cancel Check (Max. Size 1MB)
                                </label>
                                <asp:FileUpload ID="fileCancelCheck" accept=".jpg,.jpeg,.png,.pdf" CssClass="form-control" runat="server" />
                                <br />
                                <asp:Button ID="BtnViewCancelCheck" CssClass="btn btn-primary btn-sm" runat="server" OnClientClick="return openPopup(this);" Text="View Cancel Check" />
                                <asp:Label ID="lblCancelCheck" runat="server" Visible="false"></asp:Label>
                            </div>
                            <asp:Button ID="BtnSubmit" runat="server" ValidationGroup="a" OnClick="BtnSubmit_Click" CssClass="btn btn-primary" Text="Submit" />
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</div>

<script type="text/javascript">
    function openPopup(imgUrl) {
        console.log(imgUrl)
        var imgElement = $('#myModal iframe');
        imgElement.attr('src', imgUrl.src);
        $('#myModal').modal('show');
        return false;
    }
</script>
</asp:Content>
