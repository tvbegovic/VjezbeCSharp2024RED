Console.Write("Datum 1: ");
string unos = Console.ReadLine();
bool ok = DateTime.TryParse(unos, out DateTime datum1);
if(!ok)
{
    Console.WriteLine("Pogrešan format datuma");
    return;
}
Console.Write("Datum 2: ");
unos = Console.ReadLine();
ok = DateTime.TryParse(unos, out DateTime datum2);
if(!ok)
{
    Console.WriteLine("Pogrešan format datuma");
    return;
}
if(datum1 < datum2)
{
    Console.WriteLine($"Osoba 1 je starija od osobe 2 za {(datum2 - datum1).TotalDays} dana");
}
else if (datum1 > datum2)
{
    Console.WriteLine($"Osoba 2 je starija od osobe 1 za {(datum1 - datum2).TotalDays} dana");
}
else
{
    Console.WriteLine("Osobe su rođene na isti datum");
}
