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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Aplikasi_Zakat
{
    public partial class MainForm: Form
    {
        private Form activeForm = null;
        public string NamaAmil { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUser.Text = NamaAmil;

            openChildForm(new DashboardForm(), "Dashboard");
        }

        private void btnMuzaki_Click(object sender, EventArgs e)
        {
            openChildForm(new MuzakiForm(), "Data Muzaki");
        }

        private void btnMustahiq_Click(object sender, EventArgs e)
        {
            openChildForm(new MustahiqForm(), "Data Mustahiq");
        }
        private void btnAmil_Click(object sender, EventArgs e)
        {
            openChildForm(new AmilForm(), "Data Amil");
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            openChildForm(new DashboardForm(), "Dashboard");
        }
        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            openChildForm(new TransaksiForm(), "Transaksi");
        }
        private void btnAbout_Click(object sender, EventArgs e)
        {
            openChildForm(new AboutForm(), "Tentang");
        }
        private void btnLaporan_Click(object sender, EventArgs e)
        {
            openChildForm(new LaporanForm(), "Laporan");
        }

        #region METHODS
        private void openChildForm(Form childForm, string form)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            labelForm.Text = form;
            childForm.BringToFront();
            childForm.Show();
        }


        #endregion METHODS                            

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();            
        }
    }
}
