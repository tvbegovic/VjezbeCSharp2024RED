double IzracunKamata(double glavnica, double stopa)
{
    if(stopa < 0 || stopa > 20)
    {
        throw new ArgumentOutOfRangeException("Stopa mora biti između 0 i 20");
    }
    return glavnica * stopa / 100;
}

bool nastavi = true;
do
{
    Console.Write("Glavnica: ");
    string unos = Console.ReadLine();
    if(string.IsNullOrEmpty(unos))
        nastavi = false;
    else
    {
        bool ok = double.TryParse(unos, out double glavnica);
        if(!ok)
        {
            Console.WriteLine("Neispravan format broja");
            continue;
        }
        Console.Write("Stopa: ");
        unos = Console.ReadLine();
        ok = double.TryParse(unos, out double stopa);
        if(!ok)
        {
            Console.WriteLine("Neispravan format broja");
            continue;
        }
        try
        {
            double kamata = IzracunKamata(glavnica, stopa);
            Console.WriteLine($"Za unesenu glavnicu {glavnica:N2} i stopu {stopa}% kamata iznosi {kamata:N2}");
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
} while (nastavi);