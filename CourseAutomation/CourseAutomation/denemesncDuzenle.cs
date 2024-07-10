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
    public partial class denemesncDuzenle : Form
    {
        public denemesncDuzenle()
        {
            InitializeComponent();
        }

        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt = new DataTable();

        public void listeleme()
        {
            da = new SqlDataAdapter("Select ogr.ogr_adsoyad, d.deneme_adi, d.turkcedogru, d.turkceyanlis, d.matematikdogru, d.matematikyanlis, d.sosyaldogru, d.sosyalyanlis, d.fendogru, d.fenyanlis from ogrenci ogr, denemeler d where ogr.ogr_id = d.ogr_id", con);
            con.Open();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-TQ92VR9;Initial Catalog=coumanProject;Integrated Security=True");

        private void denemesncDuzenle_Load(object sender, EventArgs e)
        {
            listeleme();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "update d.deneme_adi, d.turkcedogru, d.turkceyanlis, d.matematikdogru, d.matematikyanlis, d.sosyaldogru, d.sosyalyanlis, d.fendogru, d.fenyanlis from ogrenci ogr, denemeler d where ogr.ogr_id = d.ogr_id";
            
            SqlCommand kmt = new SqlCommand(sorgu, con);
            kmt.Parameters.AddWithValue("@id", textBox9.Text);

            con.Open();
            kmt.ExecuteNonQuery();
            con.Close();
            listeleme();
            MessageBox.Show("Değişiklik başarıyla kaydedildi.", "Düzenle");
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = "ogr_adsoyad LIKE '" + textBox1.Text + "%'";
            dataGridView1.DataSource = dv;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox10.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = "Delete from denemeler where deneme_id = @id";
            SqlCommand kmt = new SqlCommand(sorgu, con);
            kmt.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
            con.Open();
            kmt.ExecuteNonQuery();
            con.Close();
            listeleme();
            MessageBox.Show("Kayıt başarıyla silindi.", "Kayıt Sil");
        }
    }
}
