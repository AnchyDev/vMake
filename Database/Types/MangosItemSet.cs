using vMake.Database.Tables;

namespace vMake.Database.Types;

public class MangosItemSet
{
    public required int Id { get; set; }
    public required string Name { get; set; }

    public List<MangosItemTemplate> Items { get; set; } = new List<MangosItemTemplate>();
}
