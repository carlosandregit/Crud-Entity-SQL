<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Produto.aspx.cs" Inherits="WebApplication1.Produto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Produto</title>
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
            height: 15vh;
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
            margin-left: 7px;
        }
    </style>
</head>
<body>
    <header>
        <h1>Produto</h1>
    </header>
    <form id="form1" runat="server">
        <div class="center">
            <div class="pricipal">
                <%--Código, Descrição, Data do Cadastro, Valor do Produto--%>
                <div class="label">
                    <asp:Label ID="lblCodigo" runat="server" Text="Código:"></asp:Label>
                    <asp:Label ID="lblDescricao" runat="server" Text="Descrição:"></asp:Label>
                    <asp:Label ID="lblDtCadastro" runat="server" Text="Data do Cadastro:"></asp:Label>
                    <asp:Label ID="lblValor" runat="server" Text="Valor do Produto:"></asp:Label>

                </div>
                <div class="input">
                    <asp:TextBox ID="txtCodigoProduto" runat="server" Width="350px"></asp:TextBox>
                    <asp:TextBox ID="txtDescricaoProduto" runat="server" Width="100px"></asp:TextBox>
                    <asp:TextBox ID="txtDtCadastroProduto" runat="server" Width="40px"></asp:TextBox>
                    <asp:TextBox ID="txtValorProduto" runat="server" Width="350px"></asp:TextBox>

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
