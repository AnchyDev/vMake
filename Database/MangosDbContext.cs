using Microsoft.EntityFrameworkCore;
using vMake.Database.Mangos;

namespace vMake.Database;

public class MangosDbContext : DbContext
{
    public DbSet<MangosItemTemplate> ItemTemplate { get; set; }

    private readonly IConfiguration config;
    private readonly ILogger<MangosDbContext> logger;

    public MangosDbContext(DbContextOptions<MangosDbContext> options,
        IConfiguration config, ILogger<MangosDbContext> logger) : base(options)
    {
        this.config = config;
        this.logger = logger;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        string? mySqlConn = config.GetConnectionString("MySqlMangos");

        if (string.IsNullOrEmpty(mySqlConn))
        {
            logger.LogCritical("MySql ConnectionString for MySqlMangos was null or empty.");
            return;
        }

        ServerVersion? mySqlVersion = ServerVersion.AutoDetect(mySqlConn);
        if (mySqlVersion is null)
        {
            logger.LogCritical("Failed to auto-detect MySql version.");
            return;
        }

        builder.UseMySql(mySqlConn, mySqlVersion);
    }
}
