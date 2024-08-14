using Microsoft.AspNetCore.Components;

using vMake.Database;
using vMake.Database.Tables;

namespace vMake.Components;

public partial class ItemEditor
{
    [Parameter]
    public MangosItemTemplate Template { get; set; } = default!;

    [Inject]
    protected MangosDbContext DbContext { get; set; } = default!;

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
}
