using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo.Cart;
namespace GORDON_STORE_BETA.Models.ViewModels
{
    public class OrderVM
    {
        public OrderVM()
        {
        }

        public OrderVM(Order row)
        {
            OrderId = row.OrderId;
            UserId = row.UserId;
            CreatedAt = row.CreatedAt;
        }

        public long OrderId { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}