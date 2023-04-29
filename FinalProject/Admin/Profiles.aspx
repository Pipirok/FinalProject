<%@ Page Title="View all profiles" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profiles.aspx.cs" Inherits="FinalProject.Admin.Profiles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainCont" runat="server">
    <main>
        <div class="container-fluid px-4">
            <h1 class="mt-4">Users</h1>
            <p>Edit your profile <a href="/Admin/EditProfile.aspx" class="m-2 btn btn-warning"><i class="fas fa-pencil"></i></a></p>
            <div class="card mb-4">
                <div class="card-header">
                    <i class="fas fa-table me-1"></i>
                    All Users
                </div>
                <div class="card-body">
                    <asp:ListView OnPagePropertiesChanging="LVUsers_PagePropertiesChanging" runat="server" ID="LVUsers" GroupPlaceholderID="LVUsersPlaceholder" ItemPlaceholderID="LVUsersItemPlaceholder">
                        <LayoutTemplate>
                            <table class="table">
                                <thead>
                                    <tr>
                                        <th>Username</th>
                                        <th>Full name</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:PlaceHolder runat="server" ID="LVUsersPlaceholder"></asp:PlaceHolder>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <td>
                                            <asp:DataPager ID="LVUsersDataPager" runat="server" PagedControlID="LVUsers" PageSize="10">
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
                                <asp:PlaceHolder runat="server" ID="LVUsersItemPlaceholder"></asp:PlaceHolder>
                            </tr>
                        </GroupTemplate>
                        <ItemTemplate>
                            <td><%#Eval("UserName")%></td>
                            <td><%#Eval("FullName")%></td>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
