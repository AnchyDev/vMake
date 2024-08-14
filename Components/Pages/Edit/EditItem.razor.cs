using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

using vMake.Components.Pages.Create;
using vMake.Database;
using vMake.Database.Tables;
using vMake.Extensions;

namespace vMake.Components.Pages.Edit;

public partial class EditItem
{
    [SupplyParameterFromForm]
    public int Entry { get; set; }

    [SupplyParameterFromForm]
    public int Patch { get; set; }

    public MangosItemTemplate? ItemTemplate { get; set; }

    [Inject]
    protected MangosDbContext DbContext { get; set; } = default!;

    [Inject]
    protected ILogger<CreateItem> Logger { get; set; } = default!;

    [Inject]
    protected NavigationManager Navigation { get; set; } = default!;

    protected string? Error { get; set; }

    private void GoBack()
    {
        ItemTemplate = null;
    }

    private async Task OnPostFindAsync()
    {
        Error = "";

        try
        {
            var itemTemplates = await DbContext.ItemTemplate.Where(i => i.Entry == Entry).ToListAsync();
            if (itemTemplates.Count < 1)
            {
                Error = "An item with that entry id does not exist.";
                return;
            }

            var itemTemplate = itemTemplates.FirstOrDefault(i => i.Patch == Patch);
            if (itemTemplate is null)
            {
                var patches = string.Join(", ", itemTemplates.Select(i => i.Patch.ToString()));
                Error = $"No entry was found with that patch. Available patch versions: {patches}";
                return;
            }

            // Clone the entity so we can edit a copy of it instead of the original.
            ItemTemplate = itemTemplate.Clone();

            // Detach the original entity since we do not want to track it.
            DbContext.Entry(itemTemplate).State = EntityState.Detached;
        }
        catch (Exception ex)
        {
            Logger.LogCritical($"{ex.Message}: {ex.StackTrace}");
            Error = $"An internal error occured while trying to get the item: {ex.Message}";
        }
    }
}
