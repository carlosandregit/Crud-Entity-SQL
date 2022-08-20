using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Entity;

namespace WebApplication1.Repository
{
    public class PedidoRepository
    {
        public List<Pedidos> ConsultarPorID(int id)
        {
            using (BDCADASTROEntities context = new BDCADASTROEntities())
            {
                return context.Pedidos.Where(pedido => pedido.CodigoPedido == id).ToList();
            }
        }

        public Pedidos AlterarPorId(int id, DateTime dtPedido, int produto, int qtProduto, int fornecedor, decimal vlrTotalPedido)
        {
            using (BDCADASTROEntities context = new BDCADASTROEntities())
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
            using (BDCADASTROEntities context = new BDCADASTROEntities())
            {
                Pedidos p = context.Pedidos.FirstOrDefault(x => x.CodigoPedido == id);
                context.Pedidos.Remove(p);
                context.SaveChanges();

                return p;
            }
        }

        public Pedidos InserRegistro(Pedidos pedidos)
        {
            using (BDCADASTROEntities context = new BDCADASTROEntities())
            {
                var list = context.Pedidos.ToList();
                var max = 0;

                if (list.Count > 0)
                    max = list.Max(p => p.CodigoPedido);              

                var codigoPedido = max + 1;
                pedidos.Produtos.ForEach(item => {

                    pedidos.Produto = item.Produto.Codigo;
                    pedidos.VlrTotalPedido = item.Quantidade * item.Produto.ValorProduto;
                    pedidos.CodigoPedido = codigoPedido;
                    context.Pedidos.Add(pedidos);
                    context.SaveChanges();
                });             

                return pedidos;
            }
        }

        public List<Pedidos> Consult()
        {
            using (BDCADASTROEntities context = new BDCADASTROEntities())
            {
                return context.Pedidos.ToList();
            }
        }
    }
}