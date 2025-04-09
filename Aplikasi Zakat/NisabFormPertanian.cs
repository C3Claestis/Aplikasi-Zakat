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
    public partial class NisabFormPertanian: Form
    {
        public NisabFormPertanian()
        {
            InitializeComponent();
        }

        private void btnHitung_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHasilPanen.Text) || cmbIrigasi.SelectedIndex == -1)
            {
                MessageBox.Show("Silakan lengkapi semua data terlebih dahulu.");
                return;
            }

            double hasilPanen = double.Parse(txtHasilPanen.Text.Replace(".", ""));
            double nisab = 653; // nisab dalam kg gabah
            double zakat = 0;
            double persen = 0;
            
            switch (cmbIrigasi.Text)
            {
                case "Irigasi Alami (Hujan, Sungai, Mata Air)":
                    persen = 0.10;
                    break;
                case "Irigasi Buatan (Pompa Air, Sumur, Irigasi Teknis)":
                    persen = 0.05;
                    break;
                case "Campuran (Alami + Buatan)":
                    persen = 0.075;
                    break;
                default:
                    MessageBox.Show("Jenis irigasi tidak valid.");
                    return;
            }

            if (hasilPanen < nisab)
            {
                txtHisab.Text = "Belum sesuai Hisab. Zakat tidak perlu dibayarkan.";
                txtHisab.ForeColor = Color.Red;
                MessageBox.Show($"Penghasilan Anda belum mencapai nisab.\nBatas nisab tahunan saat ini: {nisab:Kg}");
            }
            else
            {                
                zakat = hasilPanen * persen;
                txtHisab.Text = "Sudah sesuai Hisab. Zakat yang harus dibayarkan: " + zakat.ToString() + " Kg";
                txtHisab.ForeColor = Color.Green;
                MessageBox.Show($"Penghasilan Anda telah mencapai nisab.\nZakat yang harus dibayarkan: " + zakat.ToString() + " Kg");
            }
        }

        private void txtHasilPanen_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Hanya menerima angka (0-9) dan tombol kontrol seperti Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Mencegah input selain angka
            }
        }

        private void txtHasilPanen_TextChanged(object sender, EventArgs e)
        {
            if (txtHasilPanen.Text == "") return;

            // Simpan posisi kursor
            int selectionStart = txtHasilPanen.SelectionStart;
            int selectionLength = txtHasilPanen.SelectionLength;

            // Hapus titik yang sudah ada
            string cleaned = txtHasilPanen.Text.Replace(".", "").TrimStart('0');

            // Cek apakah angka valid
            if (long.TryParse(cleaned, out long value))
            {
                // Format ulang dengan tanda titik
                txtHasilPanen.Text = string.Format("{0:N0}", value).Replace(",", ".");

                // Atur ulang posisi kursor agar tidak lompat
                txtHasilPanen.SelectionStart = txtHasilPanen.Text.Length - selectionLength;
            }
        }
    }
}
