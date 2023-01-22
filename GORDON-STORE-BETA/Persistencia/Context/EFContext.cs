using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GORDON_STORE_BETA.Modelo.Tabelas;
using GORDON_STORE_BETA.Modelo.Cadastro;
using GORDON_STORE_BETA.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using GORDON_STORE_BETA.Modelo.Cart;
using System.Configuration;

namespace GORDON_STORE_BETA.Persistencia.Context
{
    public class EFContext : DbContext
    {
        public EFContext() : base("GORDON_STORE")
        {
            Database.SetInitializer<EFContext>(new
        MigrateDatabaseToLatestVersion<EFContext, GORDON_STORE_BETA.Migrations.Configuration>());
            //Database.SetInitializer<EFContext>(
            //        new DropCreateDatabaseIfModelChanges<EFContext>());
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Estudio> Estudios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrdersDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}