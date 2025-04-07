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

namespace Aplikasi_Zakat
{
    public partial class TransaksiModule : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AplikasiWindows\Aplikasi Zakat\Aplikasi Zakat\dbZakata.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        int idTerkait = 0;
        int idAmil = 0;

        public TransaksiModule()
        {
            InitializeComponent();
            this.Load += TransaksiModule_Load;
        }
        private void TransaksiModule_Load(object sender, EventArgs e)
        {
            LoadAmil();

            NonAktifkanKomponen();
        }
        private void btnInput_Click(object sender, EventArgs e)
        {
            string jenis = cmbJenisTransaksi.Text;
            string nama = txtNamaTransaksi.Text.Trim();
            string keterangan = txtKeterangan.Text;
            string jeniszakat = cmbJenisZakat.Text;
            string nominal = txtJumlah.Text;
            DateTime tanggal = dateTimePickerTransaksi.Value;

            // Validasi input kosong atau tidak angka
            if (string.IsNullOrEmpty(jenis) || string.IsNullOrEmpty(nama) ||
                string.IsNullOrEmpty(nominal))
            {
                MessageBox.Show("Mohon lengkapi semua data dan pastikan nominal valid.");
                return;
            }

            // Ambil IdTerkait berdasarkan jenis
            int idTerkait = GetIdTerkait(nama);
            int idAmil = GetIdAmil(cmbAmil.Text);

            if (idTerkait == 0 || idAmil == 0)
            {
                MessageBox.Show("Data tidak valid. Pastikan nama dan amil dipilih dengan benar.");
                return;
            }

            // Simpan ke database
            SqlCommand cmd = new SqlCommand("INSERT INTO tbTransaksi (Tanggal, JenisTransaksi, IdTerkait, JenisZakat, Jumlah, IdAmil, Keterangan) VALUES (@tgl, @jenis, @idTerkait, @jeniszakat, @nominal, @idAmil, @ket)", conn);
            cmd.Parameters.AddWithValue("@tgl", tanggal);
            cmd.Parameters.AddWithValue("@jenis", jenis);
            cmd.Parameters.AddWithValue("@idTerkait", idTerkait);
            cmd.Parameters.AddWithValue("@jeniszakat", jeniszakat);
            cmd.Parameters.AddWithValue("@nominal", nominal);
            cmd.Parameters.AddWithValue("@idAmil", idAmil);
            cmd.Parameters.AddWithValue("@ket", keterangan);


            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Transaksi berhasil disimpan");


        }


        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        void LoadAutoCompleteNamaTerkait()
        {
            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            SqlCommand cmd;

            if (cmbJenisTransaksi.Text == "Penerimaan")
                cmd = new SqlCommand("SELECT Nama FROM tbMuzzaki", conn);
            else
                cmd = new SqlCommand("SELECT Nama FROM tbMustahiq", conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                data.Add(dr["Nama"].ToString());
            }
            dr.Close();
            conn.Close();

            txtNamaTransaksi.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtNamaTransaksi.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtNamaTransaksi.AutoCompleteCustomSource = data;
        }

        int GetIdTerkait(string nama)
        {
            string query = "";
            if (cmbJenisTransaksi.Text == "Penerimaan")
                query = "SELECT Id FROM tbMuzzaki WHERE Nama = @nama";
            else
                query = "SELECT Id FROM tbMustahiq WHERE Nama = @nama";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@nama", nama);

            conn.Open();
            object result = cmd.ExecuteScalar();
            conn.Close();

            return result != null ? Convert.ToInt32(result) : 0;
        }

        void LoadAmil()
        {
            cmbAmil.Items.Clear();
            SqlCommand cmd = new SqlCommand("SELECT Nama FROM tbAmil", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbAmil.Items.Add(dr["Nama"].ToString());
            }
            dr.Close();
            conn.Close();
        }

        int GetIdAmil(string nama)
        {
            SqlCommand cmd = new SqlCommand("SELECT Id FROM tbAmil WHERE Nama = @nama", conn);
            cmd.Parameters.AddWithValue("@nama", nama);
            conn.Open();
            object result = cmd.ExecuteScalar();
            conn.Close();
            return result != null ? Convert.ToInt32(result) : 0;
        }

        private void cmbJenisTransaksi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbJenisTransaksi.SelectedIndex != -1)
            {
                // Aktifkan komponen
                txtNamaTransaksi.Enabled = true;
                cmbAmil.Enabled = true;
                cmbJenisZakat.Enabled = true;
                txtJumlah.Enabled = true;
                txtKeterangan.Enabled = true;
                btnInput.Enabled = true;

                LoadAutoCompleteNamaTerkait();
            }
        }

        private void cmbAmil_SelectedIndexChanged(object sender, EventArgs e)
        {
            idAmil = GetIdAmil(cmbAmil.Text);
        }

        private void txtNamaTransaksi_Leave(object sender, EventArgs e)
        {
            idTerkait = GetIdTerkait(txtNamaTransaksi.Text);
        }

        private void Clear()
        {
            txtJumlah.Clear();
            txtKeterangan.Clear();
            cmbJenisZakat.Text = "";
            cmbJenisTransaksi.Text = "";
            cmbAmil.Text = "";
            txtNamaTransaksi.Clear();
            txtJumlah.Clear();

            NonAktifkanKomponen();
        }

        void NonAktifkanKomponen()
        {
            txtNamaTransaksi.Enabled = false;
            cmbAmil.Enabled = false;
            cmbJenisZakat.Enabled = false;
            txtJumlah.Enabled = false;
            txtKeterangan.Enabled = false;
            btnInput.Enabled = false;
        }
    }
}
