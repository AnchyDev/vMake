using vMake.Database.Tables;
using vMake.Database.Types;

namespace vMake.Models;

public class MakeItemTemplate
{
    public event EventHandler<EventArgs>? ItemTemplateSpellsChanged;
    public void NotifyItemTemplateSpellsChanged()
    {
        if(ItemTemplateSpellsChanged is not null)
        {
            ItemTemplateSpellsChanged.Invoke(this, EventArgs.Empty);
        }
    }

    public required MangosItemTemplate ItemTemplate { get; set; }
    public required List<MangosItemSpell> ItemSpells { get; set; }
}
