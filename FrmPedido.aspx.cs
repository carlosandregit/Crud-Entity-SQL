using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Entity;
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
                     if(fornecedor.NomeContato != null)
                        ddlFornecedorPedido.Items.Add(new ListItem(fornecedor.NomeContato.ToString(), fornecedor.IdFornecedor.ToString()));
                 });

                produtoRepository.Consult().ForEach(produto => {
                    if(produto.Descricao != null)
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
            try
            {
               
                pedidoRepository = new PedidoRepository();
                var result = pedidoRepository.ConsultarPorID(id);

                if (result != null)
                {                  
                    gdvGridview.DataSource = result;
                    gdvGridview.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Sem Registro') ", true);
                    LimparTela();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro, procure a equipe técnica: " + ex.Message);
            }
        }        

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigoPedido.Text != "")
                {
                    Consulta(int.Parse(txtCodigoPedido.Text));
                }
                else
                    ConsultarSemId();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro, procure a equipe técnica: " + ex.Message);
            }
        }

        protected void ConsultarSemId()
        {
            try
            {
                pedidoRepository = new PedidoRepository();
                var result = pedidoRepository.Consult();

                gdvGridview.DataSource = result;
                gdvGridview.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro, procure a equipe técnica: " + ex.Message);
            }
        }
        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            try
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
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('É precisa informar código do pedido') ", true);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro, procure a equipe técnica: " + ex.Message);
            }
        }

        protected void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigoPedido.Text != "")
                {
                    pedidoRepository = new PedidoRepository();

                    var result = pedidoRepository.DeletarRegistro(int.Parse(txtCodigoPedido.Text));

                    if (result != null)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Excluido com sucesso') ", true);
                        LimparTela();
                    }
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Erro ao excluir') ", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('É precisa informar o código do pedido') ", true);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro, procure a equipe técnica: " + ex.Message);
            }
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                pedidoRepository = new PedidoRepository();
                pedidos.DtPedido = Convert.ToDateTime(txtDtPedido.Text);
                pedidos.QtProduto = int.Parse(txtQtProduto.Text);
                pedidos.Fornecedor = Convert.ToInt32(ddlFornecedorPedido.SelectedValue);

                var result = pedidoRepository.InserRegistro(pedidos);
                if (result != null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Inserido com sucesso') ", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Erro ao inserir') ", true);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro, procure a equipe técnica: " + ex.Message);
            }
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparTela();
        }

        public void LimparTela()
        {
            txtCodigoPedido.Text = string.Empty;
            txtDtPedido.Text = DateTime.Now.ToString("dd-MM-yyyy");
            ddlFornecedorPedido.SelectedIndex = -1;
            txtQtProduto.Text = "1";
            ddlProduto.SelectedIndex = -1;
            txtVlTotalPedido.Text = "0";
            gdvGridview.DataSource = null;
            gdvGridview.DataBind();
            if(pedidos != null)
            {
                pedidos.Produtos.Clear();
            }                    
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.ConsultarPorID(Convert.ToInt32(ddlProduto.SelectedValue));
                var quantidade = int.Parse(txtQtProduto.Text);
                var subtotal = Convert.ToDecimal(txtVlTotalPedido.Text) + quantidade * produto.ValorProduto;
                txtVlTotalPedido.Text = Math.Round(Convert.ToDouble(subtotal)).ToString("N2");
                pedidos.Produtos.Add(new DTO.ItemPedidoDTO() { Produto = produto, Quantidade = quantidade });
            }
            catch (Exception ex)
            {
                throw new Exception("Erro, procure a equipe técnica: "+ ex.Message);
            }           
        }
    }
}