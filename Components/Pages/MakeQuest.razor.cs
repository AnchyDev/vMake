using Microsoft.AspNetCore.Components;

using System.Text;
using System.Text.Json;

using vMake.Models;
using vMake.Services;

namespace vMake.Components.Pages;

public partial class MakeQuest
{
    [Inject]
    private MakeCacheService Cache { get; set; } = default!;

    [Inject]
    private MakeService Make { get; set; } = default!;

    [Inject]
    private ILogger<MakeQuest> Logger { get; set; } = default!;

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
            importStatus = "You must enter a base64 string exported from an quest.";
            return;
        }

        try
        {
            var data = Convert.FromBase64String(Import);
            var json = Encoding.UTF8.GetString(data);

            var questTemplate = JsonSerializer.Deserialize<MakeQuestTemplate>(json);

            if (questTemplate is null)
            {
                importHasError = true;
                importStatus = "Invalid import string.";
                return;
            }

            Cache.QuestTemplate = questTemplate;
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
            var result = await Make.CreateQuestTemplateAsync(Entry.Value, Patch.Value);
            if (!result.Success)
            {
                createEditHasError = true;
                createEditStatus = result.Message;
                return;
            }

            if (result.Result is null)
            {
                createEditHasError = true;
                createEditStatus = "An unexpected error occured: Quest template result was null.";
                return;
            }

            Cache.QuestTemplate = new MakeQuestTemplate()
            {
                QuestTemplate = result.Result,
            };
        }
        catch (Exception ex)
        {
            Logger.LogCritical($"{ex.Message}: {ex.StackTrace}");

            createEditHasError = true;
            createEditStatus = $"An internal error occured while trying to create the quest: {ex.Message}";

            return;
        }
    }

    private async Task HandleEditAsync()
    {
        if (Entry is null || Patch is null)
        {
            createEditHasError = true;
            createEditStatus = "You must enter an entry and patch.";
            return;
        }

        try
        {
            var result = await Make.GetQuestTemplateAsync(Entry.Value, Patch.Value);
            if (!result.Success)
            {
                createEditHasError = true;
                createEditStatus = result.Message;
                return;
            }

            if (result.Result is null)
            {
                Logger.LogCritical("Result was null for quest template in HandleEditAsync.");

                createEditHasError = true;
                createEditStatus = "An unexpected error occured: Quest template result was null.";
                return;
            }

            Cache.QuestTemplate = new MakeQuestTemplate()
            {
                QuestTemplate = result.Result
            };
        }
        catch (Exception ex)
        {
            createEditHasError = true;
            createEditStatus = $"An internal error occured while trying to edit the quest: {ex.Message}";
        }
    }

    private void HandleCloseTemplate()
    {
        Cache.QuestTemplate = null;
    }
}
