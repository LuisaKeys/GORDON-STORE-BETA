using GORDON_STORE_ALPHA.Models.Cart;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GORDON_STORE_ALPHA.DAL
{
    public class EFContext2 : DbContext
    {
        public EFContext2() : base("GORDON_STORE")
        {
            Database.SetInitializer<EFContext2>(
                    new DropCreateDatabaseIfModelChanges<EFContext2>());
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}