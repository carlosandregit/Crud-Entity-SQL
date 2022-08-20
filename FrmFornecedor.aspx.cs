using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Repository;

namespace WebApplication1
{
    public partial class FrmFornecedor : System.Web.UI.Page
    {
        private FornecedorRepository fornecedorRepository;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Principal.aspx");
        }

        public void Consulta(int id)
        {
            try
            {
                fornecedorRepository = new FornecedorRepository();
                var result = fornecedorRepository.ConsultarPorID(id);

                if (result != null)
                {
                    txtIdFornecedor.Text = result.IdFornecedor.ToString();
                    txtRazaoSocial.Text = result.RazaoSocial;
                    txtCNPJ.Text = result.CNPJ.ToString();
                    txtUF.Text = result.UF.ToString();
                    txtEmail.Text = result.EmailContato.ToString();
                    txtNomeContato.Text = result.NomeContato.ToString();

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
                if (txtIdFornecedor.Text != "")
                    Consulta(int.Parse(txtIdFornecedor.Text));
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
                fornecedorRepository = new FornecedorRepository();
                var result = fornecedorRepository.Consult();

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
                if (txtIdFornecedor.Text != "")
                {
                    fornecedorRepository = new FornecedorRepository();
                    var result = fornecedorRepository.AlterarPorId(int.Parse(txtIdFornecedor.Text), txtRazaoSocial.Text, txtCNPJ.Text, txtUF.Text, txtEmail.Text, txtNomeContato.Text);
                    if (result != null)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Alterado com sucesso') ", true);
                        Consulta(result.IdFornecedor);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Erro ao alterar') ", true);
                        LimparTela();
                    }
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('É preciso informar o ID Fornecedor e consultar para carregar as informações') ", true);
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
                if (txtIdFornecedor.Text != "")
                {
                    fornecedorRepository = new FornecedorRepository();
                    var result = fornecedorRepository.DeletarRegistro(int.Parse(txtIdFornecedor.Text));

                    if (result != null)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Excluido com sucesso') ", true);

                        LimparTela();
                    }
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Erro ao excluir') ", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Precisa Informa o ID fornecedor e consultar para carregar as informações') ", true);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro, procure a equipe técnica: " + ex.Message);
            }
        }

        protected void Inserir_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRazaoSocial.Text != "" && txtCNPJ.Text != "" && txtUF.Text != "" && txtEmail.Text != "" && txtNomeContato.Text != "")
                {
                    fornecedorRepository = new FornecedorRepository();
                    var result = fornecedorRepository.InserRegistro(txtRazaoSocial.Text, txtCNPJ.Text, txtUF.Text, txtEmail.Text, txtNomeContato.Text);
                    if (result != null)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Inserido com sucesso') ", true);
                        Consulta(result.IdFornecedor);
                    }
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Erro ao inserir') ", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('É necessário preencher os campos, menos o ID fornecedor') ", true);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro, procure a equipe técnica: " + ex.Message);
            }
        }

        protected void Limpar_Click(object sender, EventArgs e)
        {
            LimparTela();
        }

        public void LimparTela()
        {
            txtIdFornecedor.Text = string.Empty;
            txtRazaoSocial.Text = string.Empty;
            txtCNPJ.Text = string.Empty;
            txtUF.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtNomeContato.Text = string.Empty;
            gdvGridview.DataSource = null;
            gdvGridview.DataBind();
        }
    }
}