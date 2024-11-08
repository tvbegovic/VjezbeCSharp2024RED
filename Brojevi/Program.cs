﻿bool nastavi = true;
do
{
    Console.Write("Unesite broj elemenata (1-100): ");
    string unos = Console.ReadLine();
    if(string.IsNullOrEmpty(unos))
        nastavi = false;
    else
    {
        bool ok = int.TryParse(unos, out int brojElemenata);
        if(!ok)
        {
            Console.WriteLine("Pogrešan format");
            continue;
        }
        if(brojElemenata < 1 || brojElemenata > 100 )
        {
            Console.WriteLine("Broj je izvan raspona");
            continue;
        }
        int[] brojevi = new int[brojElemenata];
        int i = 0;
        while (i < brojElemenata)
        {
            Console.Write($"Element {i+1}: ");
            unos = Console.ReadLine();
            ok = int.TryParse(unos, out brojevi[i]);
            if(!ok)
            {
                Console.WriteLine("Pogrešan format broja");
                continue;
            }
            i++;
        }
        Console.WriteLine("Unijeli ste sljedeće polje: ");
        foreach (var broj in brojevi)
        {
            Console.Write($"{broj} ");
        }
        Console.WriteLine();
        Console.WriteLine("Sortirano polje je: ");
        Array.Sort(brojevi);
        foreach (var broj in brojevi)
        {
            Console.Write($"{broj} ");
        }
        Console.WriteLine();
        int zbroj = 0;
        int min = brojevi[0];
        int max = brojevi[0];
        foreach (var broj in brojevi)
        {
            zbroj += broj;
            if(broj < min)
                min = broj;
            if(broj > max) 
                max = broj;
        }
        double prosjek = zbroj * 1.0 / brojElemenata;
        Console.WriteLine($"Zbroj je {zbroj}, prosjek Je {prosjek:N2}, najmanji element je {min} a najveći element je {max}");

    }
}
while (nastavi);
