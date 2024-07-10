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
    public partial class siniflar : UserControl
    {
        public siniflar()
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

        private void button1_Click(object sender, EventArgs e)
        {
            sinifEkle sinifEkle = new sinifEkle();
            sinifEkle.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sinifDuzenle sinifDuzenle = new sinifDuzenle();
            sinifDuzenle.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sinifBilgileri sinifBilgileri = new sinifBilgileri();
            sinifBilgileri.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void siniflar_Load(object sender, EventArgs e)
        {
            listeleme(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listeleme();
        }
    }
}
