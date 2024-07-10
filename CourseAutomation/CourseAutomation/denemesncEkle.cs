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
    public partial class denemesncEkle : Form
    {
        public denemesncEkle()
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


        private void denemesncEkle_Load(object sender, EventArgs e)
        {
            listeleme();
        }

        private void button1_Click(object sender, EventArgs e) // EKLE BUTONU
        {
            string sorgu = "insert into denemeler (ogr_id, deneme_adi, turkcedogru, turkceyanlis, matematikdogru, matematikyanlis, sosyaldogru, sosyalyanlis, fendogru, fenyanlis) values (@ogrencid, @dAdi, @tDogru, @tYanlis, @mDogru, @mYanlis, @sDogru, @sYanlis, @fDogru, @fYanlis)";
            SqlCommand kmt = new SqlCommand(sorgu, baglan);
            kmt.Parameters.AddWithValue("@ogrencid", dataGridView1.CurrentRow.Cells[0].Value.ToString());
            kmt.Parameters.AddWithValue("@dAdi", textBox10.Text);
            kmt.Parameters.AddWithValue("@tDogru", textBox9.Text);
            kmt.Parameters.AddWithValue("@tYanlis", textBox8.Text);
            kmt.Parameters.AddWithValue("@mDogru", textBox2.Text);
            kmt.Parameters.AddWithValue("@mYanlis", textBox7.Text);
            kmt.Parameters.AddWithValue("@sDogru", textBox3.Text);
            kmt.Parameters.AddWithValue("@sYanlis", textBox6.Text);
            kmt.Parameters.AddWithValue("@fDogru", textBox4.Text);
            kmt.Parameters.AddWithValue("@fYanlis", textBox5.Text);
            baglan.Open(); 
            kmt.ExecuteNonQuery();
            MessageBox.Show("Başarıyla deneme eklendi.", "Deneme Ekle");
            baglan.Close();
            listeleme();
            this.Close();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            /*
            textBox10.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            */
        }
    }
}
