using vMake.Database.Types;

namespace vMake.Extensions;

public static class MangosColorExtensions
{
    public static string ToHexColor(this MangosClass mangosClass)
    {
        return mangosClass switch
        {
            MangosClass.Warrior => "C69B6D",
            MangosClass.Paladin => "F48CBA",
            MangosClass.Hunter => "AAD372",
            MangosClass.Rogue => "FFF468",
            MangosClass.Priest => "FFFFFF",
            MangosClass.DeathKnight => "C41E3A",
            MangosClass.Shaman => "0070DD",
            MangosClass.Mage => "3FC7EB",
            MangosClass.Warlock => "8788EE",
            MangosClass.Druid => "FF7C0A",
            _ => "FFFFFF"
        };
    }

    public static string ToHexColor(this MangosItemQuality quality)
    {
        return quality switch
        {
            MangosItemQuality.Poor => "9D9D9D",
            MangosItemQuality.Common => "FFFFFF",
            MangosItemQuality.Uncommon => "1EFF00",
            MangosItemQuality.Rare => "0070DD",
            MangosItemQuality.Epic => "A335EE",
            MangosItemQuality.Legendary => "FF8000",
            MangosItemQuality.Artifact => "E6CC80",
            _ => "FFFFFF"
        };
    }
}
