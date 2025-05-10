<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="MakeFreealncerWithdrawal.aspx.cs" Inherits="BankaSpotNew.Admin.MakeFreealncerWithdrawal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <br />
    <div class="content-page">
        <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-6 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="header-title mb-3">Make Withdrawal</h4>


                                <div class="mb-2">
                                    <label for="exampleInputEmail1" class="form-label">
                                        Total Payout
                                    </label>
                                    <asp:Label ID="txtTotalPayout" CssClass="form-control" runat="server"></asp:Label>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Total Withdrawal
                                    </label>
                                    <asp:Label ID="txtTotalWithdrawal" CssClass="form-control" runat="server"></asp:Label>
                                </div>
                                 <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                       Available Balance
                                    </label>
                                    <asp:Label ID="txtAvailableBalance" CssClass="form-control" runat="server"></asp:Label>
                                </div>
                                 <div class="mb-2" id="divPassword" runat="server">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Withdrawal Amount
                                        <asp:RequiredFieldValidator ControlToValidate="txtWithdrawal" ValidationGroup="a" ID="RequiredFieldValidator9" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator Display="Dynamic" ForeColor="Red" Operator="DataTypeCheck" ValidationGroup="a" Type="Double" ControlToValidate="txtWithdrawal" ID="CompareValidator1" runat="server" ErrorMessage="Enter Only Numbers"></asp:CompareValidator>
                                        </label>
                                    <asp:TextBox ID="txtWithdrawal" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Remarks
                                        <asp:RequiredFieldValidator ControlToValidate="txtRemarks" ValidationGroup="a" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtRemarks" TextMode="MultiLine" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                
                                <asp:Button ID="BtnSubmit" runat="server" ValidationGroup="a" OnClick="BtnSubmit_Click" CssClass="btn btn-primary" Text="Submit" />
                            </div>
                        </div>
                    </div>
                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>