using vMake.Database.Tables;
using vMake.Database.Types;
using vMake.Database;

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

    public static List<MangosItemSpell> GetSpells(this MangosItemTemplate itemTemplate, MangosDbContext dbContext)
    {
        var spells = new List<MangosItemSpell>();

        if (itemTemplate.SpellId1 > 0)
        {
            var spell = dbContext.SpellTemplate.FirstOrDefault(s => s.Entry == itemTemplate.SpellId1);
            if (spell is not null)
            {
                spells.Add(new MangosItemSpell()
                {
                    Trigger = itemTemplate.SpellTrigger1,
                    Entry = itemTemplate.SpellId1,
                    Name = spell.Name,
                    Description = spell.Description
                });
            }
        }

        if (itemTemplate.SpellId2 > 0)
        {
            var spell = dbContext.SpellTemplate.FirstOrDefault(s => s.Entry == itemTemplate.SpellId2);
            if (spell is not null)
            {
                spells.Add(new MangosItemSpell()
                {
                    Trigger = itemTemplate.SpellTrigger2,
                    Entry = itemTemplate.SpellId2,
                    Name = spell.Name,
                    Description = spell.Description
                });
            }
        }

        if (itemTemplate.SpellId3 > 0)
        {
            var spell = dbContext.SpellTemplate.FirstOrDefault(s => s.Entry == itemTemplate.SpellId3);
            if (spell is not null)
            {
                spells.Add(new MangosItemSpell()
                {
                    Trigger = itemTemplate.SpellTrigger3,
                    Entry = itemTemplate.SpellId3,
                    Name = spell.Name,
                    Description = spell.Description
                });
            }
        }

        if (itemTemplate.SpellId4 > 0)
        {
            var spell = dbContext.SpellTemplate.FirstOrDefault(s => s.Entry == itemTemplate.SpellId4);
            if (spell is not null)
            {
                spells.Add(new MangosItemSpell()
                {
                    Trigger = itemTemplate.SpellTrigger4,
                    Entry = itemTemplate.SpellId4,
                    Name = spell.Name,
                    Description = spell.Description
                });
            }
        }

        if (itemTemplate.SpellId5 > 0)
        {
            var spell = dbContext.SpellTemplate.FirstOrDefault(s => s.Entry == itemTemplate.SpellId5);
            if (spell is not null)
            {
                spells.Add(new MangosItemSpell()
                {
                    Trigger = itemTemplate.SpellTrigger5,
                    Entry = itemTemplate.SpellId5,
                    Name = spell.Name,
                    Description = spell.Description
                });
            }
        }

        return spells;
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
}
