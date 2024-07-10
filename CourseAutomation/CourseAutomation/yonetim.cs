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
    public partial class yonetim : UserControl
    {
        public yonetim()
        {
            InitializeComponent();
        }
        public void listeleme()
        {

        }

        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-TQ92VR9;Initial Catalog=coumanProject;Integrated Security=True");



        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void tabControl1_Load(object sender, EventArgs e)
        {
            listeleme();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // HESAP EKLEME BUTONU
        {
            string sorgu = "insert into hesaplar (k_kadi, k_parola, k_rol) values (@kAdi, @kParola, @kRol)";
            SqlCommand kmt = new SqlCommand(sorgu, baglan);
            kmt.Parameters.AddWithValue("@kAdi", textBox1.Text);
            kmt.Parameters.AddWithValue("@kParola", textBox2.Text);
            kmt.Parameters.AddWithValue("@kRol", comboBox2.Text);
            baglan.Open();
            kmt.ExecuteNonQuery();
            MessageBox.Show("Başarıyla hesap oluşturuldu.", "Hesap Oluştur");
            baglan.Close();
            listeleme();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
