using System.Text;

string Print1(uint sizeX = 1)
{
    var spaces = new string(' ', (int) sizeX + 2);

    return spaces + " " + Environment.NewLine +
           spaces + "|" + Environment.NewLine +
           spaces + "|";
}

string Print2(uint sizeX = 1)
{
    var underscores = new string('_', (int) sizeX);

    return  " " + underscores + " " + Environment.NewLine +
            " " + underscores + "|" + Environment.NewLine +
            "|" + underscores + " ";
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

string Print(uint nb, uint sizeX = 1)
{
    switch (nb)
    {
        case 1:
            return Print1(sizeX);
        case 2:
            return Print2(sizeX);
        default:
            return Concat(
                Print(nb / 10, sizeX),
                Print(nb % 10, sizeX)
            );
    }
}

Console.WriteLine(Print(12111));
Console.WriteLine(Print(12111, 2));
