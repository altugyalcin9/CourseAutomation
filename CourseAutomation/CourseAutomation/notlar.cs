using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseAutomation
{
    public partial class notlar : UserControl
    {
        public notlar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            denemesncEkle denemesncEkle = new denemesncEkle();
            denemesncEkle.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            denemeSnc denemeSnc = new denemeSnc();
            denemeSnc.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            denemesncDuzenle denemesncDuzenle = new denemesncDuzenle();
            denemesncDuzenle.Show();
        }
    }
}
