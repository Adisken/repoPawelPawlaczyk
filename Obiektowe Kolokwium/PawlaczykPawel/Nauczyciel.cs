using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawlaczykPawel
{
    class Nauczyciel : Pracownik
    {
        private string przedmiot { get; set; }

        public void Info()
        {
            Console.WriteLine("Nauczyciel: ");
            base.Info();
            Console.WriteLine($"Przedmiot: {this.przedmiot}");
        }
        public Nauczyciel(string name, string surname, string topic)
        {
            imie = name;
            nazwisko = surname; //mozliwosc poprawy potem czy cos
            przedmiot = topic;

        }
    }
}
