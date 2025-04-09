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
    public partial class TransaksiForm: Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AplikasiWindows\Aplikasi Zakat\Aplikasi Zakat\dbZakata.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public TransaksiForm()
        {
            InitializeComponent();
            ShowData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TransaksiModule transaksiModule = new TransaksiModule();
            transaksiModule.NonAktifkanKomponen();
            transaksiModule.btnEdit.Enabled = false;
            transaksiModule.Show();            
            ShowData();
        }
        
        void ShowData()
        {
            dgvTransaksi.Rows.Clear();

            string query = @"
            SELECT 
                t.IdTransaksi,         -- [0]
                t.Tanggal,             -- [1]
                t.JenisTransaksi,      -- [2]
                mz.NamaMuzzaki,        -- [3]
                mh.NamaMustahiq,       -- [4]
                t.JenisZakat,          -- [5]
                t.Jumlah,              -- [6]
                a.NamaAmil,            -- [7]
                t.Keterangan           -- [8]
            FROM tbTransaksi t
            LEFT JOIN tbMuzzaki mz ON t.IdTerkait = mz.IdMuzzaki AND t.JenisTransaksi = 'Penerimaan'
            LEFT JOIN tbMustahiq mh ON t.IdTerkait = mh.IdMustahiq AND t.JenisTransaksi = 'Distribusi'
            LEFT JOIN tbAmil a ON t.IdAmil = a.IdAmil
            ORDER BY t.Tanggal DESC";

            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string jenis = dr[2].ToString(); // JenisTransaksi

                string muzzaki = jenis == "Penerimaan" ? dr[3].ToString() : "-";
                string mustahiq = jenis == "Distribusi" ? dr[4].ToString() : "-";

                dgvTransaksi.Rows.Add(
                    dr[0].ToString(), // IdTransaksi
                    Convert.ToDateTime(dr[1]).ToString("dd/MM/yyyy"), // Tanggal
                    jenis,
                    muzzaki,
                    mustahiq,
                    dr[5].ToString(), // JenisZakat
                    dr[6].ToString(), // Jumlah
                    dr[7].ToString(), // Amil
                    dr[8].ToString()  // Keterangan
                );
            }


            dr.Close();
            conn.Close();
        }

        private void dgvTransaksi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = dgvTransaksi.Columns[e.ColumnIndex].Name;

            if (colname == "Edit")
            {
                TransaksiModule transaksiModule = new TransaksiModule();
                transaksiModule.lblIdTransaksi.Text = dgvTransaksi.Rows[e.RowIndex].Cells[0].Value.ToString();
                transaksiModule.dateTimePickerTransaksi.Text = dgvTransaksi.Rows[e.RowIndex].Cells[1].Value.ToString();
                transaksiModule.cmbJenisTransaksi.Text = dgvTransaksi.Rows[e.RowIndex].Cells[2].Value.ToString();

                if (dgvTransaksi.Rows[e.RowIndex].Cells[3].Value.ToString() == "-")
                {
                    transaksiModule.txtNamaTransaksi.Text = dgvTransaksi.Rows[e.RowIndex].Cells[4].Value.ToString();
                }
                else
                {
                    transaksiModule.txtNamaTransaksi.Text = dgvTransaksi.Rows[e.RowIndex].Cells[3].Value.ToString();
                }
               
                transaksiModule.cmbJenisZakat.Text = dgvTransaksi.Rows[e.RowIndex].Cells[5].Value.ToString();
                transaksiModule.txtJumlah.Text = dgvTransaksi.Rows[e.RowIndex].Cells[6].Value.ToString();
                transaksiModule.cmbAmil.Text = dgvTransaksi.Rows[e.RowIndex].Cells[7].Value.ToString();
                transaksiModule.txtKeterangan.Text = dgvTransaksi.Rows[e.RowIndex].Cells[8].Value.ToString();
                
                transaksiModule.btnInput.Enabled = false;
                transaksiModule.btnClear.Enabled = false;
                transaksiModule.btnEdit.Enabled = true;
                transaksiModule.Show();
                transaksiModule.AktifKomponen();

                ShowData();
            }
            else if (colname == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this data?", "Delete Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("DELETE FROM tbTransaksi WHERE IdTransaksi = @id", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@id", dgvTransaksi.Rows[e.RowIndex].Cells[0].Value.ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Transaksi berhasil dihapus", "Deleting Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();
                }
            }

            ShowData();
        }
    }
}
