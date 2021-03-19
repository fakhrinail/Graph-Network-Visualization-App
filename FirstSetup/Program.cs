using System;

namespace GraphConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] temp = { "A B", "A C", "A D", "B C", "B E", "B F" };
            Graph G = new Graph(6, temp);
            G.printAll();
        }
    }
}
