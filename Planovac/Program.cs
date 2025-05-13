using System.Globalization;

namespace Planovac;

class Program
{
    static List<Akce> seznamAkci = new List<Akce>();
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Co chces udelat?");
            Console.WriteLine("1. Pridat udalost");
            Console.WriteLine("2. Vypsat udalosti");
            Console.WriteLine("3. Zobrazit statistiku");
            Console.WriteLine("4. Ukoncit program");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    {
                        Console.WriteLine("Zadej nazev akce a jeji datum ve formatu: název akce; datum akce ve formátu YYYY-MM-DD");
                        string vstup = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(vstup))
                        {
                            break;
                        }
                        string[] casti = vstup.Split(';');
                        if (casti.Length != 2)
                        {
                            Console.WriteLine("Zadan neplatny vstup. Vloz nazev akce ve formatu: název akce; datum akce ve formátu YYYY-MM-DD");
                            continue;
                        }
                        string nazev = casti[0];
                        string datumText = casti[1];
                        if (!DateTime.TryParse(datumText, out DateTime datum))
                        {
                            Console.WriteLine("Datum je špatně. Použij formát YYYY-MM-DD.");
                            continue;
                        }
                        var novaAkce = new Akce(nazev, datum);
                        seznamAkci.Add(novaAkce);
                        Console.WriteLine("Akce přidána.");
                    }
                    break;
                case "2":
                    ZobrazAkce();
                    break;
                case "3":
                    Dictionary<DateTime, int> dict = seznamAkci
                    .GroupBy(s => s.DatumAkce)
                    .ToDictionary(g => g.Key, g => g.Count());
                    foreach (var zaznam in dict.OrderBy(k => k.Key))
                    {
                        Console.WriteLine($"Datum: {zaznam.Key:yyyy-MM-dd}: akce: {zaznam.Value}");
                    }
                    break;
                case "4":
                    Console.WriteLine("Konec");
                    return;
                default:
                    Console.WriteLine("Neplatná volba, zadej 1, 2, 3 nebo 4.");
                    break;
            }
        }
        static void ZobrazAkce()
        {
            foreach (Akce akce in seznamAkci)
            {
                akce.ZobrazAkci();
            }
        }
    }
}








