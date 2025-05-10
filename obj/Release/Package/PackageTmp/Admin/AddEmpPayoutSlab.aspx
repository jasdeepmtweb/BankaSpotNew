<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="AddEmpPayoutSlab.aspx.cs" Inherits="BankaSpotNew.Admin.AddEmpPayoutSlab" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="content-page">
        <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-3 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="header-title mb-3">Add Employee Payout Slab (<asp:Label ID="lblProductName" runat="server" Text="Label"></asp:Label>)</h4>
                                <div class="mb-2">
                                    <label for="exampleInputEmail1" class="form-label">
                                        Minimum Amount
                                    <asp:RequiredFieldValidator ControlToValidate="txtMinAmount" ValidationGroup="a" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ControlToValidate="txtMinAmount" Operator="DataTypeCheck" Type="Double" ID="CompareValidator1" runat="server" ErrorMessage="Please enter a valid decimal or integer number." ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
                                    </label>
                                    <asp:TextBox ID="txtMinAmount" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Maximum Amount
                                    <asp:RequiredFieldValidator ControlToValidate="txtMaxAmount" ValidationGroup="a" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="myRegexValidator" runat="server" ControlToValidate="txtMaxAmount" Display="Dynamic" ForeColor="Red" ValidationGroup="a" ErrorMessage="Please enter a valid decimal or integer number." ValidationExpression="^(\d+)?(\.\d+)?$"></asp:RegularExpressionValidator>
                                    </label>
                                    <asp:TextBox ID="txtMaxAmount" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Payout
                                    <asp:RequiredFieldValidator ControlToValidate="txtPayout" ValidationGroup="a" ID="RequiredFieldValidator8" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPayout" Display="Dynamic" ForeColor="Red" ValidationGroup="a" ErrorMessage="Please enter a valid decimal or integer number." ValidationExpression="^(\d+)?(\.\d+)?$"></asp:RegularExpressionValidator>
                                    </label>
                                    <asp:TextBox ID="txtPayout" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <asp:Button ID="BtnSubmit" runat="server" ValidationGroup="a" OnClick="BtnSubmit_Click" CssClass="btn btn-primary" Text="Submit" />
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-9 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="header-title mb-3">List</h4>
                                <div class="table-responsive">
                                    <asp:GridView ID="GridProducts" runat="server" CssClass="table table-hover mb-0" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:Button ID="BtnEdit" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="BtnEdit_Click" Text="Edit" CssClass="btn btn-primary btn-sm" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sr.No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="MinAmount" HeaderText="Min. Amount" />
                                            <asp:BoundField DataField="MaxAmount" HeaderText="Max. Amount" />
                                            <asp:BoundField DataField="Payout" HeaderText="Payout" />
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
