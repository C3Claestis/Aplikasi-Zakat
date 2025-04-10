namespace Aplikasi_Zakat
{
    partial class LaporanForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaporanForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCetak = new Guna.UI2.WinForms.Guna2Button();
            this.btnTampilLaporan = new Guna.UI2.WinForms.Guna2Button();
            this.cmbJenisZakat = new System.Windows.Forms.ComboBox();
            this.cmbJenisTransaksi = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateAkhir = new System.Windows.Forms.DateTimePicker();
            this.dateAwal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLaporan = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTotal = new System.Windows.Forms.Label();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.btnCetak);
            this.panel1.Controls.Add(this.btnTampilLaporan);
            this.panel1.Controls.Add(this.cmbJenisZakat);
            this.panel1.Controls.Add(this.cmbJenisTransaksi);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dateAkhir);
            this.panel1.Controls.Add(this.dateAwal);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 175);
            this.panel1.TabIndex = 0;
            // 
            // btnCetak
            // 
            this.btnCetak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnCetak.BorderRadius = 20;
            this.btnCetak.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCetak.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCetak.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCetak.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCetak.FillColor = System.Drawing.Color.ForestGreen;
            this.btnCetak.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCetak.ForeColor = System.Drawing.Color.White;
            this.btnCetak.Location = new System.Drawing.Point(730, 114);
            this.btnCetak.Name = "btnCetak";
            this.btnCetak.Size = new System.Drawing.Size(136, 45);
            this.btnCetak.TabIndex = 12;
            this.btnCetak.Text = "CETAK";
            this.btnCetak.Click += new System.EventHandler(this.btnCetak_Click);
            // 
            // btnTampilLaporan
            // 
            this.btnTampilLaporan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnTampilLaporan.BorderRadius = 20;
            this.btnTampilLaporan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTampilLaporan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTampilLaporan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTampilLaporan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTampilLaporan.FillColor = System.Drawing.Color.ForestGreen;
            this.btnTampilLaporan.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTampilLaporan.ForeColor = System.Drawing.Color.White;
            this.btnTampilLaporan.Location = new System.Drawing.Point(690, 55);
            this.btnTampilLaporan.Name = "btnTampilLaporan";
            this.btnTampilLaporan.Size = new System.Drawing.Size(216, 45);
            this.btnTampilLaporan.TabIndex = 11;
            this.btnTampilLaporan.Text = "TAMPILKAN LAPORAN";
            this.btnTampilLaporan.Click += new System.EventHandler(this.btnTampilLaporan_Click);
            // 
            // cmbJenisZakat
            // 
            this.cmbJenisZakat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cmbJenisZakat.FormattingEnabled = true;
            this.cmbJenisZakat.Items.AddRange(new object[] {
            "Semua",
            "Zakat Fitrah",
            "Zakat Maal",
            "Shodaqoh",
            "Infaq",
            "Fidyah"});
            this.cmbJenisZakat.Location = new System.Drawing.Point(357, 129);
            this.cmbJenisZakat.Name = "cmbJenisZakat";
            this.cmbJenisZakat.Size = new System.Drawing.Size(286, 33);
            this.cmbJenisZakat.TabIndex = 10;
            // 
            // cmbJenisTransaksi
            // 
            this.cmbJenisTransaksi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cmbJenisTransaksi.FormattingEnabled = true;
            this.cmbJenisTransaksi.Items.AddRange(new object[] {
            "Semua",
            "Penerimaan",
            "Distribusi"});
            this.cmbJenisTransaksi.Location = new System.Drawing.Point(357, 91);
            this.cmbJenisTransaksi.Name = "cmbJenisTransaksi";
            this.cmbJenisTransaksi.Size = new System.Drawing.Size(286, 33);
            this.cmbJenisTransaksi.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label6.Location = new System.Drawing.Point(214, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 25);
            this.label6.TabIndex = 8;
            this.label6.Text = "Jenis Zakat : ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label5.Location = new System.Drawing.Point(214, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Jenis Transaksi : ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateAkhir
            // 
            this.dateAkhir.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateAkhir.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateAkhir.Location = new System.Drawing.Point(521, 42);
            this.dateAkhir.Name = "dateAkhir";
            this.dateAkhir.Size = new System.Drawing.Size(122, 31);
            this.dateAkhir.TabIndex = 3;
            // 
            // dateAwal
            // 
            this.dateAwal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateAwal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateAwal.Location = new System.Drawing.Point(357, 42);
            this.dateAwal.Name = "dateAwal";
            this.dateAwal.Size = new System.Drawing.Size(122, 31);
            this.dateAwal.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.Location = new System.Drawing.Point(521, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tanggal Akhir";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.Location = new System.Drawing.Point(0, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1004, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "s/d";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.Location = new System.Drawing.Point(357, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tanggal Awal";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter Laporan :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvLaporan
            // 
            this.dgvLaporan.AllowUserToAddRows = false;
            this.dgvLaporan.AllowUserToResizeColumns = false;
            this.dgvLaporan.AllowUserToResizeRows = false;
            this.dgvLaporan.BackgroundColor = System.Drawing.Color.White;
            this.dgvLaporan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Turquoise;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.MediumAquamarine;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLaporan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLaporan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLaporan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.MediumAquamarine;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLaporan.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLaporan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLaporan.EnableHeadersVisualStyles = false;
            this.dgvLaporan.Location = new System.Drawing.Point(0, 175);
            this.dgvLaporan.Name = "dgvLaporan";
            this.dgvLaporan.RowHeadersVisible = false;
            this.dgvLaporan.RowHeadersWidth = 51;
            this.dgvLaporan.RowTemplate.Height = 24;
            this.dgvLaporan.Size = new System.Drawing.Size(1004, 331);
            this.dgvLaporan.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel2.Controls.Add(this.txtTotal);
            this.panel2.Controls.Add(this.guna2CirclePictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 456);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1004, 50);
            this.panel2.TabIndex = 2;
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(63, 16);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(408, 25);
            this.txtTotal.TabIndex = 11;
            this.txtTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.guna2CirclePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox1.Image")));
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(17, 5);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(40, 40);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox1.TabIndex = 10;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "No";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 65;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "Tanggal";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 102;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "Jenis";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 78;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.HeaderText = "Muzzaki";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 105;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.HeaderText = "Mustahiq";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 115;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column6.HeaderText = "Zakat";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 84;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column7.HeaderText = "Jumlah";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            // 
            // LaporanForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1004, 506);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvLaporan);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LaporanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LaporanForm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvLaporan;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateAwal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateAkhir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private System.Windows.Forms.ComboBox cmbJenisZakat;
        private System.Windows.Forms.ComboBox cmbJenisTransaksi;
        private Guna.UI2.WinForms.Guna2Button btnCetak;
        private Guna.UI2.WinForms.Guna2Button btnTampilLaporan;
        private System.Windows.Forms.Label txtTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}