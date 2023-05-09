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
    public partial class frmQLThanhToan : Form
    {
        public frmQLThanhToan()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection();
        DataSet ds = new DataSet("dsBBNX");
        SqlDataAdapter daThanhToan;
        SqlDataAdapter daHopDong;
        SqlDataAdapter daNhanVien;

        private void frmQLThanhToan_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = KetNoi.ChuoiKetNoi();
            HienThiDataGrid();

            //combobox hopdong
            string sQueryHopDong = @"select * from HOPDONG";
            daHopDong = new SqlDataAdapter(sQueryHopDong, conn);
            daHopDong.Fill(ds, "tblDSHopDong");
            cboTenHD.DataSource = ds.Tables["tblDSHopDong"];
            cboTenHD.DisplayMember = "TenHD";
            cboTenHD.ValueMember = "MaHD";

            //combobox nhanvien
            string sQueryNhanVien = @"select * from NHANVIEN";
            daNhanVien = new SqlDataAdapter(sQueryNhanVien, conn);
            daNhanVien.Fill(ds, "tblDSNhanVien");
            cboTenNV.DataSource = ds.Tables["tblDSNhanVien"];
            cboTenNV.DisplayMember = "HoTen";
            cboTenNV.ValueMember = "MaNV";

            //Command Them Thanh Toan
            string sThemTT = @"insert into THANHTOAN values(@matt, @mahd, @manv, @ngaytt, @tientt)";
            SqlCommand cmThemTT = new SqlCommand(sThemTT, conn);
            cmThemTT.Parameters.Add("@matt", SqlDbType.NVarChar, 10, "MaTT");
            cmThemTT.Parameters.Add("@mahd", SqlDbType.NVarChar, 10, "MaHD");
            cmThemTT.Parameters.Add("@manv", SqlDbType.NVarChar, 10, "MaNV");
            cmThemTT.Parameters.Add("@ngaytt", SqlDbType.SmallDateTime, 10, "NgayTT");
            cmThemTT.Parameters.Add("@tientt", SqlDbType.Int, 5, "TienTT");

            daThanhToan.InsertCommand = cmThemTT;

            //Command Sua Thanh Toan
            string sSuaTT = @"update THANHTOAN set MaHD=@mahd, MaNV=@manv, NgayTT=@ngaytt, TienTT=@tientt where MaTT=@matt";
            SqlCommand cmSuaTT = new SqlCommand(@sSuaTT, conn);
            cmSuaTT.Parameters.Add("@matt", SqlDbType.NVarChar, 10, "MaTT");
            cmSuaTT.Parameters.Add("@mahd", SqlDbType.NVarChar, 10, "MaHD");
            cmSuaTT.Parameters.Add("@manv", SqlDbType.NVarChar, 10, "MaNV");
            cmSuaTT.Parameters.Add("@ngaytt", SqlDbType.SmallDateTime, 10, "NgayTT");
            cmSuaTT.Parameters.Add("@tientt", SqlDbType.Int, 5, "TienTT");

            daThanhToan.UpdateCommand = cmSuaTT;

            //Command Xoa Thanh Toan
            string sXoaTT = @"delete from THANHTOAN where MaTT=@matt";
            SqlCommand cmXoaTT = new SqlCommand(sXoaTT, conn);
            cmXoaTT.Parameters.Add("@matt", SqlDbType.NVarChar, 10, "MaTT");

            daThanhToan.DeleteCommand = cmXoaTT;

            //Command Sua Hop Dong
            string sSuaHD = @"update HOPDONG set TinhTrangHD=@tinhtranghd where MaHD=@mahd";
            SqlCommand cmSuaHD = new SqlCommand(sSuaHD, conn);
            cmSuaHD.Parameters.Add("@mahd", SqlDbType.NVarChar, 10, "MaHD");
            cmSuaHD.Parameters.Add("@tinhtranghd", SqlDbType.NVarChar, 20, "TinhTrangHD");

            daHopDong.UpdateCommand = cmSuaHD;

            // Thuộc tính Enable các Button
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        public void HienThiDataGrid()
        {
            string sQueryTT = @"Select n.*, b.TenHD, c.HoTen From ThanhToan n, HOPDONG b, NHANVIEN c Where n.MaHD = b.MaHD and n.MaNV = c.MaNV ";
            daThanhToan = new SqlDataAdapter(sQueryTT, conn);
            daThanhToan.Fill(ds, "tblDSThanhToan");
            dgDSThanhToan.DataSource = ds.Tables["tblDSThanhToan"];
            dgDSThanhToan.Columns["MaHD"].Visible = false;
            dgDSThanhToan.Columns["MaNV"].Visible = false;
            dgDSThanhToan.Columns["MaTT"].HeaderText = "Mã Thanh Toán";
            dgDSThanhToan.Columns["MaTT"].Width = 100;
            dgDSThanhToan.Columns["NgayTT"].HeaderText = "Ngày Thanh Toán";
            dgDSThanhToan.Columns["NgayTT"].Width = 120;
            dgDSThanhToan.Columns["TienTT"].HeaderText = "Tiền Thanh Toán";
            dgDSThanhToan.Columns["TienTT"].Width = 80;
            dgDSThanhToan.Columns["TenHD"].HeaderText = "Tên Hợp Đồng";
            dgDSThanhToan.Columns["TenHD"].Width = 100;
            dgDSThanhToan.Columns["HoTen"].HeaderText = "Tên Nhân Viên";
            dgDSThanhToan.Columns["HoTen"].Width = 150;
        }

        private void dgDSThanhToan_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgDSThanhToan.SelectedRows[0];
            txtMaTT.Text = dr.Cells["MaTT"].Value.ToString();
            dtpNgayTT.Text = dr.Cells["NgayTT"].Value.ToString();
            txtTienTT.Text = dr.Cells["TienTT"].Value.ToString();
            cboTenHD.SelectedValue = dr.Cells["MaHD"].Value.ToString();
            cboTenNV.SelectedValue = dr.Cells["MaNV"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                //Kiem tra ma trung trong DataGridView
                DataGridViewRow dr;
                for (int i = 0; i < dgDSThanhToan.RowCount - 1; i++)
                {
                    dr = dgDSThanhToan.Rows[i];
                    if (txtMaTT.Text == dr.Cells["MaTT"].Value.ToString())
                    {
                        MessageBox.Show("Mã vừa nhập đã bị trùng!!!!", "Thông báo");
                        return;
                    }
                }
                DataRow row = ds.Tables["tblDSThanhToan"].NewRow();
                row["MaTT"] = txtMaTT.Text;
                row["MaHD"] = cboTenHD.SelectedValue;
                row["MaNV"] = cboTenNV.SelectedValue;
                row["NgayTT"] = dtpNgayTT.Text;
                row["TienTT"] = txtTienTT.Text;
                row["TenHD"] = cboTenHD.Text;
                row["HoTen"] = cboTenNV.Text;

                ds.Tables["tblDSThanhToan"].Rows.Add(row);

                //Cap nhap thanh tien bang hop dong
                foreach (DataRow r in ds.Tables["tblDSHopDong"].Rows)
                {
                    if (r["MaHD"].Equals(cboTenHD.SelectedValue))
                    {

                        r["TinhTrangHD"] = "Đã thanh toán";
                    }
                }

                btnLuu.Enabled = true;
                btnHuy.Enabled = true;
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                DataGridViewRow dr = dgDSThanhToan.SelectedRows[0];
                dgDSThanhToan.BeginEdit(true);
                dr.Cells["MaTT"].Value = txtMaTT.Text;
                dr.Cells["MaHD"].Value = cboTenHD.SelectedValue;
                dr.Cells["MaNV"].Value = cboTenNV.SelectedValue;
                dr.Cells["NgayTT"].Value = dtpNgayTT.Text;
                dr.Cells["TienTT"].Value = txtTienTT.Text;
                dr.Cells["TenHD"].Value = cboTenHD.Text;
                dr.Cells["HoTen"].Value = cboTenNV.Text;

                btnLuu.Enabled = true;
                btnHuy.Enabled = true;
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgDSThanhToan.SelectedRows[0];

            //Cap nhap tinh trang bang hop dong
            foreach (DataRow r in ds.Tables["tblDSHopDong"].Rows)
            {
                if (r["MaHD"].Equals(dr.Cells["MaHD"].Value))
                {

                    r["TinhTrangHD"] = "Chưa thanh toán";
                }
            }

            dgDSThanhToan.Rows.Remove(dr);

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                daThanhToan.Update(ds, "tblDSThanhToan");
                daHopDong.Update(ds, "tblDSHopDong");
                MessageBox.Show("Đã luu", "Thông báo");
                dgDSThanhToan.Refresh();

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
            ds.Tables["tblDSThanhToan"].RejectChanges();

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

        public bool KiemTra()
        {
            if (txtMaTT.Text == "")
            {
                MessageBox.Show("Nhập mã thanh toán", "Thông báo");
                txtMaTT.Focus();
                return false;
            }
            if (!KetNoi.KiemTraSoLonHon0(txtTienTT.Text))
            {
                MessageBox.Show("Nhập lại tiền thanh toán", "Thông báo");
                txtTienTT.Focus();
                return false;
            }
            return true;
        }
    }
}
