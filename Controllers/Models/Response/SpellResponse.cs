namespace vMake.Controllers.Models.Response;

public class SpellResponse : BasicApiResponse
{
    public SpellDto Spell { get; set; }
    public SpellResponse(bool success, string message, SpellDto spell) : base(success, message) 
    {
        Spell = spell;
    }
}
