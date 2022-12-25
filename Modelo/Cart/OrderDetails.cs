using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Cadastro;
using Modelo.Sistema;

namespace Modelo.Cart
{
    public class OrderDetails
    {
        [Key]
        public long Id { get; set; }
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public long? ProdutoId { get; set; }
        public int Quantidade { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Orders { get; set; }
        //[ForeignKey("UserId")]
        //public virtual UsuarioAdm Users { get; set; }
        [ForeignKey("ProdutoId")]
        public virtual Produto Produtos { get; set; }
    }
}
