using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp2
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-TNITFUT;Initial Catalog=kürüphane;Integrated Security=True");
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select * from data", cnn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-TNITFUT;Initial Catalog=kürüphane;Integrated Security=True");
            cnn.Open();
            SqlCommand cmd = new SqlCommand("delete data where mail=@mail", cnn);
            cmd.Parameters.AddWithValue("@mail", textBox1.Text);
            cmd.ExecuteNonQuery();

            cnn.Close();
            MessageBox.Show("delete islemi yapildi");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-TNITFUT;Initial Catalog=kürüphane;Integrated Security=True");
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Update data set mail=@mail,sifre=@sifre,kod=@kod where mail=@mail", cnn);

            cmd.Parameters.AddWithValue("@mail",textBox4.Text);
            cmd.Parameters.AddWithValue("@sifre", textBox2.Text);
            cmd.Parameters.AddWithValue("@kod", textBox3.Text);
            cmd.ExecuteNonQuery();

            MessageBox.Show("update islemi yapildi");
            cnn.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
