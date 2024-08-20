using Microsoft.EntityFrameworkCore;

using vMake.Database;
using vMake.Database.Tables;
using vMake.Database.Types;
using vMake.Models;

namespace vMake.Services;

public class MakeService
{
    private readonly MangosDbContext dbContext;

    public MakeService(MangosDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<MakeResult<MangosItemTemplate>> CreateItemTemplateAsync(int entry, int patch)
    {
        var result = await GetItemTemplateAsync(entry, patch);
        if(result.Success)
        {
            return MakeResult<MangosItemTemplate>.Fail("An item with that entry and patch already exists.");
        }

        var itemTemplate = new MangosItemTemplate()
        {
            Entry = entry,
            Patch = patch,
            Name = "vMake Item",
            Description = "This item was created using vMake!"
        };

        await dbContext.ItemTemplate.AddAsync(itemTemplate);
        var rows = await dbContext.SaveChangesAsync();

        if(rows < 1)
        {
            return MakeResult<MangosItemTemplate>.Fail("Item template not saved, expected 1 rows changed but 0 were changed.");
        }

        return MakeResult<MangosItemTemplate>.Succeed(result: itemTemplate);
    }

    public async Task<MakeResult<MangosItemTemplate>> GetItemTemplateAsync(int entry, int patch)
    {
        var itemTemplate = await dbContext.ItemTemplate.FirstOrDefaultAsync(i => i.Entry == entry && i.Patch == patch);
        if (itemTemplate is null)
        {
            return MakeResult<MangosItemTemplate>.Fail("No item with that entry and patch exists.");
        }

        return MakeResult<MangosItemTemplate>.Succeed(result: itemTemplate);
    }

    public async Task<MakeResult<List<MangosItemSpell>>> GetSpellsForItemAsync(int entry, int patch)
    {
        var result = await GetItemTemplateAsync(entry, patch);
        if(!result.Success)
        {
            return MakeResult<List<MangosItemSpell>>.Fail(result.Message);
        }

        var itemTemplate = result.Result;
        if(itemTemplate is null)
        {
            return MakeResult<List<MangosItemSpell>>.Fail("An unexpected error occured: Item Template was null.");
        }

        var spells = new List<MangosItemSpell>();
        var spellIds = new[] { itemTemplate.SpellId1, itemTemplate.SpellId2, itemTemplate.SpellId3, itemTemplate.SpellId4, itemTemplate.SpellId5 };
        var triggers = new[] { itemTemplate.SpellTrigger1, itemTemplate.SpellTrigger2, itemTemplate.SpellTrigger3, itemTemplate.SpellTrigger4, itemTemplate.SpellTrigger5 };

        for (int i = 0; i < spellIds.Length; i++)
        {
            if (spellIds[i] > 0)
            {
                var spell = await dbContext.SpellTemplate.FirstOrDefaultAsync(s => s.Entry == spellIds[i]);
                if (spell is not null)
                {
                    spells.Add(new MangosItemSpell
                    {
                        Trigger = triggers[i],
                        Spell = spell
                    });
                }
            }
        }

        return MakeResult<List<MangosItemSpell>>.Succeed(result: spells);
    }
}
