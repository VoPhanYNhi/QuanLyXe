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
    public partial class frmQLKhachHang : Form
    {
        public frmQLKhachHang()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection();
        DataSet ds = new DataSet("dsKhachHang");
        SqlDataAdapter daKhachHang;

        private void frmQLKhachHang_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = KetNoi.ChuoiKetNoi();

            HienThiDaTaGrid();

            //Command Them KHACH HANG
            string sThemKH = @"insert into KHACHHANG values(@makh,@hoten,@ngaysinh,@gioitinh,@sdt,@cmnd,@diachi)";
            SqlCommand cmThemKH = new SqlCommand(sThemKH, conn);
            cmThemKH.Parameters.Add("@makh", SqlDbType.NVarChar, 10, "MaKH");
            cmThemKH.Parameters.Add("@hoten", SqlDbType.NVarChar, 50, "HoTen");
            cmThemKH.Parameters.Add("@ngaysinh", SqlDbType.Date, 10, "NgaySinh");
            cmThemKH.Parameters.Add("@gioitinh", SqlDbType.NVarChar, 10, "GioiTinh");
            cmThemKH.Parameters.Add("@sdt", SqlDbType.Char, 10, "SDT");
            cmThemKH.Parameters.Add("@cmnd", SqlDbType.Char, 9, "CMND");
            cmThemKH.Parameters.Add("@diachi", SqlDbType.NVarChar, 100, "DiaChi");

            daKhachHang.InsertCommand = cmThemKH;

            //Command Sua KHACHHANG
            string sSuaKH = @"update KHACHHANG set HoTen=@hoten, NgaySinh=@ngaysinh, GioiTinh=@gioitinh, SDT=@sdt, CMND=@cmnd, DiaChi=@diachi where MaKH=@maKH";
            SqlCommand cmSuaKH = new SqlCommand(sSuaKH, conn);
            cmSuaKH.Parameters.Add("@makh", SqlDbType.NVarChar, 10, "MaKH");
            cmSuaKH.Parameters.Add("@hoten", SqlDbType.NVarChar, 50, "HoTen");
            cmSuaKH.Parameters.Add("@ngaysinh", SqlDbType.Date, 10, "NgaySinh");
            cmSuaKH.Parameters.Add("@gioitinh", SqlDbType.NVarChar, 10, "GioiTinh");
            cmSuaKH.Parameters.Add("@sdt", SqlDbType.Char, 10, "SDT");
            cmSuaKH.Parameters.Add("@cmnd", SqlDbType.Char, 9, "CMND");
            cmSuaKH.Parameters.Add("@diachi", SqlDbType.NVarChar, 100, "DiaChi");

            daKhachHang.UpdateCommand = cmSuaKH;

            //Command Xoa NhanVien
            string sXoaKH = @"delete from KHACHHANG where MaKH=@makh";
            SqlCommand cmXoaKH = new SqlCommand(sXoaKH, conn);
            cmXoaKH.Parameters.Add("@makh", SqlDbType.NVarChar, 10, "MaKH");

            daKhachHang.DeleteCommand = cmXoaKH;

            //Các thuoc tính button
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        public void HienThiDaTaGrid()
        {
            string sQueryKhachHang = @"select *from KHACHHANG";
            daKhachHang = new SqlDataAdapter(sQueryKhachHang, conn); ;
            daKhachHang.Fill(ds, "tblDSKhachHang");
            dgDSKhachHang.DataSource = ds.Tables["tblDSKhachHang"];

            dgDSKhachHang.Columns["MaKH"].HeaderText = "Mã Khách Hàng";
            dgDSKhachHang.Columns["MaKH"].Width = 100;
            dgDSKhachHang.Columns["HoTen"].HeaderText = "Họ Tên";
            dgDSKhachHang.Columns["HoTen"].Width = 200;
            dgDSKhachHang.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            dgDSKhachHang.Columns["NgaySinh"].Width = 80;
            dgDSKhachHang.Columns["GioiTinh"].HeaderText = "Giới Tính";
            dgDSKhachHang.Columns["GioiTinh"].Width = 50;
            dgDSKhachHang.Columns["SDT"].HeaderText = "Số Điện Thoại";
            dgDSKhachHang.Columns["SDT"].Width = 100;
            dgDSKhachHang.Columns["CMND"].HeaderText = "CMND";
            dgDSKhachHang.Columns["CMND"].Width = 100;
            dgDSKhachHang.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dgDSKhachHang.Columns["DiaChi"].Width = 250;
        }

        private void dgDSKhachHang_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgDSKhachHang.SelectedRows[0];
            txtMaKH.Text = dr.Cells["MaKH"].Value.ToString();
            txtHoTen.Text = dr.Cells["HoTen"].Value.ToString();
            dtpNgaySinh.Text = dr.Cells["NgaySinh"].Value.ToString();

            if (dr.Cells["GioiTinh"].Value.ToString() == "Nam")
                radNam.Checked = true;
            else
                radNu.Checked = true;

            txtSDT.Text = dr.Cells["SDT"].Value.ToString();
            txtCMND.Text = dr.Cells["CMND"].Value.ToString();
            txtDiaChi.Text = dr.Cells["DiaChi"].Value.ToString();
        }

        //Ham kiem tra
        public bool KiemTra()
        {
            if (dtpNgaySinh.Value > DateTime.Parse("31/12/2001"))
            {
                MessageBox.Show("Ngày sinh không thể lớn hơn 31/12/2001", "Thông báo");
                return false;
            }
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Nhập mã Khách hàng", "Thông báo");
                txtMaKH.Focus();
                return false;
            }
            if (txtHoTen.Text == "")
            {
                MessageBox.Show("Nhập họ tên Khách hàng", "Thông báo");
                txtHoTen.Focus();
                return false;
            }
            if (txtSDT.Text.Length!=10)
            {
                MessageBox.Show("Nhập số diện thoại Khách hàng", "Thông báo");
                txtSDT.Focus();
                return false;
            }
            if (txtCMND.Text.Length != 9)
            {
                MessageBox.Show("Nhập CMND Khách hàng", "Thông báo");
                txtCMND.Focus();
                return false;
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Nhập Địa chỉ Khách hàng", "Thông báo");
                txtDiaChi.Focus();
                return false;
            } 
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                //Kiem tra ma trung trong DataGridView
                DataGridViewRow dr;
                for (int i = 0; i < dgDSKhachHang.RowCount - 1; i++)
                {
                    dr = dgDSKhachHang.Rows[i];
                    if (txtMaKH.Text == dr.Cells["MaKH"].Value.ToString())
                    {
                        MessageBox.Show("Mã vừa nhập đã bị trùng!!!!", "Thông báo");
                        return;
                    }
                }

                DataRow row = ds.Tables["tblDSKhachHang"].NewRow();
                row["MaKH"] = txtMaKH.Text;
                row["HoTen"] = txtHoTen.Text;
                row["NgaySinh"] = dtpNgaySinh.Text;
                if (radNam.Checked == true)
                {
                    row["GioiTinh"] = "Nam";
                }
                else
                {
                    row["GioiTinh"] = "Nữ";
                }
                row["SDT"] = txtSDT.Text;
                row["CMND"] = txtCMND.Text;
                row["DiaChi"] = txtDiaChi.Text;

                ds.Tables["tblDSKhachHang"].Rows.Add(row);

                //Cho phep luu hoac huy
                btnLuu.Enabled = true;
                btnHuy.Enabled = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //Kiem tra dong duoc chon
            if (dgDSKhachHang.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng", "Thông báo");
                return;
            }

            if (KiemTra())
            {
                DataGridViewRow dr = dgDSKhachHang.SelectedRows[0];
                if (txtMaKH.Text == dr.Cells["MaKH"].Value.ToString())
                {
                    dgDSKhachHang.BeginEdit(true);
                    dr.Cells["MaKH"].Value = txtMaKH.Text;
                    dr.Cells["HoTen"].Value = txtHoTen.Text;
                    dr.Cells["NgaySinh"].Value = dtpNgaySinh.Text;
                    if (radNam.Checked == true)
                    {
                        dr.Cells["GioiTinh"].Value = "Nam";
                    }
                    else
                    {
                        dr.Cells["GioiTinh"].Value = "Nữ";
                    }
                    dr.Cells["SDT"].Value = txtSDT.Text;
                    dr.Cells["CMND"].Value = txtCMND.Text;
                    dr.Cells["DiaChi"].Value = txtDiaChi.Text;

                    //Cho phep luu hoac huy
                    btnLuu.Enabled = true;
                    btnHuy.Enabled = true;
                }
                else
                    MessageBox.Show("Không thể sửa mã loại!!!", "Thông báo");

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgDSKhachHang.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng", "Thông báo");
                return;
            }

            DataGridViewRow dr = dgDSKhachHang.SelectedRows[0];
            dgDSKhachHang.Rows.Remove(dr);

            //Cho phep luu hoac huy
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                daKhachHang.Update(ds, "tblDSKhachHang");
                MessageBox.Show("Đã lưu", "Thông báo");
                dgDSKhachHang.Refresh();

                //Các thuoc tính button
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo lỗi");
                return;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ds.Tables["tblDSKhachHang"].RejectChanges();

            //Các thuoc tính button
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thoát????", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            if (ds.Tables["tblDSKhachHang2"] != null)
                ds.Tables["tblDSKhachHang2"].Clear();
            SqlDataAdapter daKH2;
            string sQueryTimKiem = "Select * from KhachHang where HoTen LIKE N'%" + txtTimKiem.Text + "%'";
            daKH2 = new SqlDataAdapter(sQueryTimKiem, conn);
            daKH2.Fill(ds, "tblDSKhachHang2");
            dgDSKhachHang.DataSource = ds.Tables["tblDSKhachHang2"];
        }

        private void btnHuyTim_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            dgDSKhachHang.DataSource = ds.Tables["tblDSKhachHang"];

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
    }
}
