//1. korak - funkcija koja vraća jednu vrijednost
double Kvadrat(double broj)
{
    return broj * broj;
}
//2. korak - funkcija vraća 2 vrijednosti
double KvadratKub(double broj, out double kub)
{
    double kvadrat = broj * broj;
    kub = broj * broj * broj;
    return kvadrat;
}
//3. korak - funkcija vraća obje vrijednosti preko out parametara
void KvadratKub2(double broj, out double kvadrat, out double kub)
{
    kvadrat = broj * broj;
    kub = Math.Pow(broj, 3);
}

//Pozivamo funkciju kvadrat
double kvadrat = Kvadrat(340);
Console.WriteLine(kvadrat);
kvadrat = KvadratKub(340, out double kubBroja);
Console.WriteLine($"Kvadrat je {kvadrat} a kub je {kubBroja}");

KvadratKub2(340, out double kvadrat2, out double kub2);
Console.WriteLine($"Kvadrat je {kvadrat2} a kub je {kub2}");
