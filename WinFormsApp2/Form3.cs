
using System.Data;
using System.Data.SqlClient;

namespace WinFormsApp2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {
                SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-TNITFUT;Initial Catalog=kürüphane;Integrated Security=True");
                cnn.Open();
                SqlCommand cmd = new SqlCommand("insert into kayıt values (@gmail,@sifre,@sifre2)", cnn);

                cmd.Parameters.AddWithValue("@gmail", textBox1.Text);
                cmd.Parameters.AddWithValue("@sifre", textBox2.Text);
                cmd.Parameters.AddWithValue("@sifre2", textBox3.Text);

                cmd.ExecuteNonQuery();

               
                cnn.Close();

            }
            else if (textBox1.Text != textBox2.Text)
            {
                MessageBox.Show("şifre aynı olmalıdır");
            }
        }
    }
}
