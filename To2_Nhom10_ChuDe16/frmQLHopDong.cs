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
    public partial class frmQLHopDong : Form
    {
        public frmQLHopDong()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection();
        DataSet ds = new DataSet("dsHOPDONG");
        SqlDataAdapter daHopDong;
        SqlDataAdapter daNhanVien;
        SqlDataAdapter daKhachHang;


        private void frmQLHopDong_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = KetNoi.ChuoiKetNoi();
            HienThiDataGrid();

            //combobox nhanvien
            string sQueryNhanVien = @"select * from NHANVIEN";
            daNhanVien = new SqlDataAdapter(sQueryNhanVien, conn);
            daNhanVien.Fill(ds, "tblDSNhanVien");
            cboTenNV.DataSource = ds.Tables["tblDSNhanVien"];
            cboTenNV.DisplayMember = "HoTen";
            cboTenNV.ValueMember = "MaNV";

            //combobox khachhang
            string sQueryKhachHang = @"select * from KHACHHANG";
            daKhachHang = new SqlDataAdapter(sQueryKhachHang, conn);
            daKhachHang.Fill(ds, "tblDSKhachHang");
            cboTenKH.DataSource = ds.Tables["tblDSKhachHang"];
            cboTenKH.DisplayMember = "HoTen";
            cboTenKH.ValueMember = "MaKH";

            //Command Them Thanh Toan
            string sThemHD = @"insert into HOPDONG values(@mahd, @tenhd, @makh, @manv, @ngaylaphd, @noidunghd, @hanhd, @dongia, @tiendatcoc, @tinhtranghd)";
            SqlCommand cmThemHD = new SqlCommand(sThemHD, conn);
            cmThemHD.Parameters.Add("@mahd", SqlDbType.NVarChar, 10, "MaHD");
            cmThemHD.Parameters.Add("@tenhd", SqlDbType.NVarChar, 50, "TenHD");
            cmThemHD.Parameters.Add("@makh", SqlDbType.NVarChar, 10, "MaKH");
            cmThemHD.Parameters.Add("@manv", SqlDbType.NVarChar, 10, "MaNV");
            cmThemHD.Parameters.Add("@ngaylaphd", SqlDbType.SmallDateTime, 10, "NgayLapHD");
            cmThemHD.Parameters.Add("@noidunghd", SqlDbType.NVarChar, 1000, "NoiDungHD");
            cmThemHD.Parameters.Add("@hanhd", SqlDbType.SmallDateTime, 10, "HanHD");
            cmThemHD.Parameters.Add("@dongia", SqlDbType.Int, 15, "DonGia");
            cmThemHD.Parameters.Add("@tiendatcoc", SqlDbType.Int, 15, "TienDatCoc");
            cmThemHD.Parameters.Add("@tinhtranghd", SqlDbType.NVarChar, 50, "TinhTrangHD");

            daHopDong.InsertCommand = cmThemHD;

            //Command Sua Thanh Toan
            string sSuaHD = @"update HOPDONG set MaKH=@makh, MaNV=@manv, NgayLapHD=@ngaylaphd, NoiDungHD=@noidunghd, HanHD=@hanhd, TienDatCoc=@tiendatcoc, TinhTrangHD=@tinhtranghd where MaHD=@mahd";
            SqlCommand cmSuaHD = new SqlCommand(@sSuaHD, conn);
            cmSuaHD.Parameters.Add("@mahd", SqlDbType.NVarChar, 10, "MaHD");
            cmSuaHD.Parameters.Add("@tenhd", SqlDbType.NVarChar, 50, "TenHD");
            cmSuaHD.Parameters.Add("@makh", SqlDbType.NVarChar, 10, "MaKH");
            cmSuaHD.Parameters.Add("@manv", SqlDbType.NVarChar, 10, "MaNV");
            cmSuaHD.Parameters.Add("@ngaylaphd", SqlDbType.SmallDateTime, 10, "NgayLapHD");
            cmSuaHD.Parameters.Add("@noidunghd", SqlDbType.NVarChar, 1000, "NoiDungHD");
            cmSuaHD.Parameters.Add("@hanhd", SqlDbType.SmallDateTime, 10, "HanHD");
            cmSuaHD.Parameters.Add("@dongia", SqlDbType.Int, 15, "DonGia");
            cmSuaHD.Parameters.Add("@tiendatcoc", SqlDbType.Int, 15, "TienDatCoc");
            cmSuaHD.Parameters.Add("@tinhtranghd", SqlDbType.NVarChar, 50, "TinhTrangHD");

            daHopDong.UpdateCommand = cmSuaHD;

            //Command Xoa Thanh Toan
            string sXoaHD = @"delete from HOPDONG where MaHD=@mahd";
            SqlCommand cmXoaHD = new SqlCommand(sXoaHD, conn);
            cmXoaHD.Parameters.Add("@mahd", SqlDbType.NVarChar, 10, "MaHD");

            daHopDong.DeleteCommand = cmXoaHD;

            //Chinh kich thuoc font chu datagridview
            this.dgDSHopDong.Font = new Font("Times new roman", 9);

            //Khong cho phep chinh sua don gia
            txtDonGia.Enabled = false;

            //An button luu va huy
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        public void HienThiDataGrid()
        {
            string sQueryHD = @"Select n.*, b.HoTen as TenKH, c.HoTen as TenNV From HOPDONG n, KHACHHANG b, NHANVIEN c Where n.MaKH = b.MaKH and n.MaNV = c.MaNV ";
            daHopDong = new SqlDataAdapter(sQueryHD, conn);
            daHopDong.Fill(ds, "tblDSHopDong");
            dgDSHopDong.DataSource = ds.Tables["tblDSHopDong"];
            dgDSHopDong.Columns["MaKH"].Visible = false;
            dgDSHopDong.Columns["MaNV"].Visible = false;
            dgDSHopDong.Columns["MaHD"].HeaderText = "Mã Hợp Đồng";
            dgDSHopDong.Columns["MaHD"].Width = 100;
            dgDSHopDong.Columns["TenHD"].HeaderText = "Tên Hợp Đồng";
            dgDSHopDong.Columns["TenHD"].Width = 100;
            dgDSHopDong.Columns["NgayLapHD"].HeaderText = "Ngày Lập Hợp Đồng";
            dgDSHopDong.Columns["NgayLapHD"].Width = 100;
            dgDSHopDong.Columns["NoiDungHD"].HeaderText = "Nội Dung Hợp Đồng";
            dgDSHopDong.Columns["NoiDungHD"].Width = 100;
            dgDSHopDong.Columns["HanHD"].HeaderText = "Hạn Hợp Đồng";
            dgDSHopDong.Columns["HanHD"].Width = 100;
            dgDSHopDong.Columns["DonGia"].HeaderText = "Đơn Giá";
            dgDSHopDong.Columns["DonGia"].Width = 100;
            dgDSHopDong.Columns["TienDatCoc"].HeaderText = "Tiền Đặt Cọc";
            dgDSHopDong.Columns["TienDatCoc"].Width = 100;
            dgDSHopDong.Columns["TinhTrangHD"].HeaderText = "Tình Trạng Hợp Đồng";
            dgDSHopDong.Columns["TinhTrangHD"].Width = 100;
            dgDSHopDong.Columns["TenKH"].HeaderText = "Tên Khách Hàng";
            dgDSHopDong.Columns["TenKH"].Width = 150;
            dgDSHopDong.Columns["TenNV"].HeaderText = "Tên Nhân Viên";
            dgDSHopDong.Columns["TenNV"].Width = 150;
        }

        private void dgDSHopDong_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgDSHopDong.SelectedRows[0];
            txtMaHD.Text = dr.Cells["MaHD"].Value.ToString();
            txtTenHD.Text = dr.Cells["TenHD"].Value.ToString();
            cboTenKH.SelectedValue = dr.Cells["MaKH"].Value.ToString();
            cboTenNV.SelectedValue = dr.Cells["MaNV"].Value.ToString();
            dtpNgayLapHD.Text = dr.Cells["NgayLapHD"].Value.ToString();
            dtpHanHD.Text = dr.Cells["HanHD"].Value.ToString();
            txtNoiDungHD.Text = dr.Cells["NoiDungHD"].Value.ToString();
            txtDonGia.Text = dr.Cells["DonGia"].Value.ToString();
            txtTienDatCoc.Text = dr.Cells["TienDatCoc"].Value.ToString();
            if(dr.Cells["TinhTrangHD"].Value.ToString()=="Chưa thanh toán")
            {
                radChuaTT.Checked = true;
            }
            else
            {
                radDaTT.Checked = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                //Kiem tra ma trung trong DataGridView
                DataGridViewRow dr;
                for (int i = 0; i < dgDSHopDong.RowCount - 1; i++)
                {
                    dr = dgDSHopDong.Rows[i];
                    if (txtMaHD.Text == dr.Cells["MaHD"].Value.ToString())
                    {
                        MessageBox.Show("Mã vừa nhập đã bị trùng!!!!", "Thông báo");
                        return;
                    }
                }

                DataRow row = ds.Tables["tblDSHopDong"].NewRow();
                row["MaHD"] = txtMaHD.Text;
                row["TenHD"] = txtTenHD.Text;
                row["MaKH"] = cboTenKH.SelectedValue;
                row["MaNV"] = cboTenNV.SelectedValue;
                row["NgayLapHD"] = dtpNgayLapHD.Text;
                row["NoiDungHD"] = txtNoiDungHD.Text;
                row["HanHD"] = dtpHanHD.Text;
                row["DonGia"] = 0.ToString();
                row["TienDatCoc"] = txtTienDatCoc.Text;
                row["TenNV"] = cboTenNV.Text;
                row["TenKH"] = cboTenNV.Text;
                if (radDaTT.Checked == true)
                {
                    row["TinhTrangHD"] = "Đã thanh toán";
                }
                else
                {
                    row["TinhTrangHD"] = "Chưa thanh toán";
                }

                ds.Tables["tblDSHopDong"].Rows.Add(row);

                //Cho phep luu hoac huy
                btnLuu.Enabled = true;
                btnHuy.Enabled = true;
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //Kiem tra dong duoc chon
            if (dgDSHopDong.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng", "Thông báo");
                return;
            }

            if (KiemTra())
            {
                DataGridViewRow dr = dgDSHopDong.SelectedRows[0];
                //Kiem tra ma hop dong co thay doi khong neu co -> khong cho phep sua
                if (txtMaHD.Text == dr.Cells["MaHD"].Value.ToString())
                {
                    dgDSHopDong.BeginEdit(true);
                    dr.Cells["MaHD"].Value = txtMaHD.Text;
                    dr.Cells["TenHD"].Value = txtTenHD.Text;
                    dr.Cells["MaKH"].Value = cboTenKH.SelectedValue;
                    dr.Cells["MaNV"].Value = cboTenNV.SelectedValue;
                    dr.Cells["NgayLapHD"].Value = dtpNgayLapHD.Text;
                    dr.Cells["NoiDungHD"].Value = txtNoiDungHD.Text;
                    dr.Cells["HanHD"].Value = dtpHanHD.Text;
                    dr.Cells["DonGia"].Value = txtDonGia.Text;
                    dr.Cells["TienDatCoc"].Value = txtTienDatCoc.Text;
                    dr.Cells["TenKH"].Value = cboTenKH.Text;
                    dr.Cells["TenNV"].Value = cboTenNV.Text;
                    if (radDaTT.Checked == true)
                    {
                        dr.Cells["TinhTrangHD"].Value = "Đã thanh toán";
                    }
                    else
                    {
                        dr.Cells["TinhTrangHD"].Value = "Chưa thanh toán";
                    }

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
            if (dgDSHopDong.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng", "Thông báo");
                return;
            }

            DataGridViewRow dr = dgDSHopDong.SelectedRows[0];
            dgDSHopDong.Rows.Remove(dr);

            //Cho phep luu hoac huy
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                daHopDong.Update(ds, "tblDSHopDong");
                MessageBox.Show("Đã luu", "Thông báo");
                dgDSHopDong.Refresh();

                //An button luu va huy
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
            ds.Tables["tblDSHopDong"].RejectChanges();

            //An button luu va huy
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

        //Ham Kiem tra
        public bool KiemTra()
        {
            if (txtMaHD.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã hợp đồng", "Thông báo");
                txtMaHD.Focus();
                return false;
            }
            if (txtTenHD.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên hợp đồng", "Thông báo");
                txtTenHD.Focus();
                return false;
            }
            if (txtNoiDungHD.Text == "")
            {
                MessageBox.Show("Vui lòng nhập nội dung hợp đồng", "Thông báo");
                txtNoiDungHD.Focus();
                return false;
            }
            if (!KetNoi.KiemTraSoLonHon0(txtTienDatCoc.Text))
            {
                MessageBox.Show("Vui lòng nhập tiền cọc", "Thông báo");
                txtTienDatCoc.Focus();
                return false;
            }
            if (dtpHanHD.Value<dtpNgayLapHD.Value)
            {
                MessageBox.Show("Hạn hợp đồng không thể nhỏ hơn ngày lập", "Thông báo");
                return false;
            }
            return true;
        }
    }
}
