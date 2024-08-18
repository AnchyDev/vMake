using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

using System.Text;
using System.Text.Json;

using vMake.Database;
using vMake.Database.Tables;
using vMake.Extensions;
using vMake.Models;
using vMake.Services;

namespace vMake.Components.Pages;

public partial class MakeItem
{
    [Inject]
    private MakeCacheService Cache { get; set; } = default!;

    [Inject]
    private MangosDbContext DbContext { get; set; } = default!;

    [Inject]
    private ILogger<MakeItem> Logger { get; set; } = default!;

    public int? Entry { get; set; } = 0;

    public int? Patch { get; set; } = 0;

    public string? Import { get; set; }

    private string? importStatus;
    private bool importHasError;

    private string? createEditStatus;
    private bool createEditHasError;

    private void HandleImport()
    {
        if (string.IsNullOrWhiteSpace(Import))
        {
            importHasError = true;
            importStatus = "You must enter a base64 string exported from an item.";
            return;
        }

        try
        {
            var data = Convert.FromBase64String(Import);
            var json = Encoding.UTF8.GetString(data);

            var itemTemplate = JsonSerializer.Deserialize<MakeItemTemplate>(json);

            if(itemTemplate is null)
            {
                importHasError = true;
                importStatus = "Invalid import string.";
                return;
            }

            Cache.ItemTemplate = itemTemplate;
        }
        catch (Exception ex)
        {
            Logger.LogCritical($"{ex.Message}: {ex.StackTrace}");

            importHasError = true;
            importStatus = "Invalid import string.";
            return;
        }
    }

    private async Task HandleCreateAsync()
    {
        if (Entry is null || Patch is null)
        {
            createEditHasError = true;
            createEditStatus = "You must enter an entry and patch.";
            return;
        }

        try
        {
            var existingTemplate = await DbContext.ItemTemplate.FirstOrDefaultAsync(i => i.Entry == Entry && i.Patch == Patch);
            if (existingTemplate is not null)
            {
                createEditHasError = true;
                createEditStatus = "An item with that entry id and patch already exists.";
                return;
            }

            var itemTemplate = new MangosItemTemplate()
            {
                Entry = Entry.Value,
                Patch = Patch.Value,
                Name = "New Item",
                Description = "This is your new item!"
            };

            Cache.ItemTemplate = new MakeItemTemplate()
            {
                ItemTemplate = itemTemplate,
                ItemSpells = new List<Database.Types.MangosItemSpell>()
            };
        }
        catch (Exception ex)
        {
            Logger.LogCritical($"{ex.Message}: {ex.StackTrace}");

            createEditHasError = true;
            createEditStatus = $"An internal error occured while trying to create the item: {ex.Message}";

            return;
        }
    }

    private async Task HandleEditItemAsync()
    {
        if (Entry is null || Patch is null)
        {
            createEditHasError = true;
            createEditStatus = "You must enter an entry and patch.";
            return;
        }

        try
        {
            var itemTemplate = await DbContext.ItemTemplate.FirstOrDefaultAsync(i => i.Entry == Entry && i.Patch == Patch);
            if (itemTemplate is null)
            {
                createEditHasError = true;
                createEditStatus = "An item with that entry id and patch does not exist.";
                return;
            }

            Cache.ItemTemplate = new MakeItemTemplate()
            {
                ItemTemplate = itemTemplate,
                ItemSpells = itemTemplate.GetSpells(DbContext)
            };
        }
        catch(Exception ex)
        {
            createEditHasError = true;
            createEditStatus = $"An internal error occured while trying to edit the item: {ex.Message}";
        }
    }

    private void HandleCloseTemplate()
    {
        Cache.ItemTemplate = null;
    }
}
