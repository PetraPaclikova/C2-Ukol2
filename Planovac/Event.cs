using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planovac
{
    public class Akce
    {
        public string NazevAkce { get; set; }
        public DateTime DatumAkce { get; set; }
        public Akce(string nazevAkce, DateTime datumAkce)
        {
            NazevAkce = nazevAkce;
            DatumAkce = datumAkce;
        }

        public void ZobrazAkci()
        {
            if (DatumAkce > DateTime.Now)
            {
                TimeSpan rozdil = DatumAkce - DateTime.Now;
                Console.WriteLine($"Akce {NazevAkce} s datem {DatumAkce:yyyy-MM-dd} se uskutecni za {rozdil.Days} dni");
            }
            else
            {
                TimeSpan rozdil = DateTime.Now - DatumAkce;
                Console.WriteLine($"Akce {NazevAkce} s datem {DatumAkce:yyyy-MM-dd} se uskutecnila pred {rozdil.Days} dny");
            }
        }
    }
}