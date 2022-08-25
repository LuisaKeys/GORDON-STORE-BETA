using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo.Tabelas;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Cadastro
{
    public class Estudio
    {
        [DisplayName("Estúdio")]
        public long EstudioId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}