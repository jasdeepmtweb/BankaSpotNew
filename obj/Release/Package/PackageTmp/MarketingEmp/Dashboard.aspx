<%@ Page Title="" Language="C#" MasterPageFile="~/MarketingEmp/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="BankaSpotNew.MarketingEmp.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="content-page">
      <div class="content">
          <div class="container-fluid">
              <div class="row">
                  <div class="col-12">
                      <div class="page-title-box page-title-box-alt">
                          <h4 class="page-title"><asp:Label ID="lblName" runat="server" Text="Label"></asp:Label></h4>
                          <div class="page-title-right">
                              <ol class="breadcrumb m-0">

                                  <li class="breadcrumb-item active">Dashboard</li>
                              </ol>
                          </div>
                      </div>
                  </div>
              </div>
              <div class="row">

                  <div class="col-xl-4 col-md-6">
                      <div class="card">
                          <div class="card-body">
                              <div class="d-flex justify-content-between">
                                  <div>
                                      <h5 class="text-muted fw-normal mt-0 text-truncate">Total Incentive Amount</h5>
                                      <h3 class="my-2 py-1"><span data-plugin="counterup">
                                          <asp:Literal ID="lblTotalIncentiveAmount" runat="server" Text="0"></asp:Literal></span></h3>
                                      <p class="mb-0 text-muted">
                                      </p>
                                  </div>
                                  <div class="avatar-sm">
                                      <span class="avatar-title bg-soft-primary rounded">
                                          <i class="ri-stack-line font-20 text-primary"></i>
                                      </span>
                                  </div>
                              </div>
                          </div>
                      </div>
                  </div>


                  <div class="col-xl-4 col-md-6">
                      <div class="card">
                          <div class="card-body">
                              <div class="d-flex justify-content-between">
                                  <div>
                                      <h5 class="text-muted fw-normal mt-0 text-truncate">Total Cases</h5>
                                      <h3 class="my-2 py-1"><span data-plugin="counterup">
                                          <asp:Literal ID="lblTotalCases" runat="server" Text="0"></asp:Literal></span></h3>
                                      <p class="mb-0 text-muted">
                                      </p>
                                  </div>
                                  <div class="avatar-sm">
                                      <span class="avatar-title bg-soft-primary rounded">
                                          <i class="ri-slideshow-2-line font-20 text-primary"></i>
                                      </span>
                                  </div>
                              </div>
                          </div>
                      </div>
                  </div>
                  <div class="col-xl-4 col-md-6">
                      <div class="card">
                          <div class="card-body">
                              <div class="d-flex justify-content-between">
                                  <div>
                                      <h5 class="text-muted fw-normal mt-0 text-truncate">Today's Cases</h5>
                                      <h3 class="my-2 py-1"><span data-plugin="counterup">
                                          <asp:Literal ID="lblTodaysCases" runat="server" Text="0"></asp:Literal></span></h3>
                                      <p class="mb-0 text-muted">
                                      </p>
                                  </div>
                                  <div class="avatar-sm">
                                      <span class="avatar-title bg-soft-primary rounded">
                                          <i class="ri-hand-heart-line font-20 text-primary"></i>
                                      </span>
                                  </div>
                              </div>
                          </div>
                      </div>
                  </div>
                  <div class="col-xl-4 col-md-6">
                      <div class="card">
                          <div class="card-body">
                              <div class="d-flex justify-content-between">
                                  <div>
                                      <a href="ShowDisbursedCases.aspx"><h5 class="text-muted fw-normal mt-0 text-truncate">Disbursed Cases</h5></a>
                                      <h3 class="my-2 py-1"><span data-plugin="counterup">
                                          <asp:Literal ID="lblCompletedCases" runat="server" Text="0"></asp:Literal></span></h3>
                                      <p class="mb-0 text-muted">
                                      </p>
                                  </div>
                                  <div class="avatar-sm">
                                      <span class="avatar-title bg-soft-primary rounded">
                                          <i class="ri-hand-heart-line font-20 text-primary"></i>
                                      </span>
                                  </div>
                              </div>
                          </div>
                      </div>
                  </div>


                  <div class="col-xl-4 col-md-6">
                      <div class="card">
                          <div class="card-body">
                              <div class="d-flex justify-content-between">
                                  <div>
                                      <a href="AllCases.aspx"><h5 class="text-muted fw-normal mt-0 text-truncate" >Pending Cases</h5></a>
                                      <h3 class="my-2 py-1"><span data-plugin="counterup">
                                          <asp:Literal ID="lblPendingCases" runat="server" Text="0"></asp:Literal></span></h3>
                                      <p class="mb-0 text-muted">
                                      </p>
                                  </div>
                                  <div class="avatar-sm">
                                      <span class="avatar-title bg-soft-primary rounded">
                                          <i class="ri-money-dollar-box-line font-20 text-primary"></i>
                                      </span>
                                  </div>
                              </div>
                          </div>
                      </div>
                  </div>

                 <div class="col-xl-4 col-md-6">
                      <div class="card">
                          <div class="card-body">
                              <div class="d-flex justify-content-between">
                                  <div>
                                      <a href="ShowRejectedCases.aspx"><h5 class="text-muted fw-normal mt-0 text-truncate" >Rejected Cases</h5></a>
                                      <h3 class="my-2 py-1"><span data-plugin="counterup">
                                          <asp:Literal ID="lblRejectedCases" runat="server" Text="0"></asp:Literal></span></h3>
                                      <p class="mb-0 text-muted">
                                      </p>
                                  </div>
                                  <div class="avatar-sm">
                                      <span class="avatar-title bg-soft-primary rounded">
                                          <i class="ri-money-dollar-box-line font-20 text-primary"></i>
                                      </span>
                                  </div>
                              </div>
                          </div>
                      </div>
                  </div>

              </div>
              <div class="row">
                  <div class="col-xl-10 mx-auto">
                      <div class="card">
                          <div class="card-body">
                              <h4 class="header-title mb-3">Incentive Month Wise</h4>
                              <div class="table-responsive">

                                  <asp:GridView ID="GridCase" runat="server" CssClass="table table-striped table-nowrap table-centered mb-0" AutoGenerateColumns="false">
                                      <Columns>
                                          <asp:TemplateField HeaderText="Sr.No">
                                              <ItemTemplate>
                                                  <%#Container.DataItemIndex+1 %>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:BoundField DataField="Month" HeaderText="Month" />
                                          <asp:BoundField DataField="SummedValue" HeaderText="Incentives" />
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