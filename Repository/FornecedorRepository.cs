using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Repository
{
    public class FornecedorRepository
    {
        public Fornecedor ConsultarPorID(int id)
        {
            using (var context = new ProjetoContext())
            {
              return  context.Fornecedor.Find(id);
            }
        }
    }
}