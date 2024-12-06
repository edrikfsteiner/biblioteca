using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using Template.Context;

namespace Template.Context
{
    public class AluguelContextFactory : IDesignTimeDbContextFactory<AluguelContext>
    {
        public AluguelContext CreateDbContext(string[] args)
        {
            // Cria uma configura��o para acessar o arquivo appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // L� a string de conex�o do appsettings.json
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Configura o DbContext com a conex�o SQLite
            var optionsBuilder = new DbContextOptionsBuilder<AluguelContext>();
            optionsBuilder.UseSqlite(connectionString);

            return new AluguelContext(optionsBuilder.Options);
        }
    }
}
