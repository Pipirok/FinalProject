<%@ Page Title="Login!" Language="C#" AutoEventWireup="true" MasterPageFile="~/PreAdmin.Master" CodeBehind="Login.aspx.cs" Inherits="FinalProject.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-5">
                    <div class="card shadow-lg border-0 rounded-lg mt-5">
                        <div class="card-header">
                            <h3 class="text-center font-weight-light my-4">Login</h3>
                        </div>
                        <div class="card-body">
                            <form id="form1" runat="server">
                                <asp:Label runat="server" ID="LblFlavourText" Text="" CssClass="text-danger" />
                                <div class="form-floating mb-3">
                                    <asp:TextBox runat="server" ID="TxtUsername" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                    <label for="TxtUsername">Username</label>
                                </div>
                                <div class="form-floating mb-3">
                                    <asp:TextBox runat="server" ID="TxtPassword" TextMode="Password" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                    <label for="TxtPassword">Password</label>
                                </div>
                                <div class="d-flex align-items-center justify-content-between mt-4 mb-0">
                                    <asp:Button runat="server" ID="BtnLogin" CssClass="btn btn-primary" OnClick="BtnLogin_Click" Text="Login" />
                                </div>
                            </form>
                        </div>
                        <div class="card-footer text-center py-3">
                            <div class="small"><a href="/Register.aspx">Need an account? Sign up!</a></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
