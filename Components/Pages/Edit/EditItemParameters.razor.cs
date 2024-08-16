using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

using System.Text.Json;

using vMake.Database;
using vMake.Database.Tables;
using vMake.Database.Types;
using vMake.Extensions;
using vMake.Models;

namespace vMake.Components.Pages.Edit;

public partial class EditItemParameters
{
    [Parameter]
    public int? Entry { get; set; }

    [Parameter]
    public int? Patch { get; set; }

    [Parameter]
    public string? Import { get; set; }

    [Inject]
    protected MangosDbContext DbContext { get; set; } = default!;

    [Inject]
    protected ILogger<EditItemParameters> Logger { get; set; } = default!;

    public MakeItemTemplate? ItemTemplate { get; set; }
    protected string? Error { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        if (Entry is not null && Patch is not null)
        {
            await LoadItemTemplateAsync();
        }
        else if (Import is not null)
        {
            ImportItemTemplate();
        }

        StateHasChanged();
    }

    private async Task LoadItemTemplateAsync()
    {
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
            var clone = itemTemplate.Clone();

            // Detach the original entity since we do not want to track it.
            DbContext.Entry(itemTemplate).State = EntityState.Detached;

            if (clone is null)
            {
                Error = "Failed to clone original item template.";
                return;
            }

            ItemTemplate = new MakeItemTemplate()
            {
                ItemTemplate = clone,
                ItemSpells = clone.GetSpells(DbContext)
            };
        }
        catch (Exception ex)
        {
            Logger.LogCritical($"{ex.Message}: {ex.StackTrace}");
            Error = $"An internal error occured while trying to get the item: {ex.Message}";
        }
    }

    private void ImportItemTemplate()
    {
        if (string.IsNullOrWhiteSpace(Import))
        {
            return;
        }

        try
        {
            var json = Convert.FromBase64String(Import);
            var template = JsonSerializer.Deserialize<MangosItemTemplate>(json);

            if (template is null)
            {
                Error = $"Failed to import: Not a valid import string.";
                return;
            }

            ItemTemplate = new MakeItemTemplate()
            {
                ItemTemplate = template,
                ItemSpells = template.GetSpells(DbContext)
            };
        }
        catch (Exception)
        {
            Error = $"Failed to import: Not a valid import string.";
        }
    }
}
