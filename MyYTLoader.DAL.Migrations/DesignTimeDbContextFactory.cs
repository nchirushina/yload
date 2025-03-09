using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MyYTLoader.DAL;

namespace MyYTLoader.DAL.Migrations
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<LoaderContext>
    {
        private const string MigrationHistoryTable = "__EFMigrationsHistory";
        private const string MigrationHistoryTableScheme = "public";
        private readonly string _migrationAssemblyName = typeof(DesignTimeDbContextFactory).Assembly.GetName().Name;

        public LoaderContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LoaderContext>();
            optionsBuilder.UseNpgsql(builder =>
            {
                builder.MigrationsAssembly(_migrationAssemblyName);
                builder.MigrationsHistoryTable(MigrationHistoryTable, MigrationHistoryTableScheme);
            });

            return new LoaderContext(optionsBuilder.Options);
        }
    }
}
