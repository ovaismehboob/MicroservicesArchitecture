using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.AuthServer.Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BFIdentityContext>
    {
        public BFIdentityContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<BFIdentityContext>();

            var connectionString = "Server=OVAISPC\\sqlexpress;Database=FraymsIdentityDB1;User Id=sa;Password=P@ssw0rd;";

            builder.UseSqlServer(connectionString);

            return new BFIdentityContext(builder.Options);

        }
    }
}
