using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GORDON_STORE_BETA.Models
{
    public class Cliente
    {
        [Display(Name = "ID")]
        public int clienteID { get; set; }
        [Display(Name = "Nome do cliente")]
        public string nome { get; set; }
        //public int telefone { get; set; }
        //public string email { get; set; }
        //public long cpf { get; set; }
    }
}