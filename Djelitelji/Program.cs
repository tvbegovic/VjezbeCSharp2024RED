﻿bool nastavi = true;

do
{
    Console.Write("Unesite broj (1-100.000): ");
    string unos = Console.ReadLine();
    if(string.IsNullOrEmpty(unos))
        nastavi = false;
    else
    {
        bool ok = int.TryParse(unos, out int broj);
        if (!ok)
        {
            Console.WriteLine("Pogrešan format broja");
            continue;
        }
        if (broj < 1 || broj > 100000)
        {
            Console.WriteLine("Broj je izvan raspona");
            continue;
        }
        //da izbjegnemo overflow kod 100.000, int mijenjamo u long
        //int zbroj = 0;
        long zbroj = 0;
        for (int i = 1; i <= broj; i++)
        {
            if (i % 3 == 0 || i % 5 == 0)
                zbroj += i;
        }
        Console.WriteLine($"Zbroj brojeva od 1 do {broj} djeljivih sa 3 ili 5 je {zbroj:N0}"); 
    } 
} while (nastavi);