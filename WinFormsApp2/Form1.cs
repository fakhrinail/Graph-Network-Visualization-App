using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Msagl.Drawing;

namespace Enemyster
{
    public partial class Form1 : Form
    {
        //atribut yang dibutuhkan
        private OpenFileDialog fileSubmitted;
        private List<string> contentOfFile;
        private Graph graphApp;
        private int banyakEdge;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //panel1.Controls.Add(viewer);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Tentukan apakah BFS atau DFS
            if (radioButton1.Checked)
            {
                /* Proses exploreFriend */

                if (comboBox1.Text != "<node_src>" && comboBox2.Text != "<node_dest>")
                {
                    /* Proses exploreFriend */

                }
                else
                {
                    
                }

                /* Proses friendRecommendation */

                //cek apakah pengguna sudah memasukkan pilihan node_src
                if (comboBox1.Text != "<node_src>")     //text default
                {
                    //masukkan hasil friendRecommendation ke dalam textBox2
                    Dictionary<string, List<string>> hasilFriendRecommendation = graphApp.friendRecommendationBFS(comboBox1.Text);
                    
                    string[] tempVal = new string[hasilFriendRecommendation.Count];
                    for (int i = 0; i < hasilFriendRecommendation.Count; i++)
                    {
                        tempVal[i] = hasilFriendRecommendation.ElementAt(i).Key + ", Mutual Friend : ";
                        for (int j = 0; j < hasilFriendRecommendation.ElementAt(i).Value.Count; j++)
                        {
                            tempVal[i] = tempVal[i] + hasilFriendRecommendation.ElementAt(i).Value[j] + " ";
                        }
                    }

                    textBox2.Lines = tempVal;   //perlu diinget textBox2.Lines nerimanya array of string
                }
                else
                {
                    
                }
            }
            else if (radioButton2.Checked)
            {
                if (comboBox1.Text != "<node_src>" && comboBox2.Text != "<node_dest")
                {
                    /* Proses exploreFriend */
                    panel1.Controls.Clear();
                    Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
                    List<string> exploreFriendDFSResult = graphApp.exploreFriendDFS(comboBox1.Text, comboBox2.Text);
                    Microsoft.Msagl.Drawing.Graph graphResult = graphApp.buildMSAGLGraph(banyakEdge, contentOfFile);
                    viewer.Graph = graphApp.LoadResult(exploreFriendDFSResult, graphResult);
                    viewer.ToolBarIsVisible = false;
                    viewer.LayoutAlgorithmSettingsButtonVisible = false;
                    panel1.SuspendLayout();
                    viewer.Dock = DockStyle.Fill;
                    panel1.Controls.Add(viewer);
                    panel1.ResumeLayout();
                }
                else
                {
                    
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //mensubmit file
            fileSubmitted = new OpenFileDialog();
            fileSubmitted.Title = "Enemyster May You Know!";
            string currentPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\");
            fileSubmitted.InitialDirectory = System.IO.Path.GetFullPath(currentPath);
            fileSubmitted.Filter = "Text Files|*.txt";
            fileSubmitted.FilterIndex = 2;
            fileSubmitted.RestoreDirectory = true;

            if (fileSubmitted.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fileSubmitted.FileName;

                /* Mulai Proses File */
                string lineText;                //variabel penyimpan 1 line string     
                StreamReader sr = new StreamReader(fileSubmitted.FileName); //reader file

                //inisiasi jumlah edge
                lineText = sr.ReadLine();
                banyakEdge = int.Parse(lineText);
                contentOfFile = new List<string>();

                //iterasi isi file dan menyimpan ke dalam contentOfFile
                lineText = sr.ReadLine();
                int i = 0;
                while (i<banyakEdge)    //while not EOF
                {
                    contentOfFile.Add(lineText);
                    lineText = sr.ReadLine();
                    i++;
                }//contentOfFile terisi

                //initialize graphApp
                graphApp = new Graph(banyakEdge,contentOfFile);

                //initialize comboBox1 dan comboBox2
                string[] node = new string[graphApp.getVertices()];
                for (int j = 0; j < graphApp.getVertices(); j++)
                {
                    node[j] = graphApp.graphDict.ElementAt(j).Key;
                }

                comboBox1.Items.AddRange(node);
                comboBox2.Items.AddRange(node);

            }
        }
    }
}

