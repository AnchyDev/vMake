using Microsoft.AspNetCore.Components;
using System.Text;
using System.Text.Json;
using vMake.Database;
using vMake.Database.Tables;

namespace vMake.Components.ItemEditor;

public partial class ItemEditor
{
    [Parameter]
    public MangosItemTemplate Template { get; set; } = default!;

    [Inject]
    protected MangosDbContext DbContext { get; set; } = default!;

    public string? Export { get; private set; }

    public string Status { get; set; } = "";

    private async void UpdateItemAsync()
    {
        try
        {
            // Re-attach the cloned entity so we can update the original.
            var entity = DbContext.Attach(Template);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            await DbContext.SaveChangesAsync();

            Status = "Saved changes.";
            StateHasChanged();
        }
        catch(Exception ex)
        {
            Status = $"An error occured during save: {ex.Message}";
        }
    }

    private void ExportTemplate()
    {
        try
        {
            var json = JsonSerializer.Serialize(Template);
            Export = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));

            StateHasChanged();
        }
        catch(Exception ex)
        {
            Status = $"Failed to generate export string: {ex.Message}";
        }
    }
}
