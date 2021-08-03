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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-3HIK3AA;Initial Catalog=yurtKayit;Integrated Security=True");

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_Leave(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_ogrenci where TC=" + maskedTextBox2.Text, baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {

                label3.Text = dr[1].ToString();
                label7.Text = dr[3].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select A,B,C,D,E,F,G,H,J,K from tbl_yurt where TCY=" + maskedTextBox2.Text, baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                label4.Text = dr3[0].ToString();
                label5.Text = dr3[1].ToString();
                label8.Text = dr3[2].ToString();
                label9.Text = dr3[3].ToString();
                label10.Text = dr3[4].ToString();
                label11.Text = dr3[5].ToString();
                label12.Text = dr3[6].ToString();
                label13.Text = dr3[7].ToString();
                label14.Text = dr3[8].ToString();
                label15.Text = dr3[9].ToString();

            }
            if (label4.Text == "True")
            {
                checkBox1.Checked = true;
                checkBox1.Enabled = false;
            }
            else if (label4.Text == "False")
            {
                
                checkBox1.Checked = false;
            }
            if (label5.Text == "True")
            {
                checkBox2.Checked = true;
                checkBox2.Enabled = false;
            }
            else if (label5.Text == "False")
            {
                checkBox2.Checked = false;
                
            }
            if (label8.Text == "True")
            {
                checkBox3.Checked = true;
                checkBox3.Enabled = false;
            }
            else if (label8.Text == "False")
            {
                checkBox3.Checked = false;
            }
            if (label9.Text == "True")
            {
                checkBox4.Checked = true;
                checkBox4.Enabled = false;
            }
            else if (label9.Text == "False")
            {
                checkBox4.Checked = false;
            }
            if (label10.Text == "True")
            {
                checkBox5.Checked = true;
                checkBox5.Enabled = false;
            }
            else if (label10.Text == "False")
            {
                checkBox5.Checked = false;
            }
            if (label11.Text == "True")
            {
                checkBox6.Checked = true;
                checkBox6.Enabled = false;
            }
            else if (label11.Text == "False")
            {
                checkBox6.Checked = false;
            }
            if (label12.Text == "True")
            {
                checkBox7.Checked = true;
                checkBox7.Enabled = false;
            }
            else if (label12.Text == "False")
            {
                checkBox7.Checked = false;
            }
            if (label13.Text == "True")
            {
                checkBox8.Checked = true;
                checkBox8.Enabled = false;
            }
            else if (label13.Text == "False")
            {
                checkBox8.Checked = false;
            }
            if (label14.Text == "True")
            {
                checkBox9.Checked = true;
                checkBox9.Enabled = false;
            }
            else if (label14.Text == "False")
            {
                checkBox9.Checked = false;
            }
            if (label15.Text == "True")
            {
                checkBox10.Checked = true;
                checkBox10.Enabled = false;
            }
            else if (label15.Text == "False")
            {
                checkBox10.Checked = false;
            }

            baglanti.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("update tbl_yurt set A=@p1,B=@p2,C=@p3,D=@p4,E=@p5,F=@p6,G=@p7,H=@p8,J=@p9,K=@p10 where TCY=@p11", baglanti);
            komut2.Parameters.AddWithValue("@p1",checkBox1.Checked);
            komut2.Parameters.AddWithValue("@p2", checkBox2.Checked);
            komut2.Parameters.AddWithValue("@p3", checkBox3.Checked);
            komut2.Parameters.AddWithValue("@p4", checkBox4.Checked);
            komut2.Parameters.AddWithValue("@p5", checkBox5.Checked);
            komut2.Parameters.AddWithValue("@p6", checkBox6.Checked);
            komut2.Parameters.AddWithValue("@p7", checkBox7.Checked);
            komut2.Parameters.AddWithValue("@p8", checkBox8.Checked);
            komut2.Parameters.AddWithValue("@p9", checkBox9.Checked);
            komut2.Parameters.AddWithValue("@p10", checkBox10.Checked);
            komut2.Parameters.AddWithValue("@p11", maskedTextBox2.Text);
            komut2.ExecuteNonQuery();
            MessageBox.Show("Güncelleme Başarılı");
            baglanti.Close();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form7 frm7 = new Form7();
            frm7.Show();
        }
    }
}
