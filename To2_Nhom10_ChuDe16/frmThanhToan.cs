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
    public partial class frmThanhToan : Form
    {
        public frmThanhToan()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection();
        DataSet ds = new DataSet("dsTT");
        SqlDataAdapter daThanhToan;
        SqlDataAdapter daHopDong;
        SqlDataAdapter daNhanVien;

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            frmThanhToanChiTiet f2 = new frmThanhToanChiTiet();
            f2.MaHopDong = txtMaHD.Text;
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
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

            //Thanh toan
            string sQueryTT = @"Select * From ThanhToan ";
            daThanhToan = new SqlDataAdapter(sQueryTT, conn);
            daThanhToan.Fill(ds, "tblDSThanhToan");

            //Command Them Thanh Toan
            string sThemTT = @"insert into THANHTOAN values(@matt, @mahd, @manv, @ngaytt, @tientt)";
            SqlCommand cmThemTT = new SqlCommand(sThemTT, conn);
            cmThemTT.Parameters.Add("@matt", SqlDbType.NVarChar, 10, "MaTT");
            cmThemTT.Parameters.Add("@mahd", SqlDbType.NVarChar, 10, "MaHD");
            cmThemTT.Parameters.Add("@manv", SqlDbType.NVarChar, 10, "MaNV");
            cmThemTT.Parameters.Add("@ngaytt", SqlDbType.SmallDateTime, 10, "NgayTT");
            cmThemTT.Parameters.Add("@tientt", SqlDbType.Int, 5, "TienTT");

            daThanhToan.InsertCommand = cmThemTT;

            //Command Sua Hop Dong
            string sSuaHD = @"update HOPDONG set TinhTrangHD=@tinhtranghd where MaHD=@mahd";
            SqlCommand cmSuaHD = new SqlCommand(sSuaHD, conn);
            cmSuaHD.Parameters.Add("@mahd", SqlDbType.NVarChar, 10, "MaHD");
            cmSuaHD.Parameters.Add("@tinhtranghd", SqlDbType.NVarChar, 20, "TinhTrangHD");

            daHopDong.UpdateCommand = cmSuaHD;


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
        }

        private void btnTT_Click(object sender, EventArgs e)
        {
            //Cap nhap thanh toan bang hop dong
            /*DataGridViewRow dr = dgDSHopDong.SelectedRows[0];
            dgDSHopDong.BeginEdit(true);
            dr.Cells["TinhTrangHD"].Value = "Đã thanh toán";*/
            foreach (DataRow r in ds.Tables["tblDSHopDong"].Rows)
            {
                if (r["MaHD"].Equals(txtMaHD.Text))
                {
                    r["TinhTrangHD"] = "Đã thanh toán";
                }
            }

            DataRow row = ds.Tables["tblDSThanhToan"].NewRow();
            row["MaTT"] = txtMaTT.Text;
            row["MaHD"] = txtMaHD.Text;
            row["MaNV"] = cboTenNV.SelectedValue;
            row["NgayTT"] = dtpNgayTT.Text;
            row["TienTT"] = txtTienTT.Text;

            ds.Tables["tblDSThanhToan"].Rows.Add(row);            

            try
            {
                daHopDong.Update(ds, "tblDSHopDong");
                daThanhToan.Update(ds, "tblDSThanhToan");
                
                MessageBox.Show("Đã lưu", "Thông báo");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo lỗi");
                return;
            }
        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {
            if (ds.Tables["tblDSHopDong"] != null)
                ds.Tables["tblDSHopDong"].Clear();

            string sQueryHD = "Select n.*, b.HoTen as TenKH, c.HoTen as TenNV From HOPDONG n, KHACHHANG b, NHANVIEN c Where n.MaKH = b.MaKH and n.MaNV = c.MaNV and b.HoTen Like N'%"+txtTenKH.Text+"%' ";
            daHopDong = new SqlDataAdapter(sQueryHD, conn);
            daHopDong.Fill(ds, "tblDSHopDong");
            dgDSHopDong.DataSource = ds.Tables["tblDSHopDong"];

            //Command Sua Hop Dong
            string sSuaHD = @"update HOPDONG set TinhTrangHD=@tinhtranghd where MaHD=@mahd";
            SqlCommand cmSuaHD = new SqlCommand(sSuaHD, conn);
            cmSuaHD.Parameters.Add("@mahd", SqlDbType.NVarChar, 10, "MaHD");
            cmSuaHD.Parameters.Add("@tinhtranghd", SqlDbType.NVarChar, 20, "TinhTrangHD");
        }

        private void txtTenHD_TextChanged(object sender, EventArgs e)
        {
            if (ds.Tables["tblDSHopDong"] != null)
                ds.Tables["tblDSHopDong"].Clear();

            string sQueryHD = "Select n.*, b.HoTen as TenKH, c.HoTen as TenNV From HOPDONG n, KHACHHANG b, NHANVIEN c Where n.MaKH = b.MaKH and n.MaNV = c.MaNV and n.TenHD Like N'%" + txtTenHD.Text + "%' ";
            daHopDong = new SqlDataAdapter(sQueryHD, conn);
            daHopDong.Fill(ds, "tblDSHopDong");
            dgDSHopDong.DataSource = ds.Tables["tblDSHopDong"];

            //Command Sua Hop Dong
            string sSuaHD = @"update HOPDONG set TinhTrangHD=@tinhtranghd where MaHD=@mahd";
            SqlCommand cmSuaHD = new SqlCommand(sSuaHD, conn);
            cmSuaHD.Parameters.Add("@mahd", SqlDbType.NVarChar, 10, "MaHD");
            cmSuaHD.Parameters.Add("@tinhtranghd", SqlDbType.NVarChar, 20, "TinhTrangHD");
        }
    }
}
