<%@ Page Title="" Language="C#" MasterPageFile="~/FreeLancer/Site.Master" AutoEventWireup="true" CodeBehind="ShowSubconnectors.aspx.cs" Inherits="BankaSpotNew.FreeLancer.ShowSubconnectors" %>

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
                                <h4 class="header-title mb-3">Subconnectors List</h4>
                                <div class="table-responsive">
                                    <asp:GridView ID="GridAllCases" runat="server" CssClass="table table-bordered mb-0" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="BtnEdit" runat="server" Text="Edit" CssClass="btn btn-primary btn-sm" OnClick="BtnEdit_Click" CommandArgument='<%# Eval("Id") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sr.No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="CustomerName" HeaderText=" Name" />
                                            <asp:BoundField DataField="CustomerMobileNo" HeaderText=" Mobile No." />
                                            <asp:BoundField DataField="EmailId" HeaderText=" Email ID" />
                                            <asp:BoundField DataField="City" HeaderText=" City" />
                                            <asp:BoundField DataField="CreatedOn" HeaderText="Date" DataFormatString="{0:dd-MMM-yyyy}" />
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
