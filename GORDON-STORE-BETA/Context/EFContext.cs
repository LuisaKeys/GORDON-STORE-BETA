using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using GORDON_STORE_BETA.Models;
namespace GORDON_STORE_BETA.Context
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS") { }

        public DbSet<Cliente> Clientes { get; set; }

    }
}