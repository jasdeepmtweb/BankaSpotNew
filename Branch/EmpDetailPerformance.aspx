<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Site.Master" AutoEventWireup="true" CodeBehind="EmpDetailPerformance.aspx.cs" Inherits="BankaSpotNew.Branch.EmpDetailPerformance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <br />
    <div class="content-page">
        <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-10 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="header-title">Employee Performance Report Detail</h4>
                               
                                <div class="table-responsive">
                                    <br />
                                    <asp:GridView ID="GridPerformanceReport" CssClass="table table-hover" AutoGenerateColumns="false" runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="ProductName" HeaderText=" Product" />
                                            <asp:BoundField DataField="EmpTarget" HeaderText="Monthly Target" />
                                            <asp:BoundField DataField="TargetAchieved" HeaderText="Target Achieved" />
                                            <asp:BoundField DataField="ShortFall" HeaderText=" Target ShortFall" />
                                            <asp:BoundField DataField="ext1" HeaderText=" Month Year" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                         <div class="row">
                             <div class="col-lg-3">
                         <div class="card">
                            <div class="card-body">
                                <div class="form-group">
                                    <label>
                                        Total Target
                                    </label>
                                    <asp:Label ID="lblTotalTarget" CssClass="form-control" runat="server" Text="0"></asp:Label>
                                </div>
                            </div>
                        </div>
                                 </div>
                             <div class="col-lg-3">
                         <div class="card">
                            <div class="card-body">
                                <div class="form-group">
                                    <label>
                                        Total Target Achieved
                                    </label>
                                    <asp:Label ID="lblTotalTargetAchieved" CssClass="form-control" runat="server" Text="0"></asp:Label>
                                </div>
                            </div>
                        </div>
                                 </div>
                              <div class="col-lg-3">
                         <div class="card">
                            <div class="card-body">
                                <div class="form-group">
                                    <label>
                                        Total Shortfall
                                    </label>
                                    <asp:Label ID="lblTotalShortfall" CssClass="form-control" runat="server" Text="0"></asp:Label>
                                </div>
                            </div>
                        </div>
                                   </div>
                              <div class="col-lg-3">
                        <div class="card">
                            <div class="card-body">
                                <div class="form-group">
                                    <label>
                                        Total Achievement
                                    </label>
                                    <asp:Label ID="lblTotalAchievement" CssClass="form-control" runat="server" Text="0"></asp:Label>
                                </div>
                            </div>
                        </div>
                                   </div>
                             </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>