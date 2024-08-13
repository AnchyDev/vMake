using vMake.Database;
using vMake.SignalR;

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
        services.AddSignalR();
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

        app.MapHub<EditItemHub>("/hub/edit/item");

        app.MapControllers();
        app.MapRazorPages();
    }
}
