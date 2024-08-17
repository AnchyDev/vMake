namespace vMake.Database.Types;

public struct MangosCurrency
{
    public int Gold { get; set; }
    public int Silver { get; set; }
    public int Copper { get; set; }

    public static MangosCurrency ToCurrency(int copper)
    {
        const int copperPerSilver = 100;
        const int silverPerGold = 100;

        int gold = copper / (silverPerGold * copperPerSilver);
        int silver = (copper % (silverPerGold * copperPerSilver)) / copperPerSilver;
        copper = copper % copperPerSilver;

        return new MangosCurrency()
        {
            Gold = gold,
            Silver = silver,
            Copper = copper
        };
    }
}
