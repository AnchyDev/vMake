namespace vMake.Database.Types;

public class MangosItemSpell
{
    public int Entry { get; set; }
    public MangosItemSpellTrigger Trigger { get; set; }

    public string? Name { get; set; }
    public string? Description { get; set; }
}