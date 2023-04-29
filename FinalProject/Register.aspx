<%@ Page Title="Register" Language="C#" MasterPageFile="~/PreAdmin.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FinalProject.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-7">
                    <div class="card shadow-lg border-0 rounded-lg mt-5">
                        <div class="card-header">
                            <h3 class="text-center font-weight-light my-4">Create Account</h3>
                        </div>
                        <div class="card-body">
                            <form runat="server">
                                <div class="row mb-3">
                                    <div class="col-md-6">
                                        <div class="form-floating">
                                            <asp:TextBox OnTextChanged="TxtUsername_TextChanged" AutoPostBack="true" runat="server" ID="TxtUsername" CssClass="form-control" />
                                            <label for="TxtUsername">Username</label>
                                            <asp:Label runat="server" ID="LblUsernameFlavourText" CssClass="text-danger" Text="" />
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-floating">
                                            <asp:TextBox OnTextChanged="TxtFullName_TextChanged" AutoPostBack="true" runat="server" ID="TxtFullName" CssClass="form-control" />
                                            <label for="TxtFullName">Full name</label>
                                            <asp:Label runat="server" ID="LblFullNameFlavourText" CssClass="text-danger" Text="" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <div class="col-md-6">
                                        <div class="form-floating mb-3 mb-md-0">
                                            <asp:TextBox OnTextChanged="TxtPassword_TextChanged" AutoPostBack="true" runat="server" ID="TxtPassword" CssClass="form-control" />
                                            <label for="TxtPassword">Password</label>
                                            <asp:Label runat="server" ID="LblPasswordFlavourText" CssClass="text-danger" Text="" />
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-floating mb-3 mb-md-0">
                                            <asp:TextBox OnTextChanged="TxtPasswordConfirm_TextChanged" AutoPostBack="true" runat="server" ID="TxtPasswordConfirm" CssClass="form-control" />
                                            <label for="TxtPasswordConfirm">Confirm Password</label>
                                            <asp:Label runat="server" ID="LblPasswordConfirmFlavourText" CssClass="text-danger" Text="" />
                                        </div>
                                    </div>
                                </div>
                                <div class="mt-4 mb-0">
                                    <div class="d-grid"><asp:Button ID="BtnSubmit" runat="server" CssClass="btn btn-success" Text="Create account" OnClick="BtnSubmit_Click"/></div>
                                </div>
                            </form>
                        </div>
                        <div class="card-footer text-center py-3">
                            <div class="small"><a href="Login.aspx">Have an account? Go to login</a></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
