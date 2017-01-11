using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{
    class Przychod : IPrzychodnia
    {
        private Lekarz lekarz;
        private Stack<Pacjent> pacjenci;

        public Przychod()
        {
            pacjenci = new Stack<Pacjent>();
        }
        public void UstawLekarza(string imieN, string specjalnosc)
        {
            lekarz = new Lekarz(imieN, specjalnosc);
        }
        public void ZapiszDoLekarza(string imieN, int wiek, string choroba)
        {
            pacjenci.Push(new Pacjent(imieN, wiek, choroba));
        }
        public string WykonajPorade()
        {
            if (pacjenci.Count > 0)
                return "Wykonano poradę! " + pacjenci.Pop().ToString();
            return "Brak pacjentów";
        }
        public string WykonajBadanie()
        {
            if (pacjenci.Count > 0)
                return "Wykonano badanie! " + pacjenci.Peek().ToString();
            return "Brak pacjentów";
        }
        public int CzasOczekiwania()
        {
            return pacjenci.Count / 3;
        }
        public override string ToString()
        {
            string output = lekarz + "\n\nPacjenci oczekujący:\n";
            //Stack<Pacjent> pacjenci_poprzednio;
            foreach (var p in pacjenci)
                output += p.ToString() + '\n';
            return output + "Czas oczekiwania: " + CzasOczekiwania() + '.';
        }
        public void GenerujRaport()
        {
            using (StreamWriter plik = new StreamWriter("Raport" + DateTime.Now.ToString("ddmmyyyyHHMM") + ".txt", true))
            {
                foreach (var p in ToString().Split('\n'))
                    plik.WriteLine(p.ToString());
                plik.Close();
            }
        }
        public bool CzyLekarz()
        {
            return lekarz != null;
        }
    }
}
