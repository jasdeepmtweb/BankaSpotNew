<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Site.Master" AutoEventWireup="true" CodeBehind="AddFreelancerProductPayout.aspx.cs" Inherits="BankaSpotNew.Branch.AddFreelancerProductPayout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="content-page">
        <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-4 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="header-title mb-3">Add Freelancer Payout</h4>

                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Product
                                 <asp:RequiredFieldValidator ControlToValidate="ddlProduct" InitialValue="0" ValidationGroup="a" ID="RequiredFieldValidator9" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:DropDownList ID="ddlProduct" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Payout
                                <asp:RequiredFieldValidator ControlToValidate="txtPayout" ValidationGroup="a" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="myRegexValidator" runat="server" ControlToValidate="txtPayout" Display="Dynamic" ForeColor="Red" ValidationGroup="a" ErrorMessage="Please enter a valid decimal or integer number." ValidationExpression="^(\d+)?(\.\d+)?$"></asp:RegularExpressionValidator>

                                    </label>
                                    <asp:TextBox ID="txtPayout" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>

                                <asp:Button ID="BtnSubmit" runat="server" ValidationGroup="a" OnClick="BtnSubmit_Click" CssClass="btn btn-primary btn-sm" Text="Submit" />
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-8 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="header-title mb-3">List</h4>
                                <div class="table-responsive">
                                    <asp:GridView ID="GridStaff" runat="server" CssClass="table mb-0" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="BtnEdit" runat="server" OnClick="BtnEdit_Click" CommandArgument='<%# Eval("Id") %>' Text="Edit" class="btn btn-primary btn-sm" />
                                                    <asp:Button ID="BtnDelete" runat="server" OnClick="BtnDelete_Click" CommandArgument='<%# Eval("Id") %>' Text="Delete" class="btn btn-danger btn-sm" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sr.No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="PayoutPercent" HeaderText="Payout" />
                                            <asp:BoundField DataField="ProductName" HeaderText="Product" />
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
