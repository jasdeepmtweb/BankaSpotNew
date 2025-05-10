<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Site.Master" AutoEventWireup="true" CodeBehind="EmployeePerformanceReport.aspx.cs" Inherits="BankaSpotNew.Branch.EmployeePerformanceReport" %>

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
                                <h4 class="header-title">Employee Performance Report</h4>

                                <%--<div class="row">
                                    <div class="col-lg-6">
                                        <br />
                                        <asp:TextBox ID="txtEmployeeName" CssClass="form-control" placeholder="Enter Employee Name" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-6">
                                        <br />
                                        <asp:TextBox ID="txtMonthYear" CssClass="form-control" placeholder="Enter Month Or Year" runat="server"></asp:TextBox>
                                        <br />
                                        <asp:Button ID="BtnSearch" CssClass="btn btn-success" OnClick="BtnSearch_Click" runat="server" Text="Search" />
                                        
                                    </div>
                                </div>--%>
                                <div class="table-responsive">
                                    <br />
                                    <asp:GridView ID="GridPerformanceReport" CssClass="table table-hover" AutoGenerateColumns="false" runat="server">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="BtnDetail" runat="server" CommandArgument='<%# Eval("Empid") %>' OnClick="BtnDetail_Click" Text="Detail" class="btn btn-primary btn-sm" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="EmployeeName" HeaderText="Employee" />
                                            <%--<asp:BoundField DataField="ProductName" HeaderText=" Product" />--%>
                                            <asp:BoundField DataField="EmpTarget" HeaderText="Monthly Target" />
                                            <asp:BoundField DataField="TargetAchieved" HeaderText="Target Achieved" />
                                            <asp:BoundField DataField="ShortFall" HeaderText=" Target ShortFall" />
                                            <%--<asp:BoundField DataField="ext1" HeaderText=" Month Year" />--%>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>

                            <div class="card" style="float: right; width: 350px;">
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
</asp:Content>
