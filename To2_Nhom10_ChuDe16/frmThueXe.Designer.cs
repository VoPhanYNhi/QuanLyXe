
namespace To2_Nhom10_ChuDe16
{
    partial class frmThueXe
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnThemKH = new System.Windows.Forms.Button();
            this.cboTenHD = new System.Windows.Forms.ComboBox();
            this.btnThemHD = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpNgayTra = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayThue = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboTenTX = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTenXe = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radKhongThue = new System.Windows.Forms.RadioButton();
            this.radThue = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgDSHopDongChiTiet = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDSHopDongChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(95, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn hợp đồng cần thuê:";
            // 
            // btnThemKH
            // 
            this.btnThemKH.BackColor = System.Drawing.Color.Orange;
            this.btnThemKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemKH.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThemKH.Location = new System.Drawing.Point(640, 176);
            this.btnThemKH.Name = "btnThemKH";
            this.btnThemKH.Size = new System.Drawing.Size(143, 34);
            this.btnThemKH.TabIndex = 38;
            this.btnThemKH.Text = "Thêm Khách Hàng";
            this.btnThemKH.UseVisualStyleBackColor = false;
            this.btnThemKH.Click += new System.EventHandler(this.btnThemKH_Click);
            // 
            // cboTenHD
            // 
            this.cboTenHD.FormattingEnabled = true;
            this.cboTenHD.Location = new System.Drawing.Point(261, 181);
            this.cboTenHD.Name = "cboTenHD";
            this.cboTenHD.Size = new System.Drawing.Size(189, 27);
            this.cboTenHD.TabIndex = 39;
//            this.cboTenHD.SelectedIndexChanged += new System.EventHandler(this.cboTenHD_SelectedIndexChanged);
            // 
            // btnThemHD
            // 
            this.btnThemHD.BackColor = System.Drawing.Color.Orange;
            this.btnThemHD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemHD.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThemHD.Location = new System.Drawing.Point(475, 176);
            this.btnThemHD.Name = "btnThemHD";
            this.btnThemHD.Size = new System.Drawing.Size(143, 34);
            this.btnThemHD.TabIndex = 40;
            this.btnThemHD.Text = "Thêm Hợp Đồng";
            this.btnThemHD.UseVisualStyleBackColor = false;
            this.btnThemHD.Click += new System.EventHandler(this.btnThemHD_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dtpNgayTra);
            this.groupBox1.Controls.Add(this.dtpNgayThue);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboTenTX);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboTenXe);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(99, 226);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 221);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            // 
            // dtpNgayTra
            // 
            this.dtpNgayTra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayTra.Location = new System.Drawing.Point(138, 172);
            this.dtpNgayTra.Name = "dtpNgayTra";
            this.dtpNgayTra.Size = new System.Drawing.Size(189, 26);
            this.dtpNgayTra.TabIndex = 49;
            // 
            // dtpNgayThue
            // 
            this.dtpNgayThue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayThue.Location = new System.Drawing.Point(138, 137);
            this.dtpNgayThue.Name = "dtpNgayThue";
            this.dtpNgayThue.Size = new System.Drawing.Size(189, 26);
            this.dtpNgayThue.TabIndex = 48;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(7, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 19);
            this.label5.TabIndex = 47;
            this.label5.Text = "Chọn Ngày Thuê:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(20, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 19);
            this.label4.TabIndex = 46;
            this.label4.Text = "Chọn Ngày Trả";
            // 
            // cboTenTX
            // 
            this.cboTenTX.FormattingEnabled = true;
            this.cboTenTX.Location = new System.Drawing.Point(138, 101);
            this.cboTenTX.Name = "cboTenTX";
            this.cboTenTX.Size = new System.Drawing.Size(189, 27);
            this.cboTenTX.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(37, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 19);
            this.label3.TabIndex = 44;
            this.label3.Text = "Chọn Tài xế:";
            // 
            // cboTenXe
            // 
            this.cboTenXe.FormattingEnabled = true;
            this.cboTenXe.Location = new System.Drawing.Point(138, 19);
            this.cboTenXe.Name = "cboTenXe";
            this.cboTenXe.Size = new System.Drawing.Size(189, 27);
            this.cboTenXe.TabIndex = 42;
//            this.cboTenXe.SelectedIndexChanged += new System.EventHandler(this.cboTenXe_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 19);
            this.label2.TabIndex = 42;
            this.label2.Text = "Chọn xe cần thuê:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.radKhongThue);
            this.groupBox2.Controls.Add(this.radThue);
            this.groupBox2.Location = new System.Drawing.Point(10, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(317, 47);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            // 
            // radKhongThue
            // 
            this.radKhongThue.AutoSize = true;
            this.radKhongThue.Location = new System.Drawing.Point(152, 18);
            this.radKhongThue.Name = "radKhongThue";
            this.radKhongThue.Size = new System.Drawing.Size(138, 23);
            this.radKhongThue.TabIndex = 1;
            this.radKhongThue.TabStop = true;
            this.radKhongThue.Text = "Không thuê Tài xế";
            this.radKhongThue.UseVisualStyleBackColor = true;
            // 
            // radThue
            // 
            this.radThue.AutoSize = true;
            this.radThue.Location = new System.Drawing.Point(7, 18);
            this.radThue.Name = "radThue";
            this.radThue.Size = new System.Drawing.Size(98, 23);
            this.radThue.TabIndex = 0;
            this.radThue.TabStop = true;
            this.radThue.Text = "Thuê Tài xế";
            this.radThue.UseVisualStyleBackColor = true;
            this.radThue.CheckedChanged += new System.EventHandler(this.radThue_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Orange;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button1.Location = new System.Drawing.Point(557, 473);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 34);
            this.button1.TabIndex = 42;
            this.button1.Text = "Lưu Thông Tin";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.dgDSHopDongChiTiet);
            this.groupBox3.Location = new System.Drawing.Point(475, 236);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(308, 211);
            this.groupBox3.TabIndex = 43;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin hợp đồng chi tiết";
            // 
            // dgDSHopDongChiTiet
            // 
            this.dgDSHopDongChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDSHopDongChiTiet.Location = new System.Drawing.Point(6, 25);
            this.dgDSHopDongChiTiet.Name = "dgDSHopDongChiTiet";
            this.dgDSHopDongChiTiet.Size = new System.Drawing.Size(296, 162);
            this.dgDSHopDongChiTiet.TabIndex = 0;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Orange;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThem.Location = new System.Drawing.Point(187, 473);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(143, 34);
            this.btnThem.TabIndex = 44;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // frmThueXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::To2_Nhom10_ChuDe16.Properties.Resources.QLXE;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnThemHD);
            this.Controls.Add(this.cboTenHD);
            this.Controls.Add(this.btnThemKH);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmThueXe";
            this.Text = "Thuê xe";
            this.Load += new System.EventHandler(this.frmThueXe_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDSHopDongChiTiet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThemKH;
        private System.Windows.Forms.ComboBox cboTenHD;
        private System.Windows.Forms.Button btnThemHD;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpNgayTra;
        private System.Windows.Forms.DateTimePicker dtpNgayThue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboTenTX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboTenXe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radKhongThue;
        private System.Windows.Forms.RadioButton radThue;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgDSHopDongChiTiet;
        private System.Windows.Forms.Button btnThem;
    }
}