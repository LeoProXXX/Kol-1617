using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Zadanie 1
 * Położono na stosie kolejne liczby od 0 do n (w tej kolejności); W międzyczasie pomiedzy pomiędzy położeniami
 * wykonano zdejmowanie, którego rezultat wypisywano. Napisz metodę sprawdzającą czy
 * następujący ciąg mógł zostać wypisany? Przykładowo dla n=9 ciąg
 * 1 3 2 0 4 5 7 6 8 9 - TAK
 * 1 0 4 6 3 8 7 9 5 2 - NIE
 * 
 * 
 * 
 * 1 3 2 0 4 5 7 6 8 9 - TAK
 * 
 * 1
 * 3 2 0
 * 4
 * 5
 * 7 6
 * 8
 * 9
 * 
 * 
 * 1 0 4 6 3 8 7 9 5 2 - NIE
 * 
 * 1 0
 * 4        |5
 * 6
 * 3        <- Tu sie psuje bo pierw jest 5
 * 
 * 
 * 
 * 
 * */

namespace Zadanie1
{
    class Program
    {
        static bool CzyMogl(int[] arr)
        {
            Stack<int> stack = new Stack<int>();

            int index = 0;

            for (int i = 0; i < arr.Length + 1; i++)
            {
                if (stack.Count > 0 && stack.Peek() == arr[index])
                {
                    stack.Pop();
                    index++;
                    i--;
                }
                else
                {
                    if (i < arr.Length)
                    {
                        stack.Push(i);
                    }
                }
            }
            return stack.Count == 0;
        }

        static bool CzyMogl2(int[] arr)
        {
            Stack<int> stack = new Stack<int>();

            int index = 0;

            for (int i = 0; ;)
            {
                if (stack.Count > 0 && stack.Peek() == arr[index])
                {
                    stack.Pop();
                    index++;
                }
                else
                {
                    if (i < arr.Length)
                    {
                        stack.Push(i);
                        i++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return stack.Count == 0;
        }

        static void Main(string[] args)
        {
            int[] tab1 = new int[] { 1, 3, 2, 0, 4, 5, 7, 6, 8, 9 };
            int[] tab2 = new int[] { 1, 0, 4, 6, 3, 8, 7, 9, 5, 2 };

            Console.WriteLine(CzyMogl2(tab1));
            Console.WriteLine(CzyMogl2(tab2));

            Console.ReadKey();
        }
    }
}
