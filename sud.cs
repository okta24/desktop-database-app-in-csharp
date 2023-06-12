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
    public partial class sud : Form
    {
        public sud()
        {
            InitializeComponent();
        }

        private void sud_Load(object sender, EventArgs e)
        {
            binding();
        }
        void binding()
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\\anbar.mdb";
            OleDbDataAdapter adap = new OleDbDataAdapter();
            adap.SelectCommand = new OleDbCommand();
            adap.SelectCommand.CommandText = "select * from sud";
            adap.SelectCommand.Connection = con;
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sum=0;
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\\anbar.mdb";
            OleDbDataAdapter adap = new OleDbDataAdapter();
            adap.SelectCommand = new OleDbCommand();
            adap.SelectCommand.CommandText = "select * from sud where tarikh like '%"+ textBox1.Text+"%'";
            adap.SelectCommand.Connection = con;
            DataTable dt = new DataTable();
            adap.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow drv = (DataRow)dt.Rows[i];
                sum=sum+Int32.Parse (drv.ItemArray[0].ToString());
            }
                con.Close();
                label2.Text = sum.ToString()+"تومان";
        }
    }
}
