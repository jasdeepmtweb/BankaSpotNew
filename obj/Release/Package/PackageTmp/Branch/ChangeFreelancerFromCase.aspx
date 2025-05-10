<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Site.Master" AutoEventWireup="true" CodeBehind="ChangeFreelancerFromCase.aspx.cs" Inherits="BankaSpotNew.Branch.ChangeFreelancerFromCase" %>
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
                                <h4 class="header-title mb-3">Change Freelancer</h4>

                               
                                <div class="mb-2">
                                    <label for="exampleInputPassword1" class="form-label">
                                       Freelancer Name
                                        <asp:RequiredFieldValidator ControlToValidate="ddlFreelancer" InitialValue="0" ValidationGroup="a" ID="RequiredFieldValidator9" runat="server" ErrorMessage="*Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:DropDownList ID="ddlFreelancer" ValidationGroup="a" CssClass="form-control" runat="server"></asp:DropDownList>
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