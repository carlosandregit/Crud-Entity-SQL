using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Entity;

namespace WebApplication1.Repository
{
    public class ProdutoRepository
    {
        public Produto ConsultarPorID(int id)
        {
            using (BDCADASTROEntities context = new BDCADASTROEntities())
            {
                return context.Produto.Find(id);
            }
        }

        public Produto AlterarPorId(int id, string descricao, DateTime dtCadastro, decimal valorProduto)
        {
            using (BDCADASTROEntities context = new BDCADASTROEntities())
            {
                //Produto p = context.Produto.FirstOrDefault(x => x.Codigo == id);
                var tese = Convert.ToDecimal(valorProduto).ToString("f");
                Produto p = new Produto
                {
                    Codigo = id,
                    Descricao = descricao,
                    DtCadastro = dtCadastro,
                    ValorProduto = valorProduto

                };

                context.Produto.Add(p);
                context.Entry(p).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();          
                return p;
            }
        }

        public Produto DeletarRegistro(int id)
        {
            using (BDCADASTROEntities context = new BDCADASTROEntities())
            {
                Produto p = context.Produto.FirstOrDefault(x => x.Codigo == id);
                context.Produto.Remove(p);
                context.SaveChanges();

                return p;
            }
        }

        public Produto InserRegistro(string descricao, DateTime dtCadastro, decimal valorProduto)
        {
            using (BDCADASTROEntities context = new BDCADASTROEntities())
            {
                Produto p = new Produto
                {
                    Descricao = descricao,
                    DtCadastro = dtCadastro,
                    ValorProduto = valorProduto

                };
                context.Produto.Add(p);
                context.SaveChanges();

                return p;
            }
        }

        public List<Produto> Consult()
        {
            using (BDCADASTROEntities context = new BDCADASTROEntities())
            {
                return context.Produto.ToList();
            }
        }
    }
}