using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CourseAutomation
{
    public partial class ogretmenDuzenle : Form
    {

        public void listeleme()
        {
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from ogretmen", baglan);
            DataSet ds = new DataSet();
            da.Fill(ds, "ogrtab");
            dataGridView1.DataSource = ds.Tables["ogrtab"];
            baglan.Close();
        }

        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-TQ92VR9;Initial Catalog=coumanProject;Integrated Security=True");

        public ogretmenDuzenle()
        {
            InitializeComponent();
        }

        private void ogretmenDuzenle_Load(object sender, EventArgs e)
        {
            listeleme();
        }

        private void button1_Click(object sender, EventArgs e) // DÜZENLE BUTONU
        {
            string sorgu = "update ogretmen set ogretmen_adisoyadi = @adiSoyadi, ogretmen_dtarihi = @dogumTarihi, ogretmen_telno = @telNo, ogretmen_adresi = @adresi, ogretmen_maas = @maas where ogretmen_id = @id";
            SqlCommand kmt = new SqlCommand(sorgu, baglan);
            kmt.Parameters.AddWithValue("@id", textBox5.Text);
            kmt.Parameters.AddWithValue("@adiSoyadi", textBox1.Text);
            kmt.Parameters.AddWithValue("@dogumTarihi", textBox2.Text);
            kmt.Parameters.AddWithValue("@telNo", textBox3.Text);
            kmt.Parameters.AddWithValue("@maas", textBox4.Text);
            kmt.Parameters.AddWithValue("@adresi", textBox6.Text);
            baglan.Open();
            kmt.ExecuteNonQuery();
            baglan.Close();
            listeleme();
            MessageBox.Show("Değişiklik başarıyla kaydedildi.", "Düzenle");
            this.Close();
            
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e) // SİL BUTONU
        {
            string sorgu = "Delete from ogretmen where ogretmen_id = @id";
            SqlCommand kmt = new SqlCommand(sorgu, baglan);
            kmt.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
            baglan.Open();
            kmt.ExecuteNonQuery();
            baglan.Close();
            listeleme();
            MessageBox.Show("Kayıt başarıyla silindi.", "Kayıt Sil");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }
    }
}
