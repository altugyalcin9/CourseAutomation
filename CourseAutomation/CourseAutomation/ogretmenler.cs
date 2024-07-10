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
using System.Data.SqlClient;

namespace CourseAutomation
{
    public partial class ogretmenler : UserControl
    {
        public ogretmenler()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-TQ92VR9;Initial Catalog=coumanProject;Integrated Security=True");

        public void listeleme()
        {
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from ogretmen", baglan);
            DataSet ds = new DataSet();
            da.Fill(ds, "ogrtab");
            dataGridView1.DataSource = ds.Tables["ogrtab"];
            baglan.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ogretmenBilgileri ogretmenBilgileri = new ogretmenBilgileri();
            ogretmenBilgileri.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ogretmenEkle ogretmenEkle = new ogretmenEkle();
            ogretmenEkle.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ogretmenDuzenle ogretmenDuzenle = new ogretmenDuzenle();
            ogretmenDuzenle.Show();
        }

        private void ogretmenler_Load(object sender, EventArgs e)
        {
            listeleme();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e) // GÜNCELLE BUTONU
        {
            listeleme();
        }
    }
}
