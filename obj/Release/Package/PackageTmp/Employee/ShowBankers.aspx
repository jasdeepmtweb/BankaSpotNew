<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Site.Master" AutoEventWireup="true" CodeBehind="ShowBankers.aspx.cs" Inherits="BankaSpotNew.Employee.ShowBankers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <br />
  <div class="content-page">
      <div class="content">
          <div class="container-fluid">
              <div class="row">
                  <div class="col-lg-12 mx-auto">
                      <div class="card">
                          <div class="card-body">
                              <h4 class="header-title mb-3">List Of Bankers</h4>
                              <div class="table-responsive">
                                  <asp:GridView ID="GridProducts" runat="server" CssClass="table mb-0" AutoGenerateColumns="false">
                                      <Columns>
                                          <asp:TemplateField HeaderText="Sr.No">
                                              <ItemTemplate>
                                                  <%#Container.DataItemIndex+1 %>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:BoundField DataField="Name" HeaderText="Name" />
                                          <asp:BoundField DataField="Designation" HeaderText="Designation" />
                                          <asp:BoundField DataField="MobileNo" HeaderText="Mobile No." />
                                          <asp:BoundField DataField="EmailId" HeaderText="Email Id" />
                                          <asp:BoundField DataField="City" HeaderText="City" />
                                          <asp:BoundField DataField="AreaCovered" HeaderText="AreaCovered" />
                                          <asp:BoundField DataField="ProductName" HeaderText="Product" />
                                          <asp:BoundField DataField="RegionName" HeaderText="Location" />
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
