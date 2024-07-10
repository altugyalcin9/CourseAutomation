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
    public partial class btsetup : Form
    {
        internal object btsetup1;

        public btsetup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            subeler1.Show();
            subeler1.BringToFront();
        }

        private void subeler1_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            yonetim1.Show();
            yonetim1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ogrenciler1.Show();
            ogrenciler1.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ogretmenler1.Show();
            ogretmenler1.BringToFront();
        }

        private void ogretmenler1_Load(object sender, EventArgs e)
        {

        }

        public void name()
        {
            string baglantiCumlesi = "Data Source=DESKTOP-TQ92VR9;Initial Catalog=coumanProject;Integrated Security=True";
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            string sorgu = "Select k_kadi from hesaplar where k_rol = 'bt'";
            string deger;
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            baglanti.Open();
            deger = (string)komut.ExecuteScalar();
            baglanti.Close();
            label2.Text = deger;
        }
        private void btsetup_Load(object sender, EventArgs e)
        {
            name();
        }

        private void btsetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 Form1 = new Form1();
            Form1.Show();
            Form1.BringToFront();
            this.Hide();
        }
    }
}
