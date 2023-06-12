using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace anbar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      

        private void Form1_Load(object sender, EventArgs e)
        {
          
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form ffa = new factor();
            ffa.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form ffa = new listforush();
            ffa.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form ffa = new main();
            ffa.Show();
        }
    }
}
