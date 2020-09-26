using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgZaawZad1 {
    class People {
        public string name { get; set; }
        public string surname{ get; set; }
        public uint age { get; set; }
        public string gender { get; set; }
        public uint postCode { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public uint homeNumber { get; set; }

        public People(string name1, string surname1, uint age1, string gender1, uint postCode1, string city1, string street1, uint homeNumber1) {
            name1 = name;
            surname1 = surname;
            age1 = age;
            gender1 = gender;
            postCode1 = postCode;
            city1 = city;
            street1 = street;
            homeNumber1 = homeNumber;
        }

        //konstruktor który pyta użytkownika o wszystko
        public People() {
            Console.Clear();
            Console.Write("Podaj imię: ");
            name = Console.ReadLine();
            Console.Write("Podaj Nazwisko: ");
            surname = Console.ReadLine();
            Console.Write("Podaj wiek: ");
            age = uint.Parse(Console.ReadLine());
            Console.Write("Podaj płeć: ");
            gender = Console.ReadLine();
            Console.Write("Podaj kod pocztowy: ");
            postCode = uint.Parse(Console.ReadLine());
            Console.Write("Podaj Miasto: ");
            city = Console.ReadLine();
            Console.Write("Podaj ulicę: ");
            street = Console.ReadLine();
            Console.Write("Podaj numer domu: ");
            homeNumber = uint.Parse(Console.ReadLine());

            StringBuilder plikCsv = new StringBuilder();
            plikCsv.AppendLine(name + ";" + surname + ";"+ age +";"+gender+";"+postCode+";"+city+";"+street+";"+homeNumber);
            File.AppendAllText(Program.pathCsv, plikCsv.ToString());
        }
    }
}
