<%@ Page Title="" Language="C#" MasterPageFile="~/FreeLancer/Site.Master" AutoEventWireup="true" CodeBehind="AddSCPayout.aspx.cs" Inherits="BankaSpotNew.FreeLancer.AddSCPayout" %>

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
                                <h4 class="header-title mb-3">Add Subconnector Payout</h4>
                                <asp:Label ID="lblId" Visible="false" runat="server"></asp:Label>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Subconnector
 <asp:RequiredFieldValidator ControlToValidate="ddlSubconnector" InitialValue="0" ValidationGroup="a" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:DropDownList ID="ddlSubconnector" AutoPostBack="true" OnSelectedIndexChanged="ddlSubconnector_SelectedIndexChanged" ValidationGroup="a" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Amount
                                 <asp:RequiredFieldValidator ControlToValidate="txtPayoutAmount" ValidationGroup="a" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ControlToValidate="txtPayoutAmount" ValidationGroup="a" Operator="DataTypeCheck" Type="Double" ID="CompareValidator1" runat="server" ErrorMessage="*Enter Only Numbers" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
                                    </label>
                                    <asp:TextBox ID="txtPayoutAmount" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Any Remarks
                                 <asp:RequiredFieldValidator ControlToValidate="txtRemarks" ValidationGroup="a" ID="RequiredFieldValidator15" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
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
