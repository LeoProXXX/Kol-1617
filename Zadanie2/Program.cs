using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Zadanie 2
 * Mamy kopiec minimalny taki, że na jego wierzchołku znajduje się element najmniejszy (dzieci są
 * większe). Napisz metodę sprawdzającą czy podana tablica jest kopcem minimalnym.
 * */

namespace Zadanie2
{
    class Program
    {
        static bool IsHeap(int[] arr)
        {
            for (int i = 0; i < arr.Length / 2; i++)
            {
                int lewy = 2 * i + 1;
                int prawy = 2 * i + 2;

                if (lewy < arr.Length && arr[lewy] < arr[i])
                {
                    return false;
                }

                if (prawy < arr.Length && arr[prawy] < arr[i])
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            int[] arr1 = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            int[] arr2 = new int[] { 1, 2, 3, 4, 5, 6, 0 };

            Console.WriteLine(IsHeap(arr1));
            Console.WriteLine(IsHeap(arr2));

            Console.ReadKey();
        }
    }
}
