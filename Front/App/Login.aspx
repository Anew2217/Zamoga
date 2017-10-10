<%@ Page Title="" Language="C#" MasterPageFile="~/App/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Front.App.Login" Async="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <h1>Synthentic Financial Manager System For Fraud Transactions</h1>
        <div>
            <div class="form-group">
                <asp:Label runat="server">Usuario: </asp:Label>
                <asp:TextBox runat="server" ID="user"/>                  
            </div>
            <div class="form-group">
                <asp:Label runat="server">Contraseña: </asp:Label>
                <asp:TextBox runat="server" ID="pass" type="password"/>                  
            </div>
        </div>
        <div>
            <asp:Button runat="server" class="btn btn-primary" Text="Ingresar" OnClick="ValidarUsuario"/>
        </div>
        <div>
            <asp:Label runat="server" ID="result"></asp:Label>
        </div>
    </div>

    <div class="text-center">
        <asp:Label runat="server" ID="Error" Visible="false" Style="color:red"></asp:Label>
    </div>

</asp:Content>
