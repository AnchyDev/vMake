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
}
