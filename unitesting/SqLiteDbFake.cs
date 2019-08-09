using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace unitesting
{
    public class SqLiteDbFake
    {
        private DbContextOptions<ClientDbContext> options;

        public SqLiteDbFake()
        {
            options = GetDbContextOptions;
        }

        public ClientDbContext GetDbContext()
        {
            var context = new ClientDbContext(options);
            // Crea y abre el 'schema' en la base de datos
            context.Database.EnsureCreated();
            return context;
        }

        private DbContextOptions<ClientDbContext> GetDbContextOptions
        {
            get
            {
                // La BD in-memory solo existe cuando la conexión está abierta
                var connection = new SqliteConnection("DataSource=:memory:");
                connection.Open();

                var options = new DbContextOptionsBuilder<ClientDbContext>()
                        .UseSqlite(connection)
                        .Options;

                return options;
            }
        }
    }
}
