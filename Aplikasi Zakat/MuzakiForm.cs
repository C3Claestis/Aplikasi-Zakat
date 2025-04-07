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
    public partial class MuzakiForm: Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AplikasiWindows\Aplikasi Zakat\Aplikasi Zakat\dbZakata.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public MuzakiForm()
        {
            InitializeComponent();
            ShowData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MuzzakiModule muzzakiModule = new MuzzakiModule();
            muzzakiModule.btnInput.Enabled = true;
            muzzakiModule.btnEdit.Enabled = false;
            muzzakiModule.ShowDialog();
            ShowData();
        }

        public void ShowData()
        {            
            dgvMuzzaki.Rows.Clear();
            
            cmd = new SqlCommand("SELECT * FROM tbMuzzaki WHERE NamaMuzzaki LIKE @search OR Alamat LIKE @search OR NoHp LIKE @search OR Email LIKE @search", conn);
            cmd.Parameters.AddWithValue("@search", "%" + txtSrchMuzzaki.Text + "%");

            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dgvMuzzaki.Rows.Add(
                    dr[0].ToString(), 
                    dr[1].ToString(),
                    dr[2].ToString(),
                    dr[3].ToString(),
                    dr[4].ToString(),
                    dr[5].ToString(),
                    Convert.ToDecimal(dr[6].ToString()),
                    dr[7].ToString(),
                    dr[8].ToString(),
                    Convert.ToDateTime(dr[9].ToString()).ToString("dd/MM/yyyy")
                );
            }
            dr.Close();
            conn.Close();
        }

        private void dgvMuzzaki_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = dgvMuzzaki.Columns[e.ColumnIndex].Name;

            if (colname == "Edit")
            {
                MuzzakiModule muzzakiModule = new MuzzakiModule();  
                muzzakiModule.lblIdMuzzaki.Text = dgvMuzzaki.Rows[e.RowIndex].Cells[0].Value.ToString();
                muzzakiModule.txtNamaMuzzaki.Text = dgvMuzzaki.Rows[e.RowIndex].Cells[1].Value.ToString();
                muzzakiModule.txtAlamatMuzzaki.Text = dgvMuzzaki.Rows[e.RowIndex].Cells[2].Value.ToString();
                muzzakiModule.txtHpMuzzaki.Text = dgvMuzzaki.Rows[e.RowIndex].Cells[3].Value.ToString();
                muzzakiModule.txtEmailMuzzaki.Text = dgvMuzzaki.Rows[e.RowIndex].Cells[4].Value.ToString();
                muzzakiModule.CmbJenis.Text = dgvMuzzaki.Rows[e.RowIndex].Cells[5].Value.ToString();
                muzzakiModule.txtJumlah.Text = dgvMuzzaki.Rows[e.RowIndex].Cells[6].Value.ToString();
                muzzakiModule.CmbNominal.Text = dgvMuzzaki.Rows[e.RowIndex].Cells[7].Value.ToString();
                muzzakiModule.CmbMetodeBayar.Text = dgvMuzzaki.Rows[e.RowIndex].Cells[8].Value.ToString();
                muzzakiModule.dateTimePickerZakat.Text = dgvMuzzaki.Rows[e.RowIndex].Cells[9].Value.ToString();
                muzzakiModule.btnInput.Enabled = false;
                muzzakiModule.btnClear.Enabled = false;
                muzzakiModule.btnEdit.Enabled = true;
                muzzakiModule.ShowDialog();
            }
            else if (colname == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this data?", "Delete Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("DELETE FROM tbMuzzaki WHERE NamaMuzzaki = @name", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@name", dgvMuzzaki.Rows[e.RowIndex].Cells[1].Value.ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Muzzaki berhasil dihapus", "Deleting Product", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                    ShowData();
                }
            }

            ShowData();
        }

        private void txtSrchMuzzaki_TextChanged_1(object sender, EventArgs e)
        {
            ShowData();
        }
    }
}
