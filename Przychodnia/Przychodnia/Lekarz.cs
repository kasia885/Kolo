using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{
    class Lekarz : Osoba
    {
        private string specjalnosc;

        public Lekarz(string imieNazwisko, string specjalnosc) : base(imieNazwisko)
        {
            this.specjalnosc = specjalnosc;
        }
        public override string ToString()
        {
            return "Lekarz, imię i nazwisko: " + imieNazwisko + ", specjalność: " + specjalnosc + '.';
        }
    }
}
