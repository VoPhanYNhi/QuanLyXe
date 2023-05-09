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
    public partial class frmQLNhanVien : Form
    {
        public frmQLNhanVien()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection();
        DataSet ds = new DataSet("dsNhanVien");
        SqlDataAdapter daNhanVien;

        private void frmQLNhanVien_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = KetNoi.ChuoiKetNoi();

            HienThiDaTaGrid();

            //Command Them NhanVien
            string sThemNhanVien = @"insert into NHANVIEN values(@manv,@hoten,@ngaysinh,@gioitinh,@sdt,@cmnd,@diachi,@vaitro)";
            SqlCommand cmThemNhanVien = new SqlCommand(sThemNhanVien, conn);
            cmThemNhanVien.Parameters.Add("@manv", SqlDbType.NVarChar, 10, "MaNV");
            cmThemNhanVien.Parameters.Add("@hoten", SqlDbType.NVarChar, 50, "HoTen");
            cmThemNhanVien.Parameters.Add("@ngaysinh", SqlDbType.Date, 10, "NgaySinh");
            cmThemNhanVien.Parameters.Add("@gioitinh", SqlDbType.NVarChar, 10, "GioiTinh");
            cmThemNhanVien.Parameters.Add("@sdt", SqlDbType.Char, 10, "SDT");
            cmThemNhanVien.Parameters.Add("@cmnd", SqlDbType.Char, 9, "CMND");
            cmThemNhanVien.Parameters.Add("@diachi", SqlDbType.NVarChar, 100, "DiaChi");
            cmThemNhanVien.Parameters.Add("@vaitro", SqlDbType.NVarChar, 50, "VaiTro");

            daNhanVien.InsertCommand = cmThemNhanVien;

            //Command Sua NhanVien
            string sSuaNhanVien = @"update NHANVIEN set HoTen=@hoten, NgaySinh=@ngaysinh, GioiTinh=@gioitinh, SDT=@sdt, CMND=@cmnd, DiaChi=@diachi, VaiTro=@vaitro where MaNV=@manv";
            SqlCommand cmSuaNhanVien = new SqlCommand(sSuaNhanVien, conn);
            cmSuaNhanVien.Parameters.Add("@manv", SqlDbType.NVarChar, 10, "MaNV");
            cmSuaNhanVien.Parameters.Add("@hoten", SqlDbType.NVarChar, 50, "HoTen");
            cmSuaNhanVien.Parameters.Add("@ngaysinh", SqlDbType.Date, 10, "NgaySinh");
            cmSuaNhanVien.Parameters.Add("@gioitinh", SqlDbType.NVarChar, 10, "GioiTinh");
            cmSuaNhanVien.Parameters.Add("@sdt", SqlDbType.Char, 10, "SDT");
            cmSuaNhanVien.Parameters.Add("@cmnd", SqlDbType.Char, 9, "CMND");
            cmSuaNhanVien.Parameters.Add("@diachi", SqlDbType.NVarChar, 100, "DiaChi");
            cmSuaNhanVien.Parameters.Add("@vaitro", SqlDbType.NVarChar, 50, "VaiTro");

            daNhanVien.UpdateCommand = cmSuaNhanVien;

            //Command Xoa NhanVien
            string sXoaNhanVien = @"delete from NHANVIEN where MaNV=@manv";
            SqlCommand cmXoaNhanVien = new SqlCommand(sXoaNhanVien, conn);
            cmXoaNhanVien.Parameters.Add("@manv", SqlDbType.NVarChar, 10, "MaNV");

            daNhanVien.DeleteCommand = cmXoaNhanVien;

            //Các thuoc tính button
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        public void HienThiDaTaGrid()
        {
            string sQueryNhanVien = @"select *from NHANVIEN";
            daNhanVien = new SqlDataAdapter(sQueryNhanVien, conn); ;
            daNhanVien.Fill(ds, "tblDSNhanVien");
            dgDSNhanVien.DataSource = ds.Tables["tblDSNhanVien"];

            dgDSNhanVien.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
            dgDSNhanVien.Columns["MaNV"].Width = 100;
            dgDSNhanVien.Columns["HoTen"].HeaderText = "Họ Tên";
            dgDSNhanVien.Columns["HoTen"].Width = 200;
            dgDSNhanVien.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            dgDSNhanVien.Columns["NgaySinh"].Width = 80;
            dgDSNhanVien.Columns["GioiTinh"].HeaderText = "Giới Tính";
            dgDSNhanVien.Columns["GioiTinh"].Width = 50;
            dgDSNhanVien.Columns["SDT"].HeaderText = "Số Điện Thoại";
            dgDSNhanVien.Columns["SDT"].Width = 100;
            dgDSNhanVien.Columns["CMND"].HeaderText = "CMND";
            dgDSNhanVien.Columns["CMND"].Width = 100;
            dgDSNhanVien.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dgDSNhanVien.Columns["DiaChi"].Width = 250;
            dgDSNhanVien.Columns["VaiTro"].HeaderText = "Vai Trò";
            dgDSNhanVien.Columns["VaiTro"].Width = 100;
        }

        private void dgDSNhanVien_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgDSNhanVien.SelectedRows[0];
            txtMaNV.Text = dr.Cells["MaNV"].Value.ToString();
            txtHoTen.Text = dr.Cells["HoTen"].Value.ToString();
            dtpNgaySinh.Text = dr.Cells["NgaySinh"].Value.ToString();

            if (dr.Cells["GioiTinh"].Value.ToString() == "Nam")
                radNam.Checked = true;
            else
                radNu.Checked = true;

            txtSDT.Text = dr.Cells["SDT"].Value.ToString();
            txtCMND.Text = dr.Cells["CMND"].Value.ToString();
            txtDiaChi.Text = dr.Cells["DiaChi"].Value.ToString();
            txtVaiTro.Text = dr.Cells["VaiTro"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                //Kiem tra ma trung trong DataGridView
                DataGridViewRow dr;
                for (int i = 0; i < dgDSNhanVien.RowCount - 1; i++)
                {
                    dr = dgDSNhanVien.Rows[i];
                    if (txtMaNV.Text== dr.Cells["MaNV"].Value.ToString())
                    {
                        MessageBox.Show("Mã vừa nhập đã bị trùng!!!!", "Thông báo");
                        return;
                    }
                }

                DataRow row = ds.Tables["tblDSNhanVien"].NewRow();
                row["MaNV"] = txtMaNV.Text;
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
                row["VaiTro"] = txtVaiTro.Text;

                ds.Tables["tblDSNhanVien"].Rows.Add(row);

                //Cho phep luu hoac huy
                btnLuu.Enabled = true;
                btnHuy.Enabled = true;
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //Kiem tra dong duoc chon
            if (dgDSNhanVien.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng", "Thông báo");
                return;
            }

            if (KiemTra())
            {
                DataGridViewRow dr = dgDSNhanVien.SelectedRows[0];
                //Kiem tra ma loai co thay doi khong neu co -> khong cho phep sua
                if (txtMaNV.Text == dr.Cells["MaNV"].Value.ToString())
                {
                    dgDSNhanVien.BeginEdit(true);
                    dr.Cells["MaNV"].Value = txtMaNV.Text;
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
                    dr.Cells["VaiTro"].Value = txtVaiTro.Text;

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
            //Kiem tra dong duoc chon
            if (dgDSNhanVien.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng", "Thông báo");
                return;
            }

            DataGridViewRow dr = dgDSNhanVien.SelectedRows[0];
            dgDSNhanVien.Rows.Remove(dr);

            //Cho phep luu hoac huy
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                daNhanVien.Update(ds, "tblDSNhanVien");
                MessageBox.Show("Đã lưu", "Thông báo");
                dgDSNhanVien.Refresh();

                //Các thuoc tính button
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo lỗi");
                return;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ds.Tables["tblDSNhanVien"].RejectChanges();

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

        //Ham kiem tra
        public bool KiemTra()
        {
            if (dtpNgaySinh.Value > DateTime.Parse("31/12/2001"))
            {
                MessageBox.Show("Ngày sinh không thể lớn hơn 31/12/2001", "Thông báo");
                return false;
            }
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Nhập mã nhân viên", "Thông báo");
                txtMaNV.Focus();
                return false;
            }
            if (txtHoTen.Text == "")
            {
                MessageBox.Show("Nhập họ tên nhân viên", "Thông báo");
                txtHoTen.Focus();
                return false;
            }
            if (txtSDT.Text.Length!=10)
            {
                MessageBox.Show("Nhập lại số diện thoại nhân viên", "Thông báo");
                txtSDT.Focus();
                return false;
            }
            if (txtCMND.Text.Length != 9)
            {
                MessageBox.Show("Nhập lại CMND nhân viên", "Thông báo");
                txtCMND.Focus();
                return false;
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Nhập Địa chỉ nhân viên", "Thông báo");
                txtDiaChi.Focus();
                return false;
            }
            if (txtVaiTro.Text == "")
            {
                MessageBox.Show("Nhập vai trò nhân viên", "Thông báo");
                txtVaiTro.Focus();
                return false;
            }
            return true;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            if (ds.Tables["tblDSNhanVien2"] != null)
                ds.Tables["tblDSNhanVien2"].Clear();
            SqlDataAdapter daNV2;
            string sQueryTimKiem = "Select * from NHANVIEN where HoTen LIKE N'%" + txtTimKiem.Text + "%'";
            daNV2 = new SqlDataAdapter(sQueryTimKiem, conn);
            daNV2.Fill(ds, "tblDSNhanVien2");
            dgDSNhanVien.DataSource = ds.Tables["tblDSNhanVien2"];
        }

        private void btnHuyTim_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            dgDSNhanVien.DataSource = ds.Tables["tblDSNhanVien"];

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
    }
}
