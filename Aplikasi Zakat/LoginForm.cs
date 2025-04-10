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
    public partial class LoginForm: Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Username dan Password harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AplikasiWindows\Aplikasi Zakat\Aplikasi Zakat\dbZakata.mdf;Integrated Security=True"))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM tbAmil WHERE Username = @username AND Password = @password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            string namaQuery = "SELECT NamaAmil FROM tbAmil WHERE Username = @username";
                            using (SqlCommand namaCmd = new SqlCommand(namaQuery, conn))
                            {
                                namaCmd.Parameters.AddWithValue("@username", username);
                                string namaAmil = (string)namaCmd.ExecuteScalar();

                                MessageBox.Show("Login berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                MainForm main = new MainForm();
                                main.NamaAmil = namaAmil;
                                main.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Username atau password salah.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan koneksi: " + ex.Message);
                }
            }
        }
    }
}
