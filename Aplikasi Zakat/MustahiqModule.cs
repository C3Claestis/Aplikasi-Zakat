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
    public partial class MustahiqModule: Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AplikasiWindows\Aplikasi Zakat\Aplikasi Zakat\dbZakata.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        public MustahiqModule()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNamaMustahiq.Text.Trim() == "" || CmbJenis.Text.Trim() == "" || txtAlamatMustahiq.Text.Trim() == "")
                {
                    MessageBox.Show("Please fill all fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to save this data?", "Save Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cmd = new SqlCommand("INSERT INTO tbMustahiq (NamaMustahiq, Alamat, NoHp, Jenis, Keterangan, Tanggal, Jumlah, Status) VALUES (@Name, @Address, @Phone, @Jenis, @Keterangan, @Tanggal, @Jumlah, @Status)", conn);
                        cmd.Parameters.AddWithValue("@Name", txtNamaMustahiq.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAlamatMustahiq.Text);
                        cmd.Parameters.AddWithValue("@Phone", txtHpMustahiq.Text);                        
                        cmd.Parameters.AddWithValue("@Jenis", CmbJenis.Text);
                        cmd.Parameters.AddWithValue("@Keterangan", txtKeterangan.Text);
                        cmd.Parameters.AddWithValue("@Tanggal", Convert.ToDateTime(dateTimePickerZakat.Text));
                        cmd.Parameters.AddWithValue("@Jumlah", Convert.ToDecimal(txtJumlah.Text));                        
                        cmd.Parameters.AddWithValue("@Status", CmbStatus.Text);
                        
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
                if (MessageBox.Show("Ingin Update data ini?", "Update Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("UPDATE tbMustahiq SET NamaMustahiq = @Name, Alamat = @Address, NoHp = @Phone, Jenis = @Jenis, Keterangan = @Keterangan, Tanggal = @Tanggal, Jumlah = @Jumlah, Status = @Status WHERE IdMustahiq LIKE '" + lblIdMustahiq.Text + "' ", conn);
                    cmd.Parameters.AddWithValue("@Name", txtNamaMustahiq.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAlamatMustahiq.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtHpMustahiq.Text);                    
                    cmd.Parameters.AddWithValue("@Jenis", CmbJenis.Text);
                    cmd.Parameters.AddWithValue("@Keterangan", txtKeterangan.Text);
                    cmd.Parameters.AddWithValue("@Tanggal", Convert.ToDateTime(dateTimePickerZakat.Text));
                    cmd.Parameters.AddWithValue("@Jumlah", Convert.ToDecimal(txtJumlah.Text));                    
                    cmd.Parameters.AddWithValue("@Status", CmbStatus.Text);
                    
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
            txtNamaMustahiq.Clear();
            txtAlamatMustahiq.Clear();
            txtKeterangan.Clear();
            txtHpMustahiq.Clear();
            txtJumlah.Clear();
            CmbJenis.Text = "";
            CmbStatus.Text = "";            
        }

        private void txtHpMustahiq_KeyPress(object sender, KeyPressEventArgs e)
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
