using GORDON_STORE_BETA.Modelo.Cadastro;
using GORDON_STORE_BETA.Persistencia.DAL.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GORDON_STORE_BETA.Servico.Cadastro
{
    public class ProdutoServico
    {
        private ProdutoDAL produtoDAL = new ProdutoDAL();
        public IQueryable<Produto> ObterProdutosClassificadosPorNome()
        {
            return produtoDAL.ObterProdutosClassificadosPorNome();
        }
        public Produto ObterProdutoPorId(long? id)
        {
            return produtoDAL.ObterProdutoPorId(id);
        }
        public IQueryable<Produto> ObterProdutosClassificadosPorData()
        {
            return produtoDAL.ObterProdutosClassificadosPorData();
        }
        public void GravarProduto(Produto produto)
        {
           produtoDAL.GravarProduto(produto);
        }
        public Produto EliminarProdutoPorId(long id)
        {
            return produtoDAL.EliminarProdutoPorId(id);
        }
        
        
    }
}
