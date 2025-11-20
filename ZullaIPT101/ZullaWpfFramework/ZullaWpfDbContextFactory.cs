using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ZullaWpfFramework;

public class ZullaWpfDbContextFactory : IDesignTimeDbContextFactory<ZullaWpfDbContext>
{
    public ZullaWpfDbContext CreateDbContext(string[] args)
    {
        // Build configuration to read from appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ZullaWpf"))
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<ZullaWpfDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new ZullaWpfDbContext(optionsBuilder.Options);
    }
}
