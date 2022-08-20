using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Repository;

namespace WebApplication1
{
    public partial class FrmProduto : System.Web.UI.Page
    {
        private ProdutoRepository produtoRepository;
     
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Principal.aspx");
        }

        public void Consulta(int id)
        {
            produtoRepository = new ProdutoRepository();
            var result = produtoRepository.ConsultarPorID(id);
           
            if (result != null)
            {
                var date = Convert.ToDateTime(result.DtCadastro).ToString("dd-MM-yyyy");
                txtCodigoProduto.Text = result.Codigo.ToString();
                txtDescricaoProduto.Text = result.Descricao;
                txtDtCadastroProduto.Text = date;
                txtValorProduto.Text = Math.Round(Convert.ToDouble(result.ValorProduto), 3).ToString("N2");        
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Sem Registro') ", true);
                LimparTela();
            }
        }
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            if (txtCodigoProduto.Text != "")
            {
                Consulta(int.Parse(txtCodigoProduto.Text));
            }
            else
                ConsultarSemId();
        }
        protected void ConsultarSemId()
        {
            produtoRepository = new ProdutoRepository();
            var result = produtoRepository.Consult();

            gdvGridview.DataSource = result;
            gdvGridview.DataBind();
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCodigoProduto.Text != "")
            {
                produtoRepository = new ProdutoRepository();
                var result = produtoRepository.AlterarPorId(int.Parse(txtCodigoProduto.Text), txtDescricaoProduto.Text, Convert.ToDateTime(txtDtCadastroProduto.Text), Convert.ToDecimal(txtValorProduto.Text));
                if (result != null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Alterado com sucesso') ", true);
                    Consulta(result.Codigo);
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
            produtoRepository = new ProdutoRepository();

            var result = produtoRepository.DeletarRegistro(int.Parse(txtCodigoProduto.Text));

            if (result != null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Excluido com sucesso') ", true);                
                LimparTela();
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Erro ao excluir') ", true);
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            produtoRepository = new ProdutoRepository();
            var result = produtoRepository.InserRegistro(txtDescricaoProduto.Text,Convert.ToDateTime(txtDtCadastroProduto.Text),Convert.ToDecimal(txtValorProduto.Text));
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
            txtCodigoProduto.Text = string.Empty;
            txtDescricaoProduto.Text = string.Empty;
            txtDtCadastroProduto.Text = string.Empty;
            txtValorProduto.Text = string.Empty;
            gdvGridview.DataSource = null;
            gdvGridview.DataBind();
        }
    }
}