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
    public partial class AmilForm: Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AplikasiWindows\Aplikasi Zakat\Aplikasi Zakat\dbZakata.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public AmilForm()
        {
            InitializeComponent();
            ShowData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AmilModule amilModule = new AmilModule();
            amilModule.btnInput.Enabled = true;
            amilModule.btnEdit.Enabled = false;
            amilModule.ShowDialog();
            ShowData();
        }

        private void dgvAmil_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void ShowData()
        {
            dgvAmil.Rows.Clear();

            cmd = new SqlCommand("SELECT * FROM tbAmil WHERE Nama LIKE @search OR Alamat LIKE @search OR NoHp LIKE @search OR Jabatan LIKE @search", conn);
            cmd.Parameters.AddWithValue("@search", "%" + txtSrchAmil.Text + "%");

            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dgvAmil.Rows.Add(
                    dr[0].ToString(),
                    dr[1].ToString(),
                    dr[2].ToString(),
                    dr[3].ToString(),
                    dr[4].ToString(),
                    dr[5].ToString(),                    
                    dr[6].ToString(),
                    Convert.ToDateTime(dr[7].ToString()).ToString("dd/MM/yyyy"),
                    dr[8].ToString()
                );
            }
            dr.Close();
            conn.Close();
        }

        private void txtSrchAmil_TextChanged(object sender, EventArgs e)
        {
            ShowData(); 
        }
    }
}
