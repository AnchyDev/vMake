using vMake.Database.Types;

namespace vMake.Extensions;

public static class MangosDisplayTextExtensions
{
    public static string ToDisplayText(this MangosItemBonding bonding)
    {
        return bonding switch
        {
            MangosItemBonding.BindOnPickup => "Binds when picked up",
            MangosItemBonding.BindOnEquip => "Binds when equipped",
            MangosItemBonding.BindOnUse => "Binds when used",
            MangosItemBonding.Quest => "Quest Item",
            _ => bonding.ToString()
        };
    }

    public static string ToDisplayText(this MangosInventoryType invType)
    {
        return invType switch
        {
            MangosInventoryType.NotEquipable => "Not Equipable",
            MangosInventoryType.Ammo => "Projectile",
            MangosInventoryType.Weapon => "One-hand",
            MangosInventoryType.Weapon2H => "Two-Hand",
            MangosInventoryType.WeaponMainHand => "Main Hand",
            MangosInventoryType.WeaponOffHand => "Off Hand",
            MangosInventoryType.Cloak => "Back",
            _ => invType.ToString()
        };
    }

    public static string ToDisplayText(this MangosItemSpellTrigger bonding)
    {
        return bonding switch
        {
            MangosItemSpellTrigger.OnUse => "Use",
            MangosItemSpellTrigger.OnEquip => "Equip",
            MangosItemSpellTrigger.ChanceOnHit => "Chance on hit",
            _ => bonding.ToString()
        };
    }

    public static string ToDisplayText(this MangosItemClass itemClass)
    {
        return itemClass switch
        {
            MangosItemClass.TradeGoods => "Trade Goods",
            _ => itemClass.ToString()
        };
    }

    public static string ToDisplayText(this MangosItemClass itemClass, int itemSubClass)
    {
        return itemClass switch
        {
            MangosItemClass.Consumable => ToDisplayText((MangosItemConsumableSubClass)itemSubClass),
            MangosItemClass.Container => ToDisplayText((MangosItemContainerSubClass)itemSubClass),
            MangosItemClass.Weapon => ToDisplayText((MangosItemWeaponSubClass)itemSubClass),
            MangosItemClass.Armor => ToDisplayText((MangosItemArmorSubClass)itemSubClass),
            MangosItemClass.Reagent => ToDisplayText((MangosItemReagentSubClass)itemSubClass),
            MangosItemClass.Projectile => ToDisplayText((MangosItemProjectileSubClass)itemSubClass),
            MangosItemClass.TradeGoods => ToDisplayText((MangosItemTradeGoodsSubClass)itemSubClass),
            MangosItemClass.Recipe => ToDisplayText((MangosItemRecipeSubClass)itemSubClass),
            MangosItemClass.Quiver => ToDisplayText((MangosItemQuiverSubClass)itemSubClass),
            MangosItemClass.Quest => ToDisplayText((MangosItemQuestSubClass)itemSubClass),
            MangosItemClass.Key => ToDisplayText((MangosItemKeySubClass)itemSubClass),
            MangosItemClass.Miscellaneous => ToDisplayText((MangosItemMiscellaneousSubClass)itemSubClass),
            _ => "No subclass text found"
        };
    }

    public static string ToDisplayText(this MangosItemConsumableSubClass itemSubClass)
    {
        return itemSubClass switch
        {
            _ => itemSubClass.ToString()
        };
    }

    public static string ToDisplayText(this MangosItemContainerSubClass itemSubClass)
    {
        return itemSubClass switch
        {
            _ => itemSubClass.ToString()
        };
    }

    public static string ToDisplayText(this MangosItemWeaponSubClass itemSubClass)
    {
        return itemSubClass switch
        {
            MangosItemWeaponSubClass.Axe1H or
            MangosItemWeaponSubClass.Axe2H => "Axe",

            MangosItemWeaponSubClass.Sword1H or
            MangosItemWeaponSubClass.Sword2H => "Sword",

            MangosItemWeaponSubClass.Mace1H or
            MangosItemWeaponSubClass.Mace2H => "Mace",

            MangosItemWeaponSubClass.FishingPole => "Fishing Pole",

            _ => itemSubClass.ToString()
        };
    }

    public static string ToDisplayText(this MangosItemArmorSubClass itemSubClass)
    {
        return itemSubClass switch
        {
            _ => itemSubClass.ToString()
        };
    }

    public static string ToDisplayText(this MangosItemReagentSubClass itemSubClass)
    {
        return itemSubClass switch
        {
            _ => itemSubClass.ToString()
        };
    }

    public static string ToDisplayText(this MangosItemProjectileSubClass itemSubClass)
    {
        return itemSubClass switch
        {
            _ => itemSubClass.ToString()
        };
    }

    public static string ToDisplayText(this MangosItemTradeGoodsSubClass itemSubClass)
    {
        return itemSubClass switch
        {
            _ => itemSubClass.ToString()
        };
    }

    public static string ToDisplayText(this MangosItemRecipeSubClass itemSubClass)
    {
        return itemSubClass switch
        {
            _ => itemSubClass.ToString()
        };
    }

    public static string ToDisplayText(this MangosItemQuiverSubClass itemSubClass)
    {
        return itemSubClass switch
        {
            _ => itemSubClass.ToString()
        };
    }

    public static string ToDisplayText(this MangosItemQuestSubClass itemSubClass)
    {
        return itemSubClass switch
        {
            _ => itemSubClass.ToString()
        };
    }

    public static string ToDisplayText(this MangosItemKeySubClass itemSubClass)
    {
        return itemSubClass switch
        {
            _ => itemSubClass.ToString()
        };
    }

    public static string ToDisplayText(this MangosItemMiscellaneousSubClass itemSubClass)
    {
        return itemSubClass switch
        {
            _ => itemSubClass.ToString()
        };
    }
}
