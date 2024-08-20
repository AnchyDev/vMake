using vMake.Database.Tables;

namespace vMake.Database.Types;

public class MangosItemSpell
{
    public required MangosItemSpellTrigger Trigger { get; set; }
    public required MangosSpellTemplate Spell { get; set; }
}