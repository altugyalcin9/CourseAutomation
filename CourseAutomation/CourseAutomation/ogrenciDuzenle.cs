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

namespace CourseAutomation
{
    public partial class ogrenciDuzenle : Form
    {
        public ogrenciDuzenle()
        {
            InitializeComponent();
        }

        public void listeleme()
        {
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from ogrenci", baglan);
            DataSet ds = new DataSet();
            da.Fill(ds, "ogrtab");
            dataGridView1.DataSource = ds.Tables["ogrtab"];
            baglan.Close();
        }

        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-TQ92VR9;Initial Catalog=coumanProject;Integrated Security=True");

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ogrenciDuzenle_Load(object sender, EventArgs e)
        {
            listeleme();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "update ogrenci set ogr_adsoyad = @adSoyad, ogr_no = @oNo, ogr_dogumtarihi = @dogumTarihi, ogr_cinsiyet = @cinsiyet, ogr_telno = @telNo, ogr_sinif = @sinif, ogr_kayittarihi = @kayittarihi, ogr_ucret = @ucret, ogr_adresi = @adresi, veli_adisoyadi =@adisoyadi, veli_telno = @vtelno where ogr_id = @id";
            SqlCommand kmt = new SqlCommand(sorgu, baglan);
            kmt.Parameters.AddWithValue("@id", textBox9.Text);
            kmt.Parameters.AddWithValue("@adSoyad", textBox1.Text);
            kmt.Parameters.AddWithValue("@dogumTarihi", textBox2.Text);
            kmt.Parameters.AddWithValue("@cinsiyet", comboBox2.Text);
            kmt.Parameters.AddWithValue("@oNo", textBox10.Text);
            kmt.Parameters.AddWithValue("@telNo", textBox3.Text);
            kmt.Parameters.AddWithValue("@sinif", textBox4.Text);
            kmt.Parameters.AddWithValue("@kayittarihi", textBox5.Text);
            kmt.Parameters.AddWithValue("@adresi", textBox6.Text);
            kmt.Parameters.AddWithValue("@ucret", comboBox1.Text);
            kmt.Parameters.AddWithValue("@adisoyadi", textBox7.Text);
            kmt.Parameters.AddWithValue("@vtelno", textBox8.Text);
            baglan.Open();
            kmt.ExecuteNonQuery();
            baglan.Close();
            listeleme();
            MessageBox.Show("Değişiklik başarıyla kaydedildi.", "Düzenle");
            this.Close();

        
    }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox9.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();                      
            comboBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e) // SİL BUTONU
        {
            string sorgu = "Delete from ogrenci where ogr_id = @id";
            SqlCommand kmt = new SqlCommand(sorgu, baglan);
            kmt.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
            baglan.Open();
            kmt.ExecuteNonQuery();
            baglan.Close();
            listeleme();
            MessageBox.Show("Kayıt başarıyla silindi.", "Kayıt Sil");
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = textBox9.Text = textBox10.Text = comboBox1.Text = comboBox2.Text = "";
        }
    }
}
