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
    public partial class frmQLXe : Form
    {
        public frmQLXe()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection();
        DataSet ds = new DataSet("dsXE");
        SqlDataAdapter daXe;
        SqlDataAdapter daLoaiXe;
        

        private void frmQLXe_Load(object sender, EventArgs e)
        {
            
            conn.ConnectionString = KetNoi.ChuoiKetNoi();
            HienThiDataGrid();

            //combobox loai xe
            string sQueryLoaiXe = @"select * from LOAIXE";
            daLoaiXe = new SqlDataAdapter(sQueryLoaiXe, conn);
            daLoaiXe.Fill(ds, "tblDSLoaiXe");
            cboTenLoai.DataSource = ds.Tables["tblDSLoaiXe"];
            cboTenLoai.DisplayMember = "TenLoai";
            cboTenLoai.ValueMember = "MaLoai";

            //command cap nhat so luong loai xe
            string sSuaLoaiXe = @"update LOAIXE set SoLuong=@soluong where MaLoai=@maloai";
            SqlCommand cmSuaLoaiXe = new SqlCommand(sSuaLoaiXe, conn);
            cmSuaLoaiXe.Parameters.Add("@maloai", SqlDbType.NVarChar, 10, "MaLoai");
            cmSuaLoaiXe.Parameters.Add("@soluong", SqlDbType.Int, 5, "SoLuong");

            daLoaiXe.UpdateCommand = cmSuaLoaiXe;

            //Them Xe
            string sThemXe = @"insert into XE values(@maxe,@maloai,@tenxe,@biensoxe,@hangxe,@ngaysx,@soghe,@tinhtrang,@dongia)";
            SqlCommand cmThemXe = new SqlCommand(sThemXe, conn);
            cmThemXe.Parameters.Add("@maxe", SqlDbType.NVarChar, 10, "MaXe");
            cmThemXe.Parameters.Add("@maloai", SqlDbType.NVarChar, 10, "MaLoai");
            cmThemXe.Parameters.Add("@tenxe", SqlDbType.NVarChar, 50, "TenXe");
            cmThemXe.Parameters.Add("@biensoxe", SqlDbType.NVarChar, 20, "BienSoXe");
            cmThemXe.Parameters.Add("@hangxe", SqlDbType.NVarChar, 50, "HangXe");
            cmThemXe.Parameters.Add("@ngaySX", SqlDbType.SmallDateTime, 10, "NgaySX");
            cmThemXe.Parameters.Add("@soghe", SqlDbType.Int, 5, "SoGhe");
            cmThemXe.Parameters.Add("@tinhtrang", SqlDbType.NVarChar, 50, "TinhTrang");
            cmThemXe.Parameters.Add("@dongia", SqlDbType.Int, 10, "DonGia");

            daXe.InsertCommand = cmThemXe;

            //Command Sua Xe
            string sSuaXe = @"update XE set MaLoai=@maloai,TenXe=@tenxe,BienSoXe=@biensoxe,HangXe=@hangxe,NgaySX=@ngaysx,SoGhe=@soghe,TinhTrang=@tinhtrang,DonGia=@dongia where MaXe=@maxe";
            SqlCommand cmSuaXe = new SqlCommand(sSuaXe, conn);
            cmSuaXe.Parameters.Add("@maxe", SqlDbType.NVarChar, 10, "MaXe");
            cmSuaXe.Parameters.Add("@maloai", SqlDbType.NVarChar, 10, "MaLoai");
            cmSuaXe.Parameters.Add("@tenxe", SqlDbType.NVarChar, 50, "TenXe");
            cmSuaXe.Parameters.Add("@biensoxe", SqlDbType.NVarChar, 20, "BienSoXe");
            cmSuaXe.Parameters.Add("@hangxe", SqlDbType.NVarChar, 50, "HangXe");
            cmSuaXe.Parameters.Add("@ngaySX", SqlDbType.SmallDateTime, 10, "NgaySX");
            cmSuaXe.Parameters.Add("@soghe", SqlDbType.Int, 5, "SoGhe");
            cmSuaXe.Parameters.Add("@tinhtrang", SqlDbType.NVarChar, 50, "TinhTrang");
            cmSuaXe.Parameters.Add("@dongia", SqlDbType.Int, 10, "DonGia");

            daXe.UpdateCommand = cmSuaXe;

            //Command Xoa Xe
            string sXoaXe = @"delete from XE where MaXe=@maxe";
            SqlCommand cmXoaXe = new SqlCommand(sXoaXe, conn);
            cmXoaXe.Parameters.Add("@maxe", SqlDbType.NVarChar, 10, "MaXe");

            daXe.DeleteCommand = cmXoaXe;

            //Các thuoc tính button
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        public void HienThiDataGrid()
        {
            string sQueryXe = @"select n.*, c.TenLoai from Xe n, LOAIXE c where n.MaLoai=c.MaLoai";
            daXe = new SqlDataAdapter(sQueryXe, conn);
            daXe.Fill(ds, "tblDSXe");
            dgDSXe.DataSource = ds.Tables["tblDSXe"];
            dgDSXe.Columns["MaLoai"].Visible = false;
            dgDSXe.Columns["MaXe"].HeaderText = "Mã Xe";
            dgDSXe.Columns["MaXe"].Width = 80;
            dgDSXe.Columns["TenLoai"].HeaderText = "Tên Loại";
            dgDSXe.Columns["TenLoai"].Width = 150;
            dgDSXe.Columns["TenXe"].HeaderText = "Tên Xe";
            dgDSXe.Columns["TenXe"].Width = 100;
            dgDSXe.Columns["BienSoXe"].HeaderText = "Biển số xe";
            dgDSXe.Columns["BienSoXe"].Width = 100;
            dgDSXe.Columns["HangXe"].HeaderText = "Hãng Xe";
            dgDSXe.Columns["HangXe"].Width = 100;
            dgDSXe.Columns["NgaySX"].HeaderText = "Ngày SX";
            dgDSXe.Columns["NgaySX"].Width = 100;
            dgDSXe.Columns["SoGhe"].HeaderText = "Số ghế";
            dgDSXe.Columns["SoGhe"].Width = 80;
            dgDSXe.Columns["TinhTrang"].HeaderText = "Tình trạng";
            dgDSXe.Columns["TinhTrang"].Width = 100;
            dgDSXe.Columns["DonGia"].HeaderText = "Đơn giá";
            dgDSXe.Columns["DonGia"].Width = 100;            
        }

        private void dgDSXe_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgDSXe.SelectedRows[0];
            txtMaXe.Text = dr.Cells["MaXe"].Value.ToString();
            txtTenXe.Text = dr.Cells["TenXe"].Value.ToString();
            txtBienSoXe.Text = dr.Cells["BienSoXe"].Value.ToString();
            txtHangXe.Text = dr.Cells["HangXe"].Value.ToString();
            dtpNgaySX.Text = dr.Cells["NgaySX"].Value.ToString();
            txtSoGhe.Text = dr.Cells["SoGhe"].Value.ToString();
            txtDonGia.Text = dr.Cells["DonGia"].Value.ToString();
            cboTenLoai.SelectedValue = dr.Cells["MaLoai"].Value.ToString();
            if(dr.Cells["TinhTrang"].Value.ToString()=="Đã thuê")
            {
                radDaThue.Checked = true;
            }
            else
            {
                radChuaThue.Checked = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(KiemTra())
            {                
                DataGridViewRow dr;

                // //Kiem tra ma trung trong DataGridView
                for (int i = 0; i < dgDSXe.RowCount - 1; i++)
                {
                    dr = dgDSXe.Rows[i];
                    if (txtMaXe.Text == dr.Cells["MaXe"].Value.ToString())
                    {
                        MessageBox.Show("Mã vừa nhập đã bị trùng!!!!", "Thông báo");
                        return;
                    }
                }

                DataRow row = ds.Tables["tblDSXe"].NewRow();
                row["MaXe"] = txtMaXe.Text;
                row["MaLoai"] = cboTenLoai.SelectedValue;
                row["TenXe"] = txtTenXe.Text;
                row["BienSoXe"] = txtBienSoXe.Text;
                row["HangXe"] = txtHangXe.Text;
                row["NgaySX"] = dtpNgaySX.Text;
                row["SoGhe"] = txtSoGhe.Text;
                row["DonGia"] = txtDonGia.Text;
                if (radDaThue.Checked == true)
                {
                    row["TinhTrang"] = "Đã thuê";
                }
                else
                {
                    row["TinhTrang"] = "Chưa thuê";
                }
                row["TenLoai"] = cboTenLoai.Text;

                ds.Tables["tblDSXe"].Rows.Add(row);

                //Cap nhat so luong xe
                foreach (DataRow r in ds.Tables["tblDSLoaiXe"].Rows)
                {
                    if (r["MaLoai"] == cboTenLoai.SelectedValue)
                    {
                        int so = Int32.Parse(r["SoLuong"].ToString()) + 1;
                        r["SoLuong"] = so.ToString();
                    }
                }

                //Cho phep luu hoac huy
                btnLuu.Enabled = true;
                btnHuy.Enabled = true;
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                if (dgDSXe.SelectedRows[0].IsNewRow)
                {
                    MessageBox.Show("Vui lòng chọn 1 dòng");
                    return;
                }

                DataGridViewRow dr = dgDSXe.SelectedRows[0];
                //Kiem tra ma loai co thay doi khong neu co -> khong cho phep sua
                if (txtMaXe.Text == dr.Cells["MaXe"].Value.ToString())
                {
                    //Cap nhat lai so luong loai xe
                    foreach (DataRow r in ds.Tables["tblDSLoaiXe"].Rows)
                    {
                        if (r["MaLoai"] == cboTenLoai.SelectedValue)
                        {
                            int so = Int32.Parse(r["SoLuong"].ToString()) + 1;
                            r["SoLuong"] = so.ToString();
                        }
                        if(r["MaLoai"].Equals(dr.Cells["MaLoai"].Value))
                        {
                            int so = Int32.Parse(r["SoLuong"].ToString()) - 1;
                            r["SoLuong"] = so.ToString();
                        }
                    }

                    dgDSXe.BeginEdit(true);
                    dr.Cells["MaXe"].Value = txtMaXe.Text;
                    dr.Cells["MaLoai"].Value = cboTenLoai.SelectedValue;
                    dr.Cells["TenXe"].Value = txtTenXe.Text;
                    dr.Cells["BienSoXe"].Value = txtBienSoXe.Text;
                    dr.Cells["HangXe"].Value = txtHangXe.Text;
                    dr.Cells["NgaySX"].Value = dtpNgaySX.Text;
                    dr.Cells["SoGhe"].Value = txtSoGhe.Text;
                    if (radDaThue.Checked == true)
                    {
                        dr.Cells["TinhTrang"].Value = "Đã thuê";
                    }
                    else
                    {
                        dr.Cells["TinhTrang"].Value = "Chưa thuê";
                    }
                    dr.Cells["DonGia"].Value = txtDonGia.Text;
                }
                else
                {
                    MessageBox.Show("Không thể thay đổi mã xe", "Thông báo");
                }

                //Cho phep luu hoac huy
                btnLuu.Enabled = true;
                btnHuy.Enabled = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgDSXe.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng");
                return;
            }
            DataGridViewRow dr = dgDSXe.SelectedRows[0];

            //Cap nhat lai so luong loai xe
            foreach (DataRow r in ds.Tables["tblDSLoaiXe"].Rows)
            {
                if (r["MaLoai"].Equals(dr.Cells["MaLoai"].Value))
                {
                    int so = Int32.Parse(r["SoLuong"].ToString()) - 1;
                    r["SoLuong"] = so.ToString();
                }
            }

            dgDSXe.Rows.Remove(dr);

            //Cho phep luu hoac huy
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                daXe.Update(ds, "tblDSXe");
                daLoaiXe.Update(ds, "tblDSLoaiXe");
                MessageBox.Show("Đã lưu", "Thông báo");
                dgDSXe.Refresh();

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
            ds.Tables["tblDSXe"].RejectChanges();

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

        //Tim Ten xe
        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            if(ds.Tables["tblDSXe2"]!=null)
                ds.Tables["tblDSXe2"].Clear();
            SqlDataAdapter daXe2;
            string sQueryTimKiem = "Select  n.*, c.TenLoai from Xe n, LOAIXE c where n.TenXe LIKE N'%" + txtTim.Text + "%' AND n.MaLoai=c.MaLoai";
            daXe2 = new SqlDataAdapter(sQueryTimKiem, conn);
            daXe2.Fill(ds, "tblDSXe2");
            dgDSXe.DataSource = ds.Tables["tblDSXe2"];
            
        }
        
        private void btnHuyTim_Click(object sender, EventArgs e)
        {
            txtTim.Clear();
            dgDSXe.DataSource = ds.Tables["tblDSXe"];

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        //Ham kiem tra
        public bool KiemTra()
        {
            if (txtMaXe.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã xe", "Thông báo");
                txtMaXe.Focus();
                return false;
            }
            if (txtTenXe.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên xe", "Thông báo");
                txtTenXe.Focus();
                return false;
            }
            if (txtBienSoXe.Text == "")
            {
                MessageBox.Show("Vui lòng nhập biển số xe", "Thông báo");
                txtBienSoXe.Focus();
                return false;
            }
            if (txtHangXe.Text == "")
            {
                MessageBox.Show("Vui lòng nhập hãng xe", "Thông báo");
                txtHangXe.Focus();
                return false;
            }
            if (dtpNgaySX.Value>DateTime.Now)
            {
                MessageBox.Show("Vui lòng nhập lại ngày sản xuất", "Thông báo");
                return false;
            }
            if (!KetNoi.KiemTraSoLonHon0(txtSoGhe.Text))
            {
                MessageBox.Show("Vui lòng nhập lại số ghế", "Thông báo");
                txtSoGhe.Focus();
                return false;
            }
            if (!KetNoi.KiemTraSoLonHon0(txtDonGia.Text))
            {
                MessageBox.Show("Vui lòng nhập lại đơn giá", "Thông báo");
                txtDonGia.Focus();
                return false;
            }
            return true;
        }
    }
}
