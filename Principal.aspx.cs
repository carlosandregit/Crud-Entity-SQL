using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFornecedor_Click(object sender, EventArgs e)
        {
            Response.Redirect("Fornecedor.aspx");
        }

        protected void btnProduto_Click(object sender, EventArgs e)
        {
            Response.Redirect("Produto.aspx");
        }

        protected void btnPedido_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pedido.aspx");
        }
    }
}