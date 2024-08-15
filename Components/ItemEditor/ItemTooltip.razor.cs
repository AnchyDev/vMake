using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

using vMake.Database;
using vMake.Database.Tables;
using vMake.Database.Types;

namespace vMake.Components.ItemEditor;

public partial class ItemTooltip
{
    [Parameter]
    public MangosItemTemplate? Template { get; set; }

    [Inject]
    protected MangosDbContext DbContext { get; set; } = default!;

    public List<MangosItemSpell> Spells { get; set; } = new List<MangosItemSpell>();

    // Called when the component is re-rendered.
    protected override async Task OnParametersSetAsync()
    {
        await GetSpellsAsync();
    }

    public async Task GetSpellsAsync()
    {
        Spells.Clear();

        if (Template is null)
        {
            return;
        }

        if(Template.SpellId1 > 0)
        {
            var spell = await DbContext.SpellTemplate.FirstOrDefaultAsync(s => s.Entry == Template.SpellId1);
            if(spell is not null)
            {
                Spells.Add(new MangosItemSpell()
                {
                    Trigger = Template.SpellTrigger1,
                    Entry = Template.SpellId1,
                    Name = spell.Name,
                    Description = spell.Description
                });
            }
        }

        if (Template.SpellId2 > 0)
        {
            var spell = await DbContext.SpellTemplate.FirstOrDefaultAsync(s => s.Entry == Template.SpellId2);
            if (spell is not null)
            {
                Spells.Add(new MangosItemSpell()
                {
                    Trigger = Template.SpellTrigger2,
                    Entry = Template.SpellId2,
                    Name = spell.Name,
                    Description = spell.Description
                });
            }
        }

        if (Template.SpellId3 > 0)
        {
            var spell = await DbContext.SpellTemplate.FirstOrDefaultAsync(s => s.Entry == Template.SpellId3);
            if (spell is not null)
            {
                Spells.Add(new MangosItemSpell()
                {
                    Trigger = Template.SpellTrigger3,
                    Entry = Template.SpellId3,
                    Name = spell.Name,
                    Description = spell.Description
                });
            }
        }

        if (Template.SpellId4 > 0)
        {
            var spell = await DbContext.SpellTemplate.FirstOrDefaultAsync(s => s.Entry == Template.SpellId4);
            if (spell is not null)
            {
                Spells.Add(new MangosItemSpell()
                {
                    Trigger = Template.SpellTrigger4,
                    Entry = Template.SpellId4,
                    Name = spell.Name,
                    Description = spell.Description
                });
            }
        }

        if (Template.SpellId5 > 0)
        {
            var spell = await DbContext.SpellTemplate.FirstOrDefaultAsync(s => s.Entry == Template.SpellId5);
            if (spell is not null)
            {
                Spells.Add(new MangosItemSpell()
                {
                    Trigger = Template.SpellTrigger5,
                    Entry = Template.SpellId5,
                    Name = spell.Name,
                    Description = spell.Description
                });
            }
        }
    }
}
