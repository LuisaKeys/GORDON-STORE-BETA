using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GORDON_STORE_BETA.Modelo.Cadastro;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GORDON_STORE_BETA.Modelo.Tabelas
{
    public class Categoria
    {
        [DisplayName("Categoria")]
        public long CategoriaId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}