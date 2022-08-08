using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GORDON_STORE_BETA.Models
{
    public class Avaliação
    {
        [Display(Name = "Avaliação")]
        public string comentário { get; set; }
        [Display(Name = "classificação")]
        public int ranquear { get; set; }
    }
}