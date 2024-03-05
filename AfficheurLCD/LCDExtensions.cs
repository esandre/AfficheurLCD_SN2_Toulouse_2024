using System.Text;

namespace AfficheurLCD;

public static class LCDExtensions
{
    public static string AsLCD(this int n)
    {
        if (n == 11) return Onze();
        if (n == 111) return Concat(Nombres.Un, Onze());

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
            _ => AsLCD(n/10) + Environment.NewLine + AsLCD(n%10)
        };
    }

    private static string Onze()
    {
        return Concat(Nombres.Un, Nombres.Un);
    }

    private static string Concat(string a, string b)
    {
        var linesA = a.Split(Environment.NewLine).GetEnumerator();
        using var disposeA = linesA as IDisposable;

        var linesB = b.Split(Environment.NewLine).GetEnumerator();
        using var disposeB = linesB as IDisposable;

        var builder = new StringBuilder();
        while (linesA.MoveNext() && linesB.MoveNext())
        {
            builder.Append(linesA.Current);
            builder.Append(' ');
            builder.Append(linesB.Current);
            builder.AppendLine();
        }

        return builder.ToString();
    }
}