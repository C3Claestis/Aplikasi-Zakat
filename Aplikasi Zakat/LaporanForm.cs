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
    public partial class LaporanForm: Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AplikasiWindows\Aplikasi Zakat\Aplikasi Zakat\dbZakata.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public LaporanForm()
        {
            InitializeComponent();
        }

        private void btnTampilLaporan_Click(object sender, EventArgs e)
        {
            dgvLaporan.Rows.Clear();

            string jenisTransaksi = cmbJenisTransaksi.Text;
            string jenisZakat = cmbJenisZakat.Text;
            DateTime tanggalAwal = dateAwal.Value.Date;
            DateTime tanggalAkhir = dateAkhir.Value.Date;

            string query = @"
            SELECT 
                t.Tanggal,
                t.JenisTransaksi,
                mz.NamaMuzzaki,
                mh.NamaMustahiq,
                t.JenisZakat,
                t.Jumlah
            FROM tbTransaksi t
            LEFT JOIN tbMuzzaki mz ON t.IdTerkait = mz.IdMuzzaki AND t.JenisTransaksi = 'Penerimaan'
            LEFT JOIN tbMustahiq mh ON t.IdTerkait = mh.IdMustahiq AND t.JenisTransaksi = 'Distribusi'
            WHERE 
                t.Tanggal BETWEEN @awal AND @akhir
                AND t.JenisTransaksi = @jenisTransaksi
                AND t.JenisZakat = @jenisZakat
            ORDER BY t.Tanggal ASC";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@awal", tanggalAwal);
                cmd.Parameters.AddWithValue("@akhir", tanggalAkhir);
                cmd.Parameters.AddWithValue("@jenisTransaksi", jenisTransaksi);
                cmd.Parameters.AddWithValue("@jenisZakat", jenisZakat);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                int no = 0;
                while (dr.Read())
                {
                    no++;
                    string muzzaki = jenisTransaksi == "Penerimaan" ? dr["NamaMuzzaki"].ToString() : "-";
                    string mustahiq = jenisTransaksi == "Distribusi" ? dr["NamaMustahiq"].ToString() : "-";

                    dgvLaporan.Rows.Add(
                        no,
                        Convert.ToDateTime(dr["Tanggal"]).ToString("dd/MM/yyyy"),
                        dr["JenisTransaksi"].ToString(),
                        muzzaki,
                        mustahiq,
                        dr["JenisZakat"].ToString(),
                        dr["Jumlah"].ToString()
                    );
                }

                dr.Close();

                decimal total = 0;

                foreach (DataGridViewRow row in dgvLaporan.Rows)
                {
                    if (row.Cells[6].Value != null) // pastikan kolom 6 (Jumlah) tidak null
                    {
                        string jumlahStr = row.Cells[6].Value.ToString().Replace("Rp", "").Replace(".", "").Trim();
                        if (decimal.TryParse(jumlahStr, out decimal jumlah))
                        {
                            total += jumlah;
                        }
                    }
                }

                txtTotal.Text = $"Total Jumlah: Rp{total:N0}";

                conn.Close();
            }
        }
    }
}
