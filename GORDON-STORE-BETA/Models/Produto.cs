using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GORDON_STORE_BETA.Models
{
    public class Produto
    {
        public long ProdutoId { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Qtd { get; set; }
        public long? CategoriaId { get; set; }
        public long? EstudioId { get; set; }
        public Categoria Categoria { get; set; }
        public Estudio Estudio { get; set; }
    }
}