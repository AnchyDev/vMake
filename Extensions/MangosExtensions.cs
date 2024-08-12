using vMake.Database.Mangos;
using vMake.Database.Types;

namespace vMake.Extensions;

public static class MangosExtensions
{
    public static string GetHexColor(this MangosItemQuality quality)
    {
        switch (quality)
        {
            case MangosItemQuality.Poor:
                return "9d9d9d";

            case MangosItemQuality.Common:
                return "ffffff";

            case MangosItemQuality.Uncommon:
                return "1eff00";

            case MangosItemQuality.Rare:
                return "0070dd";

            case MangosItemQuality.Epic:
                return "a335ee";

            case MangosItemQuality.Legendary:
                return "ff8000";

            case MangosItemQuality.Artifact:
                return "e6cc80";
        }

        return "ffffff";
    }

    public static string GetBondingText(this MangosItemBonding bonding)
    {
        switch(bonding)
        {
            case MangosItemBonding.None:
                return "None";

            case MangosItemBonding.BindOnPickup:
                return "Binds when picked up";

            case MangosItemBonding.BindOnEquip:
                return "Binds when equipped";

            case MangosItemBonding.BindOnUse:
                return "Binds when used";

            case MangosItemBonding.Quest:
                return "Quest";
        }

        return "";
    }

    public static List<MangosItemStat> GetStats(this MangosItemTemplate item)
    {
        return new List<MangosItemStat>()
        {
            new() { Type = (MangosItemStatType)item.StatType1, Value = item.StatValue1 },
            new() { Type = (MangosItemStatType)item.StatType2, Value = item.StatValue2 },
            new() { Type = (MangosItemStatType)item.StatType3, Value = item.StatValue3 },
            new() { Type = (MangosItemStatType)item.StatType4, Value = item.StatValue4 },
            new() { Type = (MangosItemStatType)item.StatType5, Value = item.StatValue5 },
            new() { Type = (MangosItemStatType)item.StatType6, Value = item.StatValue6 },
            new() { Type = (MangosItemStatType)item.StatType7, Value = item.StatValue7 },
            new() { Type = (MangosItemStatType)item.StatType8, Value = item.StatValue8 },
            new() { Type = (MangosItemStatType)item.StatType9, Value = item.StatValue9 },
            new() { Type = (MangosItemStatType)item.StatType10, Value = item.StatValue10 }
        };
    }
}
