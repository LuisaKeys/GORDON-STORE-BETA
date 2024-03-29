﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GORDON_STORE_BETA.Persistencia.Context;
using System.Data.Entity;
using GORDON_STORE_BETA.Modelo.Cadastro;
using System.Net;


namespace GORDON_STORE_BETA.Persistencia.DAL.Cadastros
{
    public class ProdutoDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Produto> ObterProdutosClassificadosPorNome()
        {
            return context.Produtos.Include(c => c.Categoria).Include(f => f.Estudio).
            OrderBy(n => n.Nome);
        }
        public IQueryable<Produto> ObterProdutosClassificadosPorData()
        {
            var lancamento = DateTime.Today.AddMonths(-1);
            return context.Produtos.Where(p => p.DataCadastro >= lancamento).Include(c => c.Categoria).Include(f => f.Estudio).OrderBy(n => n.Nome);
        }
        public Produto ObterProdutoPorId(long? id)
        {
            return context.Produtos.Where(p => p.ProdutoId == id).Include(c => c.Categoria).
            Include(f => f.Estudio).First();
        }
        public void GravarProduto(Produto produto)
        {
            if (produto.ProdutoId == null)
            {
                context.Produtos.Add(produto);
            }
            else
            {
                context.Entry(produto).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Produto EliminarProdutoPorId(long id)
        {
            Produto produto = ObterProdutoPorId(id);
            context.Produtos.Remove(produto);
            context.SaveChanges();
            return produto;
        }
        
    }
}
