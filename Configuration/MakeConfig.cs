using System.Text.Json;
using System.Text.Json.Serialization;

namespace vMake.Configuration;

public class MakeConfig
{
    public const string FILE_NAME = "vMake.json";

    [JsonPropertyName("mysql")]
    public MakeMySqlConfig MySql { get; set; }

    [JsonPropertyName("isFirstBoot")]
    public bool IsFirstBoot { get; set; }

    public MakeConfig()
    {
        MySql = new MakeMySqlConfig();
        IsFirstBoot = true;
    }

    public async Task SaveAsync()
    {
        using var fs = File.OpenWrite(FILE_NAME);
        await JsonSerializer.SerializeAsync(fs, this);
    }
}
