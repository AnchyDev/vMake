using vMake.Database.Tables;
using vMake.Database.Types;

namespace vMake.Models;

public class MakeItemTemplate
{
    public required MangosItemTemplate ItemTemplate { get; set; }
    public required List<MangosItemSpell> ItemSpells { get; set; }
}
