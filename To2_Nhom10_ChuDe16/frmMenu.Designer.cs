
namespace To2_Nhom10_ChuDe16
{
    partial class frmMenu
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
            this.palGiaoDien = new System.Windows.Forms.Panel();
            this.grbDangNhap = new System.Windows.Forms.GroupBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpMenu = new System.Windows.Forms.GroupBox();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnThueXe = new System.Windows.Forms.Button();
            this.btnQuanLy = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.palQuanLy = new System.Windows.Forms.Panel();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.btnQLKhachHang = new System.Windows.Forms.Button();
            this.btnQLHopDong = new System.Windows.Forms.Button();
            this.btnQLThanhToan = new System.Windows.Forms.Button();
            this.btnQLTaiXe = new System.Windows.Forms.Button();
            this.btnQLLoaiXe = new System.Windows.Forms.Button();
            this.btnQLHopDongCT = new System.Windows.Forms.Button();
            this.btnQLBienBan = new System.Windows.Forms.Button();
            this.btnQLNhanVien = new System.Windows.Forms.Button();
            this.btnQLXe = new System.Windows.Forms.Button();
            this.lbThem = new System.Windows.Forms.LinkLabel();
            this.palGiaoDien.SuspendLayout();
            this.grbDangNhap.SuspendLayout();
            this.grpMenu.SuspendLayout();
            this.palQuanLy.SuspendLayout();
            this.SuspendLayout();
            // 
            // palGiaoDien
            // 
            this.palGiaoDien.BackColor = System.Drawing.Color.Transparent;
            this.palGiaoDien.Controls.Add(this.grbDangNhap);
            this.palGiaoDien.Controls.Add(this.grpMenu);
            this.palGiaoDien.Location = new System.Drawing.Point(116, 176);
            this.palGiaoDien.Name = "palGiaoDien";
            this.palGiaoDien.Size = new System.Drawing.Size(672, 353);
            this.palGiaoDien.TabIndex = 0;
            // 
            // grbDangNhap
            // 
            this.grbDangNhap.Controls.Add(this.lbThem);
            this.grbDangNhap.Controls.Add(this.txtPass);
            this.grbDangNhap.Controls.Add(this.txtUser);
            this.grbDangNhap.Controls.Add(this.btnDangNhap);
            this.grbDangNhap.Controls.Add(this.label2);
            this.grbDangNhap.Controls.Add(this.label1);
            this.grbDangNhap.Location = new System.Drawing.Point(42, 65);
            this.grbDangNhap.Name = "grbDangNhap";
            this.grbDangNhap.Size = new System.Drawing.Size(285, 207);
            this.grbDangNhap.TabIndex = 41;
            this.grbDangNhap.TabStop = false;
            this.grbDangNhap.Text = "Đăng Nhập";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(81, 83);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(173, 26);
            this.txtPass.TabIndex = 43;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(81, 32);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(173, 26);
            this.txtUser.TabIndex = 42;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.Orange;
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangNhap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDangNhap.Location = new System.Drawing.Point(81, 130);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(129, 32);
            this.btnDangNhap.TabIndex = 41;
            this.btnDangNhap.Text = "Đăng Nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "User:";
            // 
            // grpMenu
            // 
            this.grpMenu.Controls.Add(this.btnThongKe);
            this.grpMenu.Controls.Add(this.btnDangXuat);
            this.grpMenu.Controls.Add(this.btnThueXe);
            this.grpMenu.Controls.Add(this.btnQuanLy);
            this.grpMenu.Controls.Add(this.btnThanhToan);
            this.grpMenu.Location = new System.Drawing.Point(361, 3);
            this.grpMenu.Name = "grpMenu";
            this.grpMenu.Size = new System.Drawing.Size(292, 311);
            this.grpMenu.TabIndex = 40;
            this.grpMenu.TabStop = false;
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.Orange;
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThongKe.Location = new System.Drawing.Point(90, 195);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(145, 45);
            this.btnThongKe.TabIndex = 41;
            this.btnThongKe.Text = "Thống Kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.Orange;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDangXuat.Location = new System.Drawing.Point(90, 251);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(145, 45);
            this.btnDangXuat.TabIndex = 40;
            this.btnDangXuat.Text = "Đăng Xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnThueXe
            // 
            this.btnThueXe.BackColor = System.Drawing.Color.Orange;
            this.btnThueXe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThueXe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThueXe.Location = new System.Drawing.Point(90, 25);
            this.btnThueXe.Name = "btnThueXe";
            this.btnThueXe.Size = new System.Drawing.Size(145, 45);
            this.btnThueXe.TabIndex = 37;
            this.btnThueXe.Text = "Thuê Xe";
            this.btnThueXe.UseVisualStyleBackColor = false;
            this.btnThueXe.Click += new System.EventHandler(this.btnThueXe_Click);
            // 
            // btnQuanLy
            // 
            this.btnQuanLy.BackColor = System.Drawing.Color.Orange;
            this.btnQuanLy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnQuanLy.Location = new System.Drawing.Point(90, 137);
            this.btnQuanLy.Name = "btnQuanLy";
            this.btnQuanLy.Size = new System.Drawing.Size(145, 45);
            this.btnQuanLy.TabIndex = 39;
            this.btnQuanLy.Text = "Quản Lý";
            this.btnQuanLy.UseVisualStyleBackColor = false;
            this.btnQuanLy.Click += new System.EventHandler(this.btnQuanLy_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.Orange;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThanhToan.Location = new System.Drawing.Point(90, 81);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(145, 45);
            this.btnThanhToan.TabIndex = 38;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // palQuanLy
            // 
            this.palQuanLy.BackColor = System.Drawing.Color.Transparent;
            this.palQuanLy.Controls.Add(this.btnQuayLai);
            this.palQuanLy.Controls.Add(this.btnQLKhachHang);
            this.palQuanLy.Controls.Add(this.btnQLHopDong);
            this.palQuanLy.Controls.Add(this.btnQLThanhToan);
            this.palQuanLy.Controls.Add(this.btnQLTaiXe);
            this.palQuanLy.Controls.Add(this.btnQLLoaiXe);
            this.palQuanLy.Controls.Add(this.btnQLHopDongCT);
            this.palQuanLy.Controls.Add(this.btnQLBienBan);
            this.palQuanLy.Controls.Add(this.btnQLNhanVien);
            this.palQuanLy.Controls.Add(this.btnQLXe);
            this.palQuanLy.Location = new System.Drawing.Point(93, 161);
            this.palQuanLy.Name = "palQuanLy";
            this.palQuanLy.Size = new System.Drawing.Size(695, 377);
            this.palQuanLy.TabIndex = 40;
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.BackColor = System.Drawing.Color.Orange;
            this.btnQuayLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuayLai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnQuayLai.Location = new System.Drawing.Point(384, 280);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(235, 60);
            this.btnQuayLai.TabIndex = 52;
            this.btnQuayLai.Text = "Quay Lại";
            this.btnQuayLai.UseVisualStyleBackColor = false;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // btnQLKhachHang
            // 
            this.btnQLKhachHang.BackColor = System.Drawing.Color.Orange;
            this.btnQLKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLKhachHang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnQLKhachHang.Location = new System.Drawing.Point(65, 280);
            this.btnQLKhachHang.Name = "btnQLKhachHang";
            this.btnQLKhachHang.Size = new System.Drawing.Size(235, 60);
            this.btnQLKhachHang.TabIndex = 51;
            this.btnQLKhachHang.Text = "Quản Lý Khách Hàng";
            this.btnQLKhachHang.UseVisualStyleBackColor = false;
            this.btnQLKhachHang.Click += new System.EventHandler(this.btnQLKhachHang_Click);
            // 
            // btnQLHopDong
            // 
            this.btnQLHopDong.BackColor = System.Drawing.Color.Orange;
            this.btnQLHopDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLHopDong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnQLHopDong.Location = new System.Drawing.Point(65, 147);
            this.btnQLHopDong.Name = "btnQLHopDong";
            this.btnQLHopDong.Size = new System.Drawing.Size(235, 60);
            this.btnQLHopDong.TabIndex = 50;
            this.btnQLHopDong.Text = "Quản Lý Hợp Đồng";
            this.btnQLHopDong.UseVisualStyleBackColor = false;
            this.btnQLHopDong.Click += new System.EventHandler(this.btnQLHopDong_Click);
            // 
            // btnQLThanhToan
            // 
            this.btnQLThanhToan.BackColor = System.Drawing.Color.Orange;
            this.btnQLThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLThanhToan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnQLThanhToan.Location = new System.Drawing.Point(65, 213);
            this.btnQLThanhToan.Name = "btnQLThanhToan";
            this.btnQLThanhToan.Size = new System.Drawing.Size(235, 60);
            this.btnQLThanhToan.TabIndex = 49;
            this.btnQLThanhToan.Text = "Quản Lý Thanh Toán";
            this.btnQLThanhToan.UseVisualStyleBackColor = false;
            this.btnQLThanhToan.Click += new System.EventHandler(this.btnQLThanhToan_Click);
            // 
            // btnQLTaiXe
            // 
            this.btnQLTaiXe.BackColor = System.Drawing.Color.Orange;
            this.btnQLTaiXe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLTaiXe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnQLTaiXe.Location = new System.Drawing.Point(65, 81);
            this.btnQLTaiXe.Name = "btnQLTaiXe";
            this.btnQLTaiXe.Size = new System.Drawing.Size(235, 60);
            this.btnQLTaiXe.TabIndex = 48;
            this.btnQLTaiXe.Text = "Quản Lý Tài Xế";
            this.btnQLTaiXe.UseVisualStyleBackColor = false;
            this.btnQLTaiXe.Click += new System.EventHandler(this.btnQLTaiXe_Click);
            // 
            // btnQLLoaiXe
            // 
            this.btnQLLoaiXe.BackColor = System.Drawing.Color.Orange;
            this.btnQLLoaiXe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLLoaiXe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnQLLoaiXe.Location = new System.Drawing.Point(65, 14);
            this.btnQLLoaiXe.Name = "btnQLLoaiXe";
            this.btnQLLoaiXe.Size = new System.Drawing.Size(235, 60);
            this.btnQLLoaiXe.TabIndex = 47;
            this.btnQLLoaiXe.Text = "Quản Lý Loại Xe";
            this.btnQLLoaiXe.UseVisualStyleBackColor = false;
            this.btnQLLoaiXe.Click += new System.EventHandler(this.btnQLLoaiXe_Click);
            // 
            // btnQLHopDongCT
            // 
            this.btnQLHopDongCT.BackColor = System.Drawing.Color.Orange;
            this.btnQLHopDongCT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLHopDongCT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnQLHopDongCT.Location = new System.Drawing.Point(384, 147);
            this.btnQLHopDongCT.Name = "btnQLHopDongCT";
            this.btnQLHopDongCT.Size = new System.Drawing.Size(235, 60);
            this.btnQLHopDongCT.TabIndex = 46;
            this.btnQLHopDongCT.Text = "Quản Lý Hợp Đồng Chi Tiết";
            this.btnQLHopDongCT.UseVisualStyleBackColor = false;
            this.btnQLHopDongCT.Click += new System.EventHandler(this.btnQLHopDongCT_Click);
            // 
            // btnQLBienBan
            // 
            this.btnQLBienBan.BackColor = System.Drawing.Color.Orange;
            this.btnQLBienBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLBienBan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnQLBienBan.Location = new System.Drawing.Point(384, 213);
            this.btnQLBienBan.Name = "btnQLBienBan";
            this.btnQLBienBan.Size = new System.Drawing.Size(235, 60);
            this.btnQLBienBan.TabIndex = 42;
            this.btnQLBienBan.Text = "Quản Lý Biên Bản Nhận Xe";
            this.btnQLBienBan.UseVisualStyleBackColor = false;
            this.btnQLBienBan.Click += new System.EventHandler(this.btnQLBienBan_Click);
            // 
            // btnQLNhanVien
            // 
            this.btnQLNhanVien.BackColor = System.Drawing.Color.Orange;
            this.btnQLNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLNhanVien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnQLNhanVien.Location = new System.Drawing.Point(384, 81);
            this.btnQLNhanVien.Name = "btnQLNhanVien";
            this.btnQLNhanVien.Size = new System.Drawing.Size(235, 60);
            this.btnQLNhanVien.TabIndex = 41;
            this.btnQLNhanVien.Text = "Quản Lý Nhân Viên";
            this.btnQLNhanVien.UseVisualStyleBackColor = false;
            this.btnQLNhanVien.Click += new System.EventHandler(this.btnQLNhanVien_Click);
            // 
            // btnQLXe
            // 
            this.btnQLXe.BackColor = System.Drawing.Color.Orange;
            this.btnQLXe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLXe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnQLXe.Location = new System.Drawing.Point(384, 14);
            this.btnQLXe.Name = "btnQLXe";
            this.btnQLXe.Size = new System.Drawing.Size(235, 60);
            this.btnQLXe.TabIndex = 38;
            this.btnQLXe.Text = "Quản Lý Xe";
            this.btnQLXe.UseVisualStyleBackColor = false;
            this.btnQLXe.Click += new System.EventHandler(this.btnQLXe_Click);
            // 
            // lbThem
            // 
            this.lbThem.AutoSize = true;
            this.lbThem.Location = new System.Drawing.Point(90, 178);
            this.lbThem.Name = "lbThem";
            this.lbThem.Size = new System.Drawing.Size(109, 19);
            this.lbThem.TabIndex = 44;
            this.lbThem.TabStop = true;
            this.lbThem.Text = "Thêm tài khoản?";
            this.lbThem.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbThem_LinkClicked);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::To2_Nhom10_ChuDe16.Properties.Resources.QLXE;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.palGiaoDien);
            this.Controls.Add(this.palQuanLy);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMenu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MENU";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.palGiaoDien.ResumeLayout(false);
            this.grbDangNhap.ResumeLayout(false);
            this.grbDangNhap.PerformLayout();
            this.grpMenu.ResumeLayout(false);
            this.palQuanLy.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel palGiaoDien;
        private System.Windows.Forms.Button btnThueXe;
        private System.Windows.Forms.Button btnQuanLy;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Panel palQuanLy;
        private System.Windows.Forms.Button btnQuayLai;
        private System.Windows.Forms.Button btnQLKhachHang;
        private System.Windows.Forms.Button btnQLHopDong;
        private System.Windows.Forms.Button btnQLThanhToan;
        private System.Windows.Forms.Button btnQLTaiXe;
        private System.Windows.Forms.Button btnQLLoaiXe;
        private System.Windows.Forms.Button btnQLHopDongCT;
        private System.Windows.Forms.Button btnQLBienBan;
        private System.Windows.Forms.Button btnQLNhanVien;
        private System.Windows.Forms.Button btnQLXe;
        private System.Windows.Forms.GroupBox grbDangNhap;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpMenu;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.LinkLabel lbThem;
    }
}