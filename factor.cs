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
    public partial class factor : Form
    {
        int i=0;
        public factor()
        {
            InitializeComponent();
        }

        private void factor_Load(object sender, EventArgs e)
        {
            binding();
            i++;
            textBox1.Text = i.ToString();
            maskedTextBox1.Text="1390/12/05";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\\anbar.mdb";
            OleDbDataAdapter adap = new OleDbDataAdapter();
            adap.SelectCommand = new OleDbCommand();
            adap.SelectCommand.CommandText = "select * from ajnas where kodj="+textBox2.Text;
            adap.SelectCommand.Connection = con;
            DataTable dt = new DataTable();
            adap.Fill(dt);
            DataRow drv=(DataRow)dt.Rows[0];
            int price = Int32.Parse (drv.ItemArray[2].ToString());
            int sud = (Int32.Parse(textBox4.Text) / Int32.Parse(textBox3.Text) - price) * Int32.Parse(textBox3.Text);
           /* OleDbCommand cmd1 = new OleDbCommand();
            cmd1.CommandText = "insert into sud (sud,tarikh) values('" + sud.ToString()+"','" + maskedTextBox1.Text + "')";
            cmd1.Connection = con;
            con.Open();
            cmd1.ExecuteNonQuery();*/
          //  textBox1.Text = g.ToString();
            int tedad = Int16.Parse(drv.ItemArray[3].ToString());
            tedad = tedad - Int32.Parse(textBox3.Text);
            OleDbCommand cmd2 = new OleDbCommand();
            cmd2.CommandText = string.Format("update ajnas set tedad='{0}' where kodj={1}",tedad,Int32.Parse(textBox2.Text));
            cmd2.Connection = con;
            con.Open();
            cmd2.ExecuteNonQuery();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "insert into forush (kodm,kodj,name,tedad,price,tarikh,sud,tozih) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox5.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" +maskedTextBox1.Text + "','"+sud.ToString()+"','"+textBox6.Text+"')";
            cmd.Connection = con;
            //con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("رکورد با موفقیت ثبت شد", "ثبت رکورد", MessageBoxButtons.OK);
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\\anbar.mdb";
            OleDbDataAdapter adap = new OleDbDataAdapter();
            adap.SelectCommand = new OleDbCommand();
            adap.SelectCommand.CommandText = "select * from ajnas where name like '"+textBox5.Text+"%'";
            adap.SelectCommand.Connection = con;
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            binding();
            i++;
            textBox1.Text = i.ToString();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            i = 1;
            textBox1.Text = i.ToString();
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataRowView drv = (DataRowView)e.Row.DataBoundItem;
            int id=(int)drv.Row["kodm"];

        }

        private void maskedTextBox1_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            i = 1;
            textBox1.Text = i.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            binding();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int s;
            DataRowView drv = (DataRowView)dataGridView1.SelectedRows[0].DataBoundItem;
            textBox5.Text = (string)drv.Row["name"];
            s = (int)drv.Row["kodj"];
            textBox2.Text = s.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form ffa = new listforush();
            ffa.Show();
        }
    }
}
