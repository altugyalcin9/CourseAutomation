using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CourseAutomation

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection("Data Source=DESKTOP-TQ92VR9;Initial Catalog=coumanProject;Integrated Security=True");
            cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = ("SELECT * FROM hesaplar where k_kadi ='" + textBox1.Text + "' AND k_parola ='" + textBox2.Text + "'");
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("Giriş Başarılı");

                string rolu = dr["k_rol"].ToString().Trim();
                if (rolu == "bt")
                {
                    btsetup btsetup = new btsetup();
                    btsetup.Show();
                    btsetup.BringToFront();
                    this.Hide();
                }
                else if (rolu == "mudur")
                {
                    mudur mudur = new mudur();
                    mudur.Show();
                    mudur.BringToFront();
                    this.Hide();
                }
                else if (rolu == "ogretmen")
                {
                    ogretmen ogretmen = new ogretmen();
                    ogretmen.Show();
                    ogretmen.BringToFront();
                    this.Hide();
                }
                else if (rolu == "sekreter")
                {
                    sekreterlik sekreterlik = new sekreterlik();
                    sekreterlik.Show();
                    sekreterlik.BringToFront();
                    this.Hide();
                }
                //this.Close();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya parola hatalı.");
            }

            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }
    }
}
