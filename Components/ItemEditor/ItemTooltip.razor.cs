using Microsoft.AspNetCore.Components;

using vMake.Models;
using vMake.Models.DBC;
using vMake.Services;

namespace vMake.Components.ItemEditor;

public partial class ItemTooltip
{
    [Parameter]
    public MakeItemTemplate? Template { get; set; }

    [Inject]
    private MakeService Make { get; set; } = default!;

    [Inject]
    private MakeDBC DBC { get; set; } = default!;

    protected override void OnInitialized()
    {
        if(Template is null)
        {
            return;
        }

        Template.ItemSpellsChanged += Template_ItemSpellsChanged;
    }

    private async void Template_ItemSpellsChanged(object? sender, EventArgs e)
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
