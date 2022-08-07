using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GORDON_STORE_BETA.Models
{
    public class Estudio
    {
        [Display(Name = "ID")]
        public long EstudioId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}