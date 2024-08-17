using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations.Schema;

using vMake.Database.Types;

namespace vMake.Database.Tables;

[PrimaryKey(nameof(Entry), nameof(Patch))]
[Table("item_template")]
public class MangosItemTemplate
{
    [Column("entry")]
    public int Entry { get; set; }

    [Column("patch")]
    public int Patch { get; set; }

    [Column("class")]
    public MangosItemClass ItemClass { get; set; }

    [Column("subclass")]
    public int ItemSubClass { get; set; }

    [Column("name")]
    public string? Name { get; set; } = "";

    [Column("description")]
    public string? Description { get; set; } = "";

    [Column("display_id")]
    public int DisplayId { get; set; }

    [Column("quality")]
    public MangosItemQuality Quality { get; set; }

    [Column("flags")]
    public MangosItemFlags Flags { get; set; }

    [Column("buy_count")]
    public int BuyCount { get; set; }

    [Column("buy_price")]
    public int BuyPrice { get; set; }

    [Column("sell_price")]
    public int SellPrice { get; set; }

    [Column("inventory_type")]
    public MangosInventoryType InventoryType { get; set; }

    [Column("allowable_class")]
    public int AllowableClass { get; set; }

    [Column("allowable_race")]
    public int AllowableRace { get; set; }

    [Column("item_level")]
    public int ItemLevel { get; set; }

    [Column("required_level")]
    public int RequiredLevel { get; set; }

    [Column("required_skill")]
    public int RequiredSkill { get; set; }

    [Column("required_skill_rank")]
    public int RequiredSkillRank { get; set; }

    [Column("required_spell")]
    public int RequiredSpell { get; set; }

    [Column("required_honor_rank")]
    public int RequiredHonorRank { get; set; }

    [Column("required_city_rank")]
    public int RequiredCityRank { get; set; }

    [Column("required_reputation_faction")]
    public int RequiredReputationFaction { get; set; }

    [Column("required_reputation_rank")]
    public int RequiredReputationRank { get; set; }

    [Column("max_count")]
    public int MaxCount { get; set; }

    [Column("stackable")]
    public int MaxStackSize { get; set; }

    [Column("container_slots")]
    public int ContainerSlots { get; set; }

    [Column("stat_type1")]
    public MangosItemStatType StatType1 { get; set; }

    [Column("stat_value1")]
    public int StatValue1 { get; set; }

    [Column("stat_type2")]
    public MangosItemStatType StatType2 { get; set; }

    [Column("stat_value2")]
    public int StatValue2 { get; set; }

    [Column("stat_type3")]
    public MangosItemStatType StatType3 { get; set; }

    [Column("stat_value3")]
    public int StatValue3 { get; set; }

    [Column("stat_type4")]
    public MangosItemStatType StatType4 { get; set; }

    [Column("stat_value4")]
    public int StatValue4 { get; set; }

    [Column("stat_type5")]
    public MangosItemStatType StatType5 { get; set; }

    [Column("stat_value5")]
    public int StatValue5 { get; set; }

    [Column("stat_type6")]
    public MangosItemStatType StatType6 { get; set; }

    [Column("stat_value6")]
    public int StatValue6 { get; set; }

    [Column("stat_type7")]
    public MangosItemStatType StatType7 { get; set; }

    [Column("stat_value7")]
    public int StatValue7 { get; set; }

    [Column("stat_type8")]
    public MangosItemStatType StatType8 { get; set; }

    [Column("stat_value8")]
    public int StatValue8 { get; set; }

    [Column("stat_type9")]
    public MangosItemStatType StatType9 { get; set; }

    [Column("stat_value9")]
    public int StatValue9 { get; set; }

    [Column("stat_type10")]
    public MangosItemStatType StatType10 { get; set; }

    [Column("stat_value10")]
    public int StatValue10 { get; set; }

    [Column("delay")]
    public int Delay { get; set; }

    [Column("range_mod")]
    public float RangeModifier { get; set; }

    [Column("ammo_type")]
    public int AmmoType { get; set; }

    [Column("dmg_min1")]
    public float DmgMin1 { get; set; }

    [Column("dmg_max1")]
    public float DmgMax1 { get; set; }

    [Column("dmg_type1")]
    public MangosItemDamageType DmgType1 { get; set; }

    [Column("dmg_min2")]
    public float DmgMin2 { get; set; }

    [Column("dmg_max2")]
    public float DmgMax2 { get; set; }

    [Column("dmg_type2")]
    public MangosItemDamageType DmgType2 { get; set; }

    [Column("dmg_min3")]
    public float DmgMin3 { get; set; }

    [Column("dmg_max3")]
    public float DmgMax3 { get; set; }

    [Column("dmg_type3")]
    public MangosItemDamageType DmgType3 { get; set; }

    [Column("dmg_min4")]
    public float DmgMin4 { get; set; }

    [Column("dmg_max4")]
    public float DmgMax4 { get; set; }

    [Column("dmg_type4")]
    public MangosItemDamageType DmgType4 { get; set; }

    [Column("dmg_min5")]
    public float DmgMin5 { get; set; }

    [Column("dmg_max5")]
    public float DmgMax5 { get; set; }

