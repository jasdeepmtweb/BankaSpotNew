<%@ Page Title="" Language="C#" MasterPageFile="~/Accountant/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="BankaSpotNew.Accountant.ChangePassword" %>
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
                             <h4 class="header-title mb-3">Change Password</h4>


                             <div class="mb-2">
                                 <label for="exampleInputEmail1" class="form-label">Old Password
                                     <asp:RequiredFieldValidator ControlToValidate="txtOldPassword" ValidationGroup="a" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cmpOldPassword" runat="server" ControlToValidate="txtOldPassword"
                                    Operator="Equal" Type="String" ErrorMessage="Old password is incorrect" Display="Dynamic" ForeColor="Red" ValidationGroup="a"></asp:CompareValidator>
                                     </label>
                                 <asp:TextBox ID="txtOldPassword" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                             </div>
                             <div class="mb-2">
                                 <label for="exampleInputPassword1" class="form-label">New Password
                                     <asp:RequiredFieldValidator ControlToValidate="txtNewPassword" ValidationGroup="a" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                     </label>
                                 <asp:TextBox ID="txtNewPassword" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                             </div>
                             <div class="mb-2">
                                 <label for="exampleInputPassword1" class="form-label">Confirm New Password
                                     <asp:RequiredFieldValidator ControlToValidate="txtConfirmNewPassword" ValidationGroup="a" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtConfirmNewPassword" ControlToCompare="txtNewPassword"
                                    Operator="Equal" Type="String" ErrorMessage="Confirm password is incorrect" Display="Dynamic" ForeColor="Red" ValidationGroup="a"></asp:CompareValidator>
                                     </label>
                                 <asp:TextBox ID="txtConfirmNewPassword" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
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
