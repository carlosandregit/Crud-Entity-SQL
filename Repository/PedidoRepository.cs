using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Repository
{
    public class PedidoRepository
    {
        public Pedidos ConsultarPorID(int id)
        {
            using (BDCADASTROEntitiesContext context = new BDCADASTROEntitiesContext())
            {
                return context.Pedidos.Find(id);
            }
        }

        public Pedidos AlterarPorId(int id, DateTime dtPedido, int produto, int qtProduto, int fornecedor, decimal vlrTotalPedido)
        {
            using (BDCADASTROEntitiesContext context = new BDCADASTROEntitiesContext())
            {
                Pedidos p = context.Pedidos.FirstOrDefault(x => x.CodigoPedido == id);
                p.DtPedido = dtPedido;
                p.Produto = produto;
                p.QtProduto = qtProduto;
                p.Fornecedor = fornecedor;
                p.VlrTotalPedido = vlrTotalPedido;
                context.SaveChanges();

                return p;
            }
        }

        public Pedidos DeletarRegistro(int id)
        {
            using (BDCADASTROEntitiesContext context = new BDCADASTROEntitiesContext())
            {
                Pedidos p = context.Pedidos.FirstOrDefault(x => x.CodigoPedido == id);
                context.Pedidos.Remove(p);
                context.SaveChanges();

                return p;
            }
        }

        public Pedidos InserRegistro(DateTime dtPedido, int produto, int qtProduto, int fornecedor, decimal vlrTotalPedido)
        {
            using (BDCADASTROEntitiesContext context = new BDCADASTROEntitiesContext())
            {
                Pedidos p = new Pedidos
                {
                    DtPedido = dtPedido,
                    Produto = produto,
                    QtProduto = qtProduto,
                    Fornecedor = fornecedor,
                    VlrTotalPedido = vlrTotalPedido                 

                };
                context.Pedidos.Add(p);
                context.SaveChanges();

                return p;
            }
        }

        public List<Pedidos> Consult()
        {
            using (BDCADASTROEntitiesContext context = new BDCADASTROEntitiesContext())
            {
                return context.Pedidos.ToList();
            }
        }
    }
}