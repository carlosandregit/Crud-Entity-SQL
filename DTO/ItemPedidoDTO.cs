using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Entity;

namespace WebApplication1.DTO
{
    public class ItemPedidoDTO
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}