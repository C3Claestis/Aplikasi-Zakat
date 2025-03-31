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
    public partial class MuzzakiModule: Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AplikasiWindows\Aplikasi Zakat\Aplikasi Zakat\dbZakata.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public MuzzakiModule()
        {
            InitializeComponent();
        }

        private void MuzzakiModule_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNamaMuzzaki.Text.Trim() == "" || CmbJenis.Text.Trim() == "" || txtJumlah.Text.Trim() == ""
                          || CmbNominal.Text.Trim() == "" || CmbMetodeBayar.Text.Trim() == ""
                          || dateTimePickerZakat.Text.Trim() == "")
                {
                    MessageBox.Show("Please fill all fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {                    
                    cmd = new SqlCommand("INSERT INTO tbMuzzaki (Nama, Alamat, NoHp, Email, JenisZakat, Jumlah, Nominal, MetodeBayar, TanggalZakat) VALUES (@Name, @Address, @Phone, @Email, @Jenis, @Jumlah, @Nominal, @MetodeBayar, @Tanggal)", conn);
                    cmd.Parameters.AddWithValue("@Name", txtNamaMuzzaki.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAlamatMuzzaki.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtHpMuzzaki.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmailMuzzaki.Text);
                    cmd.Parameters.AddWithValue("@Jenis", CmbJenis.Text);
                    cmd.Parameters.AddWithValue("@Jumlah", Convert.ToDecimal(txtJumlah.Text));
                    cmd.Parameters.AddWithValue("@Nominal", CmbNominal.Text);
                    cmd.Parameters.AddWithValue("@MetodeBayar", CmbMetodeBayar.Text);
                    cmd.Parameters.AddWithValue("@Tanggal", Convert.ToDateTime(dateTimePickerZakat.Text));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Data saved successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
