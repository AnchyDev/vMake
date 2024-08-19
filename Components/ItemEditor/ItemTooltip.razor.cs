using Microsoft.AspNetCore.Components;

using vMake.Database;
using vMake.Extensions;
using vMake.Models;

namespace vMake.Components.ItemEditor;

public partial class ItemTooltip
{
    [Parameter]
    public MakeItemTemplate? Template { get; set; }

    [Inject]
    private MangosDbContext DbContext { get; set; } = default!;

    protected override void OnInitialized()
    {
        if(Template is null)
        {
            return;
        }

        Template.ItemTemplateSpellsChanged += Template_ItemTemplateSpellsChanged;
    }

    private void Template_ItemTemplateSpellsChanged(object? sender, EventArgs e)
    {
        if(Template is null)
        {
            return;
        }

        Template.ItemSpells = Template.ItemTemplate.GetSpells(DbContext);
        StateHasChanged();
    }
}
