Console.Write("Unesite redni broj mjeseca (1-12): ");
string unos = Console.ReadLine();
bool ok = int.TryParse(unos, out int redniBroj);
if(!ok)
{
    Console.WriteLine("Pogrešan format broja");
    return;
}
if(redniBroj < 1 ||  redniBroj > 12)
{
    Console.WriteLine("Broj je izvan raspona");
    return;
}
int brojDana;
switch(redniBroj)
{
    case 2:
        if (DateTime.IsLeapYear(DateTime.Now.Year))
            brojDana = 29;
        else
            brojDana = 28;
        break;
    case 4:
    case 6:
    case 9:
    case 11:
        brojDana = 30;
        break;
    default:
        brojDana = 31;
        break;
}
string dani = "dana";
if (brojDana == 31)
    dani = "dan";
Console.WriteLine($"{redniBroj}. mjesec ima {brojDana} {dani}");