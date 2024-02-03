using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MVCWEB.Models;

public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
{
    public RepositoryContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<RepositoryContext>()
            .UseMySql(
                configuration.GetConnectionString("sqlConnection"),
                new MySqlServerVersion(new Version(10, 4, 28)),
                prj => prj.MigrationsAssembly("MVCWEB")
            );
        return new RepositoryContext(builder.Options);
    }
}