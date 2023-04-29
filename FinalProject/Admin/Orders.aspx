<%@ Page Title="View all orders" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="FinalProject.Admin.Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainCont" runat="server">
    <main>
        <div class="container-fluid px-4">
            <h1 class="mt-4">Orders</h1>
            <a href="AddOrder.aspx" class="m-2 btn btn-success"><i class="fas fa-plus"></i></a>
            <div class="card mb-4">
                <div class="card-header">
                    <i class="fas fa-table me-1"></i>
                    All orders
                </div>
                <div class="card-body">
                    <asp:ListView OnPagePropertiesChanging="LVOrders_PagePropertiesChanging" runat="server" ID="LVOrders" GroupPlaceholderID="LVOrdersPlaceholder" ItemPlaceholderID="LVOrdersItemPlaceholder">
                        <LayoutTemplate>
                            <table class="table">
                                <thead>
                                    <tr>
                                        <th>Customer Name</th>
                                        <th>Laundry (kg)</th>
                                        <th>Status</th>
                                        <th>Total cost</th>
                                        <th>Date</th>
                                        <th colspan="2">Actions</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:PlaceHolder runat="server" ID="LVOrdersPlaceholder"></asp:PlaceHolder>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <td colspan="8">
                                            <asp:DataPager ID="LVOrdersDataPager" runat="server" PagedControlID="LVOrders" PageSize="10">
                                                <Fields>
                                                    <asp:NextPreviousPagerField ButtonCssClass="btn btn-link" ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true" ShowNextPageButton="false" />
                                                    <asp:NumericPagerField NumericButtonCssClass="btn btn-link" NextPreviousButtonCssClass="btn btn-link" CurrentPageLabelCssClass="btn btn-primary" ButtonType="Link" />
                                                    <asp:NextPreviousPagerField ButtonCssClass="btn btn-link" ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton="false" />
                                                </Fields>
                                            </asp:DataPager>
                                        </td>
                                    </tr>
                                </tfoot>
                            </table>
                        </LayoutTemplate>
                        <GroupTemplate>
                            <tr>
                                <asp:PlaceHolder runat="server" ID="LVOrdersItemPlaceholder"></asp:PlaceHolder>
                            </tr>
                        </GroupTemplate>
                        <ItemTemplate>
                            <td><%#Eval("CustomerName") + " " + Eval("CustomerSurname") %></td>
                            <td><%#Eval("LaundryWeight") %> kg</td>
                            <td><%#Eval("Status") %></td>
                            <td><%#Eval("TotalCost") %></td>
                            <td><%#DateTime.Parse(Eval("OrderDate").ToString()).ToLongDateString() %> <%#DateTime.Parse(Eval("OrderDate").ToString()).ToShortTimeString() %></td>
                            <td><a class="btn btn-info" href='/Admin/Order.aspx?id=<%#Eval("OrderID")%>'><i class="fas fa-eye"></i></a></td>
                            <td>
                                <asp:LinkButton ID="BtnDelete" runat="server" OnClick="BtnDelete_Click" CssClass="btn btn-danger" CommandArgument='<%#Eval("OrderID") %>' ><i class='fas fa-trash'></i></asp:LinkButton></td>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
