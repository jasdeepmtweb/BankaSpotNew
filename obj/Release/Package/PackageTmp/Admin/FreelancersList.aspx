<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="FreelancersList.aspx.cs" Inherits="BankaSpotNew.Admin.FreelancersList" %>

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
                                <h4 class="header-title mb-3">Freelancer List</h4>
                                <div class="table-responsive">
                                    <asp:GridView ID="GridConnector" runat="server" CssClass="table mb-0" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr.No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="FreelancerId" HeaderText="Freelancer Id" />
                                            <asp:BoundField DataField="Name" HeaderText=" Name" />
                                            <asp:BoundField DataField="EmailId" HeaderText="Email ID" />
                                            <asp:BoundField DataField="PanNo" HeaderText="Pan No." />
                                            <asp:BoundField DataField="AdharNo" HeaderText="Adhaar No." />
                                            <asp:BoundField DataField="MobileNo" HeaderText=" Mobile No." />
                                            <asp:BoundField DataField="Password" HeaderText=" Password" />
                                            <asp:BoundField DataField="CreatedOn" HeaderText="DOJ" DataFormatString="{0:dd-MMM-yyyy}" />
                                            <asp:BoundField DataField="DOA" HeaderText="DOA" DataFormatString="{0:dd-MMM-yyyy}" />
                                            <asp:BoundField DataField="DOB" HeaderText="DOB" DataFormatString="{0:dd-MMM-yyyy}" />
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
