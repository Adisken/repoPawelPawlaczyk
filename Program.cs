using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt3ASD {
    class Program {
        public static string pathCsv = "G:\\studia\\proj3\\QSIter 3 Diff Pivot.csv";
        public static int dlugoscTablicy = 50000;

        static void Main(string[] args) {
            //TimeTest4Sorts();
            //TimeTest4SortsRandomArray();
            //TimeTestQSIterVsRecur();
            TimeTestQS3DiffPivot();
        }

        // Testing 'V'

        static void TimeTestQS3DiffPivot() {
            StringBuilder QSMiddlePivot = new StringBuilder();
            StringBuilder QSRightPivot = new StringBuilder();
            StringBuilder QSRandomPivot = new StringBuilder();
            QSMiddlePivot.AppendLine("l.p.;array lenght;time;QSIter middle Pivot sort;Ashape Array;");
            QSRightPivot.AppendLine("l.p.;array lenght;time;QSIter right Pivot sort;Ashape Array;");
            QSRandomPivot.AppendLine("l.p.;array lenght;time;QSIter random Pivot sort;Ashape Array;");
            int l = dlugoscTablicy;

            for (int i = 0; i < 15; i++) {
                int[] badanaTablica = new int[l];
                int[] badanaTablica2 = new int[l];
                int[] badanaTablica3 = new int[l];
                MakeArrayAShape(badanaTablica);
                Array.Copy(badanaTablica, badanaTablica2, l);
                Array.Copy(badanaTablica, badanaTablica3, l);

                long timeSpend = 0;
                long max = long.MaxValue;
                long min = long.MinValue;
                int iter = 4;
                for (int w = 0; w < iter+2; w++) { //uśrednianie wyniku
                    long start = Stopwatch.GetTimestamp();
                    QuickSortIter(badanaTablica);
                    long stop = Stopwatch.GetTimestamp();
                    long timeSpendHere = stop - start;
                    timeSpend += timeSpendHere;
                    if (timeSpendHere < max) max = timeSpendHere;
                    if (timeSpendHere > min) min = timeSpendHere;
                }
                QSMiddlePivot.AppendLine((i + 1) + ";" + l + ";" + (timeSpend - (min + max)));

                timeSpend = 0;
                max = long.MaxValue;
                min = long.MinValue;
                for (int w = 0; w < iter + 2; w++) {//uśrednianie wyniku
                    long start = Stopwatch.GetTimestamp();
                    QuickSortIterRightPivot(badanaTablica2);
                    long stop = Stopwatch.GetTimestamp();
                    long timeSpendHere = stop - start;
                    timeSpend += timeSpendHere;
                    if (timeSpendHere < max) max = timeSpendHere;
                    if (timeSpendHere > min) min = timeSpendHere;
                }
                QSRightPivot.AppendLine((i + 1) + ";" + l + ";" + (timeSpend - (min + max)));

                timeSpend = 0;
                max = long.MaxValue;
                min = long.MinValue;
                for (int w = 0; w < iter + 2; w++) {//uśrednianie wyniku
                    long start = Stopwatch.GetTimestamp();
                    QuickSortIterRandomPivot(badanaTablica3);
                    long stop = Stopwatch.GetTimestamp();
                    long timeSpendHere = stop - start;
                    timeSpend += timeSpendHere;
                    if (timeSpendHere < max) max = timeSpendHere;
                    if (timeSpendHere > min) min = timeSpendHere;
                }
                QSRandomPivot.AppendLine((i + 1) + ";" + l + ";" + (timeSpend - (min + max)));
                l += 10000;
            }
            File.AppendAllText(pathCsv, QSMiddlePivot.ToString());
            File.AppendAllText(pathCsv, QSRightPivot.ToString());
            File.AppendAllText(pathCsv, QSRandomPivot.ToString());

        }

        static void TimeTestQSIterVsRecur() {
            StringBuilder QSIterCsv = new StringBuilder();
            StringBuilder QSRekuCsv = new StringBuilder();
            QSIterCsv.AppendLine("l.p.;array lenght;time;QSIter sort;RandomArray;");
            QSRekuCsv.AppendLine("l.p.;array lenght;time;QSReku sort;RandomArray;");
            int l = dlugoscTablicy;

            for (int i = 0; i < 15; i++) {
                int[] badanaTablica = new int[l];
                int[] badanaTablica2 = new int[l];
                MakeArrayRandom(badanaTablica);
                Array.Copy(badanaTablica, badanaTablica2, l);

                long start = Stopwatch.GetTimestamp();
                HeapSort(badanaTablica);
                long stop = Stopwatch.GetTimestamp();
                QSIterCsv.AppendLine((i + 1) + ";" + l + ";" + (stop - start));

                long start2 = Stopwatch.GetTimestamp();
                InsertionSort(badanaTablica2);
                long stop2 = Stopwatch.GetTimestamp();
                QSRekuCsv.AppendLine((i + 1) + ";" + l + ";" + (stop2 - start2));
                l += 10000;
            }
            File.AppendAllText(pathCsv, QSIterCsv.ToString());
            File.AppendAllText(pathCsv, QSRekuCsv.ToString());

        }
        static void TimeTest4SortsRandomArray() {
            StringBuilder RandHeapCsv = new StringBuilder();
            StringBuilder RandInsertCsv = new StringBuilder();
            StringBuilder RandSelectCsv = new StringBuilder();
            StringBuilder RandCockCsv = new StringBuilder();
            RandHeapCsv.AppendLine("l.p.;array lenght;time;heap sort;RandomArray;");
            RandInsertCsv.AppendLine("l.p.;array lenght;time;insert sort;RandomArray;");
            RandSelectCsv.AppendLine("l.p.;array lenght;time;select sort;RandomArray;");
            RandCockCsv.AppendLine("l.p.;array lenght;time;cocktail sort;RandomArray;");
            int l = dlugoscTablicy;

            for (int i = 0; i < 15; i++) {
                int[] badanaTablica = new int[l];
                int[] badanaTablica2 = new int[l];
                int[] badanaTablica3 = new int[l];
                int[] badanaTablica4 = new int[l];
                MakeArrayRandom(badanaTablica);
                Array.Copy(badanaTablica, badanaTablica2, l);
                Array.Copy(badanaTablica, badanaTablica3, l);
                Array.Copy(badanaTablica, badanaTablica4, l);

                long start = Stopwatch.GetTimestamp();
                HeapSort(badanaTablica);
                long stop = Stopwatch.GetTimestamp();
                RandHeapCsv.AppendLine((i + 1) + ";" + l + ";" + (stop - start));

                long start2 = Stopwatch.GetTimestamp();
                InsertionSort(badanaTablica2);
                long stop2 = Stopwatch.GetTimestamp();
                RandInsertCsv.AppendLine((i + 1) + ";" + l + ";" + (stop2 - start2));

                long start3 = Stopwatch.GetTimestamp();
                SelectionSort(badanaTablica3);
                long stop3 = Stopwatch.GetTimestamp();
                RandSelectCsv.AppendLine((i + 1) + ";" + l + ";" + (stop3 - start3));

                long start4 = Stopwatch.GetTimestamp();
                CocktailSort(badanaTablica4);
                long stop4 = Stopwatch.GetTimestamp();
                RandCockCsv.AppendLine((i + 1) + ";" + l + ";" + (stop4 - start4));
                l += 10000;
            }
            File.AppendAllText(pathCsv, RandHeapCsv.ToString());
            File.AppendAllText(pathCsv, RandInsertCsv.ToString());
            File.AppendAllText(pathCsv, RandSelectCsv.ToString());
            File.AppendAllText(pathCsv, RandCockCsv.ToString());
        }

        static void TimeTest4Sorts() {
            StringBuilder plikCsv = new StringBuilder();

            //HeapSort
            int l = dlugoscTablicy;
            plikCsv.AppendLine("l.p.;array lenght;time;heap sort;StaticArray;");
            for (int i = 0; i < 15; i++) {
                int[] badanaTablica = new int[l];
                // MakeArrayAsc(badanaTablica);
                //MakeArrayDsc(badanaTablica);
                //MakeArrayVShape(badanaTablica);
                MakeArrayStatic(badanaTablica);
                long start = Stopwatch.GetTimestamp();
                HeapSort(badanaTablica);
                long stop = Stopwatch.GetTimestamp();
                plikCsv.AppendLine((i + 1) + ";" + l + ";" + (stop - start));
                l += 10000;
            }

            //insertionSort
            l = dlugoscTablicy;
            plikCsv.AppendLine("l.p.;array lenght;time;insertion sort;StaticArray;");
            for (int i = 0; i < 15; i++) {
                int[] badanaTablica = new int[l];
                //MakeArrayAsc(badanaTablica);
                //MakeArrayDsc(badanaTablica);
                //MakeArrayVShape(badanaTablica);
                MakeArrayStatic(badanaTablica);
                long start = Stopwatch.GetTimestamp();
                InsertionSort(badanaTablica);
                long stop = Stopwatch.GetTimestamp();
                plikCsv.AppendLine((i + 1) + ";" + l + ";" + (stop - start));
                l += 10000;
            }

            //selectionSort
            l = dlugoscTablicy;
            plikCsv.AppendLine("l.p.;array lenght;time;selection sort;StaticArray;");
            for (int i = 0; i < 15; i++) {
                int[] badanaTablica = new int[l];
                //MakeArrayAsc(badanaTablica);
                //MakeArrayDsc(badanaTablica);
                //MakeArrayVShape(badanaTablica);
                MakeArrayStatic(badanaTablica);
                long start = Stopwatch.GetTimestamp();
                SelectionSort(badanaTablica);
                long stop = Stopwatch.GetTimestamp();
                plikCsv.AppendLine((i + 1) + ";" + l + ";" + (stop - start));
                l += 10000;
            }          

            //coctail sort
            l = dlugoscTablicy;
            plikCsv.AppendLine("l.p.;array lenght;time;Coctail sort;StaticArray;");
            for (int i = 0; i < 15; i++) {
                int[] badanaTablica = new int[l];
                //MakeArrayAsc(badanaTablica);
                //MakeArrayDsc(badanaTablica);
                //MakeArrayVShape(badanaTablica);
                MakeArrayStatic(badanaTablica);
                long start = Stopwatch.GetTimestamp();
                CocktailSort(badanaTablica);
                long stop = Stopwatch.GetTimestamp();
                plikCsv.AppendLine((i + 1) + ";" + l + ";" + (stop - start));
                l += 10000;
            }
            File.AppendAllText(pathCsv, plikCsv.ToString());
        }

        //TWORZENIE TABLIC 'V'
        static void MakeArrayAsc(int[] tab) {
            for (int i = 0; i < tab.Length; i++) {
                tab[i] = i;
            }

        }

        static void MakeArrayDsc(int[] tab) {
            int index = 0;
            for (int j = tab.Length; j > 0; j--) {
                tab[index++] = j;

            }
        }

        static void MakeArrayStatic(int[] tab) {
            for (int i = 0; i < tab.Length; i++) {
                tab[i] = 7;
            }
        }

        static void MakeArrayRandom(int[] tab) {
            Random rand = new Random();
            for (int i = 0; i < tab.Length; i++) {
                tab[i] = rand.Next(tab.Length / 2);
            }
        }

        static public void MakeArrayAShape(int[] tab) {
            int[] numberTab = new int[tab.Length];
            MakeArrayAsc(numberTab);
            int left = 0;
            int right = tab.Length - 1;
            for (int i = 0; i < tab.Length; i++) {
                if (numberTab[i] % 2 != 0) {
                    tab[left] = numberTab[i];
                    left++;

                } else {
                    tab[right] = numberTab[i];
                    right--;

                }
            }
        }

        static public void MakeArrayVShape(int[] tab) {
            int[] numberTab = new int[tab.Length];
            MakeArrayDsc(numberTab);
            int left = 0;
            int right = tab.Length - 1;
            for (int i = 0; i < tab.Length; i++) {
                if (numberTab[i] % 2 != 0) {
                    tab[left] = numberTab[i];
                    left++;

                } else {
                    tab[right] = numberTab[i];
                    right--;

                }
            }
        }

        //ALGORYTMY SORTOWANIA 'V'

        static public void CocktailSort(int[] tab) {
            int left = 1, right = tab.Length - 1, k = tab.Length - 1;
            do {
                for (int i = right; i >= left; i--) {
                    if (tab[i - 1] > tab[i]) {
                        int temp = tab[i - 1];
                        tab[i - 1] = tab[i];
                        tab[i] = temp;
                        k = i;
                    }
                }
                left = k + 1;

                for (int i = left; i <= right; i++) {
                    if (tab[i - 1] > tab[i]) {
                        int temp = tab[i - 1];
                        tab[i - 1] = tab[i];
                        tab[i] = temp;
                        k = i;
                    }
                }
                right = k - 1;
            } while (left <= right);
        }

        static public void InsertionSort(int[] tab) {
            for (int i = 0; i < tab.Length; i++) {
                int j = i;
                int temp = tab[j];
                while ((j > 0) && (tab[j - 1] > temp)) {
                    tab[j] = tab[j - 1];
                    j--;
                }
                tab[j] = temp;
            }
        }

        static public void SelectionSort(int[] tab) {
            int k;
            for (int i = 0; i < (tab.Length - 1); i++) {
                int temp = tab[i];
                k = i;
                for (int j = i; j < tab.Length; j++) {
                    if (tab[j] < temp) {
                        k = j;
                        temp = tab[j];
                    }
                }
                tab[k] = tab[i];
                tab[i] = temp;
            }
        }

        static public void Heapify(int[] tab, uint left, uint right) {
            uint i = left, j = 2 * i + 1;
            int buf = tab[i];
            while (j <= right) {
                if (j < right) {
                    if (tab[j] < tab[j + 1]) j++;
                }
                if (buf >= tab[j]) break;
                tab[i] = tab[j];
                i = j;
                j = 2 * i + 1;
            }
            tab[i] = buf;
        }

        static public void HeapSort(int[] tab) {
            uint left = ((uint)tab.Length / 2);
            uint right = (uint)tab.Length - 1;
            while (left > 0) {
                left--;
                Heapify(tab, left, right);
            }
            while (right > 0) {
                int buf = tab[left];
                tab[left] = tab[right];
                tab[right] = buf;
                right--;
                Heapify(tab, left, right);
            }
        }

        static public void QuickSortIter(int[] tab) { //pivot at middle
            int i, j, l, p, sp;
            int[] stos_l = new int[tab.Length], stos_p = new int[tab.Length];
            sp = 0;
            stos_l[sp] = 0;
            stos_p[sp] = tab.Length - 1;
            do {
                l = stos_l[sp];
                p = stos_p[sp];
                sp--;
                do {
                    int x;
                    i = l;
                    j = p;
                    x = tab[(l + p) / 2];
                    do {
                        while (tab[i] < x) i++;
                        while (x < tab[j]) j--;
                        if (i <= j) {
                            int buf = tab[i];
                            tab[i] = tab[j];
                            tab[j] = buf;
                            i++;
                            j--;
                        }
                    } while (i <= j);
                    if (i < p) {
                        sp++;
                        stos_l[sp] = i;
                        stos_p[sp] = p;
                    }
                    p = j;
                } while (l < p);
            } while (sp >= 0);
        }

        static public void QuickSortRecursive(int[] tab) {
            ActuallyQuickSortRecursive(tab, 0, tab.Length - 1);
        }

        static public void ActuallyQuickSortRecursive(int[] tab, int left, int right) { //pivot at the middle
            int i, j, x;
            i = left;
            j = right;
            x = tab[(left + right) / 2];

            do {
                while (tab[i] < x) i++;
                while (x < tab[j]) j--;
                if (i <= j) {
                    int buf = tab[i];
                    tab[i] = tab[j];
                    tab[j] = buf;
                    i++;
                    j--;
                }
            } while (i <= j);

            if (left < j) ActuallyQuickSortRecursive(tab, left, j);
            if (i < right) ActuallyQuickSortRecursive(tab, i, right);
        }

        static public void QuickSortIterRightPivot(int[] tab) { //pivot at right
            int i, j, l, p, sp;
            int[] stos_l = new int[tab.Length], stos_p = new int[tab.Length];
            sp = 0;
            stos_l[sp] = 0;
            stos_p[sp] = tab.Length - 1;
            do {
                l = stos_l[sp];
                p = stos_p[sp];
                sp--;
                do {
                    int x;
                    i = l;
                    j = p;
                    x = tab[p];
                    do {
                        while (tab[i] < x) i++;
                        while (x < tab[j]) j--;
                        if (i <= j) {
                            int buf = tab[i];
                            tab[i] = tab[j];
                            tab[j] = buf;
                            i++;
                            j--;
                        }
                    } while (i <= j);
                    if (i < p) {
                        sp++;
                        stos_l[sp] = i;
                        stos_p[sp] = p;
                    }
                    p = j;
                } while (l < p);
            } while (sp >= 0);
        }

        static public void QuickSortIterRandomPivot(int[] tab) { //pivot at random
            int i, j, l, p, sp;
            Random rand = new Random();
            int[] stos_l = new int[tab.Length], stos_p = new int[tab.Length];
            sp = 0;
            stos_l[sp] = 0;
            stos_p[sp] = tab.Length - 1;
            do {
                l = stos_l[sp];
                p = stos_p[sp];
                sp--;
                do {
                    int x;
                    i = l;
                    j = p;
                    x = tab[rand.Next(l,p)];
                    do {
                        while (tab[i] < x) i++;
                        while (x < tab[j]) j--;
                        if (i <= j) {
                            int buf = tab[i];
                            tab[i] = tab[j];
                            tab[j] = buf;
                            i++;
                            j--;
                        }
                    } while (i <= j);
                    if (i < p) {
                        sp++;
                        stos_l[sp] = i;
                        stos_p[sp] = p;
                    }
                    p = j;
                } while (l < p);
            } while (sp >= 0);
        }
    }
}
