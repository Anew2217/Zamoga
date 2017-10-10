<%@ Page Title="" Language="C#" MasterPageFile="~/App/Master.Master" AutoEventWireup="true" CodeBehind="Transactions.aspx.cs" Inherits="Front.App.Transactions" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel class="container" runat="server" ID="p1" Visible="false">
        <h1>New bank Transaction</h1>

        <div class="form-group">
            <asp:Label runat="server">Name:</asp:Label>
            <asp:TextBox class="form-control" runat="server" ID="txtName"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label runat="server">Date:</asp:Label>
            <asp:TextBox class="form-control" runat="server" ID="txtDate"></asp:TextBox>
        </div>
        
        <div>
            <asp:Button runat="server" Text="Save" class="btn btn-primary" OnClick="SaveUserAsync"/>
        </div>

        <asp:Label runat="server" ID="respuesta"></asp:Label>
    </asp:Panel>

    <asp:Panel runat="server" ID="p2" class="container" Visible="false">
        <h1>Busqueda</h1>

        <div>
            <label>Buscar por:</label>
            <asp:DropDownList runat="server" ID="Criterio">
                <asp:ListItem Value="2">NameDest</asp:ListItem>
                <asp:ListItem Value="3">TransactionDate</asp:ListItem>
                <asp:ListItem Value="4">IsFraud</asp:ListItem>
            </asp:DropDownList>            

            <asp:TextBox runat="server" ID="txtBuscar"></asp:TextBox>
        </div>
        <div>
            <asp:Button runat="server" OnClick="Buscar" Text="Buscar" class="btn btn-primary"/>
        </div>
        
        <asp:GridView runat="server" ID="Tabla">            
        </asp:GridView>

    </asp:Panel>
</asp:Content>
