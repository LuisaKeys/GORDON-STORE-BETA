using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GORDON_STORE_BETA.Areas.Seguranca.Models
{
    public class PapelModificationModel
    {
        [Required]
        public string NomePapel { get; set; }
        public string[] IdsParaAdicionar { get; set; }
        public string[] IdsParaRemover { get; set; }
    }
}