using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Zadanie 5
 * W algorytmie BFS kolejność przechodzenia wierzchołków wyznacza pewne drzewo rozpinające
 * Napisz metodę, która jako argument pobiera listową reprezentację drzewa i wierzchołków
 * a zwraca listę krawędzie: pary(wierzchołek początkowy, wierzchołek końcowy) drzewa.
 * Dla grafu jak na rysunku i wierzchołka 1 zwraca {(1,2), (2,5), (2,3), (3,4), (4,6)}
 * */

namespace Zadanie5
{

    class Graph
    {
        private int V;   // No. of vertices
        private List<int>[] adj; //Adjacency Lists

        // Constructor
        public Graph(int v)
        {
            V = v;
            adj = new List<int>[v];
            for (int i = 0; i < v; ++i)
                adj[i] = new List<int>();
        }

        public Graph(List<int>[] listy)
        {
            V = listy.Length;
            adj = listy;
        }

        // Function to add an edge into the graph
        public void addEdge(int v, int w)
        {
            adj[v].Add(w);
        }

        // prints BFS traversal from a given source s
        public void BFS(int s)
        {
            // Mark all the vertices as not visited(By default
            // set as false)
            bool[] visited = new bool[V];

            // Create a queue for BFS
            Queue<int> queue = new Queue<int>();

            // Mark the current node as visited and enqueue it
            visited[s] = true;
            queue.Enqueue(s);

            while (queue.Count != 0)
            {
                // Dequeue a vertex from queue and print it
                s = queue.Dequeue();
                Console.Write(s + " ");

                // Get all adjacent vertices of the dequeued vertex s
                // If a adjacent has not been visited, then mark it
                // visited and enqueue it
                foreach (var item in adj[s])
                {
                    if (!visited[item])
                    {
                        visited[item] = true;
                        queue.Enqueue(item);
                    }
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// BFS - z zajec 
        /// zalozenia:
        ///     dociera tylko do mniejsc dostepnym z wezla 0 - no troche to ograniczone 
        /////////////////////////////////////////////////////////////////////////////////
        static List<int> BFS(int[,] tab)
        {
            int start = 0;
            Queue<int> kolejka = new Queue<int>(); //kolejka
            List<int> wyniki = new List<int>();
            kolejka.Enqueue(start); // dodanie pierwszego wierchołka
            bool[] odwiedzone = new bool[tab.GetLength(0)];
            while (kolejka.Count != 0)
            {
                int pobrany = kolejka.Dequeue();
                if (odwiedzone[pobrany] == false)
                {
                    odwiedzone[pobrany] = true;
                    for (int i = 0; i < tab.GetLength(1); i++)
                    {
                        if (tab[pobrany, i] != 0)
                        {
                            kolejka.Enqueue(i);
                        }
                    }
                    wyniki.Add(pobrany);
                }
            }
            return wyniki;
        }

        // prints BFS traversal from a given source s
        public static List<Krawedz> BFS2(int s, List<int>[] adj)
        {
            List<Krawedz> ListaKrawedzi = new List<Krawedz>();
            List<int> lista = new List<int>();
            int V = adj.Length;
            // Mark all the vertices as not visited(By default
            // set as false)
            bool[] visited = new bool[V];

            // Create a queue for BFS
            Queue<int> queue = new Queue<int>();

            // Mark the current node as visited and enqueue it
            visited[s] = true;
            queue.Enqueue(s);

            while (queue.Count != 0)
            {
                // Dequeue a vertex from queue and print it
                s = queue.Dequeue();
                lista.Add(s);
                //Console.Write(s + " ");

                // Get all adjacent vertices of the dequeued vertex s
                // If a adjacent has not been visited, then mark it
                // visited and enqueue it
                foreach (var item in adj[s])
                {
                    if (!visited[item])
                    {
                        visited[item] = true;
                        queue.Enqueue(item);
                        //ListaKrawedzi.Add(new Krawedz(s, item));
                    }
                }
            }
            for (int i = 0; i < lista.Count - 1; i++)
            {
                ListaKrawedzi.Add(new Krawedz(lista[i], lista[i + 1]));
            }

            return ListaKrawedzi;
        }
    }

    struct Krawedz
    {
        public int wPoczatkowy;
        public int wKoncowy;

        public Krawedz(int wPoczatkowy, int wKoncowy)
        {
            this.wPoczatkowy = wPoczatkowy;
            this.wKoncowy = wKoncowy;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph(7);

            g.addEdge(1, 2);
            g.addEdge(1, 5);
            g.addEdge(2, 5);
            g.addEdge(2, 3);
            g.addEdge(3, 4);
            g.addEdge(5, 4);
            g.addEdge(4, 6);

            Console.WriteLine("Following is Breadth First Traversal " +
                               "(starting from vertex 1)");

            g.BFS(1);


            int v = 7;      // max numer wierzchołka + 1
            List<int>[] adj = new List<int>[v]; //listy sasiedztwa
            for (int i = 0; i < v; ++i)
                adj[i] = new List<int>();

            adj[1].Add(2);
            adj[1].Add(5);
            adj[2].Add(5);
            adj[2].Add(3);
            adj[3].Add(4);
            adj[5].Add(4);
            adj[4].Add(6);


            Console.WriteLine("Wier. pocz        Wier. koncowy");
            List<Krawedz> lista = Graph.BFS2(1, adj);
            foreach (var item in lista)
            {
                Console.WriteLine(item.wPoczatkowy.ToString() + "                 " + item.wKoncowy.ToString());
            }


            Console.ReadKey();
        }
    }
}
