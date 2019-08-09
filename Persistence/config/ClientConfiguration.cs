using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.config
{
    public class ClientConfiguration
    {
        public  ClientConfiguration(EntityTypeBuilder<Client> entityBuilder)
        {
            entityBuilder.HasKey(x => x.ClientId);
            entityBuilder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            entityBuilder.Property(x => x.LastName).HasMaxLength(50);
            entityBuilder.Property(x => x.Pedidos).HasMaxLength(500).IsRequired();

        }
    }
}