    [Column("dmg_type5")]
    public MangosItemDamageType DmgType5 { get; set; }

    [Column("block")]
    public int Block { get; set; }

    [Column("armor")]
    public int Armor { get; set; }

    [Column("holy_res")]
    public int HolyResistance { get; set; }

    [Column("fire_res")]
    public int FireResistance { get; set; }

    [Column("nature_res")]
    public int NatureResistance { get; set; }

    [Column("frost_res")]
    public int FrostResistance { get; set; }

    [Column("shadow_res")]
    public int ShadowResistance { get; set; }

    [Column("arcane_res")]
    public int ArcaneResistance { get; set; }

    [Column("spellid_1")]
    public int SpellId1 { get; set; }

    [Column("spelltrigger_1")]
    public MangosItemSpellTrigger SpellTrigger1 { get; set; }

    [Column("spellcharges_1")]
    public int SpellCharges1 { get; set; }

    [Column("spellppmrate_1")]
    public float SpellPPMRate1 { get; set; }

    [Column("spellcooldown_1")]
    public int SpellCooldown1 { get; set; }

    [Column("spellcategory_1")]
    public int SpellCategory1 { get; set; }

    [Column("spellcategorycooldown_1")]
    public int SpellCategoryCooldown1 { get; set; }

    [Column("spellid_2")]
    public int SpellId2 { get; set; }

    [Column("spelltrigger_2")]
    public MangosItemSpellTrigger SpellTrigger2 { get; set; }

    [Column("spellcharges_2")]
    public int SpellCharges2 { get; set; }

    [Column("spellppmrate_2")]
    public float SpellPPMRate2 { get; set; }

    [Column("spellcooldown_2")]
    public int SpellCooldown2 { get; set; }

    [Column("spellcategory_2")]
    public int SpellCategory2 { get; set; }

    [Column("spellcategorycooldown_2")]
    public int SpellCategoryCooldown2 { get; set; }

    [Column("spellid_3")]
    public int SpellId3 { get; set; }

    [Column("spelltrigger_3")]
    public MangosItemSpellTrigger SpellTrigger3 { get; set; }

    [Column("spellcharges_3")]
    public int SpellCharges3 { get; set; }

    [Column("spellppmrate_3")]
    public float SpellPPMRate3 { get; set; }

    [Column("spellcooldown_3")]
    public int SpellCooldown3 { get; set; }

    [Column("spellcategory_3")]
    public int SpellCategory3 { get; set; }

    [Column("spellcategorycooldown_3")]
    public int SpellCategoryCooldown3 { get; set; }

    [Column("spellid_4")]
    public int SpellId4 { get; set; }

    [Column("spelltrigger_4")]
    public MangosItemSpellTrigger SpellTrigger4 { get; set; }

    [Column("spellcharges_4")]
    public int SpellCharges4 { get; set; }

    [Column("spellppmrate_4")]
    public float SpellPPMRate4 { get; set; }

    [Column("spellcooldown_4")]
    public int SpellCooldown4 { get; set; }

    [Column("spellcategory_4")]
    public int SpellCategory4 { get; set; }

    [Column("spellcategorycooldown_4")]
    public int SpellCategoryCooldown4 { get; set; }

    [Column("spellid_5")]
    public int SpellId5 { get; set; }

    [Column("spelltrigger_5")]
    public MangosItemSpellTrigger SpellTrigger5 { get; set; }

    [Column("spellcharges_5")]
    public int SpellCharges5 { get; set; }

    [Column("spellppmrate_5")]
    public float SpellPPMRate5 { get; set; }

    [Column("spellcooldown_5")]
    public int SpellCooldown5 { get; set; }

    [Column("spellcategory_5")]
    public int SpellCategory5 { get; set; }

    [Column("spellcategorycooldown_5")]
    public int SpellCategoryCooldown5 { get; set; }

    [Column("bonding")]
    public MangosItemBonding Bonding { get; set; }

    [Column("page_text")]
    public int PageTextId { get; set; }

    [Column("page_language")]
    public int PageLanguage { get; set; }

    [Column("page_material")]
    public int PageMaterial { get; set; }

    [Column("start_quest")]
    public int StartQuestId { get; set; }

    [Column("set_id")]
    public int SetId { get; set; }

    [Column("max_durability")]
    public int DurabilityMax { get; set; }

    [Column("area_bound")]
    public int BoundAreaId { get; set; }

    [Column("map_bound")]
    public int BoundMapId { get; set; }

    [Column("duration")]
    public int Duration { get; set; }

    [Column("bag_family")]
    public int BagFamily { get; set; }

    [Column("disenchant_id")]
    public int DisenchantId { get; set; }

    [Column("food_type")]
    public int FoodType { get; set; }

    [Column("min_money_loot")]
    public int MoneyLootMin { get; set; }

    [Column("max_money_loot")]
    public int MoneyLootMax { get; set; }

    [Column("wrapped_gift")]
    public int WrappedGift { get; set; }

    [Column("extra_flags")]
    public int ExtraFlags { get; set; }

    [Column("other_team_entry")]
    public int EntryOtherTeam { get; set; }
}
