using Microsoft.EntityFrameworkCore;
using Model;
using Persistence.config;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class ClientDbContext : DbContext
    {
        public DbSet<Client> Client { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Selling> Selling { get; set; }

        public DbSet<Inventory> Inventory { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new ClientConfiguration(builder.Entity<Client>());

            base.OnModelCreating(builder);
        }



        public ClientDbContext(DbContextOptions<ClientDbContext> options)
        : base(options)
        { }
    }

   
}
