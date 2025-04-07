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
                    if(MessageBox.Show("Are you sure you want to save this data?", "Save Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cmd = new SqlCommand("INSERT INTO tbMuzzaki (NamaMuzzaki, Alamat, NoHp, Email, JenisZakat, Jumlah, Nominal, MetodeBayar, TanggalZakat) VALUES (@Name, @Address, @Phone, @Email, @Jenis, @Jumlah, @Nominal, @MetodeBayar, @Tanggal)", conn);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Ingin Update data ini?", "Update Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("UPDATE tbMuzzaki SET NamaMuzzaki = @Name, Alamat = @Address, NoHp = @Phone, Email = @Email, JenisZakat = @Jenis, Jumlah = @Jumlah, Nominal = @Nominal, MetodeBayar = @MetodeBayar, TanggalZakat = @Tanggal WHERE Id LIKE '" + lblIdMuzzaki.Text + "' ", conn);
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
                    MessageBox.Show("Data updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();

            btnInput.Enabled = true;
            btnEdit.Enabled = false;
        }
        public void Clear()
        {
            txtNamaMuzzaki.Clear();
            txtAlamatMuzzaki.Clear();
            txtEmailMuzzaki.Clear();
            txtHpMuzzaki.Clear();
            txtJumlah.Clear();
            CmbJenis.Text = "";
            CmbMetodeBayar.Text = "";
            CmbNominal.Text = "";            
        }

        private void txtHpMuzzaki_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Hanya menerima angka (0-9) dan tombol kontrol seperti Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Mencegah input selain angka
            }
        }

        private void txtJumlah_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Hanya menerima angka (0-9) dan tombol kontrol seperti Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Mencegah input selain angka
            }
        }
    }
}
