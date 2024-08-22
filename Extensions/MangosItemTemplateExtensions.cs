using vMake.Database.Tables;
using vMake.Database.Types;

using System.Text.Json;

namespace vMake.Extensions;

public static class MangosItemTemplateExtensions
{
    public static List<MangosItemStat> GetStats(this MangosItemTemplate item)
    {
        return new List<MangosItemStat>()
        {
            new() { Type = item.StatType1, Value = item.StatValue1 },
            new() { Type = item.StatType2, Value = item.StatValue2 },
            new() { Type = item.StatType3, Value = item.StatValue3 },
            new() { Type = item.StatType4, Value = item.StatValue4 },
            new() { Type = item.StatType5, Value = item.StatValue5 },
            new() { Type = item.StatType6, Value = item.StatValue6 },
            new() { Type = item.StatType7, Value = item.StatValue7 },
            new() { Type = item.StatType8, Value = item.StatValue8 },
            new() { Type = item.StatType9, Value = item.StatValue9 },
            new() { Type = item.StatType10, Value = item.StatValue10 }
        };
    }

    public static Dictionary<MangosItemResistType, int> GetResists(this MangosItemTemplate item)
    {
        return new Dictionary<MangosItemResistType, int>()
        {
            { MangosItemResistType.Holy, item.HolyResistance },
            { MangosItemResistType.Fire, item.FireResistance },
            { MangosItemResistType.Nature, item.NatureResistance },
            { MangosItemResistType.Frost, item.FrostResistance },
            { MangosItemResistType.Shadow, item.ShadowResistance },
            { MangosItemResistType.Arcane, item.ArcaneResistance },
        };
    }

    public static MangosItemTemplate? Clone(this MangosItemTemplate template)
    {
        return JsonSerializer.Deserialize<MangosItemTemplate>(JsonSerializer.Serialize(template));
    }

    public static float GetDps(this MangosItemTemplate template)
    {
        float divisor = (float)template.Delay / 1000f;
        float avgDmg = (template.DmgMin1 + template.DmgMin2 + template.DmgMin3 + template.DmgMin4 + template.DmgMin5 +
                template.DmgMax1 + template.DmgMax2 + template.DmgMax3 + template.DmgMax4 + template.DmgMax5) / 2;

        return avgDmg / divisor;
    }

    public static List<MangosClass> GetAllowableClasses(this MangosItemTemplate template)
    {
        var allowableClasses = new List<MangosClass>();

        foreach (MangosClass mangosClass in Enum.GetValues(typeof(MangosClass)))
        {
            if (template.AllowableClass.HasFlag(mangosClass))
            {
                allowableClasses.Add(mangosClass);
            }
        }

        return allowableClasses;
    }

    public static Dictionary<int, string> GetSubClasses(this MangosItemTemplate template)
    {
        Type subClassType = template.ItemClass switch
        {
            MangosItemClass.Consumable => typeof(MangosItemConsumableSubClass),
            MangosItemClass.Container => typeof(MangosItemContainerSubClass),
            MangosItemClass.Weapon => typeof(MangosItemWeaponSubClass),
            MangosItemClass.Armor => typeof(MangosItemArmorSubClass),
            MangosItemClass.Reagent => typeof(MangosItemReagentSubClass),
            MangosItemClass.Projectile => typeof(MangosItemProjectileSubClass),
            MangosItemClass.TradeGoods => typeof(MangosItemTradeGoodsSubClass),
            MangosItemClass.Recipe => typeof(MangosItemRecipeSubClass),
            MangosItemClass.Quiver => typeof(MangosItemQuiverSubClass),
            MangosItemClass.Quest => typeof(MangosItemQuestSubClass),
            MangosItemClass.Key => typeof(MangosItemKeySubClass),
            MangosItemClass.Miscellaneous => typeof(MangosItemMiscellaneousSubClass),
            _ => throw new NotImplementedException()
        };

        var kvp = new Dictionary<int, string>();
        foreach (var item in Enum.GetValues(subClassType))
        {
            var value = (int)item;
            var name = Enum.GetName(subClassType, item);

            if (name is null)
            {
                continue;
            }

            kvp.Add(value, name);
        }

        return kvp;
    }

    public static bool AllowsAllClasses(this MangosItemTemplate template)
    {
        return template.AllowableClass.HasFlag(MangosClass.Warrior) &&
                template.AllowableClass.HasFlag(MangosClass.Paladin) &&
                template.AllowableClass.HasFlag(MangosClass.Hunter) &&
                template.AllowableClass.HasFlag(MangosClass.Rogue) &&
                template.AllowableClass.HasFlag(MangosClass.Priest) &&
                template.AllowableClass.HasFlag(MangosClass.Shaman) &&
                template.AllowableClass.HasFlag(MangosClass.Mage) &&
                template.AllowableClass.HasFlag(MangosClass.Warlock) &&
                template.AllowableClass.HasFlag(MangosClass.Druid);
    }
}
