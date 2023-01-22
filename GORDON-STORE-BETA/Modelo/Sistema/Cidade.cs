using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GORDON_STORE_BETA.Modelo.Cadastro;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GORDON_STORE_BETA.Modelo.Tabelas
{
    public class Cidade
    {
        public long  CidadeId{ get; set; }
        public string Nome { get; set; }
        //public virtual ICollection<Produto> Estados { get; set; }
    }
}
