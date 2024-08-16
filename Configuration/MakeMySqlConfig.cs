using System.Text.Json.Serialization;

namespace vMake.Configuration;

public class MakeMySqlConfig
{
    [JsonPropertyName("host")]
    public string Host { get; set; }

    [JsonPropertyName("database")]
    public string Database { get; set; }

    [JsonPropertyName("user")]
    public string User { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }

    [JsonIgnore]
    public string ConnectionString
    {
        get
        {
            return $"Server={Host};Database={Database};Uid={User};Pwd={Password}";
        }
    }

    public MakeMySqlConfig()
    {
        Host = "localhost";
        
        Database = "vmangos_mangos";

        User = "root";
        Password = "root";
    }
}
