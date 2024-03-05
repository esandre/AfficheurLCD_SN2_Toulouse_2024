using System.Text;

string Print1(uint sizeX = 1, uint sizeY = 1)
{
    var spaces = new string(' ', (int) sizeX + 2);
    var firstLine = spaces + " ";
    var middleAndLastLine = spaces + "|";

    var builder = new StringBuilder();
    builder.AppendLine(firstLine);

    for (var i = 0; i < sizeY * 2; i++)
        builder.AppendLine(middleAndLastLine);

    return builder.ToString();
}

string Print2(uint sizeX = 1, uint sizeY = 1)
{
    var underscores = new string('_', (int) sizeX);
    var firstLine = " " + underscores + " ";
    var firstHalfFillerLine = new string(' ', (int) sizeX  + 1) + '|';
    var middleLine = " " + underscores + "|";
    var secondHalfFillerLine = '|' + new string(' ', (int) sizeX  + 1);
    var lastLine = "|" + underscores + " ";

    var numberOfFillers = sizeY / 2;

    var builder = new StringBuilder();
    builder.AppendLine(firstLine);

    for (var i = 0; i < numberOfFillers; i++)
        builder.AppendLine(firstHalfFillerLine);

    builder.AppendLine(middleLine);

    for (var i = 0; i < numberOfFillers; i++)
        builder.AppendLine(secondHalfFillerLine);
    
    builder.AppendLine(lastLine);

    return builder.ToString();
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

string Print(uint nb, uint sizeX = 1, uint sizeY = 1)
{
    switch (nb)
    {
        case 1:
            return Print1(sizeX, sizeY);
        case 2:
            return Print2(sizeX, sizeY);
        default:
            return Concat(
                Print(nb / 10, sizeX, sizeY),
                Print(nb % 10, sizeX, sizeY)
            );
    }
}

Console.WriteLine(Print(12111));
Console.WriteLine(Print(12111, sizeX: 2));
Console.WriteLine(Print(12111, sizeY: 2));
Console.WriteLine(Print(12111, 2, 2));
