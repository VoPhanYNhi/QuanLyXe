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
    public partial class frmThueXe : Form
    {
        public frmThueXe()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection();
        DataSet ds = new DataSet("dsHDCT");
        SqlDataAdapter daHDCT;
        SqlDataAdapter daXe;
        SqlDataAdapter daHopDong;
        SqlDataAdapter daTaiXe;

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            Form f2 = new frmQLHopDong();
            this.Visible = false;
            f2.ShowDialog();
            ds.Tables["tblDSHopDong"].Clear();
            ds.Tables["tblDSTaiXe"].Clear();
            ds.Tables["tblDSXe"].Clear();
            ds.Tables["tblDSHDCT"].Clear();
            frmThueXe_Load(sender, e);
            this.Visible = true;       
            
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            Form f2 = new frmQLKhachHang();
            this.Visible = false;
            f2.ShowDialog();                                 

            this.Visible = true;
        }

        private void frmThueXe_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = KetNoi.ChuoiKetNoi();
            HienThiDataGrid();
            
            // combobox xe
            string sQueryXe = @"select * from XE";
            daXe = new SqlDataAdapter(sQueryXe, conn);
            daXe.Fill(ds, "tblDSXe");
            cboTenXe.DataSource = ds.Tables["tblDSXe"];
            cboTenXe.DisplayMember = "TenXe";
            cboTenXe.ValueMember = "MaXe";

            //combobox hopdong
            string sQueryHopDong = @"select * from HOPDONG";
            daHopDong = new SqlDataAdapter(sQueryHopDong, conn);
            daHopDong.Fill(ds, "tblDSHopDong");
            cboTenHD.DataSource = ds.Tables["tblDSHopDong"];
            cboTenHD.DisplayMember = "TenHD";
            cboTenHD.ValueMember = "MaHD";

            //combobox taixe
            string sQueryTaiXe = @"select * from TaiXe";
            daTaiXe = new SqlDataAdapter(sQueryTaiXe, conn);
            daTaiXe.Fill(ds, "tblDSTaiXe");
            cboTenTX.DataSource = ds.Tables["tblDSTaiXe"];
            cboTenTX.DisplayMember = "HoTen";
            cboTenTX.ValueMember = "MaTaiXe";

            //Command Them HDCT
            string sThemHDCT = @"insert into HOPDONGCHITIET values(@mahd, @maxe, @mataixe, @ngaythue, @ngaytra, @tienthuexe)";
            SqlCommand cmThemHDCT = new SqlCommand(sThemHDCT, conn);
            cmThemHDCT.Parameters.Add("@mahd", SqlDbType.NVarChar, 10, "MaHD");
            cmThemHDCT.Parameters.Add("@maxe", SqlDbType.NVarChar, 10, "MaXe");
            cmThemHDCT.Parameters.Add("@mataixe", SqlDbType.NVarChar, 10, "MaTaiXe");
            cmThemHDCT.Parameters.Add("@ngaythue", SqlDbType.SmallDateTime, 10, "NgayThue");
            cmThemHDCT.Parameters.Add("@ngaytra", SqlDbType.SmallDateTime, 10, "NgayTra");
            cmThemHDCT.Parameters.Add("@tienthuexe", SqlDbType.Int, 10, "TienThueXe");

            daHDCT.InsertCommand = cmThemHDCT;

            //Command Sua Hop Dong
            string sSuaHD = @"update HOPDONG set DonGia=@dongia where MaHD=@mahd";
            SqlCommand cmSuaHD = new SqlCommand(sSuaHD, conn);
            cmSuaHD.Parameters.Add("@mahd", SqlDbType.NVarChar, 10, "MaHD");
            cmSuaHD.Parameters.Add("@dongia", SqlDbType.Int, 10, "DonGia");

            daHopDong.UpdateCommand = cmSuaHD;

            //Command Sua Tai Xe
            string sSuaTX = @"update TAIXE set XeDangChay=@xedangchay where MaTaiXe=@mataixe";
            SqlCommand cmSuaTX = new SqlCommand(sSuaTX, conn);
            cmSuaTX.Parameters.Add("@mataixe", SqlDbType.NVarChar, 10, "MaTaiXe");
            cmSuaTX.Parameters.Add("@xedangchay", SqlDbType.NVarChar, 10, "XeDangChay");

            daTaiXe.UpdateCommand = cmSuaTX;

            //Command Sua Xe
            string sSuaXe = @"update XE set TinhTrang=@tinhtrang where MaXe=@maxe";
            SqlCommand cmSuaXe = new SqlCommand(sSuaXe, conn);
            cmSuaXe.Parameters.Add("@maxe", SqlDbType.NVarChar, 10, "MaXe");
            cmSuaXe.Parameters.Add("@tinhtrang", SqlDbType.NVarChar, 10, "TinhTrang");

            daXe.UpdateCommand = cmSuaXe;


            //an button
            cboTenTX.Enabled = false;
        }

        public void HienThiDataGrid()
        {
            string sQueryHDCT = @"Select b.TenHD, a.TenXe, n.*  From HOPDONGCHITIET n, XE a, HOPDONG b Where n.MaXe = a.MaXe and n.MaHD = b.MaHD ";
            daHDCT = new SqlDataAdapter(sQueryHDCT, conn);
            daHDCT.Fill(ds, "tblDSHDCT");
            dgDSHopDongChiTiet.DataSource = ds.Tables["tblDSHDCT"];
            dgDSHopDongChiTiet.Columns["MaXe"].Visible = false;
            dgDSHopDongChiTiet.Columns["MaHD"].Visible = false;

            dgDSHopDongChiTiet.Columns["TenHD"].HeaderText = "Tên Hợp Đồng";
            dgDSHopDongChiTiet.Columns["TenHD"].Width = 80;
            dgDSHopDongChiTiet.Columns["TenXe"].HeaderText = "Tên Xe";
            dgDSHopDongChiTiet.Columns["TenXe"].Width = 100;
            dgDSHopDongChiTiet.Columns["MaTaiXe"].HeaderText = "Mã Tài Xế";
            dgDSHopDongChiTiet.Columns["MaTaiXe"].Width = 80;
            dgDSHopDongChiTiet.Columns["NgayThue"].HeaderText = "Ngày Thuê";
            dgDSHopDongChiTiet.Columns["NgayThue"].Width = 100;
            dgDSHopDongChiTiet.Columns["NgayTra"].HeaderText = "Ngày Trả";
            dgDSHopDongChiTiet.Columns["NgayTra"].Width = 100;
            dgDSHopDongChiTiet.Columns["TienThueXe"].HeaderText = "Tiền Thuê";
            dgDSHopDongChiTiet.Columns["TienThueXe"].Width = 100;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
           
            DataGridViewRow dr;
            for (int i = 0; i < dgDSHopDongChiTiet.RowCount - 1; i++)
            {
                dr = dgDSHopDongChiTiet.Rows[i];
                if (cboTenHD.SelectedValue.Equals(dr.Cells["MaHD"].Value) && cboTenXe.SelectedValue.Equals(dr.Cells["MaXe"].Value))
                {
                    MessageBox.Show("Mã vừa nhập đã bị trùng!!!!", "Thông báo");
                    return;
                }
            }
            if (KiemTra())
            {
                DataRow row = ds.Tables["tblDSHDCT"].NewRow();
                row["MaHD"] = cboTenHD.SelectedValue;
                row["MaXe"] = cboTenXe.SelectedValue;
                row["NgayThue"] = dtpNgayThue.Text;
                row["NgayTra"] = dtpNgayTra.Text;
                row["TienThueXe"] = TienThueXe(cboTenXe.SelectedValue.ToString());
                row["TenHD"] = cboTenHD.Text;
                row["TenXe"] = cboTenXe.Text;
                if (radThue.Checked == true)
                {
                    row["MaTaiXe"] = cboTenTX.SelectedValue;

                    //Cap nhap maxe bang taixe
                    foreach (DataRow r in ds.Tables["tblDSTaiXe"].Rows)
                    {
                        if (r["MaTaiXe"] == cboTenTX.SelectedValue)
                        {
                            r["XeDangChay"] = cboTenXe.SelectedValue;
                        }
                    }
                }
                else
                {
                    row["MaTaiXe"] = null;
                }

                ds.Tables["tblDSHDCT"].Rows.Add(row);

                //Cap nhap thanh tien bang hop dong
                foreach (DataRow r in ds.Tables["tblDSHopDong"].Rows)
                {
                    if (r["MaHD"] == cboTenHD.SelectedValue)
                    {
                        int so = Int32.Parse(r["DonGia"].ToString()) + TienThueXe(cboTenXe.SelectedValue.ToString());
                        r["DonGia"] = so.ToString();
                    }
                }

                //Cap nhap tinh trang xe bang xe
                foreach (DataRow r in ds.Tables["tblDSXe"].Rows)
                {
                    if (r["MaXe"] == cboTenXe.SelectedValue)
                    {
                        r["TinhTrang"] = "Đã thuê";
                    }
                }

                
            }
        }
        public int TienThueXe(String maxe)
        {
            int tienthue = 0;
            TimeSpan time = dtpNgayTra.Value - dtpNgayThue.Value;
            int songay = time.Days + 1;
            foreach (DataRow r in ds.Tables["tblDSXe"].Rows)
            {
                if (r["MaXe"].ToString() == maxe)
                {
                    tienthue = songay * Int32.Parse(r["DonGia"].ToString());
                }
            }
            return tienthue;
        }

        public bool KiemTra()
        {
            if (dtpNgayThue.Value > dtpNgayTra.Value)
            {
                MessageBox.Show("Ngày thuê không thể lớn hơn ngày trả", "Thông báo");
                return false;
            }
            //Kiem tra xe co nguoi chay khong            
            foreach (DataRow r in ds.Tables["tblDSXe"].Rows)
            {
                if (r["MaXe"] == cboTenXe.SelectedValue)
                {
                    if(r["TinhTrang"].Equals("Đã thuê"))
                    {
                        MessageBox.Show("Xe đã có người lái");
                        return false;
                    }
                }
            }

            //Kiem tra taixe 
            if (radThue.Checked == true)
            {
                foreach (DataRow r in ds.Tables["tblDSTaiXe"].Rows)
                {
                    if (r["MaTaiXe"] == cboTenTX.SelectedValue)
                    {
                        if (r["XeDangChay"].ToString() != "")
                        {
                            MessageBox.Show("Tài xế đang bận");
                            return false;
                        }
                    }
                }

            }

            return true;
        }

        private void radThue_CheckedChanged(object sender, EventArgs e)
        {
            if (radThue.Checked == true)
            {
                cboTenTX.Enabled = true;
            }
            if (radKhongThue.Checked == true)
            {
                cboTenTX.Enabled = false;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                daHDCT.Update(ds, "tblDSHDCT");
                daHopDong.Update(ds, "tblDSHopDong");
                daTaiXe.Update(ds, "tblDSTaiXe");
                daXe.Update(ds, "tblDSXe");
                MessageBox.Show("Đã lưu", "Thông báo");

                dgDSHopDongChiTiet.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo lỗi");
                return;
            }
        }
    }
}
