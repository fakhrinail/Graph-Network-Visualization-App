using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enemyster
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Form1 F1 = new Form1();
            /*
            string[] temp = { "A D", "A C", "A B", "C F", "B E", "D G", "B C", "C G", "B F", "D F", "E H", "F H", "E F", "J I" };
            Graph GTest = new Graph(14, temp);

            //create a form 
            System.Windows.Forms.Form form = new System.Windows.Forms.Form();
            */
            
            //create a viewer object 
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            
            //create a graph object 
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            //create the graph content 
            graph.AddEdge("A", "B");
            graph.AddEdge("B", "C");
            graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
            graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
            graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
            Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
            c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;
            //bind the graph to the viewer 
            viewer.Graph = graph;
            //associate the viewer with the form 
            F1.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            //F1.Controls.Add(viewer);
            F1.ResumeLayout();
            //show the form 
            F1.ShowDialog();

            /*
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(F1);
            */
        }
    }
}
