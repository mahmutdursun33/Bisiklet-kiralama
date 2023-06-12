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

namespace WinFormsApp2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string gmail = textBox1.Text;
            string sifre = textBox2.Text;

            bool dogruluk = kontrol(gmail, sifre);

            if (dogruluk)
            {
                MessageBox.Show("giriş yapıldı");
                Form4 form4 = new Form4();
                form4.label1.Text = this.textBox1.Text;
                form4.label2.Text = this.textBox2.Text;
                form4.ShowDialog();
            }
            else
            {
                MessageBox.Show("Gmail şifreniz yanlış veya e-posta adresi bulunamadı");
            }

            static bool kontrol(string gmail, string sifre)
            {
                SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-TNITFUT;Initial Catalog=kürüphane;Integrated Security=True");
                cnn.Open();
                string query = $"select count(*) FROM kayıt WHERE gmail = '{gmail}' AND sifre = '{sifre}'";


                using (SqlCommand cmd2 = new SqlCommand(query, cnn))
                {


                    int count = (int)cmd2.ExecuteScalar();

                    return count > 0;
                }
            }




        }




    }
}