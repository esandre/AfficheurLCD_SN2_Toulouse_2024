void Print_1()
{
    Console.WriteLine("  " + Environment.NewLine +
                      "  |" + Environment.NewLine +
                      "  |");
}

void Print_2()
{
    Console.WriteLine(" _ " + Environment.NewLine +
                      " _|" + Environment.NewLine +
                      "|_ ");
}

void Print(uint nb)
{
    switch (nb)
    {
        case 1:
            Print_1();
            break;
        case 2:
            Print_2();
            break;
        default:
            Print(nb / 10);
            Print(nb % 10);
            break;
    }
}

Print(12111);
