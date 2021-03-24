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
    public partial class Form1 : Form
    {
        //atribut yang dibutuhkan
        private OpenFileDialog fileSubmitted;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1Clicked(object sender, EventArgs e)
        {
            fileSubmitted = new OpenFileDialog();
            fileSubmitted.Title = "Enemyster May You Know!";
            fileSubmitted.InitialDirectory = @"c:\";
            fileSubmitted.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fileSubmitted.FilterIndex = 2;
            fileSubmitted.RestoreDirectory = true;
            if (fileSubmitted.ShowDialog() == DialogResult.OK)
            {
                label1.Text = fileSubmitted.FileName;
            }
        }
    }
}

