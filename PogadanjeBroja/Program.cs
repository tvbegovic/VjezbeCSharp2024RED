using System.Runtime;

Console.WriteLine("Zamislio sam broj od 1-10. Probaj ga pogoditi i možda dobiješ čokoladu");
Random random = new Random();
int zamisljeniBroj = random.Next(1, 11);
Console.Write("Koji sam broj zamislio? ");
string unos = Console.ReadLine();
bool ok = int.TryParse(unos, out int broj);
if(!ok)
{
    Console.WriteLine("Broj je u pogrešnom formatu");
    return;
}
if(broj < 1 ||  broj > 10)
{
    Console.WriteLine("Broj je izvan raspona");
    return;
}
int razlika = Math.Abs(zamisljeniBroj - broj);
string tekst = string.Empty;
switch(razlika)
{
    case 0:
        tekst = "Sjajno, pogodili ste broj. Imate čokoladu";
        break;
    case 1:
    case 2:
    case 3:
        tekst = $"Broj je {zamisljeniBroj}. Jako dobro. Osvajate pola čokolade";
        break;
    case 4:
    case 5:
    case 6:
        tekst = $"Broj je {zamisljeniBroj}. Solidno. Dobili ste jedno rebro čokolade";
        break;
    default:
        Console.WriteLine("Više sreće drugi put");
        break;
}
Console.WriteLine(tekst);
