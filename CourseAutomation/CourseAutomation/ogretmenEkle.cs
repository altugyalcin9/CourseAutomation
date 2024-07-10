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
    public partial class ogretmenEkle : Form
    {
        public ogretmenEkle()
        {
            InitializeComponent();
        }

        public void listeleme()
        {
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from ogretmen", baglan);
            DataSet ds = new DataSet();
            da.Fill(ds, "ogrtab");
            baglan.Close();
        }

        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-TQ92VR9;Initial Catalog=coumanProject;Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
            ogretmenler ogretmenler = new ogretmenler();
            string sorgu = "insert into ogretmen (ogretmen_adisoyadi, ogretmen_dtarihi, ogretmen_telno, ogretmen_maas, ogretmen_adresi) values (@adiSoyadi, @dogumTarihi, @telNo, @maas, @adresi)";
            SqlCommand kmt = new SqlCommand(sorgu, baglan);
            kmt.Parameters.AddWithValue("@adiSoyadi", textBox1.Text);
            kmt.Parameters.AddWithValue("@dogumTarihi", textBox2.Text);
            kmt.Parameters.AddWithValue("@telNo", textBox3.Text);
            kmt.Parameters.AddWithValue("@maas", textBox4.Text);
            kmt.Parameters.AddWithValue("@adresi", textBox6.Text);
            baglan.Open();
            kmt.ExecuteNonQuery();
            MessageBox.Show("Başarıyla öğretmen eklendi.", "Öğretmen Ekle");
            baglan.Close();
            listeleme();
            this.Close();
            ogretmenler.listeleme();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // OpenFileDialog ofd = new OpenFileDialog();
            //pictureBox1.ImageLocation = openFileDialog1.FileName;
                  //  pictureBox1.ImageLocation = openFileDialog1.FileName;
                  //    pictureBox1.ImageLocation = openFileDialog1.FileName;
        }
    }
}
