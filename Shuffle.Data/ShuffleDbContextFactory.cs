using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Shuffle.Data
{
    public class ShuffleDbContextFactory : IDesignTimeDbContextFactory<
        ShuffleDbContext>
    {
        public ShuffleDbContext CreateDbContext(string[] args)
        {
            var migrationsAssembly =
                typeof(ShuffleDbContextFactory).GetTypeInfo().Assembly.GetName().Name;

            var optionsBuilder =
                new DbContextOptionsBuilder<ShuffleDbContext>();
            optionsBuilder.UseSqlServer(
                "Server=tcp:doug-relias.database.windows.net,1433;Initial Catalog=shuffleboard;Persist Security Info=False;User ID=doug;Password=Training1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;",
                ma => ma.MigrationsAssembly(migrationsAssembly));

            return new ShuffleDbContext(optionsBuilder.Options);
        }
    }
}