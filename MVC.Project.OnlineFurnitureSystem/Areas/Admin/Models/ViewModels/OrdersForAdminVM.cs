using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Project.OnlineFurnitureSystem.Areas.Admin.Models.ViewModels
{
    public class OrdersForAdminVM
    {
            public int OrderNumber { get; set; }
            public string Username { get; set; }
            public decimal Total { get; set; }
            public Dictionary<string, int> ProductsAndQty { get; set; }
            public DateTime CreatedAt { get; set; }
    }
}