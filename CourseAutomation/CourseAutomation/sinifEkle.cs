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
    public partial class sinifEkle : Form
    {
        public sinifEkle()
        {
            InitializeComponent();
        }

        public void listeleme()
        {
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from sinif", baglan);
            DataSet ds = new DataSet();
            da.Fill(ds, "siniftab");
            baglan.Close();
        }

        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-TQ92VR9;Initial Catalog=coumanProject;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "insert into sinif (sinif_derecesi, sinif_alani) values (@sinif, @alan)";
            SqlCommand kmt = new SqlCommand(sorgu, baglan);
            kmt.Parameters.AddWithValue("@sinif", comboBox1.Text + comboBox2.Text);
            kmt.Parameters.AddWithValue("@alan", comboBox3.Text);
            baglan.Open();
            kmt.ExecuteNonQuery();
            MessageBox.Show("Başarıyla sınıf eklendi.", "Sınıf Ekle");
            baglan.Close();
            listeleme();
            this.Close();
        }
    }
}
