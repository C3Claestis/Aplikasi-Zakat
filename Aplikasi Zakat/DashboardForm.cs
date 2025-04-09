using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplikasi_Zakat
{
    public partial class DashboardForm: Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void btnNisab_Click(object sender, EventArgs e)
        {
            NisabForm nisabForm = new NisabForm();
            nisabForm.Show();
        }

        private void btnHitungPertanian_Click(object sender, EventArgs e)
        {
            NisabFormPertanian pertanianForm = new NisabFormPertanian();
            pertanianForm.Show();
        }

        private void btnHitungHewan_Click(object sender, EventArgs e)
        {
            NisabHewan hewanForm = new NisabHewan();
            hewanForm.Show();
        }
    }
}
