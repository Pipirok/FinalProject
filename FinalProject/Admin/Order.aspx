<%@ Page Title="View & Edit order" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="FinalProject.Admin.Order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainCont" runat="server">
    <main>
        <div class="container p-5">
            <h1 class="mt-4">Edit an order</h1>
            <hr />
            <div class="mx-auto" style="max-width: 600px">
                <asp:TextBox runat="server" Visible="false" ID="TxtOrderID" />
                <div class="mb-3">
                    <label for="TxtFirstName" class="form-label">Customer first name</label>
                    <asp:TextBox AutoPostBack="true" OnTextChanged="TxtFirstName_TextChanged" ID="TxtFirstName" runat="server" CssClass="form-control" />
                    <asp:Label runat="server" ID="LblFirstNameFlavourText" class="text-danger" Text="" />
                </div>
                <div class="mb-3">
                    <label for="TxtLastName" class="form-label">Customer last name</label>
                    <asp:TextBox AutoPostBack="true" OnTextChanged="TxtLastName_TextChanged" ID="TxtLastName" runat="server" CssClass="form-control" />
                    <asp:Label runat="server" ID="LblLastNameFlavourText" class="form-text text-danger" Text="" />
                </div>
                <div class="mb-3">
                    <label for="TxtLaundryWeight" class="form-label">Laundry weight (kilogramms)</label>
                    <asp:TextBox AutoPostBack="true" OnTextChanged="TxtLaundryWeight_TextChanged" ID="TxtLaundryWeight" TextMode="Number" runat="server" CssClass="form-control" />
                    <asp:Label runat="server" ID="LblLaundryWeightFlavourText" class="form-text text-danger" Text="" />
                </div>
                <div class="mb-3">
                    <label for="TxtOrderDate" class="form-label">Order date</label>
                    <asp:TextBox AutoPostBack="true" OnTextChanged="TxtOrderDate_TextChanged" ID="TxtOrderDate" TextMode="DateTimeLocal" runat="server" CssClass="form-control" />
                    <asp:Label runat="server" ID="LblDateFlavourText" class="form-text text-danger" Text="" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Services</label>
                    <asp:CheckBoxList AutoPostBack="true" ID="CBLServices" runat="server"></asp:CheckBoxList>
                </div>
                <div class="mb-3">
                    <label class="form-label">Status</label>
                    <asp:RadioButtonList AutoPostBack="true" ID="RBLOrderStatus" runat="server">
                        <asp:ListItem Value="1">Pending</asp:ListItem>
                        <asp:ListItem Value="2">Processing</asp:ListItem>
                        <asp:ListItem Value="3">Completed</asp:ListItem>
                        <asp:ListItem Value="4">Cancelled</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <asp:Button runat="server" Text="Save" CssClass="btn btn-success" ID="BtnSubmit" OnClick="BtnSubmit_Click" />
            </div>
        </div>
    </main>
</asp:Content>
