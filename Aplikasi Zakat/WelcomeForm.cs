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
    public partial class WelcomeForm: Form
    {
        int progressValue = 0;

        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressValue += 2;
            progressBar1.Value = progressValue;

            if (progressValue >= 100)
            {
                timer1.Stop();
                this.Hide();
                LoginForm formLogin = new LoginForm();
                formLogin.Show();
            }
        }
    }
}
