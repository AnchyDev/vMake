using System.Text.Json.Serialization;

namespace vMake.Models.DBC;

public class MakeDBCItemSet
{
    [JsonPropertyName("ID")]
    public int Id { get; set; }

    [JsonPropertyName("Name_enUS")]
    public string? NameEnUS { get; set; }

    [JsonPropertyName("Name_enGB")]
    public string? NameEnGB { get; set; }

    [JsonPropertyName("Name_koKR")]
    public string? NameKoKR { get; set; }

    [JsonPropertyName("Name_frFR")]
    public string? NameFrFR { get; set; }

    [JsonPropertyName("Name_deDE")]
    public string? NameDeDE { get; set; }

    [JsonPropertyName("Name_enCN")]
    public string? NameEnCN { get; set; }

    [JsonPropertyName("Name_zhCN")]
    public string? NameZhCN { get; set; }

    [JsonPropertyName("Name_enTW")]
    public string? NameEnTW { get; set; }

    [JsonPropertyName("Name_Mask")]
    public int NameMask { get; set; }

    [JsonPropertyName("ItemID_1")]
    public int ItemId1 { get; set; }

    [JsonPropertyName("ItemID_2")]
    public int ItemId2 { get; set; }

    [JsonPropertyName("ItemID_3")]
    public int ItemId3 { get; set; }

    [JsonPropertyName("ItemID_4")]
    public int ItemId4 { get; set; }

    [JsonPropertyName("ItemID_5")]
    public int ItemId5 { get; set; }

    [JsonPropertyName("ItemID_6")]
    public int ItemId6 { get; set; }

    [JsonPropertyName("ItemID_7")]
    public int ItemId7 { get; set; }

    [JsonPropertyName("ItemID_8")]
    public int ItemId8 { get; set; }

    [JsonPropertyName("ItemID_9")]
    public int ItemId9 { get; set; }

    [JsonPropertyName("ItemID_10")]
    public int ItemId10 { get; set; }

    [JsonPropertyName("BankItemID_1")]
    public int BankItemId1 { get; set; }

    [JsonPropertyName("BankItemID_2")]
    public int BankItemId2 { get; set; }

    [JsonPropertyName("BankItemID_3")]
    public int BankItemId3 { get; set; }

    [JsonPropertyName("BankItemID_4")]
    public int BankItemId4 { get; set; }

    [JsonPropertyName("BankItemID_5")]
    public int BankItemId5 { get; set; }

    [JsonPropertyName("BankItemID_6")]
    public int BankItemId6 { get; set; }

    [JsonPropertyName("BankItemID_7")]
    public int BankItemId7 { get; set; }

    [JsonPropertyName("BankItemID_8")]
    public int BankItemId8 { get; set; }

    [JsonPropertyName("SetSpellID_1")]
    public int SpellId1 { get; set; }

    [JsonPropertyName("SetSpellID_2")]
    public int SpellId2 { get; set; }

    [JsonPropertyName("SetSpellID_3")]
    public int SpellId3 { get; set; }

    [JsonPropertyName("SetSpellID_4")]
    public int SpellId4 { get; set; }

    [JsonPropertyName("SetSpellID_5")]
    public int SpellId5 { get; set; }

    [JsonPropertyName("SetSpellID_6")]
    public int SpellId6 { get; set; }

    [JsonPropertyName("SetSpellID_7")]
    public int SpellId7 { get; set; }

    [JsonPropertyName("SetSpellID_8")]
    public int SpellId8 { get; set; }

    [JsonPropertyName("SetThreshold_1")]
    public int SpellThreshold1 { get; set; }

    [JsonPropertyName("SetThreshold_2")]
    public int SpellThreshold2 { get; set; }

    [JsonPropertyName("SetThreshold_3")]
    public int SpellThreshold3 { get; set; }

    [JsonPropertyName("SetThreshold_4")]
    public int SpellThreshold4 { get; set; }

    [JsonPropertyName("SetThreshold_5")]
    public int SpellThreshold5 { get; set; }

    [JsonPropertyName("SetThreshold_6")]
    public int SpellThreshold6 { get; set; }

    [JsonPropertyName("SetThreshold_7")]
    public int SpellThreshold7 { get; set; }

    [JsonPropertyName("SetThreshold_8")]
    public int SpellThreshold8 { get; set; }

    [JsonPropertyName("RequiredSkill")]
    public int RequiredSkill { get; set; }

    [JsonPropertyName("RequiredSkillRank")]
    public int RequiredSkillRank { get; set; }
}
