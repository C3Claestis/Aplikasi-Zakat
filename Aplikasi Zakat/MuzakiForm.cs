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
            muzzakiModule.ShowDialog();
        }

        public void ShowData()
        {
            int i = 0;
            dgvMuzzaki.Rows.Clear();
            
            cmd = new SqlCommand("SELECT * FROM tbMuzzaki WHERE Nama LIKE @search OR Alamat LIKE @search OR NoHp LIKE @search OR Email LIKE @search", conn);
            cmd.Parameters.AddWithValue("@search", "%" + txtSrchMuzzaki.Text + "%");

            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i ++;
                dgvMuzzaki.Rows.Add(i, dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(),
                    Convert.ToDecimal(dr[6].ToString()), dr[7].ToString(), dr[8].ToString(), Convert.ToDateTime(dr[9].ToString()).ToString("dd/MM/yyyy"));
            }
            dr.Close();
            conn.Close();
        }
    }
}
