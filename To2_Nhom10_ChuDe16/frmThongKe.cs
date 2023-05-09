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
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection();
        DataSet ds = new DataSet("dsThongKe");
        SqlDataAdapter daThongKe;

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = KetNoi.ChuoiKetNoi();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if(ds.Tables["tblThongKe"] != null)
                ds.Tables["tblThongKe"].Clear();
            string TuNgay = dtpTu.Value.ToString("yyyy/MM/dd");
            string DenNgay = dtpDen.Value.ToString("yyyy/MM/dd");
            string sQueryTT = @"Select b.TenHD, c.HoTen, n.* From ThanhToan n, HOPDONG b, KHACHHANG c Where n.MaHD = b.MaHD and b.MaKH = c.MaKH and n.NgayTT>='"+TuNgay+ "' and n.NgayTT<='" + DenNgay + "'";
            daThongKe = new SqlDataAdapter(sQueryTT, conn);
            daThongKe.Fill(ds, "tblThongKe");
            dgThongKe.DataSource = ds.Tables["tblThongKe"];
            dgThongKe.Columns["MaHD"].Visible = false;
            dgThongKe.Columns["MaNV"].Visible = false;
            dgThongKe.Columns["MaTT"].HeaderText = "Mã Thanh Toán";
            dgThongKe.Columns["MaTT"].Width = 100;
            dgThongKe.Columns["NgayTT"].HeaderText = "Ngày Thanh Toán";
            dgThongKe.Columns["NgayTT"].Width = 120;
            dgThongKe.Columns["TienTT"].HeaderText = "Tiền Thanh Toán";
            dgThongKe.Columns["TienTT"].Width = 80;
            dgThongKe.Columns["TenHD"].HeaderText = "Tên Hợp Đồng";
            dgThongKe.Columns["TenHD"].Width = 100;
            dgThongKe.Columns["HoTen"].HeaderText = "Tên Khách Hàng";
            dgThongKe.Columns["HoTen"].Width = 150;

            //Tinh tong tien
            double TongTien = 0;
            DataGridViewRow dr;
            for (int i = 0; i < dgThongKe.RowCount - 1; i++)
            {
                dr = dgThongKe.Rows[i];
                TongTien += Double.Parse(dr.Cells["TienTT"].Value.ToString());
            }
            txtTongTien.Text = TongTien.ToString();

            txtTongHD.Text = (dgThongKe.RowCount-1).ToString();
        }
    }
}
