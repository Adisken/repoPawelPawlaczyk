using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgZaawZad1 {
    class Menu {
        

        static public void Display() {
            
            int userOption = 0;
            while (userOption != 7) {
                Console.WriteLine("1. Wyświetl wszystkie dane");
                Console.WriteLine("2. Wyszukaj osobe");
                Console.WriteLine("3. Dodaj osobe");
                Console.WriteLine("4. Modyfikuj osobe");
                Console.WriteLine("5. Usun dane");
                Console.WriteLine("6. Wyświetl wszystkie dane.");
                Console.WriteLine("7. Wyjdź");
                userOption = int.Parse(Console.ReadLine());
                switch (userOption) {
                    case 1:
                        Console.WriteLine("Case 1");
                        break;
                    case 2:
                        Console.WriteLine("Case 2");
                        break;
                    case 3:
                        People peopl1 = new People();
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.WriteLine("Case 2");
                        break;
                    case 5:
                        Console.WriteLine("Case 2");
                        break;
                    case 6:
                        Console.WriteLine("Case 2");
                        break;
                    default:
                        Console.WriteLine("Niewlasciwa opcja, prosze wprowadzić ponownie:");
                        userOption = int.Parse(Console.ReadLine());
                        break;
                }

            }
        }
    }
}
