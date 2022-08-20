using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Repository;

namespace WebApplication1
{
    public partial class FrmPedido : System.Web.UI.Page
    {
        private PedidoRepository pedidoRepository;
        private FornecedorRepository fornecedorRepository;
        private ProdutoRepository produtoRepository;
        private static Pedidos pedidos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDtPedido.Text = DateTime.Now.ToString("dd-MM-yyyy");
                fornecedorRepository = new FornecedorRepository();
                produtoRepository = new ProdutoRepository();

                 fornecedorRepository.Consult().ForEach(fornecedor => {
                     ddlFornecedorPedido.Items.Add(new ListItem(fornecedor.NomeContato.ToString(), fornecedor.IdFornecedor.ToString()));
                 });

                produtoRepository.Consult().ForEach(produto => {
                    ddlProduto.Items.Add(new ListItem(produto.Descricao.ToString(), produto.Codigo.ToString()));
                });

                if (pedidos == null)
                    pedidos = new Pedidos();
            }

            
        }
        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Principal.aspx");
        }
        public void Consulta(int id)
        {
            pedidoRepository = new PedidoRepository();
            var result = pedidoRepository.ConsultarPorID(id);

            if (result != null)
            {
                txtCodigoPedido.Text = result.CodigoPedido.ToString();
                txtDtPedido.Text =  result.DtPedido.ToString();
                //txtProduto.Text = result.Produto.ToString();
                txtQtProduto.Text = result.QtProduto.ToString();
                //txtFornecedorPedido.Text = result.Fornecedor.ToString();
                txtVlTotalPedido.Text = result.VlrTotalPedido.ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Sem Registro') ", true);
                LimparTela();
            }

        }        

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            if (txtCodigoPedido.Text != "")
            {
                Consulta(int.Parse(txtCodigoPedido.Text));
            }
            else
                ConsultarSemId();
        }

        protected void ConsultarSemId()
        {
            pedidoRepository = new PedidoRepository();
            var result = pedidoRepository.Consult();

            gdvGridview.DataSource = result;
            gdvGridview.DataBind();
        }
        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCodigoPedido.Text != "")
            {
                pedidoRepository = new PedidoRepository();
                var result = pedidoRepository.AlterarPorId(int.Parse(txtCodigoPedido.Text), Convert.ToDateTime(txtDtPedido.Text), int.Parse(ddlProduto.SelectedValue), int.Parse(txtQtProduto.Text), int.Parse(ddlFornecedorPedido.SelectedValue), Convert.ToDecimal(txtVlTotalPedido.Text));
                if (result != null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Alterado com sucesso') ", true);
                    Consulta(result.CodigoPedido);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Erro ao alterar') ", true);
                    LimparTela();
                }
            }
        }

        protected void btnDeletar_Click(object sender, EventArgs e)
        {
            pedidoRepository = new PedidoRepository();

            var result = pedidoRepository.DeletarRegistro(int.Parse(txtCodigoPedido.Text));

            if (result != null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Erro ao excluir') ", true);
                LimparTela();
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Excluido com sucesso') ", true);
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            pedidoRepository = new PedidoRepository();
            pedidos.DtPedido = Convert.ToDateTime(txtDtPedido.Text);
            pedidos.QtProduto = int.Parse(txtQtProduto.Text);
            pedidos.Fornecedor1 = new Fornecedor() { IdFornecedor = Convert.ToInt32( ddlFornecedorPedido.SelectedValue)};
    
            var result = pedidoRepository.InserRegistro(pedidos);
            if (result != null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Inserido com sucesso') ", true);
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Erro ao inserir') ", true);
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparTela();
        }

        public void LimparTela()
        {
            txtCodigoPedido.Text = " ";
            txtDtPedido.Text = " ";
            ddlFornecedorPedido.SelectedIndex = -1;
            txtQtProduto.Text = " ";
            ddlProduto.SelectedIndex = -1;
            txtVlTotalPedido.Text = " ";
          
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            produtoRepository = new ProdutoRepository();
            var produto = produtoRepository.ConsultarPorID(Convert.ToInt32(ddlProduto.SelectedValue));
            var quantidade = int.Parse(txtQtProduto.Text);
            var subtotal = Convert.ToDecimal(txtVlTotalPedido.Text) + quantidade * produto.ValorProduto;
            txtVlTotalPedido.Text = subtotal.ToString();
            pedidos.Produtos.Add(new DTO.ItemPedidoDTO() { Produto = produto, Quantidade = quantidade});

        }
    }
}