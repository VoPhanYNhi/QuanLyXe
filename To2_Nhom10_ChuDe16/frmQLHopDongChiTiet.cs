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
    public partial class frmQLHopDongChiTiet : Form
    {
        public frmQLHopDongChiTiet()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection();
        DataSet ds = new DataSet("dsHDCT");
        SqlDataAdapter daHDCT;
        SqlDataAdapter daXe;
        SqlDataAdapter daHopDong;
        SqlDataAdapter daTaiXe;

        private void frmQLHopDongChiTiet_Load(object sender, EventArgs e)
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

            //Command Sua HDCT
            string sSuaHDCT = @"update HOPDONGCHITIET set MaTaiXe=@mataixe, NgayThue=@ngaythue, NgayTra=@ngaytra, TienThueXe=@tienthuexe Where MaHD=@mahd and MaXe=@maxe";
            SqlCommand cmSuaHDCT = new SqlCommand(sSuaHDCT, conn);
            cmSuaHDCT.Parameters.Add("@mahd", SqlDbType.NVarChar, 10, "MaHD");
            cmSuaHDCT.Parameters.Add("@maxe", SqlDbType.NVarChar, 10, "MaXe");
            cmSuaHDCT.Parameters.Add("@mataixe", SqlDbType.NVarChar, 10, "MaTaiXe");
            cmSuaHDCT.Parameters.Add("@ngaythue", SqlDbType.SmallDateTime, 10, "NgayThue");
            cmSuaHDCT.Parameters.Add("@ngaytra", SqlDbType.SmallDateTime, 10, "NgayTra");
            cmSuaHDCT.Parameters.Add("@tienthuexe", SqlDbType.Int, 10, "TienThueXe");

            daHDCT.UpdateCommand = cmSuaHDCT;

            //Command Xoa HDCT
            string sXoaHDCT = @"delete from HOPDONGCHITIET where  MaHD=@mahd and MaXe=@maxe";
            SqlCommand cmXoaHDCT = new SqlCommand(sXoaHDCT, conn);
            cmXoaHDCT.Parameters.Add("@mahd", SqlDbType.NVarChar, 10, "MaHD");
            cmXoaHDCT.Parameters.Add("@maxe", SqlDbType.NVarChar, 10, "MaXe");

            daHDCT.DeleteCommand = cmXoaHDCT;

            //Command Sua Hop Dong
            string sSuaHD = @"update HOPDONG set DonGia=@dongia where MaHD=@mahd";
            SqlCommand cmSuaHD = new SqlCommand(sSuaHD, conn);
            cmSuaHD.Parameters.Add("@mahd", SqlDbType.NVarChar, 10, "MaHD");
            cmSuaHD.Parameters.Add("@dongia", SqlDbType.Int, 10, "DonGia");

            daHopDong.UpdateCommand = cmSuaHD;            

            //An combobox 
            cboTenTX.Enabled = false;
            txtTienThue.Enabled = false;
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

        private void dgDSHopDongChiTiet_Click(object sender, EventArgs e)
        {            
            
            if (dgDSHopDongChiTiet.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng","Thông báo");
                return;
            }
            DataGridViewRow dr = dgDSHopDongChiTiet.SelectedRows[0];
            cboTenHD.Text = dr.Cells["TenHD"].Value.ToString();
            cboTenXe.Text = dr.Cells["TenXe"].Value.ToString();
            dtpNgayThue.Text = dr.Cells["NgayThue"].Value.ToString();
            dtpNgayTra.Text = dr.Cells["NgayTra"].Value.ToString();            
            txtTienThue.Text = dr.Cells["TienThueXe"].Value.ToString();
            if (dr.Cells["MaTaiXe"].Value.ToString() == "")
            {
                radKhongThue.Checked = true;
            }
            else
            {
                radThue.Checked = true;
                cboTenTX.SelectedValue = dr.Cells["MaTaiXe"].Value.ToString();
            }
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Kiem tra ma trung trong DataGridView
            DataGridViewRow dr;
            for (int i = 0; i < dgDSHopDongChiTiet.RowCount - 1; i++)
            {
                dr = dgDSHopDongChiTiet.Rows[i];
                if (cboTenHD.SelectedValue.Equals(dr.Cells["MaHD"].Value)&& cboTenXe.SelectedValue.Equals(dr.Cells["MaXe"].Value))
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
            }
            
        }

        //Phuong thuc tinh tien thue xe
        public int TienThueXe(String maxe)
        {
            int tienthue = 0;
            TimeSpan time = dtpNgayTra.Value - dtpNgayThue.Value;
            int songay = time.Days +1;
            foreach(DataRow r in ds.Tables["tblDSXe"].Rows)
            {
                if (r["MaXe"].ToString() == maxe)
                {
                    tienthue = songay * Int32.Parse(r["DonGia"].ToString());
                }
            }
            return tienthue;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgDSHopDongChiTiet.SelectedRows[0];
            if (dgDSHopDongChiTiet.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng", "Thông báo");
                return;
            }
            if (KiemTra())
            {
                dgDSHopDongChiTiet.BeginEdit(true);

                //Cap nhap thanh tien bang hop dong
                foreach (DataRow r in ds.Tables["tblDSHopDong"].Rows)
                {
                    if (r["MaHD"] == cboTenHD.SelectedValue)
                    {
                        int so = Int32.Parse(r["DonGia"].ToString()) + TienThueXe(cboTenXe.SelectedValue.ToString()) - Int32.Parse(dr.Cells["TienThueXe"].Value.ToString());
                        r["DonGia"] = so.ToString();
                    }

                }

                dr.Cells["MaHD"].Value = cboTenHD.SelectedValue;
                dr.Cells["MaXe"].Value = cboTenXe.SelectedValue;
                dr.Cells["Ngaythue"].Value = dtpNgayThue.Text;
                dr.Cells["NgayTra"].Value = dtpNgayTra.Text;
                dr.Cells["TienThueXe"].Value = TienThueXe(cboTenXe.SelectedValue.ToString());
                dr.Cells["TenHD"].Value = cboTenHD.Text;
                dr.Cells["TenXe"].Value = cboTenXe.Text;
                if (radThue.Checked == true)
                {
                    dr.Cells["MaTaiXe"].Value = cboTenTX.SelectedValue;
                }
                else
                {
                    dr.Cells["MaTaiXe"].Value = null;
                }
            }
                        
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgDSHopDongChiTiet.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng", "Thông báo");
                return;
            }
            DataGridViewRow dr = dgDSHopDongChiTiet.SelectedRows[0];

            //Cap nhap thanh tien bang hop dong
            foreach (DataRow r in ds.Tables["tblDSHopDong"].Rows)
            {
                if (r["MaHD"].Equals(dr.Cells["MaHD"].Value))
                {
                    int so = Int32.Parse(r["DonGia"].ToString()) - Int32.Parse(dr.Cells["TienThueXe"].Value.ToString());
                    r["DonGia"] = so.ToString();
                }
            }

            dgDSHopDongChiTiet.Rows.Remove(dr);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                daHDCT.Update(ds, "tblDSHDCT");
                daHopDong.Update(ds, "tblDSHopDong");
                MessageBox.Show("Đã lưu", "Thông báo");
                
                dgDSHopDongChiTiet.Refresh();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo lỗi");
                return;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ds.Tables["tblDSBBNX"].RejectChanges();
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
            if (dtpNgayThue.Value > dtpNgayTra.Value)
            {
                MessageBox.Show("Ngày thuê không thể lớn hơn ngày trả", "Thông báo");
                return false;
            }
            return true;
        }
    }
}
