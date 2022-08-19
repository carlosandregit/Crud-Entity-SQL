using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Repository;

namespace WebApplication1
{
    public partial class Fornecedor : System.Web.UI.Page
    {
        private FornecedorRepository fornecedorRepository;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Principal.aspx");
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            fornecedorRepository = new FornecedorRepository();
            var result = fornecedorRepository.ConsultarPorID(int.Parse("1"));
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {

        }

        protected void btnDeletar_Click(object sender, EventArgs e)
        {

        }
    }
}