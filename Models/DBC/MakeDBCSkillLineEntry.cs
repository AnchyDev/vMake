using System.Text.Json.Serialization;

namespace vMake.Models.DBC;

public class MakeDBCSkillLineEntry
{
    [JsonPropertyName("ID")]
    public int Id { get; set; }

    [JsonPropertyName("CategoryID")]
    public int CategoryId { get; set; }

    [JsonPropertyName("SkillCostsID")]
    public int SkillCostsId { get; set; }

    [JsonPropertyName("DisplayName_enUS")]
    public string? DisplayNameEnUS { get; set; }

    [JsonPropertyName("DisplayName_enGB")]
    public string? DisplayNameEnGB { get; set; }

    [JsonPropertyName("DisplayName_koKR")]
    public string? DisplayNameKoKR { get; set; }

    [JsonPropertyName("DisplayName_frFR")]
    public string? DisplayNameFrFR { get; set; }

    [JsonPropertyName("DisplayName_deDE")]
    public string? DisplayNameDeDE { get; set; }

    [JsonPropertyName("DisplayName_enCN")]
    public string? DisplayNameEnCN { get; set; }

    [JsonPropertyName("DisplayName_zhCN")]
    public string? DisplayNameZhCN { get; set; }

    [JsonPropertyName("DisplayName_enTW")]
    public string? DisplayNameEnTW { get; set; }

    [JsonPropertyName("DisplayName_Mask")]
    public int DisplayNameMask { get; set; }

    [JsonPropertyName("Description_enUS")]
    public string? DescriptionEnUS { get; set; }

    [JsonPropertyName("Description_enGB")]
    public string? DescriptionEnGB { get; set; }

    [JsonPropertyName("Description_koKR")]
    public string? DescriptionKoKR { get; set; }

    [JsonPropertyName("Description_frFR")]
    public string? DescriptionFrFR { get; set; }

    [JsonPropertyName("Description_deDE")]
    public string? DescriptionDeDE { get; set; }

    [JsonPropertyName("Description_enCN")]
    public string? DescriptionEnCN { get; set; }

    [JsonPropertyName("Description_zhCN")]
    public string? DescriptionZhCN { get; set; }

    [JsonPropertyName("Description_enTW")]
    public string? DescriptionEnTW { get; set; }

    [JsonPropertyName("Description_Mask")]
    public int DescriptionMask { get; set; }

    [JsonPropertyName("SpellIconID")]
    public int SpellIconId { get; set; }
}
