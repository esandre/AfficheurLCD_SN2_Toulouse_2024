namespace AfficheurLCD;

public static class LCDExtensions
{
    public static string AsLCD(this int n)
    {
        return n switch
        {
            0 => Nombres.Zero,
            1 => Nombres.Un,
            2 => Nombres.Deux,
            3 => Nombres.Trois,
            4 => Nombres.Quatre,
            5 => Nombres.Cinq,
            6 => Nombres.Six,
            7 => Nombres.Sept,
            8 => Nombres.Huit,
            9 => Nombres.Neuf,
            _ => throw new NotSupportedException()
        };
    }
}