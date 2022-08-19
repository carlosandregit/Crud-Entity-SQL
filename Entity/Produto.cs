using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Entites
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string DtCadastro { get; set; }
        public string ValorProduto { get; set; }
    }
}