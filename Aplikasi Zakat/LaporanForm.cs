using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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

            StringBuilder queryBuilder = new StringBuilder(@"
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
            WHERE t.Tanggal BETWEEN @awal AND @akhir
            ");

            if (jenisTransaksi != "Semua")
                queryBuilder.Append(" AND t.JenisTransaksi = @jenisTransaksi");

            if (jenisZakat != "Semua")
                queryBuilder.Append(" AND t.JenisZakat = @jenisZakat");

            queryBuilder.Append(" ORDER BY t.Tanggal ASC");

            using (SqlCommand cmd = new SqlCommand(queryBuilder.ToString(), conn))
            {
                cmd.Parameters.AddWithValue("@awal", tanggalAwal);
                cmd.Parameters.AddWithValue("@akhir", tanggalAkhir);

                if (jenisTransaksi != "Semua")
                    cmd.Parameters.AddWithValue("@jenisTransaksi", jenisTransaksi);

                if (jenisZakat != "Semua")
                    cmd.Parameters.AddWithValue("@jenisZakat", jenisZakat);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                int no = 0;
                while (dr.Read())
                {
                    no++;
                    string muzzaki = dr["JenisTransaksi"].ToString() == "Penerimaan" ? dr["NamaMuzzaki"].ToString() : "-";
                    string mustahiq = dr["JenisTransaksi"].ToString() == "Distribusi" ? dr["NamaMustahiq"].ToString() : "-";

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
                    if (row.Cells[6].Value != null)
                    {
                        string jumlahStr = row.Cells[6].Value.ToString().Replace("Rp", "").Replace(".", "").Trim();
                        if (decimal.TryParse(jumlahStr, out decimal jumlah))
                            total += jumlah;
                    }
                }

                txtTotal.Text = $"Total Jumlah: Rp{total:N0}";
                conn.Close();
            }
        }
        private void ExportToPDF(DataGridView dgv, string filePath)
        {
            Document doc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();

            PdfPTable table = new PdfPTable(dgv.Columns.Count);
            table.WidthPercentage = 100;

            // Header
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                table.AddCell(cell);
            }

            // Data
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        table.AddCell(cell.Value?.ToString() ?? "");
                    }
                }
            }

            doc.Add(table);
            doc.Close();

            MessageBox.Show("Data berhasil diexport ke PDF!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCetak_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "PDF Files|*.pdf";
            save.Title = "Simpan Laporan ke PDF";
            save.FileName = "LaporanZakat.pdf";

            if (save.ShowDialog() == DialogResult.OK)
            {
                ExportToPDF(dgvLaporan, save.FileName);
            }
        }
    }
}
