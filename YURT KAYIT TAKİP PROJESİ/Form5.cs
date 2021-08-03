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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-3HIK3AA;Initial Catalog=yurtKayit;Integrated Security=True");

        private void Form5_Load(object sender, EventArgs e)
        {
            
            


        }

        private void maskedTextBox2_Leave(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_ogrenci where TC=" + maskedTextBox2.Text, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.ValueMember = "ogrID";
            comboBox1.DisplayMember = "adi";
            comboBox1.DataSource = dt;
            baglanti.Close();
           
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select oda from tbl_ogrenci where TC=" + maskedTextBox2.Text, baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Text = dr[0].ToString();
            }
            baglanti.Close();

           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into tbl_yurt (ogrenci,oda,tarih,TCY) values (@p1,@p2,@p3,@p4)", baglanti);
            komut2.Parameters.AddWithValue("@p1",comboBox1.SelectedValue);
            komut2.Parameters.AddWithValue("@p2", comboBox2.Text);
            komut2.Parameters.AddWithValue("@p3", maskedTextBox1.Text);
            komut2.Parameters.AddWithValue("@p4", maskedTextBox2.Text);



            komut2.ExecuteNonQuery();
            MessageBox.Show("Başarılı kayıt");

            baglanti.Close();
        }

        
        
    }
}
