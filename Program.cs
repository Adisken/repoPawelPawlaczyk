using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BinaryAndLinearSearch {
    class Program {
        public static int counter = 0;

        static void Main(string[] args) {
            //startLinearSearchDiagnose(); //funkcja dla zwiekszajacej sie wielkosci tablicy
            //startBinarySearchDiagnose(); //funkcja dla zwiekszajacej sie wielkosci tablicy
            startSingleBinarySearchDiagnose(); //funkcja dla tablicy o rozmiarze 2^28
            //startSingleLinearSearchDiagnose(); //funkcja dla tablicy o rozmiarze 2^28
        }

        public static int linearSearch(int[] tab, int n) {
            for (int i = 0; i < tab.Length; i++) {
                if (tab[i] == n) return i;
            }
            return -1;
        }

        public static int linearSearchOperations(int[] tab, int n) { //osobna funkcja do liczenia operacji, w celu dokladniejszego odczytu czasu
            for (int i = 0; i < tab.Length; i++) {
                counter++;
                if (tab[i] == n) return i;
            }
            return -1;
        }
        public static int binarySearch(int[] tab, int n) {
            int left = 0;
            int right = tab.Length - 1;
            while (left <= right) {
                int middle = (left + right) / 2;
                if (n == tab[middle]) {
                    return n;
                }
                else if (n < tab[middle]) {
                    right = middle - 1;
                }
                else {
                    left = middle + 1;
                }
            }
            return -1;
        }
        public static int binarySearchOperations(int[] tab, int n) {
            int left = 0;
            int right = tab.Length - 1;
            while (left <= right) {
                counter++;
                int middle = (left + right) / 2;
                if (n == tab[middle]) {
                    return n;
                }
                else if (n < tab[middle]) {
                    right = middle - 1;
                }
                else {
                    left = middle + 1;
                }
            }
            return -1;
        }

        public static void startBinarySearchDiagnose() {
            StringBuilder plikCsv = new StringBuilder();
            string pathCsv = "H:\\studia\\binarySearchAvarage2mTo200m.csv";
            plikCsv.AppendLine("searched;size;operations;time");
            Random rand = new Random();
            for (int j = 2000000; j <= 200000000; j += 2000000) {
                counter = 0;
                int[] tablica = new int[j];
                for (int i = 0; i < tablica.Length; i++) {
                    tablica[i] = rand.Next(1001);
                }
                Array.Sort(tablica);//sorting array cos' it's neccessary in binary search
                //int lookUpValue = 1001; //negative scenario
                int lookUpValue = rand.Next(1001); //avarage scenario
                long timeSpend = 0;
                long max = long.MaxValue;
                long min = long.MinValue;
                int iter = 10;
                for (int i = 0; i < iter + 2; i++) {
                    long start = Stopwatch.GetTimestamp();
                    binarySearch(tablica, lookUpValue);
                    long stop = Stopwatch.GetTimestamp();
                    long timeSpendHere = stop - start;
                    timeSpend += timeSpendHere;
                    if (timeSpendHere < max) max = timeSpendHere;
                    if (timeSpendHere > min) min = timeSpendHere;
                }
                binarySearchOperations(tablica, lookUpValue);
                Console.WriteLine(lookUpValue + ";" + j + ";" + counter + ";" + (timeSpend - (min + max) / iter));
                plikCsv.AppendLine(lookUpValue + ";" + j + ";" + counter + ";" + (timeSpend - (min + max) / iter));
            }
            File.AppendAllText(pathCsv, plikCsv.ToString());
        }

        public static void startLinearSearchDiagnose() {
            StringBuilder plikCsv = new StringBuilder();
            string pathCsv = "H:\\studia\\LinearSearchAvarageScenario2mTo200m.csv";
            plikCsv.AppendLine("searched;size;operations;time");
            Random rand = new Random();
            for (int j = 2000000; j <= 200000000; j += 2000000) {
                counter = 0;
                int[] tablica = new int[j];
                for (int i = 0; i < tablica.Length; i++) {
                    tablica[i] = rand.Next(1001);
                }
                // int lookUpValue = 1001; //negative scenario
                int lookUpValue = rand.Next(1001); //avarage scenario
                long timeSpend = 0;
                long max = long.MaxValue;
                long min = long.MinValue;
                int iter = 10;
                for (int i = 0; i < iter + 2; i++) {
                    long start = Stopwatch.GetTimestamp();
                    linearSearch(tablica, lookUpValue);
                    long stop = Stopwatch.GetTimestamp();
                    long timeSpendHere = stop - start;
                    timeSpend += timeSpendHere;
                    if (timeSpendHere < max) max = timeSpendHere;
                    if (timeSpendHere > min) min = timeSpendHere;
                }
                linearSearchOperations(tablica, lookUpValue);
                Console.WriteLine(lookUpValue + ";" + j + ";" + counter + ";" + (timeSpend - (min + max) / iter));
                plikCsv.AppendLine(lookUpValue + ";" + j + ";" + counter + ";" + (timeSpend - (min + max) / iter));
            }
            File.AppendAllText(pathCsv, plikCsv.ToString());
        }

        public static void startSingleBinarySearchDiagnose() { //dla tablicy 2^28 elementów
            StringBuilder plikCsv = new StringBuilder();
            string pathCsv = "C:\\studia\\BinarySearch2^28avarage.csv";
            plikCsv.AppendLine("searched;size;operations;time");
            Random rand = new Random();
            counter = 0;
            int[] tablica = new int[268435456];
            int lookUpValue = 1001;
            long timeSpend = 0;
            long max = long.MaxValue;
            long min = long.MinValue;
            long maxCounter = long.MaxValue;
            long minCounter = long.MinValue;
            int totalCounter = 0;
            int iter = 10;
            for (int k = 0; k < iter + 2; k++) { //dodatkowa fukncja by uśrednik wyniki ilosci operacji
                counter = 0;
                for (int i = 0; i < tablica.Length; i++) {
                    tablica[i] = rand.Next(1001);
                }
                Array.Sort(tablica);
                // lookUpValue = 1001; //negative scenario
                lookUpValue = rand.Next(1001); //avarage scenario
                binarySearchOperations(tablica, lookUpValue);
                totalCounter += counter;
                if (counter < maxCounter) maxCounter = counter;
                if (counter > minCounter) minCounter = counter;
            }
            for (int i = 0; i < iter + 2; i++) {
                long start = Stopwatch.GetTimestamp();
                binarySearch(tablica, lookUpValue);
                long stop = Stopwatch.GetTimestamp();
                long timeSpendHere = stop - start;
                timeSpend += timeSpendHere;
                if (timeSpendHere < max) max = timeSpendHere;
                if (timeSpendHere > min) min = timeSpendHere;
            }
            Console.WriteLine(lookUpValue + ";" + tablica.Length + ";" + counter + ";" + (timeSpend - (min + max) / iter));
            plikCsv.AppendLine(lookUpValue + ";" + tablica.Length + ";" + counter + ";" + (timeSpend - (min + max) / iter));
            File.AppendAllText(pathCsv, plikCsv.ToString());
        }
        public static void startSingleLinearSearchDiagnose() { //dla tablicy 2^28 elementów
            StringBuilder plikCsv = new StringBuilder();
            string pathCsv = "C:\\studia\\linearSearch2^28avarage.csv";
            plikCsv.AppendLine("searched;size;operations;time");
            Random rand = new Random();
            
            long maxCounter = long.MaxValue;
            long minCounter = long.MinValue;
            int iter = 10;
            int[] tablica = new int[268435456];
            int lookUpValue = rand.Next(1001);
            int totalCounter = 0;
            for (int k = 0; k < iter + 2; k++) { //dodatkowa fukncja by uśrednik wyniki ilosci operacji
                counter = 0;
                for (int i = 0; i < tablica.Length; i++) {
                    tablica[i] = rand.Next(1001);
                }
                // lookUpValue = 1001; //negative scenario
                 lookUpValue = rand.Next(1001); //avarage scenario
                linearSearchOperations(tablica, lookUpValue);
                totalCounter += counter;
                if (counter < maxCounter) maxCounter = counter;
                if (counter > minCounter) minCounter = counter;
            }
            long timeSpend = 0;
            long max = long.MaxValue;
            long min = long.MinValue;
            for (int i = 0; i < iter + 2; i++) {
                long start = Stopwatch.GetTimestamp();
                linearSearch(tablica, lookUpValue);
                long stop = Stopwatch.GetTimestamp();
                long timeSpendHere = stop - start;
                timeSpend += timeSpendHere;
                if (timeSpendHere < max) max = timeSpendHere;
                if (timeSpendHere > min) min = timeSpendHere;
            }
            
            Console.WriteLine(lookUpValue + ";" + tablica.Length + ";" + (totalCounter - (minCounter+maxCounter)/iter) + ";" + (timeSpend - (min + max) / iter));
            plikCsv.AppendLine(lookUpValue + ";" + tablica.Length + ";" + (totalCounter - (minCounter + maxCounter) / iter) + ";" + (timeSpend - (min + max) / iter));

            File.AppendAllText(pathCsv, plikCsv.ToString());
        }
    }


}
