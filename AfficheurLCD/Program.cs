using System.Text;

string Print1()
{
    return "   " + Environment.NewLine +
           "  |" + Environment.NewLine +
           "  |";
}

string Print2()
{
    return  " _ " + Environment.NewLine +
            " _|" + Environment.NewLine +
            "|_ ";
}

string Concat(string a, string b)
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

string Print(uint nb)
{
    switch (nb)
    {
        case 1:
            return Print1();
        case 2:
            return Print2();
        default:
            return Concat(
                Print(nb / 10),
                Print(nb % 10)
            );
    }
}

Console.WriteLine(Print(12111));
