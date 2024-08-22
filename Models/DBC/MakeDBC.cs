using System.Text.Json;

namespace vMake.Models.DBC;

public class MakeDBC
{
    public required List<MakeDBCSkillLineEntry> SkillLine { get; set; }
    public required List<MakeDBCItemSet> ItemSet { get; set; }

    public static async Task<List<T>> LoadDBCAsync<T>(string path)
    {
        using var fs = File.OpenRead(path);
        var dbc = await JsonSerializer.DeserializeAsync<List<T>>(fs);

        if (dbc is null)
        {
            throw new Exception($"Failed to deserialize DBC at path '{path}'.");
        }

        return dbc;
    }
}
