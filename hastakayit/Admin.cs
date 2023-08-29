using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace hastakayit
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {
            dbb.openConnection();
            doldur();
            groupBox1.Visible = false;
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbb.closeConnection();
        }

        private void doldur()
        {
            string cumle = "Select * from admin";
            dbb.cmd.CommandText = cumle;
            dbb.da = new SqlDataAdapter(dbb.cmd);
            dbb.ds = new DataSet();
            dbb.da.Fill(dbb.ds);
            dataGridView1.DataSource = dbb.ds.Tables[0];



        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbb.cmd.Parameters.Clear();
            dbb.cmd.CommandText = "insert into admin (kul,sifre) values (@kul,@sifre)";
            dbb.cmd.Parameters.AddWithValue("@kul", textBox2.Text);
            dbb.cmd.Parameters.AddWithValue("@sifre", textBox3.Text);
            dbb.cmd.ExecuteNonQuery();
            doldur();
            MessageBox.Show("Kayıt Eklendi");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.CurrentCell.RowIndex;
            textBox2.Text= dataGridView1.Rows[secim].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            textBox1.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dbb.cmd.Parameters.Clear();
            dbb.cmd.CommandText = "update admin set kul=@kul,sifre=@sifre where Id=@Id";
            dbb.cmd.Parameters.AddWithValue("@kul", textBox2.Text);
            dbb.cmd.Parameters.AddWithValue("@sifre", textBox3.Text);
            dbb.cmd.Parameters.AddWithValue("@Id", textBox1.Text);
            dbb.cmd.ExecuteNonQuery();
            doldur();
            MessageBox.Show("Kayıt Düzenlendi");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dbb.cmd.Parameters.Clear();
            dbb.cmd.CommandText = "Delete from admin where Id=@Id  ";
            
            dbb.cmd.Parameters.AddWithValue("@Id", textBox1.Text);
            dbb.cmd.ExecuteNonQuery();
            doldur();
            MessageBox.Show("Kayıt Silindi");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //string ad = Interaction.InputBox("Aranan kişi adını giriniz");
            groupBox1.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                dbb.cmd.Parameters.Clear();
                string cumle = "Select * from admin where kul like @kul ";
                dbb.cmd.CommandText = cumle;
                dbb.cmd.Parameters.AddWithValue("@kul",'%'+ textBox4.Text+'%');
                dbb.da = new SqlDataAdapter(dbb.cmd);
                dbb.ds = new DataSet();
                dbb.da.Fill(dbb.ds);
                dataGridView1.DataSource = dbb.ds.Tables[0];
            }
            catch (Exception ex)
            {

                MessageBox.Show("Kayıt Bulunamadı");
            }
            
        }
    }
}
