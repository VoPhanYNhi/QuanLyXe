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
    public partial class frmQLLoaiXe : Form
    {
        public frmQLLoaiXe()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection();
        DataSet ds = new DataSet("dsLOAIXE");
        SqlDataAdapter daLoaiXe;

        private void frmQLLoaiXe_Load(object sender, EventArgs e)
        {            
            conn.ConnectionString = KetNoi.ChuoiKetNoi();
            
            HienThiDataGrid();

            //Command Them LoaiXe
            string sThemLoaiXe = @"insert into LOAIXE values(@maloai,@tenloai,@soluong,@mota)";
            SqlCommand cmThemLoaiXe = new SqlCommand(sThemLoaiXe, conn);
            cmThemLoaiXe.Parameters.Add("@maloai", SqlDbType.NVarChar, 10, "MaLoai");
            cmThemLoaiXe.Parameters.Add("@tenloai", SqlDbType.NVarChar, 50, "TenLoai");
            cmThemLoaiXe.Parameters.Add("@soluong", SqlDbType.Int, 5, "SoLuong");
            cmThemLoaiXe.Parameters.Add("@mota", SqlDbType.NVarChar, 1000, "MoTa");

            daLoaiXe.InsertCommand = cmThemLoaiXe;            

            //Command Sua LoaiXe
            string sSuaLoaiXe = @"update LOAIXE set TenLoai=@tenloai, MoTa=@mota where MaLoai=@maloai";
            SqlCommand cmSuaLoaiXe = new SqlCommand(sSuaLoaiXe, conn);
            cmSuaLoaiXe.Parameters.Add("@maloai", SqlDbType.NVarChar, 10, "MaLoai");
            cmSuaLoaiXe.Parameters.Add("@tenloai", SqlDbType.NVarChar, 50, "TenLoai");
            cmSuaLoaiXe.Parameters.Add("@mota", SqlDbType.NVarChar, 1000, "MoTa");

            daLoaiXe.UpdateCommand = cmSuaLoaiXe;

            //Command Xoa LoaiXe
            string sXoaLoaiXe = @"delete from LOAIXE where MaLoai=@maloai";            
            SqlCommand cmXoaLoaiXe = new SqlCommand(sXoaLoaiXe, conn);
            cmXoaLoaiXe.Parameters.Add("@maloai", SqlDbType.NVarChar, 10, "MaLoai");
            daLoaiXe.DeleteCommand = cmXoaLoaiXe;


            //Khong the nhap so luong cho loai xe so luong se duoc tinh dua tren so xe trong bang xe
            txtSoLuong.Enabled = false;

            //Các thuoc tính button
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            
        }

        public void HienThiDataGrid()
        {
            string sQueryLoaiXe = @"select *from LOAIXE";
            daLoaiXe = new SqlDataAdapter(sQueryLoaiXe, conn);
            daLoaiXe.Fill(ds, "tblDSLoaiXe");
            dgDSLoaiXe.DataSource = ds.Tables["tblDSLoaiXe"];
            dgDSLoaiXe.Columns["MaLoai"].HeaderText = "Mã Loại";
            dgDSLoaiXe.Columns["MaLoai"].Width = 100;
            dgDSLoaiXe.Columns["TenLoai"].HeaderText = "Tên Loại";
            dgDSLoaiXe.Columns["TenLoai"].Width = 200;
            dgDSLoaiXe.Columns["SoLuong"].HeaderText = "Số Lượng";
            dgDSLoaiXe.Columns["SoLuong"].Width = 80;
            dgDSLoaiXe.Columns["MoTa"].HeaderText = "Mô Tả";
            dgDSLoaiXe.Columns["MoTa"].Width = 225;
        }

        private void dgDSLoaiXe_Click(object sender, EventArgs e)
        {
            //Kiem tra dong duoc chon
            if(dgDSLoaiXe.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng", "Thông báo");
                return;
            }

            //Hien thi gia tri len cac textbox
            DataGridViewRow dr = dgDSLoaiXe.SelectedRows[0];
            txtMaLoai.Text = dr.Cells["MaLoai"].Value.ToString();
            txtTenLoai.Text = dr.Cells["TenLoai"].Value.ToString();
            txtSoLuong.Text = dr.Cells["SoLuong"].Value.ToString();
            txtMoTa.Text = dr.Cells["MoTa"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {         
            //Kiem tra rong
            if (KiemTraRong())
            {
                //Kiem tra ma trung trong DataGridView
                DataGridViewRow dr;
                for (int i = 0; i < dgDSLoaiXe.RowCount - 1; i++)
                {
                    dr = dgDSLoaiXe.Rows[i];
                    if (txtMaLoai.Text == dr.Cells["MaLoai"].Value.ToString())
                    {
                        MessageBox.Show("Mã vừa nhập đã bị trùng!!!!", "Thông báo");
                        return;
                    }
                }

                //Them loai xe vao DataGridView
                DataRow row = ds.Tables["tblDSLoaiXe"].NewRow();
                row["MaLoai"] = txtMaLoai.Text;
                row["TenLoai"] = txtTenLoai.Text;
                row["SoLuong"] = 0;
                row["MoTa"] = txtMoTa.Text;
                ds.Tables["tblDSLoaiXe"].Rows.Add(row);

                //Cho phep luu hoac huy
                btnLuu.Enabled = true;
                btnHuy.Enabled = true;
            }    
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //Kiem tra dong duoc chon
            if (dgDSLoaiXe.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng", "Thông báo");
                return;
            }
            //Kiem tra rong
            if (KiemTraRong())
            {
                DataGridViewRow dr = dgDSLoaiXe.SelectedRows[0];
                //Kiem tra ma loai co thay doi khong neu co -> khong cho phep sua
                if (txtMaLoai.Text == dr.Cells["MaLoai"].Value.ToString())
                {
                    dgDSLoaiXe.BeginEdit(true);
                    dr.Cells["TenLoai"].Value = txtTenLoai.Text;
                    dr.Cells["MoTa"].Value = txtMoTa.Text;
                    MessageBox.Show("Đã sửa!!!", "Thông báo");

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
            if (dgDSLoaiXe.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng", "Thông báo");
                return;
            }

            //Xoa dong duoc chon
            DataGridViewRow dr = dgDSLoaiXe.SelectedRows[0];
            dgDSLoaiXe.Rows.Remove(dr);

            //Cho phep luu hoac huy
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                daLoaiXe.Update(ds, "tblDSLoaiXe");
                MessageBox.Show("Đã lưu", "Thông báo");
                dgDSLoaiXe.Refresh();

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
            ds.Tables["tblDSLoaiXe"].RejectChanges();

            //An button luu va huy
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Thoát????","Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        //Kiem tra cac dieu kien
        public bool KiemTraRong()
        {
            if (txtMaLoai.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã loại", "Thông báo");
                txtMaLoai.Focus();
                return false;
            }
            if (txtTenLoai.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên loại", "Thông báo");
                txtTenLoai.Focus();
                return false;
            }
            if (txtMoTa.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mô tả", "Thông báo");
                txtMoTa.Focus();
                return false;
            }
            return true;
        }

        //Tim kiem ten loai xe
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            if (ds.Tables["tblDSLoaiXe2"] != null)
                ds.Tables["tblDSLoaiXe2"].Clear();
            SqlDataAdapter daLoaiXe2;
            string sQueryTimKiem = "Select * from LOAIXE where TenLoai LIKE N'%" + txtTimKiem.Text + "%'";
            daLoaiXe2 = new SqlDataAdapter(sQueryTimKiem, conn);
            daLoaiXe2.Fill(ds, "tblDSLoaiXe2");
            dgDSLoaiXe.DataSource = ds.Tables["tblDSLoaiXe2"];
        }

        private void btnHuyTim_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            dgDSLoaiXe.DataSource = ds.Tables["tblDSLoaiXe"];

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
    }
}
