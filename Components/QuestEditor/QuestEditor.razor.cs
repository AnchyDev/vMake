using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

using System.Text;
using System.Text.Json;

using vMake.Database;
using vMake.Models;

namespace vMake.Components.QuestEditor;

public partial class QuestEditor
{
    [Parameter]
    public MakeQuestTemplate Template { get; set; } = default!;

    [Inject]
    private MangosDbContext DbContext { get; set; } = default!;

    public string? Export { get; private set; }

    public string Status { get; set; } = "";

    private enum QuestEditorTab
    {
        General,
        Save
    }

    private QuestEditorTab currentTab = QuestEditorTab.General;

    private async void UpdateQuestAsync()
    {
        try
        {
            // Re-attach the cloned entity so we can update the original.
            var entity = DbContext.Attach(Template.QuestTemplate);
            entity.State = EntityState.Modified;

            await DbContext.SaveChangesAsync();

            // Detach the entity again as we do not want to track it.
            entity.State = EntityState.Detached;

            Status = "Saved changes.";
            StateHasChanged();
        }
        catch (Exception ex)
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
        catch (Exception ex)
        {
            Status = $"Failed to generate export string: {ex.Message}";
        }
    }
}
