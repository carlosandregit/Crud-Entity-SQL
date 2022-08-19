using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Entites
{
    public class Pedido
    {      
        public int CodigoPedido { get; set; }
        public string DtPedido { get; set; }
        public int Produto { get; set; }
        public int QtProduto { get; set; }
        public string Fornecedor { get; set; }
        public int VlrTotalPedido { get; set; }
    }
}