<%@ Page Title="" Language="C#" MasterPageFile="~/SubConnector/Site.Master" AutoEventWireup="true" CodeBehind="ShowPayouts.aspx.cs" Inherits="BankaSpotNew.SubConnector.ShowPayouts" %>
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
                            <h4 class="header-title mb-3">Payouts List</h4>
                            <div class="table-responsive">
                                <asp:GridView ID="GridAllCases" runat="server" CssClass="table table-bordered mb-0" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr.No">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Name" HeaderText="File Name" />
                                        <asp:BoundField DataField="ProductName" HeaderText=" Product" />
                                        <asp:BoundField DataField="AmountDisbursed" HeaderText="Amount Disbursed" />
                                        <asp:BoundField DataField="PayoutAmount" HeaderText="Payout" />
                                        <asp:BoundField DataField="Remarks" HeaderText=" Remarks" />
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
