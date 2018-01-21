using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Zadanie 3
 * Mamy jednokierunkową listę dowiązaniową przechowującą liczby naturalne.
 * 
 * .
 * .
 * .
 * 
 * Napisz metodę dublującą na liście wszystkie elementy o podanej wartości klucza, tzn. bezpośrednio
 * za węzłem o podanej wartości klucza należy wstawić kolejny węzeł z tą wartością.
 * Uwaga: należy napisać program testujący uwzględniający wszystkie przypadki (węzeł na początku.
 * końcu, w środku). Przykładowe dane testowe { 1, 1, 1, 2, 3, 5, 3, 1, 1, 4, 3, 2, 1, 1, 1 }.
 * 
 * */


namespace Zadanie3
{
    class Lista
    {
        class Węzeł
        {
            public int dane; // w węźle porzechowujemy liczbę
            public Węzeł następny; // oraz referencję do następnego
        }

        Węzeł głowa = null;

        public void Dodaj(int liczba) // Do głowy
        {
            Węzeł tmp = new Węzeł(); // Nowy węzeł
            tmp.dane = liczba;
            tmp.następny = głowa;   // dotychczasowa głowa staje się "następny"
            głowa = tmp;            // dodany element staje się głową
        }

        public void Wyświetl()
        {
            for (Węzeł tmp = głowa; tmp != null; tmp = tmp.następny)
            {
                Console.Write(tmp.dane + " ");
            }
            Console.WriteLine();
        }

        public void Dubluj(int klucz)
        {
            if (głowa == null)
            {
                return;
            }
            if (głowa.następny == null)
            {
                if (głowa.dane == klucz)
                {
                    Dodaj(klucz);
                }

                return;
            }

            Węzeł tmp = głowa;

            while (tmp.następny != null)
            {
                if (tmp.dane == klucz)
                {
                    Węzeł w = new Węzeł();
                    w.dane = klucz;
                    w.następny = tmp.następny;
                    tmp.następny = w;
                    tmp = tmp.następny;
                }
                tmp = tmp.następny;
            }
            if (tmp.dane == klucz)
            {
                Węzeł w = new Węzeł();
                w.dane = klucz;
                tmp.następny = w;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = new int[] { 1, 1, 1, 2, 3, 5, 3, 1, 1, 4, 3, 2, 1, 1, 1 };
            int[] arr2 = new int[] { 3, 1, 2 };

            Lista lista = new Lista();
            foreach (var item in arr1)
            {
                lista.Dodaj(item);
            }
            lista.Wyświetl();

            Lista lista2 = new Lista();
            foreach (var item in arr2)
            {
                lista2.Dodaj(item);
            }
            lista2.Wyświetl();

            lista2.Dubluj(3);
            lista2.Dubluj(1);
            lista2.Dubluj(2);
            lista2.Dubluj(6);
            lista2.Wyświetl();


            Console.ReadKey();
        }
    }
}
