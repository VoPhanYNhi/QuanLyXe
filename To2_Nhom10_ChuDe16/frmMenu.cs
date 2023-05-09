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

namespace To2_Nhom10_ChuDe16
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection();
        DataSet ds = new DataSet("dsDANGNHAP");
        SqlDataAdapter daDangNhap;

        private void frmMenu_Load(object sender, EventArgs e)
        {
            palGiaoDien.Visible = true;
            palQuanLy.Visible = false;
            grpMenu.Visible = false;

            //Ket noi dang nhap
            conn.ConnectionString = KetNoi.ChuoiKetNoi();
            string sQueryDangNhap = @"Select * from DANGNHAP ";
            daDangNhap = new SqlDataAdapter(sQueryDangNhap, conn);
            daDangNhap.Fill(ds, "tblDSDangNhap");
        }

        private void btnThueXe_Click(object sender, EventArgs e)
        {
            Form ThueXe = new frmThueXe();
            this.Visible = false;
            ThueXe.ShowDialog();
            this.Visible = true;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            Form ThanhToan = new frmThanhToan();
            this.Visible = false;
            ThanhToan.ShowDialog();
            this.Visible = true;
        }

        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            palGiaoDien.Visible = false;
            palQuanLy.Visible = true;
        }

        private void btnQLLoaiXe_Click(object sender, EventArgs e)
        {
            Form f2 = new frmQLLoaiXe();
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }

        private void btnQLXe_Click(object sender, EventArgs e)
        {
            Form f2 = new frmQLXe();
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }

        private void btnQLTaiXe_Click(object sender, EventArgs e)
        {
            Form f2 = new frmQLTaiXe();
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }

        private void btnQLNhanVien_Click(object sender, EventArgs e)
        {
            Form f2 = new frmQLNhanVien();
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }

        private void btnQLHopDong_Click(object sender, EventArgs e)
        {
            Form f2 = new frmQLHopDong();
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }

        private void btnQLHopDongCT_Click(object sender, EventArgs e)
        {
            Form f2 = new frmQLHopDongChiTiet();
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }

        private void btnQLThanhToan_Click(object sender, EventArgs e)
        {
            Form f2 = new frmQLThanhToan();
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }

        private void btnQLBienBan_Click(object sender, EventArgs e)
        {
            Form f2 = new frmQLBienBanNhanXe();
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }

        private void btnQLKhachHang_Click(object sender, EventArgs e)
        {
            Form f2 = new frmQLKhachHang();
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            palQuanLy.Visible = false;
            palGiaoDien.Visible = true;            
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            foreach(DataRow r in ds.Tables["tblDSDangNhap"].Rows)
            {
                if (r["TenDangNhap"].ToString() == txtUser.Text)
                {
                    if (r["MatKhau"].ToString() == txtPass.Text)
                    {
                        grpMenu.Visible = true;
                        if (r["LoaiTaiKhoan"].ToString() == "admin")
                        {
                            btnDangXuat.Enabled = true;
                            btnThanhToan.Enabled = true;
                            btnThueXe.Enabled = true;
                            btnQuanLy.Enabled = true;
                            btnThongKe.Enabled = true;
                            grbDangNhap.Enabled = false;
                            return;
                        }
                        else
                        {
                            btnDangXuat.Enabled = true;
                            btnThanhToan.Enabled = true;
                            btnThueXe.Enabled = true;
                            btnQuanLy.Enabled = false;
                            btnThongKe.Enabled = false;
                            grbDangNhap.Enabled = false;
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không đúng!", "Thông báo");
                        txtPass.Clear();
                        txtPass.Focus();
                        return;
                    }
                }
            }
            MessageBox.Show("Tên đăng nhập không đúng!", "Thông báo");
            txtPass.Clear();
            txtUser.Clear();
            txtUser.Focus();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Đăng xuất????", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                txtPass.Clear();
                txtUser.Clear();

                grbDangNhap.Enabled = true;
                btnDangXuat.Enabled = false;
                grpMenu.Visible = false;
            }
            
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            Form f2 = new frmThongKe();
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }

        private void lbThem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form f2 = new frmTaoTaiKhoan();
            f2.ShowDialog();
            frmMenu_Load(sender, e);
        }
    }
}
