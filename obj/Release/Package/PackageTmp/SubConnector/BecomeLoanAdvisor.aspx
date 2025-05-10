<%@ Page Title="" Language="C#" MasterPageFile="~/SubConnector/Site.Master" AutoEventWireup="true" CodeBehind="BecomeLoanAdvisor.aspx.cs" Inherits="BankaSpotNew.SubConnector.BecomeLoanAdvisor" %>
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
                               <h4 class="header-title mb-3">Become Loan Advisor</h4>

                               <div class="mb-2">
                                   <label for="fullname" class="form-label">
                                       Name
<asp:RequiredFieldValidator ControlToValidate="txtName" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic" ValidationGroup="a"></asp:RequiredFieldValidator>
                                   </label>
                                   <asp:TextBox ID="txtName" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                               </div>
                               <div class="mb-2">
                                   <label for="emailaddress" class="form-label">
                                       Mobile No.
   <asp:RequiredFieldValidator ControlToValidate="txtMobileNo" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic" ValidationGroup="a"></asp:RequiredFieldValidator>
                                   </label>
                                   <asp:TextBox ID="txtMobileNo" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                               </div>
                               <div class="mb-2">
                                   <label for="emailaddress" class="form-label">
                                       Qualification
                                       <asp:RequiredFieldValidator ControlToValidate="ddlQualification" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic" ValidationGroup="a"></asp:RequiredFieldValidator>
                                   </label>
                                   <asp:DropDownList ID="ddlQualification" ValidationGroup="a" CssClass="form-control" runat="server">
                                       <asp:ListItem Text="8th" Value="8th"/>
                                       <asp:ListItem Text="10th" Value="10th"/>
                                       <asp:ListItem Text="12th" Value="12th"/>
                                       <asp:ListItem Text="Graduate" Value="Graduate"/>
                                       <asp:ListItem Text="Post Graduate" Value="PostGraduate"/>
                                   </asp:DropDownList>
                               </div>
                              
                               <div class="mb-2">
                                   <label for="emailaddress" class="form-label">
                                       Current Profession
        <asp:RequiredFieldValidator ControlToValidate="txtCurrentProfession" ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic" ValidationGroup="a"></asp:RequiredFieldValidator>
                                   </label>
                                   <asp:TextBox ID="txtCurrentProfession" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                               </div>
                               <div class="mb-2" id="divPassword" runat="server">
                                   <label for="emailaddress" class="form-label">
                                       City
<asp:RequiredFieldValidator ControlToValidate="txtCity" ID="RequiredFieldValidator15" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic" ValidationGroup="a"></asp:RequiredFieldValidator>
                                   </label>
                                   <asp:TextBox ID="txtCity" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
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
