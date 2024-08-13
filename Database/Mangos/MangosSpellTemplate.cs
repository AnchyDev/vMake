using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations.Schema;

namespace vMake.Database.Mangos;

[PrimaryKey(nameof(Entry), nameof(Build))]
[Table("spell_template")]
public class MangosSpellTemplate
{
    [Column("entry")]
    public int Entry { get; set; }

    [Column("build")]
    public int Build { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("description")]
    public string? Description { get; set; }
}
