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

namespace CourseAutomation
{
    public partial class ogrenciEkle : Form
    {
        public ogrenciEkle()
        {
            InitializeComponent();
            combodoldur();
        }

        public void combodoldur()
        {
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select sinif_derecesi from sinif", baglan);
            DataTable ds = new DataTable();
            da.Fill(ds);
            for (int i = 0; i < ds.Rows.Count; i++)
            {
                comboBox1.Items.Add(ds.Rows[i]["sinif_derecesi"].ToString());
            }
            baglan.Close();
        }

        public void listeleme()
        {
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from ogrenci", baglan);
            DataSet ds = new DataSet();
            da.Fill(ds, "ogrencitab");
            baglan.Close();
        }

        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-TQ92VR9;Initial Catalog=coumanProject;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "insert into ogrenci (ogr_adsoyad, ogr_dogumtarihi, ogr_cinsiyet, ogr_no, ogr_telno, ogr_sinif, ogr_kayittarihi, ogr_adresi, ogr_ucret, veli_adisoyadi, veli_telno) values (@oadSoyad, @oDogum, @oCinsiyet, @oNo, @oTel, @oSinif, @oKayit, @oAdres, @oUcret, @vadSoyad, @vTel)";
            SqlCommand kmt = new SqlCommand(sorgu, baglan);
            kmt.Parameters.AddWithValue("@oadSoyad", textBox1.Text);
            kmt.Parameters.AddWithValue("@oDogum", textBox2.Text);
            kmt.Parameters.AddWithValue("@oNo", textBox3.Text);
            kmt.Parameters.AddWithValue("@oTel", textBox4.Text);
            kmt.Parameters.AddWithValue("@oSinif", comboBox1.Text);
            kmt.Parameters.AddWithValue("@oKayit", textBox6.Text);
            kmt.Parameters.AddWithValue("@oUcret", textBox7.Text);
            kmt.Parameters.AddWithValue("@oAdres", textBox8.Text);
            kmt.Parameters.AddWithValue("@oCinsiyet", comboBox2.Text);
            kmt.Parameters.AddWithValue("@vadSoyad", textBox9.Text);
            kmt.Parameters.AddWithValue("@vTel", textBox10.Text);
            baglan.Open();
            kmt.ExecuteNonQuery();
            MessageBox.Show("Başarıyla öğrenci eklendi.", "Öğrenci Ekle");
            baglan.Close();
            listeleme();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ogrenciEkle_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
