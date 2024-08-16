using ElectronNET.API;

using vMake.Configuration;
using vMake.Database;

namespace vMake;

class Program
{
    static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.WebHost.UseElectron(args);
        builder.WebHost.UseStaticWebAssets();

        await ConfigureServicesAsync(builder);

        var app = builder.Build();

        ConfigureMiddleware(app);

        await app.StartAsync();

        await Electron.WindowManager.CreateWindowAsync();

        await app.WaitForShutdownAsync();
    }

    static async Task ConfigureServicesAsync(WebApplicationBuilder builder)
    {
        var services = builder.Services;

        var config = new MakeConfig();
        if (!File.Exists(MakeConfig.FILE_NAME))
        {
            await config.SaveAsync();
        }

        builder.Configuration.AddJsonFile(MakeConfig.FILE_NAME);
        builder.Configuration.Bind(config);

        services.AddSingleton(config);

        services.AddDbContext<MangosDbContext>(ServiceLifetime.Transient);
        services.AddRazorComponents().AddInteractiveServerComponents();

        services.AddElectron();
    }

    static void ConfigureMiddleware(WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
        }

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<Components.App>().AddInteractiveServerRenderMode();
    }
}
