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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-3HIK3AA;Initial Catalog=yurtKayit;Integrated Security=True");

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {

                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                baglanti.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from tbl_oda where mevcutKap=1 and durum=1",baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox1.ValueMember = "odaID";
                comboBox1.DisplayMember = "odaNum";
                comboBox1.DataSource = dt;
                
                baglanti.Close();
                
            }
            else if (checkBox1.Checked == false)
            {
                comboBox1.DataSource = null;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {

                checkBox1.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                baglanti.Open();
                SqlDataAdapter da2 = new SqlDataAdapter("select * from tbl_oda where mevcutKap=2 and durum=1", baglanti);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                comboBox1.ValueMember = "odaID";
                comboBox1.DisplayMember = "odaNum";
                comboBox1.DataSource = dt2;
                baglanti.Close();

            }
            else if (checkBox2.Checked == false)
            {
                comboBox1.DataSource = null;
                checkBox1.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {

                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox4.Enabled = false;
                

                baglanti.Open();
                SqlDataAdapter da3 = new SqlDataAdapter("select * from tbl_oda where mevcutKap=3 and durum=1", baglanti);
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);
                comboBox1.ValueMember = "odaID";
                comboBox1.DisplayMember = "odaNum";
                comboBox1.DataSource = dt3;
                baglanti.Close();

            }
            else if (checkBox3.Checked == false)
            {
                comboBox1.DataSource = null;
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox4.Enabled = true;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {

                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                baglanti.Open();
                SqlDataAdapter da4 = new SqlDataAdapter("select * from tbl_oda where mevcutKap=4 and durum=1", baglanti);
                DataTable dt4 = new DataTable();
                da4.Fill(dt4);
                comboBox1.ValueMember = "odaID";
                comboBox1.DisplayMember = "odaNum";
                comboBox1.DataSource = dt4;
                baglanti.Close();

            }
            else if (checkBox4.Checked == false)
            {
                comboBox1.DataSource = null;
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==""||textBox2.Text==""||textBox3.Text==""|| comboBox1.Text=="")
            {
                MessageBox.Show("BU ALANLAR BOŞ BIRAKILAMAZ!");

            }
            else
            {

                baglanti.Open();
                SqlCommand komut4 = new SqlCommand("update tbl_oda set mevcutKap=mevcutKap-1 where odaNum=@k1", baglanti);
                komut4.Parameters.AddWithValue("@k1",comboBox1.Text);
                komut4.ExecuteNonQuery();
                baglanti.Close();






                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("insert into tbl_ogrenci (adi,soyadi,ucret,oda,TC) values (@h1,@h2,@h3,@h4,@h5)",baglanti);
                komut2.Parameters.AddWithValue("@h1",textBox1.Text);
                komut2.Parameters.AddWithValue("@h2", textBox2.Text);
                komut2.Parameters.AddWithValue("@h3", textBox3.Text);
                komut2.Parameters.AddWithValue("@h4", comboBox1.SelectedValue);
                komut2.Parameters.AddWithValue("@h5", maskedTextBox2.Text);
                komut2.ExecuteNonQuery();
                MessageBox.Show("KAYIT BAŞARILI !");
                baglanti.Close();


            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select adi,soyadi,oda from tbl_ogrenci where TC=@n1",baglanti);
            komut5.Parameters.AddWithValue("@n1",maskedTextBox1.Text);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while(dr5.Read())
            {
                textBox5.Text = dr5[0].ToString() + " " + dr5[1].ToString();
                textBox4.Text = dr5[2].ToString();
            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand komut7 = new SqlCommand("update tbl_oda set mevcutKap=mevcutKap+1 where odaNum=@n3", baglanti);
            komut7.Parameters.AddWithValue("@n3", textBox4.Text);
            komut7.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut10 = new SqlCommand("delete from tbl_yurt where TCY=@nk1",baglanti);
            komut10.Parameters.AddWithValue("nk1",maskedTextBox1.Text);
            komut10.ExecuteNonQuery();
            baglanti.Close();
            
            
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("delete from tbl_ogrenci where TC=@n2",baglanti);
            komut6.Parameters.AddWithValue("@n2",maskedTextBox1.Text);
            komut6.ExecuteNonQuery();
            MessageBox.Show("KAYIT SİLİNDİ!");
            
            baglanti.Close();
            maskedTextBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";



        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form6 frm6 = new Form6();
            frm6.Show();
        }
    }
}
