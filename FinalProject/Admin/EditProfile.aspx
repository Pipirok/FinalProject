<%@ Page Title="Edit your profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="FinalProject.Admin.EditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainCont" runat="server">
    <main>
        <div class="container p-5">
            <h1 class="mt-4">Edit your profile</h1>
            <hr />
            <div class="mx-auto" style="max-width: 600px">
                <asp:TextBox ID="TxtUserID" runat="server" CssClass="form-control" Visible="false" />
                <div class="mb-3">
                    <label for="TxtFullName" class="form-label">Full name</label>
                    <asp:TextBox AutoPostBack="true" OnTextChanged="TxtFullName_TextChanged" ID="TxtFullName" runat="server" CssClass="form-control" />
                    <asp:Label runat="server" ID="LblFullNameFlavourText" class="form-text text-danger" Text="" />
                </div>
                <div class="mb-3">
                    <label for="TxtPassword" class="form-label">New password</label>
                    <asp:TextBox AutoPostBack="true" OnTextChanged="TxtPassword_TextChanged" ID="TxtPassword" runat="server" CssClass="form-control" />
                    <asp:Label runat="server" ID="LblPasswordFlavourText" class="form-text text-danger" Text="" />
                </div>
                <div class="mb-3">
                    <label for="TxtPasswordConfirm" class="form-label">New password (repeat)</label>
                    <asp:TextBox AutoPostBack="true" OnTextChanged="TxtPasswordConfirm_TextChanged" ID="TxtPasswordConfirm" runat="server" CssClass="form-control" />
                    <asp:Label runat="server" ID="LblPasswordConfirmFlavourText" class="form-text text-danger" Text="" />
                </div>
                <asp:Button runat="server" Text="Save" CssClass="btn btn-success" ID="BtnSubmit" OnClick="BtnSubmit_Click" />
                <asp:Button runat="server" Text="Delete your profile" CssClass="btn btn-danger" ID="BtnDelete" OnClick="BtnDelete_Click" />
            </div>
        </div>
    </main>
</asp:Content>
