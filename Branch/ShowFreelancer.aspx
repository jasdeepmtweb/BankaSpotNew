<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Site.Master" AutoEventWireup="true" CodeBehind="ShowFreelancer.aspx.cs" Inherits="BankaSpotNew.Branch.ShowFreelancer" %>

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
                                <h4 class="header-title mb-3">Show Freelancer</h4>
                                <div class="table-responsive">
                                    <asp:GridView ID="GridFreelancerForBranch" runat="server" CssClass="table mb-0" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="BtnEdit" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="BtnEdit_Click" Text="Edit/Show" class="btn btn-success btn-sm" />
                                                    <asp:Button ID="BtnDelete" Visible="false" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="BtnDelete_Click" Text="Delete" class="btn btn-danger btn-sm" />
                                                    <asp:Button ID="BtnActivate" Visible='<%# Eval("ext4").ToString().Equals("0") %>' runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="BtnActivate_Click" Text="Active" CssClass="btn btn-success btn-sm" />
                                                    <asp:Button ID="BtnInactive" runat="server" Visible='<%# Eval("ext4").ToString().Equals("1") %>' CommandArgument='<%# Eval("Id") %>' OnClick="BtnInactive_Click" OnClientClick="return confirm('Do you want to inactive this User?');" Text="Inactive" CssClass="btn btn-danger btn-sm" />
                                                    <asp:Button ID="BtnUpdateDocs" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="BtnUpdateDocs_Click" Text="Docs" CssClass="btn btn-dark btn-sm" />
                                                    <asp:Button ID="BtnProPayout" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="BtnProPayout_Click" Text="Payout" CssClass="btn btn-info btn-sm" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sr.No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Image">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgButton" Width="50px" Height="50px" runat="server" ImageUrl='<%# Eval("FreelancerPic") %>' OnClientClick="return openPopup(this);" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="FreelancerId" HeaderText="Freelancer Id" />
                                            <asp:BoundField DataField="Name" HeaderText=" Name" />
                                            <asp:BoundField DataField="EmailId" HeaderText="Email ID" />
                                            <asp:BoundField DataField="MobileNo" HeaderText=" Mobile No." />
                                            <asp:BoundField DataField="Password" HeaderText=" Password" />
                                            <asp:BoundField DataField="CreatedOn" HeaderText=" DOJ" DataFormatString="{0:dd-MMM-yyyy}"/>
                                            <asp:BoundField DataField="DOA" HeaderText=" DOA" DataFormatString="{0:dd-MMM-yyyy}"/>
                                            <asp:BoundField DataField="DOB" HeaderText=" DOB" DataFormatString="{0:dd-MMM-yyyy}"/>
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
