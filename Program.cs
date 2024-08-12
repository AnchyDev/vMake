using vMake.Database;

namespace vMake;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        ConfigureServices(builder.Services);

        var app = builder.Build();

        ConfigureMiddleware(app);

        app.Run();
    }


    static void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<MangosDbContext>();

        services.AddControllers();
        services.AddRazorPages();
    }

    static void ConfigureMiddleware(WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
        }

        //RunDatabaseMigrations(app);

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
        app.MapRazorPages();
    }
}
