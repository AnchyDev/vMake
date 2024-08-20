using ElectronNET.API;

using Microsoft.AspNetCore.Components;

using vMake.Configuration;

namespace vMake.Components.Layout;

public partial class MainLayout
{
    [Inject]
    protected MakeConfig Config { get; set; } = default!;

    [Inject]
    protected WindowManager Window { get; set; } = default!;

    [Inject]
    protected ElectronNET.API.App App { get; set; } = default!;

    private bool maximizeState;

    protected override async Task OnInitializedAsync()
    {
        var window = Window.BrowserWindows.FirstOrDefault();
        if (window is null)
        {
            return;
        }

        maximizeState = await window.IsMaximizedAsync();
    }

    private void Minimize()
    {
        var window = Window.BrowserWindows.FirstOrDefault();
        if (window is null)
        {
            return;
        }

        window.Minimize();
    }

    private async Task MaximizeAsync()
    {
        var window = Window.BrowserWindows.FirstOrDefault();
        if(window is null)
        {
            return;
        }

        if(await window.IsMaximizedAsync())
        {
            maximizeState = false;
            window.Unmaximize();
        }
        else
        {
            maximizeState = true;
            window.Maximize();
        }
    }

    private void Exit()
    {
        App.Quit();
    }
}
