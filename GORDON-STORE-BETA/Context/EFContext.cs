using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GORDON_STORE_BETA.Models;
using System.Data.Entity;

namespace GORDON_STORE_BETA.Context
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS")
        {
            Database.SetInitializer<EFContext>(
            new DropCreateDatabaseIfModelChanges<EFContext>());
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Estudio> Estudios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}