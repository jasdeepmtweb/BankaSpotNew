<%@ Page Title="" Language="C#" MasterPageFile="~/FreeLancer/Site.Master" AutoEventWireup="true" CodeBehind="AddCase.aspx.cs" Inherits="BankaSpotNew.FreeLancer.AddCase" %>
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
                                <h4 class="header-title mb-3">Add Case</h4>

                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Name
                                        <asp:RequiredFieldValidator ControlToValidate="txtName" ValidationGroup="a" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtName" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Mobile No.
                                        <asp:RequiredFieldValidator ControlToValidate="txtMobileNo" ValidationGroup="a" ID="RequiredFieldValidator8" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtMobileNo" MaxLength="10" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                 <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                       City
                                        <asp:RequiredFieldValidator ControlToValidate="txtCity" ValidationGroup="a" ID="RequiredFieldValidator15" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtCity" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                       Product Required
                                        <asp:RequiredFieldValidator ControlToValidate="ddlProduct" InitialValue="0" ValidationGroup="a" ID="RequiredFieldValidator9" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:DropDownList ID="ddlProduct" ValidationGroup="a" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                   <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                    Amount Required
                                        <asp:RequiredFieldValidator ControlToValidate="txtAmount" ValidationGroup="a" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="myRegexValidator" runat="server" ControlToValidate="txtAmount" Display="Dynamic" ForeColor="Red" ValidationGroup="a" ErrorMessage="Please enter a valid decimal or integer number." ValidationExpression="^(\d+)?(\.\d+)?$"></asp:RegularExpressionValidator>
                                        </label>
                                    <asp:TextBox ID="txtAmount" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                               
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="header-title mb-3">&nbsp</h4>
                             
                                 <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                      Profile
                                        <asp:RequiredFieldValidator ControlToValidate="ddlProfile" ValidationGroup="a" ID="RequiredFieldValidator12" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <%--<asp:TextBox ID="txtProfile" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>--%>
                                     <asp:DropDownList ID="ddlProfile" CssClass="form-control" runat="server">
                                         <asp:ListItem Value="0" Text="Salaried"></asp:ListItem>
                                         <asp:ListItem Value="1" Text="Self Employed"></asp:ListItem>
                                         <asp:ListItem Value="2" Text="Businessman"></asp:ListItem>
                                         <asp:ListItem Value="3" Text="Agriculturist"></asp:ListItem>
                                          <asp:ListItem Value="4" Text="Pensioner"></asp:ListItem>
                                     </asp:DropDownList>
                                </div>
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Address
                                        <asp:RequiredFieldValidator ControlToValidate="txtAddress" ValidationGroup="a" ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtAddress" ValidationGroup="a" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                  <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Monthly Income
                                        <asp:RequiredFieldValidator ControlToValidate="txtMonthlyIncome" ValidationGroup="a" ID="RequiredFieldValidator10" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMonthlyIncome" Display="Dynamic" ForeColor="Red" ValidationGroup="a" ErrorMessage="Please enter a valid decimal or integer number." ValidationExpression="^(\d+)?(\.\d+)?$"></asp:RegularExpressionValidator>
                                        </label>
                                    <asp:TextBox ID="txtMonthlyIncome" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                  <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                        Remarks
                                        <asp:RequiredFieldValidator ControlToValidate="txtRemarks" ValidationGroup="a" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>                                 
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