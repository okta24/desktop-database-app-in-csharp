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
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void main_Load(object sender, EventArgs e)
        {
            binding();
        }
        void binding()
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\\anbar.mdb";
            OleDbDataAdapter adap = new OleDbDataAdapter();
            adap.SelectCommand = new OleDbCommand();
            adap.SelectCommand.CommandText = "select * from ajnas";
            adap.SelectCommand.Connection = con;
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\\anbar.mdb";
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "insert into ajnas (name,price,tedad) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text  + "')";
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("رکورد با موفقیت ثبت شد", "ثبت رکورد", MessageBoxButtons.OK);
            binding();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\\anbar.mdb";
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "insert into ajnas (name,price,tedad) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("رکورد با موفقیت ثبت شد", "ثبت رکورد", MessageBoxButtons.OK);
            binding();
        }
        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\\anbar.mdb";
            OleDbCommand cmd2 = new OleDbCommand();
            cmd2.CommandText = string.Format("update ajnas set name='{0}' where kodj={1}", textBox1.Text, Int32.Parse(textBox4.Text));
            cmd2.Connection = con;
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();
            binding();
            MessageBox.Show("رکورد با موفقیت ویرایش شد", "ویرایش رکورد", MessageBoxButtons.OK);
        }

        private void dataGridView1_UserDeletingRow_1(object sender, DataGridViewRowCancelEventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\\anbar.mdb";
            DataRowView drv = (DataRowView)e.Row.DataBoundItem;
            int kodj = (int)drv.Row["kodj"];
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "delete from ajnas where kodj=" + kodj.ToString();
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("رکورد با موفقیت حذف شد", "حذف رکورد", MessageBoxButtons.OK);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\\anbar.mdb";
            OleDbCommand cmd2 = new OleDbCommand();
            cmd2.CommandText = string.Format("update ajnas set price='{0}' where kodj={1}", textBox2.Text, Int32.Parse(textBox4.Text));
            cmd2.Connection = con;
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();
            binding();
            MessageBox.Show("رکورد با موفقیت ویرایش شد", "ویرایش رکورد", MessageBoxButtons.OK);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\\anbar.mdb";
            OleDbCommand cmd2 = new OleDbCommand();
            cmd2.CommandText = string.Format("update ajnas set tedad='{0}' where kodj={1}", textBox3.Text, Int32.Parse(textBox4.Text));
            cmd2.Connection = con;
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();
            binding();
            MessageBox.Show("رکورد با موفقیت ویرایش شد", "ویرایش رکورد", MessageBoxButtons.OK);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\\anbar.mdb";
            OleDbDataAdapter adap = new OleDbDataAdapter();
            adap.SelectCommand = new OleDbCommand();
            adap.SelectCommand.CommandText = "select * from ajnas where tedad=0";
            adap.SelectCommand.Connection = con;
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
            textBox1.Text = "";
            binding();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\\anbar.mdb";
            OleDbDataAdapter adap = new OleDbDataAdapter();
            adap.SelectCommand = new OleDbCommand();
            adap.SelectCommand.CommandText = "select * from ajnas where name like '" + textBox1.Text + "%'";
            adap.SelectCommand.Connection = con;
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int s;
            DataRowView drv = (DataRowView)dataGridView1.SelectedRows[0].DataBoundItem;
            textBox1.Text = (string)drv.Row["name"];
            s = (int)drv.Row["kodj"];
            textBox4.Text = s.ToString();
        }
    }
}
