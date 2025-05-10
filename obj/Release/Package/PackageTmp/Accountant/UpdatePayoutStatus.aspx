<%@ Page Title="" Language="C#" MasterPageFile="~/Accountant/Site.Master" AutoEventWireup="true" CodeBehind="UpdatePayoutStatus.aspx.cs" Inherits="BankaSpotNew.Accountant.UpdatePayoutStatus" %>

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
                                <h4 class="header-title mb-3">Update Payout Status</h4>

                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Payout Date
                                        <asp:RequiredFieldValidator ControlToValidate="txtPayoutDate" ValidationGroup="a" ID="RequiredFieldValidator9" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtPayoutDate" ValidationGroup="a" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2" id="divType" runat="server" visible="false">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Type
                                    </label>
                                    <asp:DropDownList ID="ddlPayoutType" ValidationGroup="a" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="Extra Payout" Value="1" />
                                        <asp:ListItem Text="Any Deduction" Value="2" />
                                    </asp:DropDownList>
                                </div>
                                <div class="mb-2" id="divAmount" runat="server" visible="false">
                                    <label for="exampleInputEmail1" class="form-label">
                                        Amount
                                        <asp:RequiredFieldValidator ControlToValidate="txtPayoutDeduction" ValidationGroup="a" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ControlToValidate="txtPayoutDeduction" Operator="DataTypeCheck" Type="Double" ID="CompareValidator1" runat="server" ErrorMessage="*Enter Only Numbers" ForeColor="Red" Display="Dynamic" ValidationGroup="a"></asp:CompareValidator>
                                    </label>
                                    <asp:TextBox ID="txtPayoutDeduction" Text="0" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2" id="divReason" runat="server" visible="false">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Reason
                                   <asp:RequiredFieldValidator ControlToValidate="txtAnyReason" ValidationGroup="a" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtAnyReason" Text="-" ValidationGroup="a" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
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
