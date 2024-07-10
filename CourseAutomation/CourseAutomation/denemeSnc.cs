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
    public partial class denemeSnc : Form
    {
        public denemeSnc()
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


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void denemeSnc_Load(object sender, EventArgs e)
        {
            listeleme();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            // DataView dv = dataGridView1.DefaultView1;
            DataView dv = dt.DefaultView;
            dv.RowFilter = "ogr_adsoyad LIKE '" + textBox1.Text + "%'";
            dataGridView1.DataSource = dv;
            // ogradi LIKE '" + textBox2.Text + "%'

            /*
            DataSet ds = new DataSet();
            DataView dv = new DataView();
            dv.RowFilter = "SELECT* FROM ogrenci WHERE ogr_adsoyad LIKE '%" + textBox1.Text + "%' OR ogr_no LIKE '%" + textBox1.Text + "%'";
            listeleme();
            //dv.RowFilter = string.Format("Ad LIKE '{0}%'", textBox5.Text);
            dataGridView1.DataSource = dv;
            */

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox11.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
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
    }
}
