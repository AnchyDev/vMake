using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

using vMake.Database;
using vMake.Database.Types;
using vMake.Extensions;

namespace vMake.SignalR;

public class EditItemHub : Hub
{
    private readonly MangosDbContext dbContext;

    public EditItemHub(MangosDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task GetSpellInfo(int? entry, object? metadata)
    {
        if(entry is null)
        {
            await Clients.Caller.SendAsync("GetSpellInfoCallback", new SignalResponse(false, "Missing spell entry for callback.", null));
            return;
        }

        if (metadata is null)
        {
            await Clients.Caller.SendAsync("GetSpellInfoCallback", new SignalResponse(false, "Missing metadata for callback.", null));
            return;
        }

        var template = await dbContext.SpellTemplate.FirstOrDefaultAsync(s => s.Entry == entry);
        if (template is null)
        {
            await Clients.Caller.SendAsync("GetSpellInfoCallback", new SignalResponse(false, "No spell found with that entry."));
            return;
        }

        var spell = new MangosSpellInfo()
        {
            Entry = template.Entry,
            Name = template.Name,
            Description = template.Description
        };

        await Clients.Caller.SendAsync("GetSpellInfoCallback", new SignalResponse(true, "", spell, metadata));
    }

    public async Task GetSubClasses(MangosItemClass? itemClass, object? metadata)
    {
        if (itemClass is null)
        {
            await Clients.Caller.SendAsync("GetSubClassesCallback", new SignalResponse(false, "Missing item class for callback.", null));
            return;
        }

        if (metadata is null)
        {
            await Clients.Caller.SendAsync("GetSubClassesCallback", new SignalResponse(false, "Missing metadata for callback.", null));
            return;
        }

        await Clients.Caller.SendAsync("GetSubClassesCallback", new SignalResponse(true, "", itemClass.Value.GetSubClass(), metadata));
    }
}
