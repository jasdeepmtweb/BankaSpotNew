<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Site.Master" AutoEventWireup="true" CodeBehind="ConnectorCaseCount.aspx.cs" Inherits="BankaSpotNew.Branch.ConnectorCaseCount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="content-page">
        <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-6">
                        <label>
                            From Date
                            <asp:RequiredFieldValidator ErrorMessage="*Required" Display="Dynamic" ForeColor="Red" ValidationGroup="a" ControlToValidate="txtFromDate" runat="server" />
                        </label>
                        <asp:TextBox ID="txtFromDate" TextMode="Date" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <label>
                            To Date
                             <asp:RequiredFieldValidator ErrorMessage="*Required" Display="Dynamic" ForeColor="Red" ValidationGroup="a" ControlToValidate="txtToDate" runat="server" />
                        </label>
                        <asp:TextBox ID="txtToDate" TextMode="Date" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                        <br />
                        <asp:Button ID="BtnSearch" CssClass="btn btn-success btn-sm" ValidationGroup="a" OnClick="BtnSearch_Click" runat="server" Text="Show" />
                    </div>

                    <div class="col-lg-12 mx-auto mt-2">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="header-title mb-3">Active/Inactive Connectors</h4>
                                <div class="table-responsive">
                                    <asp:GridView ID="GridShowConnector" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr.No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Name" HeaderText="Connector Name" />

                                            <asp:BoundField DataField="MobileNo" HeaderText=" Mobile No." />
                                            <asp:BoundField DataField="ConLocation" HeaderText=" Location" />
                                            <asp:BoundField DataField="EmpName" HeaderText=" Emp. Name" />
                                            <asp:BoundField DataField="MarketEmpName" HeaderText=" Market Emp. Name" />
                                            <asp:BoundField DataField="totalCases" HeaderText=" Total Case" />
                                            <asp:TemplateField HeaderText="Active Case">
                                                <ItemTemplate>
                                                    <a href="ShowCases.aspx?conid=<%# Eval("Id") %>"><%# Eval("activeCases") %></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Disbursed Case">
                                                <ItemTemplate>
                                                    <a href="ShowDisbursedCases.aspx?conid=<%# Eval("Id") %>"><%# Eval("disbursedCases") %></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rejected Case">
                                                <ItemTemplate>
                                                    <a href="ShowRejectedCases.aspx?conid=<%# Eval("Id") %>"><%# Eval("rejectedCases") %></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="CreatedOn" HeaderText=" Join Date" DataFormatString="{0:dd-MM-yyyy}" />
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
