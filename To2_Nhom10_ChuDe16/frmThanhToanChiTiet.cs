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
    public partial class frmThanhToanChiTiet : Form
    {
        public frmThanhToanChiTiet()
        {
            InitializeComponent();
        }

        public string MaHopDong;

        SqlConnection conn = new SqlConnection();
        DataSet ds = new DataSet("dsBBNX");
        SqlDataAdapter daHDCT;
        SqlDataAdapter daXe;
        SqlDataAdapter daBBNX;
        SqlDataAdapter daTaiXe;

        private void frmThanhToanChiTiet_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = KetNoi.ChuoiKetNoi();
            HienThiDataGrid();

            //BBNX
            string sQueryBBNX = @"Select * From BienBanNhanXe ";
            daBBNX = new SqlDataAdapter(sQueryBBNX, conn);
            daBBNX.Fill(ds, "tblDSBBNX");

            //Xe
            string sQueryXe = @"Select * From Xe ";
            daXe = new SqlDataAdapter(sQueryXe, conn);
            daXe.Fill(ds, "tblDSXe");
            string sSuaXe = @"update XE set TinhTrang=@tinhtrang where MaXe=@maxe";
            SqlCommand cmSuaXe = new SqlCommand(sSuaXe, conn);
            cmSuaXe.Parameters.Add("@maxe", SqlDbType.NVarChar, 10, "MaXe");
            cmSuaXe.Parameters.Add("@tinhtrang", SqlDbType.NVarChar, 20, "TinhTrang");

            daXe.UpdateCommand = cmSuaXe;

            //TaiXe
            string sQueryTaiXe = @"Select * From TaiXe ";
            daTaiXe = new SqlDataAdapter(sQueryTaiXe, conn);
            daTaiXe.Fill(ds, "tblDSTaiXe");
            string sSuaTaiXe = @"update TAIXE set XeDangChay=@xedangchay where MaTaiXe=@mataixe";
            SqlCommand cmSuaTaiXe = new SqlCommand(sSuaTaiXe, conn);
            cmSuaTaiXe.Parameters.Add("@mataixe", SqlDbType.NVarChar, 10, "MaTaiXe");
            cmSuaTaiXe.Parameters.Add("@xedangchay", SqlDbType.NVarChar, 20, "XeDangChay");

            daTaiXe.UpdateCommand = cmSuaTaiXe;

            //Command Them BBNX
            string sThemBBNX = @"insert into BIENBANNHANXE values(@mahd, @maxe, @ngaygiao, @trangthaive, @sucophatsinh, @tienphat, @ngaynhan)";
            SqlCommand cmThemBBNX = new SqlCommand(sThemBBNX, conn);
            cmThemBBNX.Parameters.Add("@mahd", SqlDbType.NVarChar, 10, "MaHD");
            cmThemBBNX.Parameters.Add("@maxe", SqlDbType.NVarChar, 10, "MaXe");
            cmThemBBNX.Parameters.Add("@ngaygiao", SqlDbType.SmallDateTime, 10, "NgayGiao");
            cmThemBBNX.Parameters.Add("@trangthaive", SqlDbType.NVarChar, 50, "TrangThaiVe");
            cmThemBBNX.Parameters.Add("@sucophatsinh", SqlDbType.NVarChar, 1000, "SuCoPhatSinh");
            cmThemBBNX.Parameters.Add("@tienphat", SqlDbType.Int, 10, "TienPhat");
            cmThemBBNX.Parameters.Add("@ngaynhan", SqlDbType.SmallDateTime, 10, "NgayNhan");

            daBBNX.InsertCommand = cmThemBBNX;

            
        }

        public void HienThiDataGrid()
        {
            string sQueryHDCT = @"Select b.TenHD, a.TenXe, n.*  From HOPDONGCHITIET n, XE a, HOPDONG b Where n.MaXe = a.MaXe and n.MaHD = '"+ MaHopDong+ "' and n.MaHD=b.MaHD";
            daHDCT = new SqlDataAdapter(sQueryHDCT, conn);
            daHDCT.Fill(ds, "tblDSHDCT");
            dgDSHopDongChiTiet.DataSource = ds.Tables["tblDSHDCT"];
            dgDSHopDongChiTiet.Columns["MaXe"].Visible = false;
            dgDSHopDongChiTiet.Columns["MaHD"].Visible = false;

            dgDSHopDongChiTiet.Columns["TenHD"].HeaderText = "Tên Hợp Đồng";
            dgDSHopDongChiTiet.Columns["TenHD"].Width = 80;
            dgDSHopDongChiTiet.Columns["TenXe"].HeaderText = "Tên Xe";
            dgDSHopDongChiTiet.Columns["TenXe"].Width = 200;
            dgDSHopDongChiTiet.Columns["MaTaiXe"].HeaderText = "Mã Tài Xế";
            dgDSHopDongChiTiet.Columns["MaTaiXe"].Width = 200;
            dgDSHopDongChiTiet.Columns["NgayThue"].HeaderText = "Ngày Thuê";
            dgDSHopDongChiTiet.Columns["NgayThue"].Width = 100;
            dgDSHopDongChiTiet.Columns["NgayTra"].HeaderText = "Ngày Trả";
            dgDSHopDongChiTiet.Columns["NgayTra"].Width = 100;
            dgDSHopDongChiTiet.Columns["TienThueXe"].HeaderText = "Tiền Thuê";
            dgDSHopDongChiTiet.Columns["TienThueXe"].Width = 100;
        }

        private void btnTraXe_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgDSHopDongChiTiet.SelectedRows[0];
            DataRow row = ds.Tables["tblDSBBNX"].NewRow();
            row["MaHD"] = dr.Cells["MaHD"].Value;
            row["MaXe"] = dr.Cells["MaXe"].Value;
            row["NgayGiao"] = dr.Cells["NgayThue"].Value;
            row["TrangThaiVe"] = txtTrangThaiVe.Text;
            row["SuCoPhatSinh"] = txtSuCoPhatSinh.Text;
            row["TienPhat"] = txtTienPhat.Text;
            row["NgayNhan"] = dtpNgayNhan.Text;

            ds.Tables["tblDSBBNX"].Rows.Add(row);

            foreach (DataRow r in ds.Tables["tblDSXe"].Rows)
            {
                if (r["MaXe"].Equals(dr.Cells["MaXe"].Value))
                {
                    r["TinhTrang"] = "Chưa thuê";
                }
            }

            foreach (DataRow r in ds.Tables["tblDSTaiXe"].Rows)
            {
                if (r["MaTaiXe"].Equals(dr.Cells["MaTaiXe"].Value)) 
                {
                    r["XeDangChay"] = null;
                }
            }

            try
            {
                daBBNX.Update(ds, "tblDSBBNX");
                daTaiXe.Update(ds, "tblDSTaiXe");
                daXe.Update(ds, "tblDSXe");
                MessageBox.Show("Đã lưu", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo lỗi");
                return;
            }
        }
    }
}
