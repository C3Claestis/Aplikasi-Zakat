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
    public partial class MainForm: Form
    {
        private Form activeForm = null;
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnMuzaki_Click(object sender, EventArgs e)
        {
            openChildForm(new MuzakiForm(), "Data Muzaki");
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
    }
}
