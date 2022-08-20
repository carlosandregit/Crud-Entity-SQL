<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmProduto.aspx.cs" Inherits="WebApplication1.FrmProduto" %>

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
            margin-left: 126px;
        }
    </style>
    <script>
        function mascaraData(val) {
            var pass = val.value;
            var expr = /[0123456789]/;

            for (i = 0; i < pass.length; i++) {
                // charAt -> retorna o caractere posicionado no índice especificado
                var lchar = val.value.charAt(i);
                var nchar = val.value.charAt(i + 1);

                if (i == 0) {
                    // search -> retorna um valor inteiro, indicando a posição do inicio da primeira
                    // ocorrência de expReg dentro de instStr. Se nenhuma ocorrencia for encontrada o método retornara -1
                    // instStr.search(expReg);
                    if ((lchar.search(expr) != 0) || (lchar > 3)) {
                        val.value = "";
                    }

                } else if (i == 1) {

                    if (lchar.search(expr) != 0) {
                        // substring(indice1,indice2)
                        // indice1, indice2 -> será usado para delimitar a string
                        var tst1 = val.value.substring(0, (i));
                        val.value = tst1;
                        continue;
                    }

                    if ((nchar != '-') && (nchar != '')) {
                        var tst1 = val.value.substring(0, (i) + 1);

                        if (nchar.search(expr) != 0)
                            var tst2 = val.value.substring(i + 2, pass.length);
                        else
                            var tst2 = val.value.substring(i + 1, pass.length);

                        val.value = tst1 + '-' + tst2;
                    }

                } else if (i == 4) {

                    if (lchar.search(expr) != 0) {
                        var tst1 = val.value.substring(0, (i));
                        val.value = tst1;
                        continue;
                    }

                    if ((nchar != '-') && (nchar != '')) {
                        var tst1 = val.value.substring(0, (i) + 1);

                        if (nchar.search(expr) != 0)
                            var tst2 = val.value.substring(i + 2, pass.length);
                        else
                            var tst2 = val.value.substring(i + 1, pass.length);

                        val.value = tst1 + '-' + tst2;
                    }
                }

                if (i >= 6) {
                    if (lchar.search(expr) != 0) {
                        var tst1 = val.value.substring(0, (i));
                        val.value = tst1;
                    }
                }
            }

            if (pass.length > 10)
                val.value = val.value.substring(0, 10);
            return true;
        }
    </script>
</head>
<body>
    <header>
        <h1>Produto</h1>
    </header>
    <form id="form1" runat="server">
        <div class="center">
            <div class="pricipal">
                <div class="label">
                    <asp:Label ID="lblCodigo" runat="server" Text="Código:"></asp:Label>
                    <asp:Label ID="lblDescricao" runat="server" Text="Descrição:"></asp:Label>
                    <asp:Label ID="lblDtCadastro" runat="server" Text="Data do Cadastro:"></asp:Label>
                    <asp:Label ID="lblValor" runat="server" Text="Valor do Produto:"></asp:Label>

                </div>
                <div class="input">
                    <asp:TextBox ID="txtCodigoProduto" runat="server" Width="100px" type="number"></asp:TextBox>
                    <asp:TextBox ID="txtDescricaoProduto" runat="server" Width="350px"></asp:TextBox>
                    <asp:TextBox ID="txtDtCadastroProduto" runat="server" Width="100px" maxlength="10" onkeypress="mascaraData(this)" Enabled="false"></asp:TextBox>
                    <asp:TextBox ID="txtValorProduto" runat="server" Width="100px"></asp:TextBox>

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
                                        
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
