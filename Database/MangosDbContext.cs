using Microsoft.EntityFrameworkCore;

using vMake.Configuration;
using vMake.Database.Tables;

namespace vMake.Database;

public class MangosDbContext : DbContext
{
    public DbSet<MangosItemTemplate> ItemTemplate { get; set; }
    public DbSet<MangosSpellTemplate> SpellTemplate { get; set; }

    private readonly MakeConfig config;
    private readonly ILogger<MangosDbContext> logger;

    public MangosDbContext(DbContextOptions<MangosDbContext> options,
        MakeConfig config, ILogger<MangosDbContext> logger) : base(options)
    {
        this.config = config;
        this.logger = logger;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        string mySqlConn = config.MySql.ConnectionString;

        ServerVersion? mySqlVersion = ServerVersion.AutoDetect(mySqlConn);
        if (mySqlVersion is null)
        {
            logger.LogCritical("Failed to auto-detect MySql version.");
            return;
        }

        builder.UseMySql(mySqlConn, mySqlVersion);
    }
}
