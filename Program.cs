using vMake.Components;
using vMake.Database;

namespace vMake;

class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        ConfigureServices(builder.Services);

        var app = builder.Build();

        ConfigureMiddleware(app);

        app.Run();
    }

    static void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<MangosDbContext>(ServiceLifetime.Transient);
        services.AddRazorComponents().AddInteractiveServerComponents();
    }

    static void ConfigureMiddleware(WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
        }

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
    }
}
