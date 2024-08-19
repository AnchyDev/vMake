using Microsoft.AspNetCore.Components;

using vMake.Database;
using vMake.Models;
using vMake.Services;

namespace vMake.Components.ItemEditor;

public partial class ItemTooltip
{
    [Parameter]
    public MakeItemTemplate? Template { get; set; }

    [Inject]
    private MakeService Make { get; set; } = default!;

    protected override void OnInitialized()
    {
        if(Template is null)
        {
            return;
        }

        Template.ItemTemplateSpellsChanged += Template_ItemTemplateSpellsChanged;
    }

    private async void Template_ItemTemplateSpellsChanged(object? sender, EventArgs e)
    {
        if(Template is null)
        {
            return;
        }

        var spellsResult = await Make.GetSpellsForItemAsync(Template.ItemTemplate.Entry, Template.ItemTemplate.Patch);
        if(!spellsResult.Success ||
            spellsResult.Result is null)
        {
            return;
        }

        Template.ItemSpells = spellsResult.Result;
        StateHasChanged();
    }
}
