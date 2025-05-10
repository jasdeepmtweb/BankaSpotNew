<%@ Page Title="" Language="C#" MasterPageFile="~/SubConnector/Site.Master" AutoEventWireup="true" CodeBehind="ShowAppliedLoans.aspx.cs" Inherits="BankaSpotNew.SubConnector.ShowAppliedLoans" %>
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
                             <h4 class="header-title mb-3">Applied Loans List</h4>
                             <div class="table-responsive">
                                 <asp:GridView ID="GridAllCases" runat="server" CssClass="table table-bordered mb-0" AutoGenerateColumns="false">
                                     <Columns>
                                         <asp:TemplateField HeaderText="Action">
                                             <ItemTemplate>
                                                 <asp:Button ID="BtnEdit" CommandArgument='<%# Eval("Id") %>' OnClick="BtnEdit_Click" CssClass="btn btn-success btn-sm" runat="server" Text="Edit" />
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Sr.No">
                                             <ItemTemplate>
                                                 <%#Container.DataItemIndex+1 %>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         
                                         <asp:BoundField DataField="Name" HeaderText=" Name" />
                                         <asp:BoundField DataField="MobileNo" HeaderText=" Mobile No." />
                                         <asp:BoundField DataField="LoanReq" HeaderText="Loan Req." />
                                         <asp:BoundField DataField="AmountReq" HeaderText=" Amount Req." />
                                         <asp:BoundField DataField="Profile" HeaderText="Profile" />
                                         <asp:BoundField DataField="MonthlyIncome" HeaderText=" Monthly Income" />
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
