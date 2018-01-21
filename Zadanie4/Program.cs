using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Zadanie 4
 * Napisz metodę do tworzenia drzewa BST o możliwie najmniejszej wysokości na podstawie
 * uporządkowanego rosnąco ciągu kluczy podanych w tablicy np.: { 2, 4, 7, 12, 15, 20, 25 }.
 * */

namespace Zadanie4
{
    class BST
    {
        class Node
        {
            public int data;
            public Node left = null;
            public Node right = null;

            public Node(int data)
            {
                this.data = data;
            }
        }

        Node root = null;

        public void Add(int value)
        {
            Node tmp = new Node(value);

            if (root == null)
            {
                root = tmp;
                return;
            }

            AddRec(root, tmp);
        }

        private void AddRec(Node root, Node tmp)
        {
            if (root.data > tmp.data)
            {
                if (root.left == null)
                {
                    root.left = tmp;
                    return;
                }
                else
                {
                    AddRec(root.left, tmp);
                }
            }
            else
            {
                if (root.right == null)
                {
                    root.right = tmp;
                    return;
                }
                else
                {
                    AddRec(root.right, tmp);
                }
            }
        }

        public int GetHeight()
        {
            return GetHeight(root);
        }

        private int GetHeight(Node root)
        {
            int height = 0;

            if (root.left != null)
            {
                return Math.Max(height, GetHeight(root.left) + 1);
            }
            if (root.right != null)
            {
                return Math.Max(height, GetHeight(root.right) + 1);
            }

            return height;
        }

        /* function to print level order traversal of tree*/
        public void printLevelOrderF()
        {
            if (root == null)
            {
                return;
            }
            int h = GetHeight();
            int i;
            for (i = 0; i <= h; i++)
            {
                printGivenLevel(root, i);
                Console.WriteLine();                // Jak usuniemy to linijkie to wypisuje w jednej lini
            }
        }

        /* Print nodes at the given level */
        void printGivenLevel(Node root, int level)
        {
            if (root == null)
                return;
            if (level == 0)
                Console.Write(root.data + " ");
            else if (level > 0)
            {
                printGivenLevel(root.left, level - 1);
                printGivenLevel(root.right, level - 1);
            }
        }


        public void InOrder()
        {
            ShowInOrder(root);
        }

        //IN-ORDER
        private void ShowInOrder(Node root)
        {
            if (root.left != null)
            {
                ShowInOrder(root.left);
            }
            Console.Write("{0} ", root.data);
            if (root.right != null)
            {
                ShowInOrder(root.right);
            }
        }

        public static BST CreateMinHeightBST(int[] arr)
        {
            BST tree = new BST();

            CreateMinHeightBST(tree, arr, 0, arr.Length);

            return tree;
        }

        private static void CreateMinHeightBST(BST tree, int[] arr, int start, int end)
        {
            if (start == end)
            {
                return;
            }

            int middle = start + (end - start) / 2;
            tree.Add(arr[middle]);
            CreateMinHeightBST(tree, arr, start, middle);
            CreateMinHeightBST(tree, arr, middle + 1, end);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = new int[] { 2, 4, 7, 12, 15, 20, 25 };
            int[] arr2 = new int[] { 1, 3, 5, 8, 9 };

            BST tree = BST.CreateMinHeightBST(arr1);
            tree.printLevelOrderF();

            Console.ReadKey();
        }
    }
}
