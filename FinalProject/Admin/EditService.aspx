<%@ Page Title="Edit a service" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditService.aspx.cs" Inherits="FinalProject.Admin.EditService" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainCont" runat="server">
    <main>
        <div class="container p-5">
            <h1 class="mt-4">Edit a service</h1>
            <hr />
            <div class="mx-auto" style="max-width: 600px">
                <asp:TextBox ID="TxtOriginalName" runat="server" Visible="false"/>
                <asp:TextBox ID="TxtServiceID" runat="server" Visible="false"/>
                <div class="mb-3">
                    <label for="TxtDisplayName" class="form-label">Service name</label>
                    <asp:TextBox ID="TxtDisplayName" runat="server" CssClass="form-control" />
                    <asp:Label runat="server" ID="LblDisplayNameFlavourText" class="form-text text-danger" Text="" />
                </div>
                <div class="mb-3">
                    <label for="TxtFee" class="form-label">Fee</label>
                    <asp:TextBox ID="TxtFee" TextMode="Number" runat="server" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="TxtDuration" class="form-label">Service duration</label>
                    <asp:TextBox ID="TxtDuration" TextMode="Number" runat="server" CssClass="form-control" />
                </div>
                <asp:Button runat="server" Text="Save" CssClass="btn btn-success" ID="BtnSubmit" OnClick="BtnSubmit_Click" />
                <asp:Label runat="server" ID="LblSubmitFlavourtext" class="form-text text-danger" Text="" />
            </div>
        </div>
    </main>
</asp:Content>
