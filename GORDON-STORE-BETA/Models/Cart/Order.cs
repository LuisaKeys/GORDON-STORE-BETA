using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GORDON_STORE_BETA.Models.Cart
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public String UserId { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
