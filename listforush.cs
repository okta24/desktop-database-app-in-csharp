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
    public partial class listforush : Form
    {
        public listforush()
        {
            InitializeComponent();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\\anbar.mdb";
                OleDbDataAdapter adap = new OleDbDataAdapter();
                adap.SelectCommand = new OleDbCommand();
                adap.SelectCommand.CommandText = "select * from forush where tarikh like '%" + textBox1.Text + "%'";
                adap.SelectCommand.Connection = con;
                DataTable dt = new DataTable();
                adap.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
                label2.Text = "میزان سود:  ";
                label3.Text = "میزان فروش: ";
                label4.Text = "درصد فروش: ";
 
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listforush_Load(object sender, EventArgs e)
        {
            binding();
        }
        void binding()
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\\anbar.mdb";
            OleDbDataAdapter adap = new OleDbDataAdapter();
            adap.SelectCommand = new OleDbCommand();
            adap.SelectCommand.CommandText = "select * from forush ";
            adap.SelectCommand.Connection = con;
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\\anbar.mdb";
            DataRowView drv = (DataRowView)e.Row.DataBoundItem;
            int kodm=(int)drv.Row["kodm"];
            string tarikh = (string)drv.Row["tarikh"];
            int kodj=(int)drv.Row["kodj"];
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "delete from forush where kodm="+kodm.ToString()+" and kodj="+kodj.ToString()+" and tarikh='"+tarikh+"'";
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            OleDbDataAdapter adap = new OleDbDataAdapter();
            adap.SelectCommand = new OleDbCommand();
            adap.SelectCommand.CommandText = "select * from ajnas where kodj=" + (int)drv.Row["kodj"];
            adap.SelectCommand.Connection = con;
            DataTable dt = new DataTable();
            adap.Fill(dt);
            DataRow dr = (DataRow)dt.Rows[0];
            int tedad = Int16.Parse(dr.ItemArray[3].ToString());
            tedad = tedad +(int)drv.Row["tedad"];
            OleDbCommand cmd2 = new OleDbCommand();
            cmd2.CommandText = string.Format("update ajnas set tedad='{0}' where kodj={1}", tedad, (int)drv.Row["kodj"]);
            cmd2.Connection = con;
            cmd2.ExecuteNonQuery();
            con.Close();
           // binding();
            MessageBox.Show("رکورد با موفقیت حذف شد", "حذف رکورد", MessageBoxButtons.OK);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sum = 0;
            float total = 0;
            float d=0;
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\\anbar.mdb";
            OleDbDataAdapter adap = new OleDbDataAdapter();
            adap.SelectCommand = new OleDbCommand();
            adap.SelectCommand.CommandText = "select * from forush where tarikh like '%" + textBox1.Text + "%'";
            adap.SelectCommand.Connection = con;
            DataTable dt = new DataTable();
            adap.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow drv = (DataRow)dt.Rows[i];
                sum = sum + Int32.Parse(drv.ItemArray[6].ToString());
                total =total  + Int32.Parse(drv.ItemArray[4].ToString());
            }
            con.Close();
            d = sum / total;
            label2.Text =label2.Text+ sum.ToString() + "تومان";
            label3.Text =label3.Text+ total.ToString() + "تومان";
            label4.Text = label4.Text + d.ToString() + "درصد";

        }
    }
}
