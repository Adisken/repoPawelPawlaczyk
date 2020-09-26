using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Witaj! Prosze podaj:");
            Console.Write("Markę samochodu: ");
            string marka = Console.ReadLine();
            Console.Write("Model samochodu: ");
            string model = Console.ReadLine();
            Console.Write("pojemnosc silnika: ");
            uint pojemnosc = uint.Parse(Console.ReadLine());
            Console.Write("Aktualny stan paliwa: ");
            double currentFuel = double.Parse(Console.ReadLine());
            Console.Write("Pojemność baku: ");
            double maxFuel = double.Parse(Console.ReadLine());
            

            Samochod samochod1 = new Samochod(marka,model,pojemnosc,currentFuel,maxFuel);
            bool checJazdy = true;
            while (checJazdy) {
                Console.Write("Ile km chcesz przejechać?: ");
                uint odleglosc = uint.Parse(Console.ReadLine());
                samochod1.Jedz(odleglosc);
                Console.Write("Masz ochote wyruszyć w kolejną podróż? (y/n): ");
                string czyJechac = Console.ReadLine();
                if (czyJechac != "y") {
                    checJazdy = false;
                    break;
                }
                samochod1.Tankuj();
            }
            
        }
    }
}
