using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Aplikasi_Zakat
{
    public partial class MustahiqForm: Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AplikasiWindows\Aplikasi Zakat\Aplikasi Zakat\dbZakata.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public MustahiqForm()
        {
            InitializeComponent();
            ShowData();
        }

        public void ShowData()
        {
            dgvMustahiq.Rows.Clear();

            cmd = new SqlCommand("SELECT * FROM tbMustahiq WHERE NamaMustahiq LIKE @search OR Alamat LIKE @search OR NoHp LIKE @search OR Jenis LIKE @search", conn);
            cmd.Parameters.AddWithValue("@search", "%" + txtSrchMustahiq.Text + "%");

            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dgvMustahiq.Rows.Add(
                    dr[0].ToString(),
                    dr[1].ToString(),
                    dr[2].ToString(),
                    dr[3].ToString(),
                    dr[4].ToString(),
                    dr[5].ToString(),
                    Convert.ToDateTime(dr[6].ToString()).ToString("dd/MM/yyyy"),
                    Convert.ToDecimal(dr[7].ToString()),
                    dr[8].ToString()                                        
                );
            }
            dr.Close();
            conn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MustahiqModule mustahiqModule = new MustahiqModule();
            mustahiqModule.btnInput.Enabled = true;
            mustahiqModule.btnEdit.Enabled = false;
            mustahiqModule.ShowDialog();
            ShowData();
        }

        private void txtSrchMustahiq_TextChanged_1(object sender, EventArgs e)
        {
            ShowData();
        }

        private void dgvMustahiq_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = dgvMustahiq.Columns[e.ColumnIndex].Name;

            if (colname == "Edit")
            {
                MustahiqModule mustahiqModule = new MustahiqModule();
                mustahiqModule.lblIdMustahiq.Text = dgvMustahiq.Rows[e.RowIndex].Cells[0].Value.ToString();
                mustahiqModule.txtNamaMustahiq.Text = dgvMustahiq.Rows[e.RowIndex].Cells[1].Value.ToString();
                mustahiqModule.txtAlamatMustahiq.Text = dgvMustahiq.Rows[e.RowIndex].Cells[2].Value.ToString();
                mustahiqModule.txtHpMustahiq.Text = dgvMustahiq.Rows[e.RowIndex].Cells[3].Value.ToString();
                mustahiqModule.CmbJenis.Text = dgvMustahiq.Rows[e.RowIndex].Cells[4].Value.ToString();
                mustahiqModule.txtKeterangan.Text = dgvMustahiq.Rows[e.RowIndex].Cells[5].Value.ToString();
                mustahiqModule.dateTimePickerZakat.Text = dgvMustahiq.Rows[e.RowIndex].Cells[6].Value.ToString();
                mustahiqModule.txtJumlah.Text = dgvMustahiq.Rows[e.RowIndex].Cells[7].Value.ToString();
                mustahiqModule.CmbStatus.Text = dgvMustahiq.Rows[e.RowIndex].Cells[8].Value.ToString();               
                mustahiqModule.btnInput.Enabled = false;
                mustahiqModule.btnClear.Enabled = false;
                mustahiqModule.btnEdit.Enabled = true;
                mustahiqModule.ShowDialog();
            }
            else if (colname == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this data?", "Delete Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("DELETE FROM tbMustahiq WHERE NamaMustahiq = @name", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@name", dgvMustahiq.Rows[e.RowIndex].Cells[1].Value.ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Mustahiq berhasil dihapus", "Deleting Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();
                }
            }

            ShowData();
        }
    }
}
