<%@ Page Title="Dashboard - Laundrie" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="FinalProject.Admin.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainCont" runat="server">
    <main>
        <div class="container-fluid px-4">
            <h1 class="mt-4">Dashboard</h1>
            <ol class="breadcrumb mb-4">
                <li class="breadcrumb-item active">Dashboard</li>
            </ol>
            <div class="row">
                <div class="col-xl-3 col-md-6">
                    <div class="card bg-primary text-white mb-4">
                        <div class="card-body">
                            <h4 class="h4">Total orders</h4>
                            <asp:Label CssClass="text-center h2" runat="server" ID="LblTotalOrders"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="col-xl-3 col-md-6">
                    <div class="card bg-warning text-white mb-4">
                        <div class="card-body">
                            
                            <h4 class="h4">Pending orders</h4>
                            <asp:Label CssClass="text-center h2" runat="server" ID="LblPendingOrders"></asp:Label>
                        </div>
                        
                    </div>
                </div>
                <div class="col-xl-3 col-md-6">
                    <div class="card bg-success text-white mb-4">
                        <div class="card-body">
                            <h4 class="h4">Completed orders</h4>
                            <asp:Label CssClass="text-center h2" runat="server" ID="LblCompletedOrders"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="col-xl-3 col-md-6">
                    <div class="card bg-danger text-white mb-4">
                        <div class="card-body">
                            <h4 class="h4">Cancelled orders</h4>
                            <asp:Label CssClass="text-center h2" runat="server" ID="LblCancelledOrders"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="card mb-4">
                <div class="card-header">
                    <i class="fas fa-table me-1"></i>
                    Most recent orders
                </div>
                <div class="card-body">
                    <asp:DataList runat="server" ID="DLRecentOrders" CssClass="table">
                        <HeaderTemplate>
                            <th>Customer Name</th>
                            <th>Laundry (kg)</th>
                            <th>Status</th>
                            <th>Total cost</th>
                            <th>Actions</th>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <td><%#Eval("CustomerName") + " " + Eval("CustomerSurname") %></td>
                            <td><%#Eval("LaundryWeight") %> kg</td>
                            <td><%#Eval("Status") %></td>
                            <td><%#Eval("TotalCost") %></td>
                            <td><a class="btn btn-info" href='/Admin/Order.aspx?id=<%#Eval("OrderID")%>'><i class="fas fa-eye"></i></a></td>
                        </ItemTemplate>
                        <FooterTemplate>
                            <th>Customer Name</th>
                            <th>Laundry (kg)</th>
                            <th>Status</th>
                            <th>Total cost</th>
                            <th>Actions</th>
                        </FooterTemplate>
                    </asp:DataList>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
