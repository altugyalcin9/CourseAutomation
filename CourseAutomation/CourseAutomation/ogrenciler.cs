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
    public partial class ogrenciler : UserControl
    {
        public ogrenciler()
        {
            InitializeComponent();
        }

        public void listeleme()
        {
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from ogrenci", baglan);
            DataSet ds = new DataSet();
            da.Fill(ds, "ogrencitab");
            dataGridView1.DataSource = ds.Tables["ogrencitab"];
            baglan.Close();
        }

        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-TQ92VR9;Initial Catalog=coumanProject;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            ogrDetay ogrDetay = new ogrDetay();
            ogrDetay.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            denemeSonuc denemeSonuc = new denemeSonuc();
            denemeSonuc.Show();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            ogrenciEkle ogrenciEkle = new ogrenciEkle();

            ogrenciEkle.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ogrenciDuzenle ogrenciDuzenle = new ogrenciDuzenle();
            ogrenciDuzenle.Show();
        }

        private void ogrenciler_Load(object sender, EventArgs e)
        {
            listeleme();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listeleme();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
