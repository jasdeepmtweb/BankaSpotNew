<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Site.Master" AutoEventWireup="true" CodeBehind="FreelancerListForMapping.aspx.cs" Inherits="BankaSpotNew.Branch.FreelancerListForMapping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="content-page">
        <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-12 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="header-title mb-3">Freelancers List</h4>
                                <div class="table-responsive">
                                    <asp:GridView ID="GridFreelancerForBranch" runat="server" CssClass="table mb-0" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="BtnMap" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="BtnMap_Click" Text="Map To Emp/Market Emp." CssClass="btn btn-success btn-sm" />
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
                                            <asp:BoundField DataField="EmpName" HeaderText=" Emp. Name" />
                                            <asp:BoundField DataField="MarketEmpName" HeaderText=" Market. Emp. Name" />
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
</asp:Content>
