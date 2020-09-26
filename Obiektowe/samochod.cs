using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2 {
    class Samochod {
        public string Marka { get; set; }
        public string Model { get; set; }

        Silnik sil = new Silnik(70);
        public Samochod(string marka, string model, uint poj, double iloscBenz, double pojBaku) {
            marka = marka;
            Model = model;
            sil.pojemnosc = poj;
            sil.ilePaliwa = iloscBenz;
            sil.pojZbDomyslna = pojBaku;
        }
        public Samochod(string marka, string model, Silnik silnik) {
            Marka = marka;
            Model = model;
        }
        public void Jedz(uint dystans) {
            Console.WriteLine("Ruszamy...");
            for (uint i = 1; i <= dystans / 10; i++) {
                double stanBaku = Spalaj();
                Thread.Sleep(1000);
                Console.WriteLine("Sekundy: " + i);
                Console.WriteLine($"Przejechales: {i * 10}km, w baku masz {stanBaku} paliwa, do celu zostało {dystans - i * 10}km.");
                if (i * dystans % 50 == 0) {

                    this.Tankuj();

                }

            }

        }

        private double Spalaj() {
            double spalNaSto = (sil.pojemnosc * 4) / 1000;
            double spalNaDziesiec = spalNaSto / 10;
            return sil.ilePaliwa = sil.ilePaliwa - spalNaDziesiec;

        }

        public void Tankuj() {
            Console.Write("Czy chcesz zatankować swoje auto? (y/n)");
            string wybor = Console.ReadLine();
            if (wybor == "y") {
                Console.Write("Ile litrów chcesz zatankować? ");
                int litry = int.Parse(Console.ReadLine());
                while (sil.ilePaliwa + litry <= sil.pojBaku) {
                    Console.Write($"Za dużo litrów próbujesz nalać! Twój stan baku to:{sil.ilePaliwa}l, a twój bak mieści:{sil.pojBaku}l. Podaj jeszcze raz ile chcesz zatankować: ");
                    litry = int.Parse(Console.ReadLine());
                }
                sil.ilePaliwa += litry;
            } else Console.WriteLine("Nie, to nie");
        }


    }
}
