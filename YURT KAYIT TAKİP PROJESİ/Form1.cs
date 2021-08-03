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

namespace YURT_KAYIT_TAKİP_PROJESİ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-3HIK3AA;Initial Catalog=yurtKayit;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("BU ALANLAR BOŞ BIRAKILAMAZ !");
            }
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select * from tbl_yonetici where username=@p1 and password= @p2", baglanti);
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.Parameters.AddWithValue("@p2", textBox2.Text);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    Form2 frm2 = new Form2();
                    frm2.Show();
                    this.Hide();
                }
                
                else
                {
                    MessageBox.Show("KULLANICI ADI VEYA ŞİFRE HATALI !");
                }
                baglanti.Close();
            }
        }
    }
}
