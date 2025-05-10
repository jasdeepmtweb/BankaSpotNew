<%@ Page Title="" Language="C#" MasterPageFile="~/Accountant/Site.Master" AutoEventWireup="true" CodeBehind="AddBanker.aspx.cs" Inherits="BankaSpotNew.Accountant.AddBanker" %>
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
                             <h4 class="header-title mb-3">Add Banker</h4>


                             <div class="mb-2">
                                 <label for="exampleInputEmail1" class="form-label">
                                     Name
                                 <asp:RequiredFieldValidator ControlToValidate="txtName" ValidationGroup="a" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                 </label>
                                 <asp:TextBox ID="txtName" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                             </div>
                             <div class="mb-2">
                                 <label for="exampleInputPassword1" class="form-label">
                                     Mobile No.
                                 <asp:RequiredFieldValidator ControlToValidate="txtMobileNo" ValidationGroup="a" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                 </label>
                                 <asp:TextBox ID="txtMobileNo" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                             </div>
                             <div class="mb-2">
                                 <label for="exampleInputPassword1" class="form-label">
                                     Email ID
                                 <asp:RequiredFieldValidator ControlToValidate="txtEmailId" ValidationGroup="a" ID="RequiredFieldValidator8" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                 </label>
                                 <asp:TextBox ID="txtEmailId" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                             </div>
                             <div class="mb-2">
                                 <label for="exampleInputPassword1" class="form-label">
                                     Bank Name
  <asp:RequiredFieldValidator ControlToValidate="txtBankName" ValidationGroup="a" ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                 </label>
                                 <asp:TextBox ID="txtBankName" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                             </div>
                             <div class="mb-2">
                                 <label for="exampleInputPassword1" class="form-label">
                                     Product
                                 <asp:RequiredFieldValidator ControlToValidate="ddlProduct" InitialValue="0" ValidationGroup="a" ID="RequiredFieldValidator9" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                 </label>
                                 <asp:DropDownList ID="ddlProduct" CssClass="form-control" runat="server"></asp:DropDownList>
                             </div>
                             <div class="mb-2">
                                 <label for="exampleInputPassword1" class="form-label">
                                     City
  <asp:RequiredFieldValidator ControlToValidate="txtCity" ValidationGroup="a" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                 </label>
                                 <asp:TextBox ID="txtCity" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                             </div>
                             <div class="mb-2">
                                 <label for="exampleInputPassword1" class="form-label">
                                     Area Covered
                                     <asp:RequiredFieldValidator ControlToValidate="txtAreaCovered" ValidationGroup="a" ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                 </label>
                                 <asp:TextBox ID="txtAreaCovered" ValidationGroup="a" CssClass="form-control" runat="server"></asp:TextBox>
                             </div>
                             <div class="mb-2">
                                 <label for="exampleInputPassword1" class="form-label">
                                     Location (Branch)
 <asp:RequiredFieldValidator ControlToValidate="ddlLocation" InitialValue="0" ValidationGroup="a" ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                 </label>
                                 <asp:DropDownList ID="ddlLocation" CssClass="form-control" runat="server"></asp:DropDownList>
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
                                 <asp:GridView ID="GridProducts" runat="server" CssClass="table mb-0" AutoGenerateColumns="false">
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
                                         <asp:BoundField DataField="Name" HeaderText="Name" />
                                         <asp:BoundField DataField="MobileNo" HeaderText="Mobile No." />
                                         <asp:BoundField DataField="EmailId" HeaderText="Email Id" />
                                         <asp:BoundField DataField="City" HeaderText="City" />
                                         <asp:BoundField DataField="AreaCovered" HeaderText="AreaCovered" />
                                         <asp:BoundField DataField="BankName" HeaderText="Bank" />
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
