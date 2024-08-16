using System.Text.Json;

using vMake.Database;
using vMake.Database.Tables;
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
        switch (bonding)
        {
            case MangosItemBonding.BindOnPickup:
                return "Binds when picked up";

            case MangosItemBonding.BindOnEquip:
                return "Binds when equipped";

            case MangosItemBonding.BindOnUse:
                return "Binds when used";

            case MangosItemBonding.Quest:
                return "Quest Item";
        }

        return bonding.ToString();
    }

    public static string GetItemClassText(this MangosItemClass itemClass)
    {
        switch (itemClass)
        {
            case MangosItemClass.TradeGoods:
                return "Trade Goods";
        }

        return itemClass.ToString();
    }

    public static string GetInventoryTypeText(this MangosInventoryType invType)
    {
        switch (invType)
        {
            case MangosInventoryType.NotEquipable:
                return "Not Equipable";

            case MangosInventoryType.Weapon2H:
                return "Two-Hand";

            case MangosInventoryType.WeaponMainHand:
                return "Main Hand";

            case MangosInventoryType.WeaponOffHand:
                return "Off Hand";

            case MangosInventoryType.Cloak:
                return "Back";
        }

        return invType.ToString();
    }

    public static string GetTriggerText(this MangosItemSpellTrigger bonding)
    {
        switch (bonding)
        {
            case MangosItemSpellTrigger.OnUse:
                return "Use";

            case MangosItemSpellTrigger.OnEquip:
                return "Equip";

            case MangosItemSpellTrigger.ChanceOnHit:
                return "Chance on hit";

            case MangosItemSpellTrigger.Soulstone:
                return "Use";

            case MangosItemSpellTrigger.OnUseWithoutDelay:
                return "Use";
        }

        return "";
    }

    public static Dictionary<int, string> GetSubClass(this MangosItemClass itemClass)
    {
        Type subClassType = itemClass switch
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

    public static string GetSubClassText(this MangosItemClass itemClass, int itemSubClass)
    {
        switch(itemClass)
        {
            case MangosItemClass.Consumable:
                return GetSubClassConsumableText((MangosItemConsumableSubClass)itemSubClass);

            case MangosItemClass.Container:
                return GetSubClassContainerText((MangosItemContainerSubClass)itemSubClass);

            case MangosItemClass.Weapon:
                return GetSubClassWeaponText((MangosItemWeaponSubClass)itemSubClass);

            case MangosItemClass.Armor:
                return GetSubClassArmorText((MangosItemArmorSubClass)itemSubClass);

            case MangosItemClass.Reagent:
                return GetSubClassReagentText((MangosItemReagentSubClass)itemSubClass);

            case MangosItemClass.Projectile:
                return GetSubClassProjectileText((MangosItemProjectileSubClass)itemSubClass);

            case MangosItemClass.TradeGoods:
                return GetSubClassTradeGoodsText((MangosItemTradeGoodsSubClass)itemSubClass);

            case MangosItemClass.Recipe:
                return GetSubClassRecipeText((MangosItemRecipeSubClass)itemSubClass);

            case MangosItemClass.Quiver:
                return GetSubClassQuiverText((MangosItemQuiverSubClass)itemSubClass);

            case MangosItemClass.Quest:
                return GetSubClassQuestText((MangosItemQuestSubClass)itemSubClass);

            case MangosItemClass.Key:
                return GetSubClassKeyText((MangosItemKeySubClass)itemSubClass);

            case MangosItemClass.Miscellaneous:
                return GetSubClassMiscellaneousText((MangosItemMiscellaneousSubClass)itemSubClass);
        }

        return "";
    }

    public static string GetSubClassConsumableText(this MangosItemConsumableSubClass itemSubClass)
    {
        return itemSubClass.ToString();
    }

    public static string GetSubClassContainerText(this MangosItemContainerSubClass itemSubClass)
    {
        return itemSubClass.ToString();
    }

    public static string GetSubClassWeaponText(this MangosItemWeaponSubClass itemSubClass)
    {
        return itemSubClass.ToString();
    }

    public static string GetSubClassArmorText(this MangosItemArmorSubClass itemSubClass)
    {
        return itemSubClass.ToString();
    }

    public static string GetSubClassReagentText(this MangosItemReagentSubClass itemSubClass)
    {
        return itemSubClass.ToString();
    }

    public static string GetSubClassProjectileText(this MangosItemProjectileSubClass itemSubClass)
    {
        return itemSubClass.ToString();
    }

    public static string GetSubClassTradeGoodsText(this MangosItemTradeGoodsSubClass itemSubClass)
    {
        return itemSubClass.ToString();
    }

    public static string GetSubClassRecipeText(this MangosItemRecipeSubClass itemSubClass)
    {
        return itemSubClass.ToString();
    }

    public static string GetSubClassQuiverText(this MangosItemQuiverSubClass itemSubClass)
    {
        return itemSubClass.ToString();
    }

    public static string GetSubClassQuestText(this MangosItemQuestSubClass itemSubClass)
    {
        return itemSubClass.ToString();
    }

    public static string GetSubClassKeyText(this MangosItemKeySubClass itemSubClass)
    {
        return itemSubClass.ToString();
    }

    public static string GetSubClassMiscellaneousText(this MangosItemMiscellaneousSubClass itemSubClass)
    {
        return itemSubClass.ToString();
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
}
