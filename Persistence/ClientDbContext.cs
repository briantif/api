﻿using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class ClientDbContext : DbContext
    {
        public DbSet<Client> Client { get; set; }

        public ClientDbContext(DbContextOptions<ClientDbContext> options)
        : base(options)
        { }
    }

   
}
