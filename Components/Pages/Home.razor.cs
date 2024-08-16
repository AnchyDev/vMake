using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

using vMake.Configuration;

namespace vMake.Components.Pages;

public partial class Home
{
    [Inject]
    protected MakeConfig Config { get; set; } = default!;

    [Inject]
    protected NavigationManager Navigation { get; set; } = default!;

    private bool canSaveConfiguration = false;

    private bool hasErrors;
    private string? status;

    private void TestMySqlConnection()
    {
        hasErrors = false;
        status = "";

        try
        {
            MySqlServerVersion.AutoDetect(Config.MySql.ConnectionString);

            canSaveConfiguration = true;

            status = "Connection Successful!";
        }
        catch (Exception ex)
        {
            canSaveConfiguration = false;

            hasErrors = true;
            status = $"Connection Failed: {ex.Message}";
        }

        StateHasChanged();
    }

    private async Task SaveConfigurationAsync()
    {
        hasErrors = false;

        try
        {
            await Config.SaveAsync();
            status = $"Configuration Saved!";

            canSaveConfiguration = false;
            StateHasChanged();
        }
        catch(Exception ex)
        {
            hasErrors = true;
            status = $"Connection Failed: {ex.Message}";
        }
    }
}
