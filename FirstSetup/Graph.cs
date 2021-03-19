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

                if (graphDict.ContainsKey(rawKey))
                {
                    graphDict[rawKey].Add(rawValue);
                }
                else
                {
                    List<string> temp = new List<string>();
                    temp.Add(rawValue);
                    graphDict.Add(rawKey, temp);
                    this.countVertices++;
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

        public List<string> exploreFriendBFS()
        {
            List<string> retVal = new List<string>();
            return retVal;
        }
        public List<string> exploreFriendDFS()
        {
            List<string> retVal = new List<string>();
            return retVal;
        }
        public List<string> friendRecommendationBFS()
        {
            List<string> retVal = new List<string>();
            return retVal;
        }
        public List<string> friendRecommendationDFS()
        {
            List<string> retVal = new List<string>();
            return retVal;
        }

    }
}
