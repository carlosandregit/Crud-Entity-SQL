<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmPedido.aspx.cs" Inherits="WebApplication1.FrmPedido" %>

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
            margin-left: 168px;
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
                    <asp:Label ID="lblProduto" runat="server" Text="Produto:"></asp:Label>
                    <asp:Label ID="lblQtProduto" runat="server" Text="Quantidade de Produtos:"></asp:Label>
                    <asp:Label ID="lblFornecedorPedido" runat="server" Text="Fornecedor:"></asp:Label>
                    <asp:Label ID="lblVlTotalPedido" runat="server" Text="Valor Total do Pedido:"></asp:Label>

                </div>
                <div class="input">
                    <asp:TextBox ID="txtCodigoPedido" runat="server" Width="100px" type="number"></asp:TextBox>
                    <asp:TextBox ID="txtDtPedido" runat="server" Width="100px" Enabled="false"></asp:TextBox>
                    <%--<asp:TextBox ID="txtProduto" runat="server" Width="350px"></asp:TextBox>--%>
                    <asp:DropDownList ID="ddlProduto" runat="server" Width="350px"></asp:DropDownList>
                    <div>
                        <asp:TextBox ID="txtQtProduto" runat="server" Width="100px" type="number" Text="1"></asp:TextBox>
                        <asp:Button ID="btnAdd" runat="server" Text="Adcionar Produto" OnClick="btnAdd_Click" UseSubmitBehavior="false" />
                    </div>                    
                    <%--<asp:TextBox ID="txtFornecedorPedido" runat="server" Width="350px"></asp:TextBox>--%>
                    <asp:DropDownList ID="ddlFornecedorPedido" runat="server" Width="350px"></asp:DropDownList>
                    <asp:TextBox ID="txtVlTotalPedido" runat="server" Width="100px" Enabled="false" Text="0"></asp:TextBox>

                </div>
            </div>
            <div class="btn">
                <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
                <asp:Button ID="btnConsultar" runat="server" Text="Consultar" OnClick="btnConsultar_Click" />
                <asp:Button ID="btnAlterar" runat="server" Text="Alterar" OnClick="btnAlterar_Click" />
                <asp:Button ID="btnDeletar" runat="server" Text="Deletar" OnClick="btnDeletar_Click" />
                <asp:Button ID="btnInserir" runat="server" Text="Inserir" OnClick="btnInserir_Click" />
                <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click" />
            </div>

            <br /><br />
              <div class="grid">
                <asp:GridView ID="gdvGridview" runat="server" AutoGenerateColumns="true" >
                  <%--  <Columns>
                        <asp:BoundField DataField="Codigo" HeaderText="CodigoProduto" ItemStyle-Width="80" ItemStyle-HorizontalAlign="Center"/>
                        <asp:BoundField DataField="Descricao" HeaderText="DescricaoProduto" ItemStyle-Width="80" ItemStyle-HorizontalAlign="Center"/>
                        <asp:BoundField DataField="DtCadastro" HeaderText="DtCadastroProduto" ItemStyle-Width="80" ItemStyle-HorizontalAlign="Center"/>
                        <asp:BoundField DataField="ValorProduto" HeaderText="ValorProduto" ItemStyle-Width="80" ItemStyle-HorizontalAlign="Center"/>                      
                    </Columns> --%>                   
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
