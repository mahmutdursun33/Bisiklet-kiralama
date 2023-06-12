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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp2
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Rastgele harf ve sayıları içerecek karakter dizisi
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            // Rastgele harf ve sayı oluşturmak için Random sınıfını kullanın
            Random random = new Random();

            // Belirli bir uzunlukta rastgele harf ve sayı oluşturmak için StringBuilder sınıfını kullanın
            StringBuilder sb = new StringBuilder();
            int length = 8; // Oluşturulacak karakter dizisinin uzunluğu

            for (int i = 0; i < length; i++)
            {
                // Rastgele bir karakteri seçin ve StringBuilder'a ekleyin
                int index = random.Next(characters.Length);
                sb.Append(characters[index]);
            }

            // Oluşturulan rastgele harf ve sayıyı yazdırın
            MessageBox.Show(sb.ToString());


            SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-TNITFUT;Initial Catalog=kürüphane;Integrated Security=True");
            cnn.Open();
            SqlCommand cmd = new SqlCommand("insert into data values (@mail,@sifre,@kod)", cnn);

            cmd.Parameters.AddWithValue("@mail", label1.Text);
            cmd.Parameters.AddWithValue("@sifre", label2.Text);
            cmd.Parameters.AddWithValue("@kod", sb.ToString());


            cmd.ExecuteNonQuery();


            cnn.Close();
        }
    }
}
