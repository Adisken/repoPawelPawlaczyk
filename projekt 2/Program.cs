using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp1 {
    class Program {
        public static string pathCsv = "G:\\studia\\NotEffectiveTime.csv";
        public static ulong counter;
        public static BigInteger[] badaneLiczbyPierwsze = { 100913, 1009139, 10091401, 100914061, 1009140611, 10091406133, 100914061337, 1009140613399 };

        static void Main(string[] args) {
            runTestTime();
            //runTestCount();
        }
        

        static void runTestTime() { //funkcja dla diagnozy potrzebnego czasu na wykonanie wybranego algorytmu
            StringBuilder plikCsv = new StringBuilder();
            plikCsv.AppendLine("l.p.;number;time;");
            for (int i = 7; i < 8; i++) {
                long start = Stopwatch.GetTimestamp();
                IsPrime(badaneLiczbyPierwsze[i]);
                //IsPrimeBetter(badaneLiczbyPierwsze[i]);
                long stop = Stopwatch.GetTimestamp();
                plikCsv.AppendLine((i + 1) + ";" + badaneLiczbyPierwsze[i] + ";" + (stop - start));
                Console.WriteLine((i + 1) + ";" + badaneLiczbyPierwsze[i] + ";" + (stop - start));
            }
            File.AppendAllText(pathCsv, plikCsv.ToString());
        }
        static void runTestCount() { //funkcja dla diagnozy potrzebnej ilości operacja dla wykoniania wybranego algorytmu
            StringBuilder plikCsv = new StringBuilder();
            plikCsv.AppendLine("l.p.;number;operations;");
            for (int i = 0; i < 8; i++) {
                long start = Stopwatch.GetTimestamp();
                //IsPrimeCount(badaneLiczbyPierwsze[i]);
                IsPrimeBetterCount(badaneLiczbyPierwsze[i]);
                long stop = Stopwatch.GetTimestamp();
                plikCsv.AppendLine((i + 1) + ";" + badaneLiczbyPierwsze[i] + ";" + counter);
                Console.WriteLine((i + 1) + ";" + badaneLiczbyPierwsze[i] + ";" + counter);
            }
            File.AppendAllText(pathCsv, plikCsv.ToString());
        }

        static bool IsPrime(BigInteger Num) { //sprawdza czy liczba jest pierwsza, przy użyciu przykładowego algorytmu
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            else for (BigInteger u = 3; u < Num / 2; u += 2)
                    if (Num % u == 0) return false;
            return true;
        }

        static bool IsPrimeCount(BigInteger Num) { //sprawdza czy liczba jest pierwsza, dodatkowo zlicza operacje, przy użyciu przykładowego algorytmu
            counter = 0;
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            else for (BigInteger u = 3; u < Num / 2; u += 2) {
                    counter++;
                    if (Num % u == 0) return false;
                }
            return true;
        }

        static bool IsPrimeBetter(BigInteger Num) { //sprawdza czy liczba jest pierwsza, przy użyciu przyzwoitego algorytmu
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            else for (BigInteger u = 3; u * u <= Num; u += 2)
                    if (Num % u == 0) return false;
            return true;
        }

        static bool IsPrimeBetterCount(BigInteger Num) { //sprawdza czy liczba jest pierwsza, dodatkowo zlicza operacje, przy użyciu przywoitego algorytmu
            counter = 0;
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            else for (BigInteger u = 3; u * u <= Num / 2; u += 2) {
                    counter++;
                    if (Num % u == 0) return false;
                }
            return true;
        }
    }
}
