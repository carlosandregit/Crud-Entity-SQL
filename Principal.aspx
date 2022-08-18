<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="WebApplication1.Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Pagina Principal</title>
    <style>
        #princi{
            display: flex;
            justify-content: center;          
           
        }
        body{
            background-color: white;
            width: 100vw;
        }
        #img{
            text-align: center;
        }
        .botoes{
            padding: 0.5rem 1rem;
            margin-left: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       
        <div id="img">
            <img src="img/download.png"/>
        </div>
         <div id="princi">
            <asp:Button ID="btnFornecedor" runat="server" cssClass="botoes" Text="Fornecedor" OnClick="btnFornecedor_Click" Width="200px"/>
            <asp:Button ID="btnProduto" runat="server" cssClass="botoes" Text="Produto" OnClick="btnProduto_Click" Width="200px"/>
            <asp:Button ID="btnPedido" runat="server" cssClass="botoes" Text="Pedidos" OnClick="btnPedido_Click" Width="200px"/>            
        </div>
    </form>
</body>
</html>
