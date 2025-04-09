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
    public partial class NisabForm: Form
    {        
        public NisabForm()
        {
            InitializeComponent();
        }

        private void btnHitung_Click(object sender, EventArgs e)
        {
            // Validasi input
            if (string.IsNullOrEmpty(txtPenghasilan.Text))
            {
                MessageBox.Show("Masukkan jumlah penghasilan terlebih dahulu.");
                return;
            }

            double penghasilan;
            if (!double.TryParse(txtPenghasilan.Text, out penghasilan))
            {
                MessageBox.Show("Penghasilan harus berupa angka.");
                return;
            }

            // Harga emas saat ini (misalnya Rp 1.100.000 per gram)
            double hargaEmasPerGram = Convert.ToDouble(txtEmasGram.Text);
            double nisabTahunan = (hargaEmasPerGram * 85) / 12;

            // Cek apakah sudah mencapai nisab
            if (penghasilan >= nisabTahunan)
            {
                double zakat = 0.025 * penghasilan;
                txtHisab.Text = "Sudah sesuai Hisab. Zakat yang harus dibayarkan: Rp " + zakat.ToString("N0");
                txtHisab.ForeColor = Color.Green;
                MessageBox.Show($"Penghasilan Anda telah mencapai nisab.\nZakat yang harus dibayarkan: Rp {zakat:N0}");
            }
            else
            {
                txtHisab.Text = "Belum sesuai Hisab. Zakat tidak perlu dibayarkan.";
                txtHisab.ForeColor = Color.Red;
                MessageBox.Show($"Penghasilan Anda belum mencapai nisab.\nBatas nisab bulanan saat ini: Rp {nisabTahunan:N0}");
            }
        }

        private void txtPenghasilan_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Hanya menerima angka (0-9) dan tombol kontrol seperti Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Mencegah input selain angka
            }
        }

        private void txtEmasGram_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Hanya menerima angka (0-9) dan tombol kontrol seperti Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Mencegah input selain angka
            }
        }

        private void txtPenghasilan_TextChanged(object sender, EventArgs e)
        {
            if (txtPenghasilan.Text == "") return;

            // Simpan posisi kursor
            int selectionStart = txtPenghasilan.SelectionStart;
            int selectionLength = txtPenghasilan.SelectionLength;

            // Hapus titik yang sudah ada
            string cleaned = txtPenghasilan.Text.Replace(".", "").TrimStart('0');

            // Cek apakah angka valid
            if (long.TryParse(cleaned, out long value))
            {
                // Format ulang dengan tanda titik
                txtPenghasilan.Text = string.Format("{0:N0}", value).Replace(",", ".");

                // Atur ulang posisi kursor agar tidak lompat
                txtPenghasilan.SelectionStart = txtPenghasilan.Text.Length - selectionLength;
            }
        }

        private void txtEmasGram_TextChanged(object sender, EventArgs e)
        {
            if (txtEmasGram.Text == "") return;

            // Simpan posisi kursor
            int selectionStart = txtEmasGram.SelectionStart;
            int selectionLength = txtEmasGram.SelectionLength;

            // Hapus titik yang sudah ada
            string cleaned = txtEmasGram.Text.Replace(".", "").TrimStart('0');

            // Cek apakah angka valid
            if (long.TryParse(cleaned, out long value))
            {
                // Format ulang dengan tanda titik
                txtEmasGram.Text = string.Format("{0:N0}", value).Replace(",", ".");

                // Atur ulang posisi kursor agar tidak lompat
                txtEmasGram.SelectionStart = txtEmasGram.Text.Length - selectionLength;
            }
        }
    }
}
