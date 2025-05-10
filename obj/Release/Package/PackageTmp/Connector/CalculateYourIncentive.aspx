<%@ Page Title="" Language="C#" MasterPageFile="~/Connector/Site.Master" AutoEventWireup="true" CodeBehind="CalculateYourIncentive.aspx.cs" Inherits="BankaSpotNew.Connector.CalculateYourIncentive" %>

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
                                <h4 class="header-title mb-3">Calculate Your Incentive</h4>

                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Select Product
                                        <asp:RequiredFieldValidator ControlToValidate="ddlProduct" InitialValue="0" ValidationGroup="a" ID="RequiredFieldValidator9" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:DropDownList ID="ddlProduct" ValidationGroup="a" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Amount
                                        <asp:RequiredFieldValidator ControlToValidate="txtAmount" ValidationGroup="a" ID="RequiredFieldValidator10" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAmount" Display="Dynamic" ForeColor="Red" ValidationGroup="a" ErrorMessage="Please enter a valid decimal or integer number." ValidationExpression="^(\d+)?(\.\d+)?$"></asp:RegularExpressionValidator>
                                    </label>
                                    <asp:TextBox ID="txtAmount" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Incentive
                                    </label>
                                    <asp:Label ID="txtIncentive" CssClass="form-control" runat="server"></asp:Label>
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
