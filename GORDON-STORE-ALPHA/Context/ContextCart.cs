using Modelo.Cadastro;
using Modelo.Tabelas;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GORDON_STORE_ALPHA.Models.Cart;

namespace GORDON_STORE_ALPHA.Context
{
    public class ContextCart : DbContext
    {
        public ContextCart() : base("GORDON_STORE")
        {
            Database.SetInitializer<EFContext>(
    new DropCreateDatabaseAlways<EFContext>());
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}