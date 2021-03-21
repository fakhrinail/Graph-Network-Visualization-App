using System;
using System.Collections.Generic;

namespace GraphConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] temp = { "A B", "A C", "A D", "B C", "B E", "B F" };
            Graph G = new Graph(6, temp);
            G.printAll();
            Console.Out.WriteLine();

            // Explore Friend BFS
            List<string> path = new List<string>();
            string awal = "A";
            string tujuan = "F";
            path = G.exploreFriendBFS(awal, tujuan);

            Console.Out.WriteLine("Nama akun: "+awal+" dan "+tujuan);

            if (path.Count > 0)
            {
                int n = path.Count - 2;
                Console.Write(n);
                if (n % 10 == 1 && (n % 100 < 10 || n % 100 > 20))
                {
                    Console.Write("st");
                }
                else if (n % 10 == 2 && (n % 100 < 10 || n % 100 > 20))
                {
                    Console.Write("nd");
                }
                else if (n % 10 == 3 && (n % 100 < 10 || n % 100 > 20))
                {
                    Console.Write("rd");
                }
                else
                {
                    Console.Write("th");
                }
                Console.Out.WriteLine("-degree connection");
                for (int i = 0; i < path.Count - 1; i++)
                {
                    Console.Write(path[i] + " --> ");
                }
                Console.WriteLine(path[path.Count - 1]);
            }
            else
            {
                Console.WriteLine("Tidak ada jalur koneksi yang tersedia");
                Console.WriteLine("Anda harus memulai koneksi baru itu sendiri.");
            }
            
        }
    }
}
