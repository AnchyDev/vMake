using vMake.Database.Tables;
using vMake.Database.Types;

namespace vMake.Models;

public class MakeItemTemplate
{
    public event EventHandler<EventArgs>? ItemSpellsChanged;
    public void NotifyItemSpellsChanged()
    {
        if(ItemSpellsChanged is not null)
        {
            ItemSpellsChanged.Invoke(this, EventArgs.Empty);
        }
    }

    public required MangosItemTemplate ItemTemplate { get; set; }
    public required List<MangosItemSpell> ItemSpells { get; set; }
}
