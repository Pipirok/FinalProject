<%@ Page Title="View all services" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Services.aspx.cs" Inherits="FinalProject.Admin.Services" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainCont" runat="server">
     <main>
        <div class="container-fluid px-4">
            <h1 class="mt-4">Services</h1>
            <a href="AddService.aspx" class="m-2 btn btn-success"><i class="fas fa-plus"></i></a>
            <div class="card mb-4">
                <div class="card-header">
                    <i class="fas fa-table me-1"></i>
                    All services
                </div>
                <div class="card-body">
                    <asp:ListView OnPagePropertiesChanging="LVServices_PagePropertiesChanging" runat="server" ID="LVServices" GroupPlaceholderID="LVServicesPlaceholder" ItemPlaceholderID="LVServicesItemPlaceholder">
                        <LayoutTemplate>
                            <table class="table">
                                <thead>
                                    <tr>
                                        <th>Service name</th>
                                        <th>Fee</th>
                                        <th>Duration (in minutes)</th>
                                        <th colspan="2">Actions</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:PlaceHolder runat="server" ID="LVServicesPlaceholder"></asp:PlaceHolder>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <td colspan="5">
                                            <asp:DataPager ID="LVServicesDataPager" runat="server" PagedControlID="LVServices" PageSize="10">
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
                                <asp:PlaceHolder runat="server" ID="LVServicesItemPlaceholder"></asp:PlaceHolder>
                            </tr>
                        </GroupTemplate>
                        <ItemTemplate>
                            <td><%#Eval("DisplayName") %></td>
                            <td><%#Eval("Fee") %></td>
                            <td><%#Eval("Duration") %></td>
                            <td><a class="btn btn-warning" href='/Admin/EditService.aspx?id=<%#Eval("ServiceID")%>'><i class="fas fa-pencil"></i></a></td>
                            <td><asp:LinkButton ID="BtnDelete" runat="server" OnClick="BtnDelete_Click" CssClass="btn btn-danger" CommandArgument='<%#Eval("ServiceID") %>' ><i class='fas fa-trash'></i></asp:LinkButton></td>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
