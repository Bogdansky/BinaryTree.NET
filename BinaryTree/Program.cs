using System;
using System.Collections.Generic;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            BinaryTree<int> tree = new BinaryTree<int>();
            List<int> valuesInOrder = new List<int>();
            List<int> valuesPreOrder = new List<int>();
            int counter = 0;
            int root = 0;
            while(counter < 10)
            {
                int value = rand.Next(0, 20);
                if (counter == 0)
                {
                    root = value;
                }
                tree.AppendNode(value);
                counter++;
            }
            Console.WriteLine($"Вершина - {root}");
            tree.InOrderResearch(tree.GetRoot(), ref valuesInOrder);
            tree.PreOrderResearch(tree.GetRoot(), ref valuesPreOrder);
            for (int index = 0; index < tree.Size; index++)
            {
                Console.WriteLine($"{valuesInOrder[index]} - {valuesPreOrder[index]}");
            }
        }
    }
}
