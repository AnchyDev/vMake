using Microsoft.AspNetCore.Components;

using System.Text;
using System.Text.Json;

using vMake.Database.Tables;
using vMake.Models;
using vMake.Services;

namespace vMake.Components.Pages;

public partial class MakeItem
{
    [Inject]
    private MakeCacheService Cache { get; set; } = default!;

    [Inject]
    private MakeService Make { get; set; } = default!;

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
            var existingTemplate = await Make.GetItemTemplateAsync(Entry.Value, Patch.Value);
            if (existingTemplate.Success)
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
            var result = await Make.GetItemTemplateAsync(Entry.Value, Patch.Value);
            if (!result.Success)
            {
                createEditHasError = true;
                createEditStatus = result.Message;
                return;
            }

            if (result.Result is null)
            {
                Logger.LogCritical("Result was null for item template in HandleEditItemAsync.");

                createEditHasError = true;
                createEditStatus = "An unexpected error occured: Item template result was null.";
                return;
            }

            var spellsResult = await Make.GetSpellsForItemAsync(Entry.Value, Patch.Value);
            if(!spellsResult.Success)
            {
                createEditHasError = true;
                createEditStatus = spellsResult.Message;
                return;
            }

            if(spellsResult.Result is null)
            {
                Logger.LogCritical("Result was null for spells in HandleEditItemAsync.");

                createEditHasError = true;
                createEditStatus = "An unexpected error occured: Spells result was null.";
                return;
            }

            Cache.ItemTemplate = new MakeItemTemplate()
            {
                ItemTemplate = result.Result,
                ItemSpells = spellsResult.Result
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
