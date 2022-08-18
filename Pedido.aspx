<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pedido.aspx.cs" Inherits="WebApplication1.Pedido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Pedidos</title>
    <style>
        body {
            background-color: white;
            width: 100vw;
            height: 100vh;
        }

        h1 {
            text-align: center;
        }

        .center {
            display: flex;
            justify-content: center;
            flex-direction: column;
            align-items: center;
        }

        .pricipal {
            display: flex;
            flex-direction: row;
            height: 25vh;
        }

        .label {
            display: flex;
            justify-content: space-between;
            flex-direction: column;
        }

        .input {
            display: flex;
            justify-content: space-between;
            flex-direction: column;           
        }

        .btn {
            padding: 0.3rem 0.5rem;
            margin-left: 49px;
        }
    </style>
</head>
<body>
    <header>
        <h1>Pedidos</h1>
    </header>
    <form id="form1" runat="server">
        <div class="center">
            <div class="pricipal">
                <%--Código do pedido, Data do pedido,Produto, Quantidade de Produtos, Fornecedor, Valor Total do Pedido;--%>
                <div class="label">
                    <asp:Label ID="lblCodigoPedido" runat="server" Text="Código do pedido:"></asp:Label>
                    <asp:Label ID="lblDtPedido" runat="server" Text="Data do pedido:"></asp:Label>
                    <asp:Label ID="lblProdutoPedido" runat="server" Text="Produto:"></asp:Label>
                    <asp:Label ID="lblDtProduto" runat="server" Text="Quantidade de Produtos:"></asp:Label>
                    <asp:Label ID="lblFornecedorPedido" runat="server" Text="Fornecedor:"></asp:Label>
                    <asp:Label ID="lblVlTotalPedido" runat="server" Text="Valor Total do Pedido:"></asp:Label>

                </div>
                <div class="input">
                    <asp:TextBox ID="txtCodigoPedido" runat="server" Width="100px"></asp:TextBox>
                    <asp:TextBox ID="txtDtPedido" runat="server" Width="100px"></asp:TextBox>
                    <asp:TextBox ID="txtDtCadastroProduto" runat="server" Width="350px"></asp:TextBox>
                    <asp:TextBox ID="txtProdutoPedido" runat="server" Width="100px"></asp:TextBox>
                    <asp:TextBox ID="txtFornecedorPedido" runat="server" Width="350px"></asp:TextBox>
                    <asp:TextBox ID="txtVlTotalPedido" runat="server" Width="100px"></asp:TextBox>

                </div>
            </div>
            <div class="btn">
                <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
                <asp:Button ID="btnConsultar" runat="server" Text="Consultar" OnClick="btnConsultar_Click" />
                <asp:Button ID="btnAlterar" runat="server" Text="Alterar" OnClick="btnAlterar_Click" />
                <asp:Button ID="btnDeletar" runat="server" Text="Deletar" OnClick="btnDeletar_Click" />
            </div>
        </div>
    </form>
</body>
</html>
