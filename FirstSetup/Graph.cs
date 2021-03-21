using System;
using System.Collections.Generic;
using System.Text;

namespace GraphConsole
{
    class Graph
    {
        private Dictionary<string, List<string>> graphDict;  //menyimpan dictionary edges dengan key adalah node dan valuenya adalah nama node yang ia terhubung
        private int countEdges;                 //menyimpan ada berapa edge
        private int countVertices;              //menyimpan ada berapa vertice

        //ctor tp langsung aja masukin ada berapa edge dan apa aja
        public Graph(int countEdges, string[] rawEdges)
        {
            this.countEdges = countEdges;
            this.countVertices = 0;

            graphDict = new Dictionary<string, List<string>>();
            for (int i = 0; i < rawEdges.Length; i++)
            {
                string rawKey = rawEdges[i].Split(" ")[0];
                string rawValue = rawEdges[i].Split(" ")[1];

                //cek apakah node rawKey sudah ada atau belum
                if (graphDict.ContainsKey(rawKey))              //node rawKey ada
                {
                    //cek apakah node rawKey punya edge ke rawValue atau tidak
                    if (!graphDict[rawKey].Contains(rawValue))
                    {
                        graphDict[rawKey].Add(rawValue);
                    }
                }
                else                                            //node rawKey blm ada
                {
                    //inisialisasi node rawKey dengan edge pertama ke rawValue
                    List<string> temp = new List<string>();
                    temp.Add(rawValue);
                    graphDict.Add(rawKey, temp);
                    countVertices++;
                }

                //cek apakah node rawValue sudah ada atau belum
                if (graphDict.ContainsKey(rawValue))
                {
                    //cek apakah node rawValue punya edge ke rawKey atau tidak
                    if (!graphDict[rawValue].Contains(rawKey))
                    {
                        graphDict[rawValue].Add(rawKey);
                    }
                }
                else
                {
                    //inisialisasi node rawEdge dengan edge pertama ke rawKey
                    List<string> temp = new List<string>();
                    temp.Add(rawKey);
                    graphDict.Add(rawValue, temp);
                    countVertices++;
                }
            }
        }
        
        public void printAll()
        {
            foreach (KeyValuePair<string, List<string>> entry in graphDict)
            {
                Console.Out.Write("Key: "+ entry.Key +" Value: ");
                foreach(string str in entry.Value)
                {
                    Console.Out.Write(str + " ");
                }
                Console.Out.WriteLine();
            }
        }

        public List<string> exploreFriendBFS(string A, string B)
        {
            // inisialisasi awal
            bool ditemukan = false;
            List<string> retVal = new List<string>();
            List<string> reverseRetVal = new List<string>();
            List<string> queue = new List<string>();

            Dictionary<string, bool> dikunjungi = new Dictionary<string, bool>(this.countVertices);
            Dictionary<string, string> pred = new Dictionary<string, string>(this.countVertices);
            foreach (string s in graphDict.Keys)
            {
                dikunjungi.Add(s, false);
                pred.Add(s, null);
            }

            // kondisi awal
            queue.Add(A);
            dikunjungi[A] = true;
            
            // iterasi mencari simpul tujuan dengan algoritma BFS
            while (queue.Count > 0 && !ditemukan)
            {   
                foreach (string node in graphDict[queue[0]])
                {
                    if (!dikunjungi[node])
                    {
                        dikunjungi[node] = true;
                        queue.Add(node);
                        pred[node] = queue[0];
                        
                        if (string.Equals(node, B))
                        {
                            ditemukan = true;
                        }
                    }
                }
                queue.RemoveAt(0);
            }

            // tracking jalur solusi yang ditemukan
            if (ditemukan)
            {
                // tracking dari simpul tujuan ke simpul awal
                string v = B;
                reverseRetVal.Add(v);
                while(pred[v] != null)
                {
                    reverseRetVal.Add(pred[v]);
                    v = pred[v];
                }

                // membalikkan urutan untuk return value
                for (int i = reverseRetVal.Count - 1; i >= 0; i--)
                {
                    retVal.Add(reverseRetVal[i]);
                }
            }
            return retVal;
        }
        public List<string> exploreFriendDFS()
        {
            List<string> retVal = new List<string>();
            return retVal;
        }
        public Dictionary<string, int> friendRecommendationBFS()
        {
            Console.WriteLine("Input your node of choice: ");
            string rootNode = Console.ReadLine(); // harusnya input dicek dulu
            string observedNode;
            int friendCounter = 0;
            List<string> visitedNodes = new List<string>();
            List<string> rootFriendlist = new List<string>(graphDict[rootNode]);
            List<string> queueOfNodes = new List<string>();
            Dictionary<string, int> friendRecommendations = new Dictionary<string, int>();

            queueOfNodes.Add(rootNode);
            visitedNodes.Add(rootNode);
            Console.WriteLine(rootNode);

            //lakukan BFS
            while (queueOfNodes.Count != 0)
            {
                observedNode = queueOfNodes[0];
                queueOfNodes.RemoveAt(0); //pop queue
                if (rootFriendlist.Contains(observedNode))
                {
                    friendCounter++;
                }
                foreach (string node in graphDict[observedNode])
                {
                    if (!queueOfNodes.Contains(node) && !visitedNodes.Contains(node) && friendCounter != rootFriendlist.Count)
                    { //batas BFS cuma di tingkat ke-2
                        visitedNodes.ForEach(Console.Write);
                        queueOfNodes.Add(node);
                        visitedNodes.Add(node);
                    }
                    else if (rootFriendlist.Contains(node) && !rootFriendlist.Contains(observedNode))
                    {
                        if (friendRecommendations.ContainsKey(observedNode))
                        {
                            friendRecommendations[observedNode]++;
                        }
                        else
                        {
                            friendRecommendations.Add(observedNode, 1);
                        }
                    }
                }
            }

            return friendRecommendations;
        }
    }
}
