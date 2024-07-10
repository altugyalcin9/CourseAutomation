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
    public partial class sinifDuzenle : Form
    {
        public sinifDuzenle()
        {
            InitializeComponent();
        }

        public void listeleme()
        {
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from sinif", baglan);
            DataSet ds = new DataSet();
            da.Fill(ds, "siniftab");
            dataGridView1.DataSource = ds.Tables["siniftab"];
            baglan.Close();
        }

        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-TQ92VR9;Initial Catalog=coumanProject;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e) // KAYDET BUTONU
        {
            string sorgu = "update sinif set sinif_derecesi = @sinif, sinif_alani = @alan where sinif_id = @id";
            SqlCommand kmt = new SqlCommand(sorgu, baglan);
            kmt.Parameters.AddWithValue("@id", textBox1.Text);
            kmt.Parameters.AddWithValue("@sinif", comboBox1.Text);
            kmt.Parameters.AddWithValue("@alan", comboBox2.Text);
            baglan.Open();
            kmt.ExecuteNonQuery();
            baglan.Close();
            listeleme();
            MessageBox.Show("Değişiklik başarıyla kaydedildi.", "Düzenle");
            this.Close();
        }

        private void sinifDuzenle_Load(object sender, EventArgs e)
        {
            listeleme();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = "Delete from sinif where sinif_id = @id";
            SqlCommand kmt = new SqlCommand(sorgu, baglan);
            kmt.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
            baglan.Open();
            kmt.ExecuteNonQuery();
            baglan.Close();
            listeleme();
            MessageBox.Show("Kayıt başarıyla silindi.", "Kayıt Sil");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
