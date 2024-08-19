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

        if (itemTemplate.SpellId1 > 0)
        {
            var spell = await dbContext.SpellTemplate.FirstOrDefaultAsync(s => s.Entry == itemTemplate.SpellId1);
            if (spell is not null)
            {
                spells.Add(new MangosItemSpell()
                {
                    Trigger = itemTemplate.SpellTrigger1,
                    Entry = itemTemplate.SpellId1,
                    Name = spell.Name,
                    Description = spell.Description
                });
            }
        }

        if (itemTemplate.SpellId2 > 0)
        {
            var spell = await dbContext.SpellTemplate.FirstOrDefaultAsync(s => s.Entry == itemTemplate.SpellId2);
            if (spell is not null)
            {
                spells.Add(new MangosItemSpell()
                {
                    Trigger = itemTemplate.SpellTrigger2,
                    Entry = itemTemplate.SpellId2,
                    Name = spell.Name,
                    Description = spell.Description
                });
            }
        }

        if (itemTemplate.SpellId3 > 0)
        {
            var spell = await dbContext.SpellTemplate.FirstOrDefaultAsync(s => s.Entry == itemTemplate.SpellId3);
            if (spell is not null)
            {
                spells.Add(new MangosItemSpell()
                {
                    Trigger = itemTemplate.SpellTrigger3,
                    Entry = itemTemplate.SpellId3,
                    Name = spell.Name,
                    Description = spell.Description
                });
            }
        }

        if (itemTemplate.SpellId4 > 0)
        {
            var spell = await dbContext.SpellTemplate.FirstOrDefaultAsync(s => s.Entry == itemTemplate.SpellId4);
            if (spell is not null)
            {
                spells.Add(new MangosItemSpell()
                {
                    Trigger = itemTemplate.SpellTrigger4,
                    Entry = itemTemplate.SpellId4,
                    Name = spell.Name,
                    Description = spell.Description
                });
            }
        }

        if (itemTemplate.SpellId5 > 0)
        {
            var spell = await dbContext.SpellTemplate.FirstOrDefaultAsync(s => s.Entry == itemTemplate.SpellId5);
            if (spell is not null)
            {
                spells.Add(new MangosItemSpell()
                {
                    Trigger = itemTemplate.SpellTrigger5,
                    Entry = itemTemplate.SpellId5,
                    Name = spell.Name,
                    Description = spell.Description
                });
            }
        }

        return MakeResult<List<MangosItemSpell>>.Succeed(result: spells);
    }
}
