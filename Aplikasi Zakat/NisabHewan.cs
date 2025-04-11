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
    public partial class NisabHewan: Form
    {
        public NisabHewan()
        {
            InitializeComponent();
        }

        private void txtJumlahEkor_TextChanged(object sender, EventArgs e)
        {
            if (txtJumlahEkor.Text == "") return;

            // Simpan posisi kursor
            int selectionStart = txtJumlahEkor.SelectionStart;
            int selectionLength = txtJumlahEkor.SelectionLength;

            // Hapus titik yang sudah ada
            string cleaned = txtJumlahEkor.Text.Replace(".", "").TrimStart('0');

            // Cek apakah angka valid
            if (long.TryParse(cleaned, out long value))
            {
                // Format ulang dengan tanda titik
                txtJumlahEkor.Text = string.Format("{0:N0}", value).Replace(",", ".");

                // Atur ulang posisi kursor agar tidak lompat
                txtJumlahEkor.SelectionStart = txtJumlahEkor.Text.Length - selectionLength;
            }
        }

        private void txtJumlahEkor_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Hanya menerima angka (0-9) dan tombol kontrol seperti Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Mencegah input selain angka
            }
        }

        private void btnHitung_Click(object sender, EventArgs e)
        {
            if (cmbJenis.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtJumlahEkor.Text))
            {
                MessageBox.Show("Silakan pilih jenis ternak dan masukkan jumlahnya.");
                return;
            }

            double jumlah = double.Parse(txtJumlahEkor.Text);
            string hasil = "";
            string jenis = cmbJenis.Text;

            if (jenis == "Kambing/Domba")
            {
                if (jumlah < 40)
                {
                    txtHisab.Text = "Belum mencapai nisab zakat.";
                    txtHisab.ForeColor = Color.Red;
                    return;
                }
                else if (jumlah <= 120)
                    hasil = "Zakat: 1 ekor kambing/domba.";
                else if (jumlah <= 200)
                    hasil = "Zakat: 2 ekor kambing/domba.";
                else
                    hasil = $"Zakat: {jumlah / 100} ekor kambing/domba.";

                txtHisab.Text = "Sudah sesuai Hisab. " + hasil;
                txtHisab.ForeColor = Color.Green;
                MessageBox.Show($"Ternak Anda telah mencapai nisab.\n{hasil}", "Zakat Ternak", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (jenis == "Sapi/Kerbau")
            {
                if (jumlah < 30)
                {
                    txtHisab.Text = "Belum mencapai nisab zakat.";
                    txtHisab.ForeColor = Color.Red;
                    return;
                }
                else if (jumlah < 40)
                    hasil = "Zakat: 1 anak sapi umur 1 tahun.";
                else if (jumlah < 60)
                    hasil = "Zakat: 1 anak sapi umur 2 tahun.";
                else
                    hasil = $"Zakat: {jumlah / 30} ekor (tiap 30 ekor = 1 anak sapi).";

                txtHisab.Text = "Sudah sesuai Hisab. " + hasil;
                txtHisab.ForeColor = Color.Green;
                MessageBox.Show($"Ternak Anda telah mencapai nisab.\n{hasil}", "Zakat Ternak", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (jenis == "Unta")
            {
                if (jumlah < 5)
                {
                    txtHisab.Text = "Belum mencapai nisab zakat.";
                    txtHisab.ForeColor = Color.Red;
                    return;
                }
                else if (jumlah < 10)
                    hasil = "Zakat: 1 ekor kambing.";
                else if (jumlah < 15)
                    hasil = "Zakat: 2 ekor kambing.";
                else if (jumlah < 20)
                    hasil = "Zakat: 3 ekor kambing.";
                else if (jumlah < 25)
                    hasil = "Zakat: 4 ekor kambing.";
                else
                    hasil = $"Zakat: {jumlah / 5} ekor kambing atau sesuai tingkat unta.";

                txtHisab.Text = "Sudah sesuai Hisab. " + hasil;
                txtHisab.ForeColor = Color.Green;
                MessageBox.Show($"Ternak Anda telah mencapai nisab.\n{hasil}", "Zakat Ternak", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
