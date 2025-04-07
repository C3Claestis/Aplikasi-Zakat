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
    public partial class AmilModule: Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AplikasiWindows\Aplikasi Zakat\Aplikasi Zakat\dbZakata.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        public AmilModule()
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
                if (txtNamaAmil.Text.Trim() == "" || CmbJabatan.Text.Trim() == "" || txtAlamatAmil.Text.Trim() == "")
                {
                    MessageBox.Show("Please fill all fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to save this data?", "Save Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cmd = new SqlCommand("INSERT INTO tbAmil (NamaAmil, NoHp, Alamat, Jabatan, Username, Password, TanggalBergabung, Status) VALUES (@Name, @Phone, @Address, @Jabatan, @Username, @Password, @TanggalBergabung, @Status)", conn);
                        cmd.Parameters.AddWithValue("@Name", txtNamaAmil.Text);
                        cmd.Parameters.AddWithValue("@Phone", txtNoHpAmil.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAlamatAmil.Text);                       
                        cmd.Parameters.AddWithValue("@Jabatan", CmbJabatan.Text);
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@TanggalBergabung", Convert.ToDateTime(dateTimePickerZakat.Text));
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
                    cmd = new SqlCommand("UPDATE tbAmil SET NamaAmil = @Name, NoHp = @Phone, Alamat = @Address, Jabatan = @Jabatan, Username = @Username, Password = @Password, TanggalBergabung = @TanggalBergabung, Status = @Status WHERE Id LIKE '" + lblIdAmil.Text + "' ", conn);
                    cmd.Parameters.AddWithValue("@Name", txtNamaAmil.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtNoHpAmil.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAlamatAmil.Text);                    
                    cmd.Parameters.AddWithValue("@Jabatan", CmbJabatan.Text);
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@TanggalBergabung", Convert.ToDateTime(dateTimePickerZakat.Text));                    
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
            txtNamaAmil.Clear();
            txtAlamatAmil.Clear();
            txtNoHpAmil.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            CmbJabatan.Text = "";
            CmbStatus.Text = "";
        }

        private void txtNoHpAmil_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Hanya menerima angka (0-9) dan tombol kontrol seperti Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Mencegah input selain angka
            }
        }
    }
}
