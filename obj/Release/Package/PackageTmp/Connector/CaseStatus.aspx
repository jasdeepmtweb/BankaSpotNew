<%@ Page Title="" Language="C#" MasterPageFile="~/Connector/Site.Master" AutoEventWireup="true" CodeBehind="CaseStatus.aspx.cs" Inherits="BankaSpotNew.Connector.CaseStatus" %>
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
                                <h4 class="header-title mb-3">Case Status</h4>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                         Status
                                        <asp:RequiredFieldValidator ControlToValidate="txtPreStatus" ValidationGroup="a" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtPreStatus" Enabled="false" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                         Amount
                                        <asp:RequiredFieldValidator ControlToValidate="txtAmount" ValidationGroup="a" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtAmount" Enabled="false" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Remarks
                                        <asp:RequiredFieldValidator ControlToValidate="txtRemarks" ValidationGroup="a" ID="RequiredFieldValidator15" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtRemarks" TextMode="MultiLine" Enabled="false" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                  <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                         Bank Name
                                    </label>
                                    <asp:TextBox ID="txtBankName" Enabled="false" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                  <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                         Bankaspot Employee
                                    </label>
                                    <asp:TextBox ID="txtBankaspotEmp" Enabled="false" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                 <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                          Employee Mobile No.
                                    </label>
                                    <asp:TextBox ID="txtEmpMobileNo" Enabled="false" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>