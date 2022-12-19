using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo.Cadastro;

namespace GORDON_STORE_ALPHA.Models.ViewModels
{
    public class HomeClass
    {
        public IQueryable<Produto> listaProdutoLancamento;
        public IQueryable<Produto> listaprodutos;
    }
}